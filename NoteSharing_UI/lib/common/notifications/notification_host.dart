import 'package:flutter/material.dart';
import 'app_notification.dart';
import 'notification_service.dart';
import 'package:notesharing_ui/application/configs/app_colors.dart';

class NotificationHost extends StatelessWidget {
  final Widget child;
  const NotificationHost({super.key, required this.child});

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        child,
        Positioned(
          top: 24,
          left: 0,
            right: 0,
          child: SafeArea(
            child: _NotificationOverlay(),
          ),
        ),
      ],
    );
  }
}

class _NotificationOverlay extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final service = NotificationProvider.of(context);
    final notes = service.notifications;
    return Column(
      mainAxisSize: MainAxisSize.min,
      children: [
        for (final n in notes)
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 6),
            child: _NotificationCard(notification: n, onDismiss: () => service.dismiss(n.id)),
          ),
      ],
    );
  }
}

class _NotificationCard extends StatefulWidget {
  final AppNotification notification;
  final VoidCallback onDismiss;
  const _NotificationCard({required this.notification, required this.onDismiss});

  @override
  State<_NotificationCard> createState() => _NotificationCardState();
}

class _NotificationCardState extends State<_NotificationCard> with SingleTickerProviderStateMixin {
  late AnimationController _controller;
  late Animation<double> _fade;
  late Animation<Offset> _slide;

  @override
  void initState() {
    super.initState();
    _controller = AnimationController(vsync: this, duration: const Duration(milliseconds: 260));
    _fade = CurvedAnimation(parent: _controller, curve: Curves.easeOut);
    _slide = Tween(begin: const Offset(0, -0.2), end: Offset.zero)
        .animate(CurvedAnimation(parent: _controller, curve: Curves.easeOutCubic));
    _controller.forward();
  }

  @override
  void dispose() {
    _controller.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    final n = widget.notification;
    final color = notificationColor(n.type);
    return Dismissible(
      key: ValueKey(n.id),
      direction: DismissDirection.horizontal,
      onDismissed: (_) => widget.onDismiss(),
      child: FadeTransition(
        opacity: _fade,
        child: SlideTransition(
          position: _slide,
          child: Material(
            elevation: 8,
            color: Colors.transparent,
            child: Container(
              constraints: const BoxConstraints(maxWidth: 520),
              decoration: BoxDecoration(
                color: AppColors.loginBoxBackgroundColor,
                borderRadius: BorderRadius.circular(18),
                border: Border.all(color: color, width: 2),
                boxShadow: const [
                  BoxShadow(
                    color: Colors.black12,
                    blurRadius: 16,
                    offset: Offset(0, 6),
                  )
                ],
              ),
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 14),
              child: Row(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Container(
                    width: 40,
                    height: 40,
                    decoration: BoxDecoration(
                      color: color,
                      shape: BoxShape.circle,
                      boxShadow: const [
                        BoxShadow(
                          color: Colors.black12,
                          blurRadius: 8,
                          offset: Offset(0, 3),
                        )
                      ],
                    ),
                    child: Icon(notificationIcon(n.type), color: Colors.white, size: 22),
                  ),
                  const SizedBox(width: 14),
                  Expanded(
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text(
                          n.title,
                          style: TextStyle(
                            fontFamily: 'Candal',
                            fontWeight: FontWeight.bold,
                            fontSize: 14,
                            color: color,
                          ),
                        ),
                        if (n.message != null && n.message!.trim().isNotEmpty) ...[
                          const SizedBox(height: 6),
                          Text(
                            n.message!,
                            style: TextStyle(
                              fontFamily: 'Candal',
                              fontWeight: FontWeight.bold,
                              fontSize: 11.5,
                              height: 1.25,
                              color: AppColors.loginMainTextColor.withValues(alpha: 0.85),
                            ),
                          ),
                        ],
                      ],
                    ),
                  ),
                  const SizedBox(width: 8),
                  InkWell(
                    onTap: widget.onDismiss,
                    borderRadius: BorderRadius.circular(20),
                    child: Padding(
                      padding: const EdgeInsets.all(4.0),
                      child: Icon(Icons.close, size: 18, color: AppColors.loginMainTextColor.withValues(alpha: 0.7)),
                    ),
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
