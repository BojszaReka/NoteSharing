import 'package:flutter/material.dart';
import 'package:notesharing_ui/application/configs/app_colors.dart';

enum AppNotificationType { error, info, success }

class AppNotification {
  final String id;
  final String title;
  final String? message;
  final AppNotificationType type;
  final Duration duration;
  final DateTime createdAt;

  AppNotification({
    required this.id,
    required this.title,
    this.message,
    required this.type,
    Duration? duration,
  })  : duration = duration ?? const Duration(seconds: 4),
        createdAt = DateTime.now();
}

IconData notificationIcon(AppNotificationType type) {
  switch (type) {
    case AppNotificationType.error:
      return Icons.error_outline;
    case AppNotificationType.success:
      return Icons.check_circle_outline;
    case AppNotificationType.info:
      return Icons.info_outline;
  }
}

Color notificationColor(AppNotificationType type) {
  switch (type) {
    case AppNotificationType.error:
      return AppColors.notificationError;
    case AppNotificationType.success:
      return AppColors.notificationSuccess;
    case AppNotificationType.info:
      return AppColors.notificationInfo;
  }
}