import 'package:flutter/material.dart';
import 'package:notesharing_ui/application/configs/app_colors.dart';
import 'package:notesharing_ui/common/notifications/notification_service.dart';
import 'package:notesharing_ui/common/notifications/app_notification.dart';
import 'package:notesharing_ui/features/register/register_page.dart';
import 'package:openapi/openapi.dart';
import 'package:dio/dio.dart';
import 'package:built_value/serializer.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'dart:convert';

class LoginPage extends StatefulWidget {
  const LoginPage({super.key});

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();
  final _storage = const FlutterSecureStorage();
  final _api = Openapi(basePathOverride: 'http://localhost:5000');

  @override
  void dispose() {
    _emailController.dispose();
    _passwordController.dispose();
    super.dispose();
  }

  Widget _inputField({required String label, bool obscure = false, TextEditingController? controller}) {
    return TextField(
      controller: controller,
      obscureText: obscure,
      decoration: InputDecoration(
        labelText: label,
        labelStyle: const TextStyle(
          color: AppColors.loginMainTextColor,
          fontFamily: 'Candal',
          fontWeight: FontWeight.bold,
        ),
        filled: true,
        fillColor: Colors.white,
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(12)),
        contentPadding: const EdgeInsets.symmetric(
          horizontal: 16,
          vertical: 18,
        ),
      ),
      style: const TextStyle(
        color: AppColors.loginMainTextColor,
        fontFamily: 'Candal',
        fontWeight: FontWeight.bold,
      ),
    );
  }

  Widget _socialButton({required String asset, required String label}) {
    return Flexible(
      child: SizedBox(
        height: 40,
        child: OutlinedButton.icon(
          onPressed: () {},
          icon: Image.asset(asset, height: 20, width: 20),
          label: Text(
            label,
            style: const TextStyle(
              fontFamily: 'Candal',
              fontWeight: FontWeight.bold,
              color: AppColors.loginMainTextColor,
            ),
          ),
          style: OutlinedButton.styleFrom(
            padding: const EdgeInsets.symmetric(vertical: 6, horizontal: 6),
            textStyle: const TextStyle(
              fontSize: 14,
              fontWeight: FontWeight.w600,
            ),
            side: BorderSide(color: Colors.grey.shade400),
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(10),
            ),
          ),
        ),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    Future<void> doLogin() async {
      final svc = NotificationProvider.of(context);
      final email = _emailController.text.trim();
      final password = _passwordController.text;
      if (email.isEmpty || password.isEmpty) {
        svc.show(title: 'Hiányzó mezők', message: 'Kérem adja meg az emailt és jelszót', type: AppNotificationType.error);
        return;
      }

        try {
          final loginDto = LoginDTO((b) => b
            ..email = email
            ..password = password
          );

          // Serialize login DTO using generated serializers and post with raw Dio to receive JSON body
          final serialized = _api.serializers.serialize(loginDto, specifiedType: const FullType(LoginDTO));
          final response = await _api.dio.request('/api/Auth/login', data: serialized, options: Options(method: 'POST', contentType: 'application/json'));

          final map = response.data is String ? json.decode(response.data as String) : response.data as Map<String, dynamic>?;
          if (map == null) {
            svc.show(title: 'Hiba', message: 'Helytelen válasz a szervertől', type: AppNotificationType.error);
            return;
          }

        final success = map['success'] == true;
        final data = map['data'];
        if (!success || data == null) {
          svc.show(title: 'Bejelentkezés sikertelen', message: map['message']?.toString() ?? 'Ismeretlen hiba', type: AppNotificationType.error);
          return;
        }

        final accessToken = data['accessToken'] as String?;
        final refreshToken = data['refreshToken'] as String?;

        if (accessToken == null) {
          svc.show(title: 'Hiba', message: 'A szerver nem adott vissza hozzáférési tokent', type: AppNotificationType.error);
          return;
        }

        // Store tokens securely
        await _storage.write(key: 'accessToken', value: accessToken);
        if (refreshToken != null) await _storage.write(key: 'refreshToken', value: refreshToken);

        // Set authorization header for future requests
        _api.setBearerAuth('default', accessToken);
        _api.dio.options.headers['Authorization'] = 'Bearer $accessToken';

        svc.show(title: 'Sikeres bejelentkezés', message: 'Üdvözöljük, ${data['name'] ?? ''}', type: AppNotificationType.success);

        // Navigate to home
        Navigator.of(context).pushReplacementNamed('/');
      } catch (e) {
        final svc = NotificationProvider.of(context);
        // Provide richer diagnostics for Dio errors (useful for XMLHttpRequest onerror)
        if (e is DioError) {
          final req = e.requestOptions;
          final uri = req.uri.toString();
          final dioType = e.type.toString();
          final status = e.response?.statusCode?.toString() ?? 'no-status';
          final respBody = e.response?.data?.toString() ?? 'no-body';
          final respHeaders = e.response?.headers.map.map((k, v) => MapEntry(k, v.join(','))) ?? {};

          final details = 'DioError: $dioType\nURI: $uri\nStatus: $status\nHeaders: $respHeaders\nBody: $respBody\nMessage: ${e.message}';
          svc.show(title: 'Hiba (HTTP)', message: details, type: AppNotificationType.error);
        } else {
          svc.show(title: 'Hiba', message: e.toString(), type: AppNotificationType.error);
        }
      }
    }
    final size = MediaQuery.of(context).size;
    final boxWidth = size.width * 0.8 > 350 ? 350.0 : size.width * 0.8;
    final boxHeight = size.height * 0.5 > 600 ? 600.0 : size.height * 0.5;
    final titleFontSize = boxWidth * 0.13;
    final titleTop = -titleFontSize * 0.7;

    return Scaffold(
      body: Stack(
        children: [
          Positioned.fill(
            child: Image(
              image: const AssetImage('assets/images/NoteShareBackground.png'),
              fit: BoxFit.cover,
            ),
          ),
          Center(
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                SizedBox(
                  width: boxWidth,
                  height: boxHeight,
                  child: Stack(
                    clipBehavior: Clip.none,
                    alignment: Alignment.topCenter,
                    children: [
                      DecoratedBox(
                        decoration: BoxDecoration(
                          color: AppColors.loginBoxBackgroundColor,
                          borderRadius: const BorderRadius.all(
                            Radius.circular(24),
                          ),
                          boxShadow: const [
                            BoxShadow(
                              color: Colors.black12,
                              blurRadius: 16,
                              offset: Offset(0, 8),
                            ),
                          ],
                        ),
                        child: Padding(
                          padding: const EdgeInsets.symmetric(
                            horizontal: 24.0,
                            vertical: 24.0,
                          ),
                          child: Column(
                            mainAxisAlignment: MainAxisAlignment.start,
                            crossAxisAlignment:
                                CrossAxisAlignment.stretch,
                            children: [
                              Expanded(
                                child: Column(
                                  mainAxisAlignment: MainAxisAlignment.start,
                                  crossAxisAlignment:
                                      CrossAxisAlignment.stretch,
                                  children: [
                                    const SizedBox(height: 8),
                                    _inputField(
                                     label: 'Email',
                                     controller: _emailController,
                                    ),
                                    const SizedBox(height: 8),
                                    _inputField(
                                      label: 'Password',
                                        obscure: true,
                                        controller: _passwordController,
                                      ),
                                    const SizedBox(height: 8),
                                    Center(
                                      child: TextButton(
                                        onPressed: () {},
                                        style: TextButton.styleFrom(
                                          foregroundColor:
                                              AppColors.loginMainTextColor,
                                          padding: EdgeInsets.zero,
                                          minimumSize: Size.zero,
                                          tapTargetSize:
                                              MaterialTapTargetSize.shrinkWrap,
                                        ),
                                        child: const Text(
                                          'Elfelejtett jelszó?',
                                          style: TextStyle(
                                            fontFamily: 'Candal',
                                            fontWeight: FontWeight.bold,
                                          ),
                                        ),
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                              const SizedBox(height: 8),
                              Center(
                                child: SizedBox(
                                  width: 180,
                                  child: ElevatedButton(
                                    onPressed: () => doLogin(),
                                    style: ElevatedButton.styleFrom(
                                      padding: const EdgeInsets.symmetric(
                                        vertical: 12,
                                      ),
                                      backgroundColor:
                                          AppColors.loginMainTextColor,
                                      textStyle: const TextStyle(
                                        fontSize: 15,
                                        fontFamily: 'Candal',
                                        fontWeight: FontWeight.bold,
                                        color: Colors.white,
                                      ),
                                      shape: RoundedRectangleBorder(
                                        borderRadius: BorderRadius.circular(12),
                                      ),
                                    ),
                                    child: const Text(
                                      'Bejelentkezés',
                                      style: TextStyle(color: Colors.white),
                                    ),
                                  ),
                                ),
                              ),
                              const SizedBox(height: 8),
                              Container(
                                width: double.infinity,
                                height: 3,
                                decoration: BoxDecoration(
                                  color: AppColors.loginMainTextColor,
                                  borderRadius: BorderRadius.circular(2),
                                ),
                              ),
                              const SizedBox(height: 8),
                              Center(
                                child: Text(
                                  'További bejelentkezési lehetőségek:',
                                  style: const TextStyle(
                                    fontSize: 12,
                                    fontFamily: 'Candal',
                                    fontWeight: FontWeight.bold,
                                    color: AppColors.loginMainTextColor,
                                    letterSpacing: 0.2,
                                  ),
                                  textAlign: TextAlign.center,
                                ),
                              ),
                              const SizedBox(height: 8),
                              Row(
                                mainAxisAlignment:
                                    MainAxisAlignment.spaceEvenly,
                                children: [
                                  _socialButton(
                                    asset: 'assets/images/google_logo.png',
                                    label: 'Google',
                                  ),
                                  const SizedBox(width: 8),
                                  _socialButton(
                                    asset: 'assets/images/facebook_logo.png',
                                    label: 'Facebook',
                                  ),
                                ],
                              ),
                            ],
                          ),
                        ),
                      ),
                      Positioned(
                        top: titleTop,
                        left: 0,
                        right: 0,
                        child: Center(
                          child: SizedBox(
                            height: titleFontSize * 1.6,
                            child: Align(
                              alignment: Alignment.topCenter,
                              child: Text(
                                'NoteSharing',
                                style: TextStyle(
                                  fontFamily: 'Candal',
                                  fontSize: titleFontSize,
                                  fontWeight: FontWeight.bold,
                                  color: AppColors.loginMainTextColor,
                                  shadows: const [
                                    Shadow(
                                      color: Colors.black12,
                                      blurRadius: 16,
                                      offset: Offset(0, 5),
                                    ),
                                  ],
                                ),
                                textAlign: TextAlign.center,
                              ),
                            ),
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
                const SizedBox(height: 32),
                SizedBox(
                  width: boxWidth,
                  child: DecoratedBox(
                    decoration: BoxDecoration(
                      color: AppColors.loginBoxBackgroundColor,
                      borderRadius: const BorderRadius.all(Radius.circular(24)),
                      boxShadow: const [
                        BoxShadow(
                          color: Colors.black12,
                          blurRadius: 16,
                          offset: Offset(0, 8),
                        ),
                      ],
                    ),
                    child: Padding(
                      padding: const EdgeInsets.symmetric(
                        horizontal: 12.0,
                        vertical: 12.0,
                      ),
                      child: Row(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          const Text(
                            "Nincs még fiókod? ",
                            style: TextStyle(
                              fontFamily: 'Candal',
                              fontWeight: FontWeight.bold,
                              fontSize: 12,
                              color: AppColors.loginMainTextColor,
                            ),
                          ),
                          TextButton(
                            onPressed: () {
                              Navigator.of(context).push(
                                MaterialPageRoute(
                                  builder: (_) => const RegisterPage(),
                                ),
                              );
                            },
                            style: TextButton.styleFrom(
                              foregroundColor: Colors.blue,
                              padding: EdgeInsets.zero,
                              minimumSize: Size.zero,
                              tapTargetSize: MaterialTapTargetSize.shrinkWrap,
                            ),
                            child: const Text(
                              'Regisztrálj itt!',
                              style: TextStyle(
                                fontFamily: 'Candal',
                                fontWeight: FontWeight.bold,
                                fontSize: 12,
                                color: Colors.blue,
                                decoration: TextDecoration.underline,
                              ),
                            ),
                          ),
                        ],
                      ),
                    ),
                  ),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
