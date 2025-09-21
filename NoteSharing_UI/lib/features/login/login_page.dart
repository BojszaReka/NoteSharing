import 'package:flutter/material.dart';
import 'package:notesharing_ui/application/configs/app_colors.dart';

class LoginPage extends StatelessWidget {
  const LoginPage({Key? key}) : super(key: key);

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
              image: AssetImage('assets/images/NoteShareBackground.png'),
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
                      // The box
                      DecoratedBox(
                        decoration: BoxDecoration(
                          color: AppColors.loginBoxBackgroundColor,
                          borderRadius: BorderRadius.all(Radius.circular(24)),
                          boxShadow: [
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
                                  crossAxisAlignment: CrossAxisAlignment.stretch,
                                  children: [
                                    const SizedBox(height: 8),
                                    Expanded(
                                      child: TextField(
                                        decoration: InputDecoration(
                                          labelText: 'Email',
                                          labelStyle: TextStyle(
                                            color: AppColors.loginMainTextColor,
                                            fontFamily: 'Candal',
                                            fontWeight: FontWeight.bold,
                                          ),
                                          filled: true,
                                          fillColor: Colors.white,
                                          border: OutlineInputBorder(
                                            borderRadius: BorderRadius.circular(12),
                                          ),
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
                                      ),
                                    ),
                                    const SizedBox(height: 8),
                                    Expanded(
                                      child: TextField(
                                        obscureText: true,
                                        decoration: InputDecoration(
                                          labelText: 'Password',
                                          labelStyle: TextStyle(
                                            color: AppColors.loginMainTextColor,
                                            fontFamily: 'Candal',
                                            fontWeight: FontWeight.bold,
                                          ),
                                          filled: true,
                                          fillColor: Colors.white,
                                          border: OutlineInputBorder(
                                            borderRadius: BorderRadius.circular(12),
                                          ),
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
                                          foregroundColor: AppColors.loginMainTextColor,
                                          padding: EdgeInsets.zero,
                                          minimumSize: Size(0, 0),
                                          tapTargetSize: MaterialTapTargetSize.shrinkWrap,
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
                                      backgroundColor: AppColors.loginMainTextColor,
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
                                  style: TextStyle(
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
                                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                                children: [
                                  Flexible(
                                    child: SizedBox(
                                      height: 40,
                                      child: OutlinedButton.icon(
                                        onPressed: () {},
                                        icon: Image.asset(
                                          'assets/images/google_logo.png',
                                          height: 20,
                                          width: 20,
                                        ),
                                        label: const Text(
                                          'Google',
                                          style: TextStyle(
                                            fontFamily: 'Candal',
                                            fontWeight: FontWeight.bold,
                                            color: AppColors.loginMainTextColor,
                                          ),
                                        ),
                                        style: OutlinedButton.styleFrom(
                                          padding: const EdgeInsets.symmetric(
                                            vertical: 6,
                                            horizontal: 6,
                                          ),
                                          textStyle: const TextStyle(
                                            fontSize: 14,
                                            fontWeight: FontWeight.w600,
                                          ),
                                          side: BorderSide(
                                            color: Colors.grey.shade400,
                                          ),
                                          shape: RoundedRectangleBorder(
                                            borderRadius: BorderRadius.circular(10),
                                          ),
                                        ),
                                      ),
                                    ),
                                  ),
                                  const SizedBox(width: 8),
                                  Flexible(
                                    child: SizedBox(
                                      height: 40,
                                      child: OutlinedButton.icon(
                                        onPressed: () {},
                                        icon: Image.asset(
                                          'assets/images/facebook_logo.png',
                                          height: 20,
                                          width: 20,
                                        ),
                                        label: const Text(
                                          'Facebook',
                                          style: TextStyle(
                                            fontFamily: 'Candal',
                                            fontWeight: FontWeight.bold,
                                            color: AppColors.loginMainTextColor,
                                          ),
                                        ),
                                        style: OutlinedButton.styleFrom(
                                          padding: const EdgeInsets.symmetric(
                                            vertical: 6,
                                            horizontal: 6,
                                          ),
                                          textStyle: const TextStyle(
                                            fontSize: 14,
                                            fontWeight: FontWeight.w600,
                                          ),
                                          side: BorderSide(
                                            color: Colors.grey.shade400,
                                          ),
                                          shape: RoundedRectangleBorder(
                                            borderRadius: BorderRadius.circular(10),
                                          ),
                                        ),
                                      ),
                                    ),
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
                                  shadows: [
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
                // Registration floating box (single line)
                SizedBox(
                  width: boxWidth,
                  child: DecoratedBox(
                    decoration: BoxDecoration(
                      color: AppColors.loginBoxBackgroundColor,
                      borderRadius: BorderRadius.all(Radius.circular(24)),
                      boxShadow: [
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
                          Text(
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
