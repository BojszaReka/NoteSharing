import 'package:flutter/material.dart';
import 'package:notesharing_ui/application/configs/app_colors.dart';

class LoginPage extends StatelessWidget {
  const LoginPage({Key? key}) : super(key: key);

  Widget _inputField({required String label, bool obscure = false}) {
    return TextField(
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
                            crossAxisAlignment: CrossAxisAlignment.stretch,
                            children: [
                              Expanded(
                                child: Column(
                                  mainAxisAlignment: MainAxisAlignment.start,
                                  crossAxisAlignment:
                                      CrossAxisAlignment.stretch,
                                  children: [
                                    const SizedBox(height: 8),
                                    Expanded(
                                      child: _inputField(label: 'Email'),
                                    ),
                                    const SizedBox(height: 8),
                                    Expanded(
                                      child: _inputField(
                                        label: 'Password',
                                        obscure: true,
                                      ),
                                    ),
                                    const SizedBox(height: 8),
                                    Center(
                                      child: TextButton(
                                        onPressed: () {},
                                        child: const Text(
                                          'Elfelejtett jelszó?',
                                          style: TextStyle(
                                            fontFamily: 'Candal',
                                            fontWeight: FontWeight.bold,
                                          ),
                                        ),
                                        style: TextButton.styleFrom(
                                          foregroundColor:
                                              AppColors.loginMainTextColor,
                                          padding: EdgeInsets.zero,
                                          minimumSize: Size(0, 0),
                                          tapTargetSize:
                                              MaterialTapTargetSize.shrinkWrap,
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
                                    onPressed: () {},
                                    child: const Text(
                                      'Bejelentkezés',
                                      style: TextStyle(color: Colors.white),
                                    ),
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
                            onPressed: () {},
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
                            style: TextButton.styleFrom(
                              foregroundColor: Colors.blue,
                              padding: EdgeInsets.zero,
                              minimumSize: Size(0, 0),
                              tapTargetSize: MaterialTapTargetSize.shrinkWrap,
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
