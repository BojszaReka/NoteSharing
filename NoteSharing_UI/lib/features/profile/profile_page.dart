import 'package:flutter/material.dart';
import 'package:notesharing_ui/application/configs/app_colors.dart';

class ProfilePage extends StatefulWidget {
  final String userId;
  final String userName;
  final bool isOwnProfile;

  const ProfilePage({
    super.key,
    required this.userId,
    required this.userName,
    this.isOwnProfile = false,
  });

  @override
  State<ProfilePage> createState() => _ProfilePageState();
}

class _ProfilePageState extends State<ProfilePage> {
  bool _isFollowing = false;
  int _selectedTab = 0; // 0 = Notes, 1 = About

  @override
  Widget build(BuildContext context) {
    final size = MediaQuery.of(context).size;

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
                    // Back button
                    Row(
                      children: [
                        IconButton(
                          icon: const Icon(Icons.arrow_back, color: AppColors.loginMainTextColor),
                          onPressed: () => Navigator.of(context).pop(),
                        ),
                      ],
                    ),
                    const SizedBox(height: 16),
                    // Profile card
                    SizedBox(
                      width: size.width * 0.9 > 380 ? 380 : size.width * 0.9,
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
                          padding: const EdgeInsets.all(24.0),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.center,
                            children: [
                              // Avatar
                              CircleAvatar(
                                radius: 48,
                                backgroundColor: AppColors.loginMainTextColor.withOpacity(0.2),
                                child: Text(
                                  widget.userName.substring(0, 1).toUpperCase(),
                                  style: const TextStyle(
                                    fontFamily: 'Candal',
                                    fontWeight: FontWeight.bold,
                                    fontSize: 40,
                                    color: AppColors.loginMainTextColor,
                                  ),
                                ),
                              ),
                              const SizedBox(height: 16),
                              // Name
                              Text(
                                widget.userName,
                                style: const TextStyle(
                                  fontFamily: 'Candal',
                                  fontWeight: FontWeight.bold,
                                  fontSize: 20,
                                  color: AppColors.loginMainTextColor,
                                ),
                                textAlign: TextAlign.center,
                              ),
                              const SizedBox(height: 8),
                              // Email
                              Text(
                                '${widget.userName.toLowerCase().replaceAll(' ', '.')}@example.com',
                                style: TextStyle(
                                  fontFamily: 'Candal',
                                  fontWeight: FontWeight.bold,
                                  fontSize: 12,
                                  color: AppColors.loginMainTextColor.withOpacity(0.6),
                                ),
                                textAlign: TextAlign.center,
                              ),
                              const SizedBox(height: 16),
                              // Stats
                              Row(
                                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                                children: [
                                  _StatItem(label: 'Jegyzetek', value: '12'),
                                  _StatItem(label: 'Követők', value: '48'),
                                  _StatItem(label: 'Követett', value: '23'),
                                ],
                              ),
                              const SizedBox(height: 20),
                              // Follow/Edit button
                              SizedBox(
                                width: double.infinity,
                                child: ElevatedButton(
                                  onPressed: widget.isOwnProfile
                                      ? () {
                                          ScaffoldMessenger.of(context).showSnackBar(
                                            const SnackBar(
                                              content: Text('Profil szerkesztésének funkciója hamarosan...'),
                                              duration: Duration(seconds: 2),
                                            ),
                                          );
                                        }
                                      : () {
                                          setState(() => _isFollowing = !_isFollowing);
                                        },
                                  style: ElevatedButton.styleFrom(
                                    backgroundColor: widget.isOwnProfile
                                        ? AppColors.loginMainTextColor
                                        : (_isFollowing ? Colors.grey : AppColors.loginMainTextColor),
                                    padding: const EdgeInsets.symmetric(vertical: 12),
                                    shape: RoundedRectangleBorder(
                                      borderRadius: BorderRadius.circular(12),
                                    ),
                                  ),
                                  child: Text(
                                    widget.isOwnProfile
                                        ? 'Profil Szerkesztése'
                                        : (_isFollowing ? 'Követve' : 'Követés'),
                                    style: const TextStyle(
                                      fontFamily: 'Candal',
                                      fontWeight: FontWeight.bold,
                                      color: Colors.white,
                                    ),
                                  ),
                                ),
                              ),
                            ],
                          ),
                        ),
                      ),
                    ),
                    const SizedBox(height: 24),
                    // Tab buttons
                    SizedBox(
                      width: size.width * 0.9 > 380 ? 380 : size.width * 0.9,
                      child: Row(
                        children: [
                          Expanded(
                            child: _TabButton(
                              label: 'Jegyzetek',
                              isActive: _selectedTab == 0,
                              onTap: () => setState(() => _selectedTab = 0),
                            ),
                          ),
                          const SizedBox(width: 12),
                          Expanded(
                            child: _TabButton(
                              label: 'Rólam',
                              isActive: _selectedTab == 1,
                              onTap: () => setState(() => _selectedTab = 1),
                            ),
                          ),
                        ],
                      ),
                    ),
                    const SizedBox(height: 16),
                    // Tab content
                    SizedBox(
                      width: size.width * 0.9 > 380 ? 380 : size.width * 0.9,
                      child: _selectedTab == 0
                          ? _buildNotesTab()
                          : _buildAboutTab(),
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

  Widget _buildNotesTab() {
    return Column(
      children: List.generate(
        3,
        (index) => Padding(
          padding: const EdgeInsets.only(bottom: 12.0),
          child: DecoratedBox(
            decoration: BoxDecoration(
              color: AppColors.loginBoxBackgroundColor,
              borderRadius: BorderRadius.circular(16),
              boxShadow: const [
                BoxShadow(
                  color: Colors.black12,
                  blurRadius: 8,
                  offset: Offset(0, 4),
                ),
              ],
              border: Border.all(color: Colors.black12),
            ),
            child: Padding(
              padding: const EdgeInsets.all(12.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    'Jegyzet ${index + 1}',
                    style: const TextStyle(
                      fontFamily: 'Candal',
                      fontWeight: FontWeight.bold,
                      fontSize: 14,
                      color: AppColors.loginMainTextColor,
                    ),
                  ),
                  const SizedBox(height: 6),
                  Text(
                    'Ez egy rövid leírás a jegyzetről...',
                    style: TextStyle(
                      fontFamily: 'Candal',
                      fontWeight: FontWeight.bold,
                      fontSize: 11,
                      color: AppColors.loginMainTextColor.withOpacity(0.6),
                    ),
                    maxLines: 2,
                    overflow: TextOverflow.ellipsis,
                  ),
                  const SizedBox(height: 8),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Text(
                        'Matematika',
                        style: TextStyle(
                          fontFamily: 'Candal',
                          fontWeight: FontWeight.bold,
                          fontSize: 10,
                          color: AppColors.loginMainTextColor.withOpacity(0.5),
                        ),
                      ),
                      Row(
                        children: [
                          const Icon(Icons.star, size: 14, color: Colors.amber),
                          const SizedBox(width: 4),
                          Text(
                            '4.5',
                            style: TextStyle(
                              fontFamily: 'Candal',
                              fontWeight: FontWeight.bold,
                              fontSize: 10,
                              color: AppColors.loginMainTextColor.withOpacity(0.6),
                            ),
                          ),
                        ],
                      ),
                    ],
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildAboutTab() {
    return DecoratedBox(
      decoration: BoxDecoration(
        color: AppColors.loginBoxBackgroundColor,
        borderRadius: BorderRadius.circular(16),
        boxShadow: const [
          BoxShadow(
            color: Colors.black12,
            blurRadius: 8,
            offset: Offset(0, 4),
          ),
        ],
      ),
      child: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              'Bio',
              style: const TextStyle(
                fontFamily: 'Candal',
                fontWeight: FontWeight.bold,
                fontSize: 14,
                color: AppColors.loginMainTextColor,
              ),
            ),
            const SizedBox(height: 8),
            Text(
              'Matematika és fizika rajongó hallgató. Szívesen megosztom tanulmányi anyagaimat és tanulok a többiektől.',
              style: TextStyle(
                fontFamily: 'Candal',
                fontWeight: FontWeight.bold,
                fontSize: 12,
                color: AppColors.loginMainTextColor.withOpacity(0.7),
                height: 1.5,
              ),
            ),
            const SizedBox(height: 20),
            Text(
              'Intézmény',
              style: const TextStyle(
                fontFamily: 'Candal',
                fontWeight: FontWeight.bold,
                fontSize: 14,
                color: AppColors.loginMainTextColor,
              ),
            ),
            const SizedBox(height: 8),
            Text(
              'Eötvös Loránd Tudományegyetem',
              style: TextStyle(
                fontFamily: 'Candal',
                fontWeight: FontWeight.bold,
                fontSize: 12,
                color: AppColors.loginMainTextColor.withOpacity(0.7),
              ),
            ),
            const SizedBox(height: 20),
            Text(
              'Csatlakozás Dátuma',
              style: const TextStyle(
                fontFamily: 'Candal',
                fontWeight: FontWeight.bold,
                fontSize: 14,
                color: AppColors.loginMainTextColor,
              ),
            ),
            const SizedBox(height: 8),
            Text(
              '2024. szeptember 15.',
              style: TextStyle(
                fontFamily: 'Candal',
                fontWeight: FontWeight.bold,
                fontSize: 12,
                color: AppColors.loginMainTextColor.withOpacity(0.7),
              ),
            ),
          ],
        ),
      ),
    );
  }
}

class _StatItem extends StatelessWidget {
  final String label;
  final String value;

  const _StatItem({
    required this.label,
    required this.value,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text(
          value,
          style: const TextStyle(
            fontFamily: 'Candal',
            fontWeight: FontWeight.bold,
            fontSize: 18,
            color: AppColors.loginMainTextColor,
          ),
        ),
        const SizedBox(height: 4),
        Text(
          label,
          style: TextStyle(
            fontFamily: 'Candal',
            fontWeight: FontWeight.bold,
            fontSize: 11,
            color: AppColors.loginMainTextColor.withOpacity(0.6),
          ),
        ),
      ],
    );
  }
}

class _TabButton extends StatelessWidget {
  final String label;
  final bool isActive;
  final VoidCallback onTap;

  const _TabButton({
    required this.label,
    required this.isActive,
    required this.onTap,
  });

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: onTap,
      borderRadius: BorderRadius.circular(12),
      child: Container(
        padding: const EdgeInsets.symmetric(vertical: 12),
        decoration: BoxDecoration(
          border: Border.all(
            color: isActive
                ? AppColors.loginMainTextColor
                : AppColors.loginMainTextColor.withOpacity(0.3),
            width: 2,
          ),
          borderRadius: BorderRadius.circular(12),
          color: isActive
              ? AppColors.loginMainTextColor.withOpacity(0.1)
              : Colors.transparent,
        ),
        child: Text(
          label,
          style: TextStyle(
            fontFamily: 'Candal',
            fontWeight: FontWeight.bold,
            fontSize: 13,
            color: isActive ? AppColors.loginMainTextColor : AppColors.loginMainTextColor.withOpacity(0.5),
          ),
          textAlign: TextAlign.center,
        ),
      ),
    );
  }
}
