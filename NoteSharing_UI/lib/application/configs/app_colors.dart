import 'package:flutter/material.dart';

abstract class AppColors {
  static const Color _blue1 = Color(0xFF004AAD);
  static const Color _lightBlue1 = Color(0xFFF1FAFF);
  // Notification palette
  static const Color _error = Color(0xFFE53935); // Red 600-ish
  static const Color _success = Color(0xFF2E7D32); // Green 700-ish
  static const Color _info = Color(0xFF1565C0); // Blue 800-ish
  static const Color _warning = Color(0xFFF9A825); // Amber 800 (reserved for future)

  // Login Page Colors
  static const loginMainTextColor = _blue1;
  static const loginBoxBackgroundColor = _lightBlue1;

  // Notifications (exported)
  static const notificationError = _error;
  static const notificationSuccess = _success;
  static const notificationInfo = _info;
  static const notificationWarning = _warning; // not yet used, future expansion
  static const notificationBackground = Colors.white; // Card surface for notifications
}