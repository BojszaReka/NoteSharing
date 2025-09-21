import 'package:flutter/material.dart';

import 'features/login/login_page.dart';

void main() {
  runApp(const NoteSharingApp());
}

class NoteSharingApp extends StatelessWidget {
  const NoteSharingApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Note Sharing',
      debugShowCheckedModeBanner: false,
      initialRoute: '/',
      routes: {
        // Define your routes here, e.g.:
        '/': (context) => LoginPage(),
      },
    );
  }
}
