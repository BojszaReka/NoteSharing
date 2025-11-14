import 'package:flutter/material.dart';

import 'features/login/login_page.dart';
import 'features/home/home_page.dart';
import 'features/main/main_page.dart';
import 'common/notifications/notification_service.dart';
import 'common/notifications/notification_host.dart';

void main() {
  runApp(const NoteSharingApp());
}

class NoteSharingApp extends StatelessWidget {
  const NoteSharingApp({super.key});

  @override
  Widget build(BuildContext context) {
    final notificationService = NotificationService();
    return NotificationProvider(
      service: notificationService,
      child: MaterialApp(
        title: 'Note Sharing',
        debugShowCheckedModeBanner: false,
        builder: (context, child) => NotificationHost(child: child ?? const SizedBox()),
        initialRoute: '/login',
        routes: {
          '/': (context) => const MainPage(),
          '/home': (context) => const HomePage(),
          '/login': (context) => const LoginPage(),
        },
      ),
    );
  }
}
