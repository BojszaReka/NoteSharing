import 'package:flutter/material.dart';
import 'package:notesharing_ui/application/configs/app_colors.dart';
import 'package:notesharing_ui/features/profile/profile_page.dart';

class NoteDetailPage extends StatefulWidget {
  final String noteId;
  final String title;
  final String author;
  final String authorId;
  final String subject;
  final String institution;
  final int score;
  final String preview;
  final String content;
  final int minutesAgo;

  const NoteDetailPage({
    super.key,
    required this.noteId,
    required this.title,
    required this.author,
    required this.authorId,
    required this.subject,
    required this.institution,
    required this.score,
    required this.preview,
    required this.content,
    required this.minutesAgo,
  });

  @override
  State<NoteDetailPage> createState() => _NoteDetailPageState();
}

class _NoteDetailPageState extends State<NoteDetailPage> {
  bool _isLiked = false;
  int _currentScore = 0;

  @override
  void initState() {
    super.initState();
    _currentScore = widget.score;
  }

  void _toggleLike() {
    setState(() {
      if (_isLiked) {
        _currentScore--;
        _isLiked = false;
      } else {
        _currentScore++;
        _isLiked = true;
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: [
          Positioned.fill(
            child: Image(
              image: const AssetImage('assets/images/NoteShareBackground.png'),
              fit: BoxFit.cover,
            ),
          ),
          SafeArea(
            child: SingleChildScrollView(
              child: Padding(
                padding: const EdgeInsets.symmetric(horizontal: 16.0, vertical: 16.0),
                child: Column(
                  children: [
                    // Header with back button
                    Row(
                      children: [
                        IconButton(
                          icon: const Icon(Icons.arrow_back, color: AppColors.loginMainTextColor),
                          onPressed: () => Navigator.of(context).pop(),
                        ),
                        const Spacer(),
                        IconButton(
                          icon: Icon(
                            _isLiked ? Icons.favorite : Icons.favorite_border,
                            color: _isLiked ? Colors.red : AppColors.loginMainTextColor,
                          ),
                          onPressed: _toggleLike,
                        ),
                      ],
                    ),
                    const SizedBox(height: 16),
                    // Main note card
                    SizedBox(
                      width: double.infinity,
                      child: DecoratedBox(
                        decoration: BoxDecoration(
                          color: AppColors.loginBoxBackgroundColor,
                          borderRadius: BorderRadius.circular(20),
                          boxShadow: const [
                            BoxShadow(
                              color: Colors.black12,
                              blurRadius: 16,
                              offset: Offset(0, 8),
                            ),
                          ],
                          border: Border.all(color: Colors.black12),
                        ),
                        child: Padding(
                          padding: const EdgeInsets.all(20.0),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              // Title
                              Text(
                                widget.title,
                                style: const TextStyle(
                                  fontFamily: 'Candal',
                                  fontWeight: FontWeight.bold,
                                  fontSize: 20,
                                  color: AppColors.loginMainTextColor,
                                ),
                              ),
                              const SizedBox(height: 16),
                              // Author info
                              InkWell(
                                onTap: () {
                                  Navigator.of(context).push(
                                    MaterialPageRoute(
                                      builder: (_) => ProfilePage(
                                        userId: widget.authorId,
                                        userName: widget.author,
                                        isOwnProfile: false,
                                      ),
                                    ),
                                  );
                                },
                                child: Row(
                                  children: [
                                    CircleAvatar(
                                      radius: 24,
                                      backgroundColor: AppColors.loginMainTextColor.withOpacity(0.12),
                                      child: Text(
                                        widget.author.substring(0, 1).toUpperCase(),
                                        style: const TextStyle(
                                          fontFamily: 'Candal',
                                          fontWeight: FontWeight.bold,
                                          fontSize: 18,
                                          color: AppColors.loginMainTextColor,
                                        ),
                                      ),
                                    ),
                                    const SizedBox(width: 12),
                                    Column(
                                      crossAxisAlignment: CrossAxisAlignment.start,
                                      children: [
                                        Text(
                                          widget.author,
                                          style: const TextStyle(
                                            fontFamily: 'Candal',
                                            fontWeight: FontWeight.bold,
                                            fontSize: 13,
                                            color: AppColors.loginMainTextColor,
                                          ),
                                        ),
                                        const SizedBox(height: 4),
                                        Text(
                                          '${widget.minutesAgo} perce',
                                          style: TextStyle(
                                            fontFamily: 'Candal',
                                            fontWeight: FontWeight.bold,
                                            fontSize: 10,
                                            color: AppColors.loginMainTextColor.withOpacity(0.5),
                                          ),
                                        ),
                                      ],
                                    ),
                                  ],
                                ),
                              ),
                              const SizedBox(height: 16),
                              // Metadata badges
                              Wrap(
                                spacing: 8,
                                runSpacing: 8,
                                children: [
                                  _MetaBadge(
                                    icon: Icons.book,
                                    label: widget.subject,
                                  ),
                                  _MetaBadge(
                                    icon: Icons.location_city,
                                    label: widget.institution,
                                  ),
                                  _MetaBadge(
                                    icon: Icons.star,
                                    label: _currentScore.toString(),
                                  ),
                                ],
                              ),
                              const SizedBox(height: 20),
                              Container(
                                width: double.infinity,
                                height: 1,
                                color: AppColors.loginMainTextColor.withOpacity(0.2),
                              ),
                              const SizedBox(height: 20),
                              // Content
                              Text(
                                'Tartalom',
                                style: const TextStyle(
                                  fontFamily: 'Candal',
                                  fontWeight: FontWeight.bold,
                                  fontSize: 14,
                                  color: AppColors.loginMainTextColor,
                                ),
                              ),
                              const SizedBox(height: 12),
                              Text(
                                widget.content,
                                style: TextStyle(
                                  fontFamily: 'Candal',
                                  fontWeight: FontWeight.bold,
                                  fontSize: 12,
                                  color: AppColors.loginMainTextColor.withOpacity(0.8),
                                  height: 1.6,
                                ),
                              ),
                              const SizedBox(height: 20),
                              // Interaction row
                              Row(
                                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                                children: [
                                  _InteractionButton(
                                    icon: Icons.cloud_download,
                                    label: 'Letöltés',
                                    onTap: () {
                                      ScaffoldMessenger.of(context).showSnackBar(
                                        const SnackBar(
                                          content: Text('Letöltés indítva...'),
                                          duration: Duration(seconds: 2),
                                        ),
                                      );
                                    },
                                  ),
                                  _InteractionButton(
                                    icon: Icons.share,
                                    label: 'Megosztás',
                                    onTap: () {
                                      ScaffoldMessenger.of(context).showSnackBar(
                                        const SnackBar(
                                          content: Text('Megosztás funkciója hamarosan...'),
                                          duration: Duration(seconds: 2),
                                        ),
                                      );
                                    },
                                  ),
                                  _InteractionButton(
                                    icon: Icons.comment,
                                    label: 'Hozzászólás',
                                    onTap: () {
                                      ScaffoldMessenger.of(context).showSnackBar(
                                        const SnackBar(
                                          content: Text('Hozzászólások funkciója hamarosan...'),
                                          duration: Duration(seconds: 2),
                                        ),
                                      );
                                    },
                                  ),
                                ],
                              ),
                            ],
                          ),
                        ),
                      ),
                    ),
                    const SizedBox(height: 24),
                  ],
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}

class _MetaBadge extends StatelessWidget {
  final IconData icon;
  final String label;

  const _MetaBadge({
    required this.icon,
    required this.label,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 12, vertical: 6),
      decoration: BoxDecoration(
        color: AppColors.loginMainTextColor.withOpacity(0.1),
        borderRadius: BorderRadius.circular(20),
        border: Border.all(
          color: AppColors.loginMainTextColor.withOpacity(0.3),
        ),
      ),
      child: Row(
        mainAxisSize: MainAxisSize.min,
        children: [
          Icon(icon, size: 14, color: AppColors.loginMainTextColor),
          const SizedBox(width: 6),
          Text(
            label,
            style: const TextStyle(
              fontFamily: 'Candal',
              fontWeight: FontWeight.bold,
              fontSize: 11,
              color: AppColors.loginMainTextColor,
            ),
          ),
        ],
      ),
    );
  }
}

class _InteractionButton extends StatelessWidget {
  final IconData icon;
  final String label;
  final VoidCallback onTap;

  const _InteractionButton({
    required this.icon,
    required this.label,
    required this.onTap,
  });

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: onTap,
      borderRadius: BorderRadius.circular(12),
      child: Container(
        padding: const EdgeInsets.symmetric(horizontal: 12, vertical: 8),
        decoration: BoxDecoration(
          border: Border.all(
            color: AppColors.loginMainTextColor.withOpacity(0.3),
            width: 2,
          ),
          borderRadius: BorderRadius.circular(12),
        ),
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            Icon(icon, color: AppColors.loginMainTextColor, size: 20),
            const SizedBox(height: 4),
            Text(
              label,
              style: const TextStyle(
                fontFamily: 'Candal',
                fontWeight: FontWeight.bold,
                fontSize: 10,
                color: AppColors.loginMainTextColor,
              ),
            ),
          ],
        ),
      ),
    );
  }
}
