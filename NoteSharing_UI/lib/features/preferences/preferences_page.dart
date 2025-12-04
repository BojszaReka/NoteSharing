import 'package:flutter/material.dart';
import 'package:notesharing_ui/application/configs/app_colors.dart';

class PreferencesPage extends StatefulWidget {
  const PreferencesPage({super.key});

  @override
  State<PreferencesPage> createState() => _PreferencesPageState();
}

class _PreferencesPageState extends State<PreferencesPage> {
  bool _notificationsEnabled = true;
  bool _privateNotes = false;
  bool _showRecommendations = true;
  String _selectedTheme = 'light';

  @override
  Widget build(BuildContext context) {
    final size = MediaQuery.of(context).size;
    final boxWidth = size.width * 0.85 > 380 ? 380.0 : size.width * 0.85;

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
                padding: const EdgeInsets.symmetric(vertical: 24.0),
                child: Center(
                  child: Column(
                    children: [
                      // Header
                      Padding(
                        padding: const EdgeInsets.symmetric(horizontal: 16.0),
                        child: Row(
                          children: [
                            IconButton(
                              icon: const Icon(Icons.arrow_back, color: AppColors.loginMainTextColor),
                              onPressed: () => Navigator.of(context).pop(),
                            ),
                            const Expanded(
                              child: Text(
                                'Beállítások',
                                style: TextStyle(
                                  fontFamily: 'Candal',
                                  fontWeight: FontWeight.bold,
                                  fontSize: 20,
                                  color: AppColors.loginMainTextColor,
                                ),
                                textAlign: TextAlign.center,
                              ),
                            ),
                            const SizedBox(width: 48),
                          ],
                        ),
                      ),
                      const SizedBox(height: 24),
                      // Notifications section
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
                            padding: const EdgeInsets.all(20.0),
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  'Értesítések',
                                  style: TextStyle(
                                    fontFamily: 'Candal',
                                    fontWeight: FontWeight.bold,
                                    fontSize: 14,
                                    color: AppColors.loginMainTextColor,
                                  ),
                                ),
                                const SizedBox(height: 16),
                                _PreferenceToggle(
                                  label: 'Értesítések Engedélyezése',
                                  value: _notificationsEnabled,
                                  onChanged: (value) {
                                    setState(() => _notificationsEnabled = value);
                                  },
                                ),
                              ],
                            ),
                          ),
                        ),
                      ),
                      const SizedBox(height: 16),
                      // Privacy section
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
                            padding: const EdgeInsets.all(20.0),
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  'Adatvédelem',
                                  style: TextStyle(
                                    fontFamily: 'Candal',
                                    fontWeight: FontWeight.bold,
                                    fontSize: 14,
                                    color: AppColors.loginMainTextColor,
                                  ),
                                ),
                                const SizedBox(height: 16),
                                _PreferenceToggle(
                                  label: 'Saját Jegyzetek',
                                  sublabel: 'Csak Ön számára látható',
                                  value: _privateNotes,
                                  onChanged: (value) {
                                    setState(() => _privateNotes = value);
                                  },
                                ),
                                const SizedBox(height: 12),
                                _PreferenceToggle(
                                  label: 'Ajánlások Megjelenítése',
                                  sublabel: 'Személyre szabott tartalom',
                                  value: _showRecommendations,
                                  onChanged: (value) {
                                    setState(() => _showRecommendations = value);
                                  },
                                ),
                              ],
                            ),
                          ),
                        ),
                      ),
                      const SizedBox(height: 16),
                      // Theme selection
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
                            padding: const EdgeInsets.all(20.0),
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  'Megjelenítés',
                                  style: TextStyle(
                                    fontFamily: 'Candal',
                                    fontWeight: FontWeight.bold,
                                    fontSize: 14,
                                    color: AppColors.loginMainTextColor,
                                  ),
                                ),
                                const SizedBox(height: 16),
                                Container(
                                  decoration: BoxDecoration(
                                    border: Border.all(
                                      color: AppColors.loginMainTextColor.withOpacity(0.3),
                                      width: 2,
                                    ),
                                    borderRadius: BorderRadius.circular(12),
                                  ),
                                  child: DropdownButtonHideUnderline(
                                    child: DropdownButton<String>(
                                      value: _selectedTheme,
                                      isExpanded: true,
                                      isDense: true,
                                      items: [
                                        DropdownMenuItem(
                                          value: 'light',
                                          child: Padding(
                                            padding: const EdgeInsets.symmetric(horizontal: 12.0),
                                            child: Row(
                                              children: [
                                                const Icon(Icons.light_mode, size: 18, color: AppColors.loginMainTextColor),
                                                const SizedBox(width: 8),
                                                const Text(
                                                  'Világos',
                                                  style: TextStyle(
                                                    fontFamily: 'Candal',
                                                    fontWeight: FontWeight.bold,
                                                    color: AppColors.loginMainTextColor,
                                                  ),
                                                ),
                                              ],
                                            ),
                                          ),
                                        ),
                                        DropdownMenuItem(
                                          value: 'dark',
                                          child: Padding(
                                            padding: const EdgeInsets.symmetric(horizontal: 12.0),
                                            child: Row(
                                              children: [
                                                const Icon(Icons.dark_mode, size: 18, color: AppColors.loginMainTextColor),
                                                const SizedBox(width: 8),
                                                const Text(
                                                  'Sötét',
                                                  style: TextStyle(
                                                    fontFamily: 'Candal',
                                                    fontWeight: FontWeight.bold,
                                                    color: AppColors.loginMainTextColor,
                                                  ),
                                                ),
                                              ],
                                            ),
                                          ),
                                        ),
                                        DropdownMenuItem(
                                          value: 'system',
                                          child: Padding(
                                            padding: const EdgeInsets.symmetric(horizontal: 12.0),
                                            child: Row(
                                              children: [
                                                const Icon(Icons.settings_brightness, size: 18, color: AppColors.loginMainTextColor),
                                                const SizedBox(width: 8),
                                                const Text(
                                                  'Rendszer',
                                                  style: TextStyle(
                                                    fontFamily: 'Candal',
                                                    fontWeight: FontWeight.bold,
                                                    color: AppColors.loginMainTextColor,
                                                  ),
                                                ),
                                              ],
                                            ),
                                          ),
                                        ),
                                      ],
                                      onChanged: (value) {
                                        setState(() => _selectedTheme = value ?? 'light');
                                      },
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ),
                        ),
                      ),
                      const SizedBox(height: 24),
                      // Save button
                      SizedBox(
                        width: boxWidth,
                        child: ElevatedButton(
                          onPressed: () {
                            ScaffoldMessenger.of(context).showSnackBar(
                              const SnackBar(
                                content: Text('Beállítások mentve'),
                                duration: Duration(seconds: 2),
                              ),
                            );
                            Navigator.of(context).pop();
                          },
                          style: ElevatedButton.styleFrom(
                            backgroundColor: AppColors.loginMainTextColor,
                            padding: const EdgeInsets.symmetric(vertical: 14),
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(12),
                            ),
                          ),
                          child: const Text(
                            'Mentés',
                            style: TextStyle(
                              fontFamily: 'Candal',
                              fontWeight: FontWeight.bold,
                              color: Colors.white,
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
          ),
        ],
      ),
    );
  }
}

class _PreferenceToggle extends StatelessWidget {
  final String label;
  final String? sublabel;
  final bool value;
  final ValueChanged<bool> onChanged;

  const _PreferenceToggle({
    required this.label,
    this.sublabel,
    required this.value,
    required this.onChanged,
  });

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: () => onChanged(!value),
      child: Row(
        children: [
          Expanded(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  label,
                  style: const TextStyle(
                    fontFamily: 'Candal',
                    fontWeight: FontWeight.bold,
                    fontSize: 13,
                    color: AppColors.loginMainTextColor,
                  ),
                ),
                if (sublabel != null) ...[
                  const SizedBox(height: 4),
                  Text(
                    sublabel!,
                    style: TextStyle(
                      fontFamily: 'Candal',
                      fontWeight: FontWeight.bold,
                      fontSize: 11,
                      color: AppColors.loginMainTextColor.withOpacity(0.6),
                    ),
                  ),
                ],
              ],
            ),
          ),
          const SizedBox(width: 12),
          Switch(
            value: value,
            onChanged: onChanged,
            activeColor: AppColors.loginMainTextColor,
          ),
        ],
      ),
    );
  }
}
