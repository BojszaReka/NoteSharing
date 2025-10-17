import 'dart:async';
import 'package:flutter/material.dart';
import 'app_notification.dart';

class NotificationService extends ChangeNotifier {
  final List<AppNotification> _queue = [];

  List<AppNotification> get notifications => List.unmodifiable(_queue);

  void show({
    required String title,
    String? message,
    required AppNotificationType type,
    Duration? duration,
  }) {
    final note = AppNotification(
      id: UniqueKey().toString(),
      title: title,
      message: message,
      type: type,
      duration: duration,
    );
    _queue.add(note);
    notifyListeners();
    Timer(note.duration, () => dismiss(note.id));
  }

  void dismiss(String id) {
    final index = _queue.indexWhere((n) => n.id == id);
    if (index != -1) {
      _queue.removeAt(index);
      notifyListeners();
    }
  }

  void clear() {
    if (_queue.isNotEmpty) {
      _queue.clear();
      notifyListeners();
    }
  }
}

class NotificationProvider extends InheritedNotifier<NotificationService> {
  const NotificationProvider({
    super.key,
    required NotificationService service,
    required super.child,
  }) : super(notifier: service);

  static NotificationService of(BuildContext context) {
    final provider = context.dependOnInheritedWidgetOfExactType<NotificationProvider>();
    assert(provider != null, 'NotificationProvider not found in context');
    return provider!.notifier!;
  }
}
