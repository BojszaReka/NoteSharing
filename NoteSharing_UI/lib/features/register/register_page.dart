import 'package:flutter/material.dart';
import 'package:notesharing_ui/application/configs/app_colors.dart';
import 'package:notesharing_ui/common/notifications/notification_service.dart';
import 'package:notesharing_ui/common/notifications/app_notification.dart';

enum UserType { simple, student, instructor }

class _StepConfig {
  final String title;
  final Widget Function() builder;
  _StepConfig(this.title, this.builder);
}

class RegisterPage extends StatefulWidget {
  const RegisterPage({super.key});

  @override
  State<RegisterPage> createState() => _RegisterPageState();
}

class _RegisterPageState extends State<RegisterPage> {
  // Controllers (design only)
  final _usernameController = TextEditingController();
  final _nameController = TextEditingController();
  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();
  final _confirmPasswordController = TextEditingController();
  final _gradeController = TextEditingController();

  // Data state (design only)
  UserType? _userType;
  String? _selectedInstitution;
  final Set<String> _selectedSubjects = {};

  // Mock data
  final List<String> _institutions = const [
    'BME',
    'ELTE',
    'Szegedi Tudományegyetem',
    'Debreceni Egyetem',
  ];
  final List<String> _subjects = const [
    'Matematika',
    'Fizika',
    'Programozás',
    'Adatbázisok',
    'Közgazdaságtan',
    'Történelem',
  ];

  // Preferences (design only)
  bool prioritiseUsersFromInstitution = false;
  bool prioritiseInstructorNotes = false;
  bool privateMyNotes = false;
  bool prioritiseRatedNotes = true;
  bool prioritiseFollowedUsers = true;

  int _currentStep = 0;

  List<_StepConfig> get _steps {
    final steps = <_StepConfig>[
      _StepConfig('Szerep', _buildRoleStep),
      _StepConfig('Fiók', _buildAccountStep),
      _StepConfig('Intézmény', _buildInstitutionStep),
    ];
    if (_userType == UserType.student || _userType == UserType.instructor) {
      steps.add(_StepConfig('Tantárgyak', _buildSubjectsStep));
    }
    steps.add(_StepConfig('Preferenciák', _buildPreferencesStep));
    steps.add(_StepConfig('Összegzés', _buildSummaryStep));
    if (_currentStep >= steps.length) {
      _currentStep = steps.length - 1;
    }
    return steps;
  }

  @override
  void dispose() {
    _usernameController.dispose();
    _nameController.dispose();
    _emailController.dispose();
    _passwordController.dispose();
    _confirmPasswordController.dispose();
    _gradeController.dispose();
    super.dispose();
  }

  // UI building blocks
  Widget _inputField({
    required String label,
    TextEditingController? controller,
    bool obscure = false,
    TextInputType? keyboardType,
  }) {
    return TextField(
      controller: controller,
      obscureText: obscure,
      keyboardType: keyboardType,
      decoration: InputDecoration(
        labelText: label,
        labelStyle: const TextStyle(
          color: AppColors.loginMainTextColor,
          fontFamily: 'Candal',
          fontWeight: FontWeight.bold,
        ),
        filled: true,
        fillColor: Colors.white,
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(12)),
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
    );
  }

  Widget _sectionTitle(String title) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 4.0),
      child: Text(
        title,
        style: const TextStyle(
          fontFamily: 'Candal',
          fontWeight: FontWeight.bold,
          fontSize: 14,
          color: AppColors.loginMainTextColor,
        ),
      ),
    );
  }

  // Step 1: Role selector (three choices)
  Widget _buildRoleStep() {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.stretch,
      children: [
        _sectionTitle('Kérjük, válaszd ki a szereped!'),
        const SizedBox(height: 8),
        Wrap(
          spacing: 16,
          runSpacing: 16,
          children: [
            _roleCard(
              title: 'Egyszerű felhasználó',
              description:
                  'Jegyzetek böngészése és megosztása. Követhetsz felhasználókat, tantárgyakat, és beállíthatod az alappreferenciáidat.',
              icon: Icons.person_outline,
              type: UserType.simple,
            ),
            _roleCard(
              title: 'Diák',
              description:
                  'Tanult tárgyaid és évfolyam megadása a jobb ajánlásokért. Jegyzetek olvasása és megosztása, oktatók és tárgyak követése.',
              icon: Icons.school_outlined,
              type: UserType.student,
            ),
            _roleCard(
              title: 'Oktató',
              description:
                  'Intézmény és tanított tárgyak megadása. Jegyzetek létrehozása és megosztása, kiemelt oktatói tartalmak előtérbe helyezése.',
              icon: Icons.menu_book_outlined,
              type: UserType.instructor,
            ),
          ],
        ),
        const SizedBox(height: 8),
        Text(
          'A választásod alapján később külön mezők jelennek meg.',
          style: TextStyle(
            color: AppColors.loginMainTextColor.withValues(alpha: 0.8),
            fontFamily: 'Candal',
            fontSize: 12,
            fontWeight: FontWeight.bold,
          ),
        ),
      ],
    );
  }

  Widget _roleCard({
    required String title,
    required String description,
    required IconData icon,
    required UserType type,
  }) {
    final bool selected = _userType == type;
    return SizedBox(
      width: 340,
      child: InkWell(
        borderRadius: BorderRadius.circular(16),
        onTap: () {
          setState(() {
            _userType = type;
            _selectedSubjects.clear();
          });
          // Auto-advance to next step for a smoother flow
          if (_currentStep == 0) {
            Future.delayed(const Duration(milliseconds: 150), _goNext);
          }
        },
        child: AnimatedContainer(
          duration: const Duration(milliseconds: 200),
          padding: const EdgeInsets.symmetric(vertical: 16, horizontal: 14),
          decoration: BoxDecoration(
      color: selected
        ? AppColors.loginMainTextColor.withValues(alpha: 0.06)
        : Colors.white,
            borderRadius: BorderRadius.circular(16),
            border: Border.all(
              color: selected ? AppColors.loginMainTextColor : Colors.grey.shade300,
              width: selected ? 2 : 1,
            ),
            boxShadow: const [
              BoxShadow(
                color: Colors.black12,
                blurRadius: 10,
                offset: Offset(0, 4),
              )
            ],
          ),
          child: Row(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Container(
                width: 48,
                height: 48,
                decoration: BoxDecoration(
                  color: selected ? AppColors.loginMainTextColor : Colors.grey.shade200,
                  shape: BoxShape.circle,
                ),
                child: Icon(
                  icon,
                  color: selected ? Colors.white : AppColors.loginMainTextColor,
                  size: 24,
                ),
              ),
              const SizedBox(width: 14),
              Expanded(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      title,
                      style: const TextStyle(
                        fontFamily: 'Candal',
                        fontWeight: FontWeight.bold,
                        color: AppColors.loginMainTextColor,
                        fontSize: 14,
                      ),
                    ),
                    const SizedBox(height: 6),
                    Text(
                      description,
                      softWrap: true,
                      maxLines: 4,
                      overflow: TextOverflow.fade,
                      style: TextStyle(
                        fontFamily: 'Candal',
                        fontWeight: FontWeight.bold,
                        color: AppColors.loginMainTextColor.withValues(alpha: 0.75),
                        fontSize: 12,
                        height: 1.25,
                      ),
                    ),
                  ],
                ),
              ),
              const SizedBox(width: 8),
              AnimatedOpacity(
                opacity: selected ? 1 : 0,
                duration: const Duration(milliseconds: 200),
                child: Icon(Icons.check_circle, color: AppColors.loginMainTextColor),
              ),
            ],
          ),
        ),
      ),
    );
  }

  // Step 2: Account info
  Widget _buildAccountStep() {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.stretch,
      children: [
        _sectionTitle('Fiók adatok'),
        const SizedBox(height: 6),
        Row(
          children: [
            Expanded(
              child: _inputField(
                label: 'Felhasználónév',
                controller: _usernameController,
              ),
            ),
            const SizedBox(width: 12),
            Expanded(
              child: _inputField(
                label: 'Név',
                controller: _nameController,
              ),
            ),
          ],
        ),
        const SizedBox(height: 8),
        _inputField(
          label: 'Email',
          controller: _emailController,
          keyboardType: TextInputType.emailAddress,
        ),
        const SizedBox(height: 8),
        Row(
          children: [
            Expanded(
              child: _inputField(
                label: 'Jelszó',
                controller: _passwordController,
                obscure: true,
              ),
            ),
            const SizedBox(width: 12),
            Expanded(
              child: _inputField(
                label: 'Jelszó megerősítése',
                controller: _confirmPasswordController,
                obscure: true,
              ),
            ),
          ],
        ),
      ],
    );
  }

  // Step 3: Institution (+ grade for students)
  Widget _buildInstitutionStep() {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.stretch,
      children: [
        _sectionTitle('Intézmény'),
        if (_userType == UserType.student || _userType == UserType.instructor) ...[
          DropdownButtonFormField<String>(
            initialValue: _selectedInstitution,
            hint: const Text(
              'Válassz intézményt',
              style: TextStyle(
                color: AppColors.loginMainTextColor,
                fontFamily: 'Candal',
                fontWeight: FontWeight.bold,
              ),
            ),
            decoration: InputDecoration(
              filled: true,
              fillColor: Colors.white,
              border: OutlineInputBorder(borderRadius: BorderRadius.circular(12)),
              contentPadding: const EdgeInsets.symmetric(horizontal: 12, vertical: 6),
            ),
            dropdownColor: Colors.white,
            iconEnabledColor: AppColors.loginMainTextColor,
            style: const TextStyle(
              color: AppColors.loginMainTextColor,
              fontFamily: 'Candal',
              fontWeight: FontWeight.bold,
            ),
            items: _institutions
                .map((e) => DropdownMenuItem<String>(value: e, child: Text(e)))
                .toList(),
            onChanged: (val) => setState(() => _selectedInstitution = val),
          ),
          const SizedBox(height: 8),
        ],
        if (_userType == UserType.student) ...[
          _inputField(
            label: 'Osztály/Évfolyam',
            controller: _gradeController,
          ),
        ],
        if (_userType == UserType.simple)
          Text(
            'Egyszerű felhasználóként nincs szükség intézmény kiválasztására.',
            style: TextStyle(
              color: AppColors.loginMainTextColor.withValues(alpha: 0.8),
              fontFamily: 'Candal',
              fontSize: 12,
              fontWeight: FontWeight.bold,
            ),
          ),
        if (_userType == null)
          Text(
            'Először válaszd ki a szereped a következő lépéshez.',
            style: TextStyle(
              color: AppColors.loginMainTextColor.withValues(alpha: 0.8),
              fontFamily: 'Candal',
              fontSize: 12,
              fontWeight: FontWeight.bold,
            ),
          ),
      ],
    );
  }

  // Step 4: Subjects (only for student/instructor)
  Widget _buildSubjectsStep() {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        _sectionTitle(_userType == UserType.instructor
            ? 'Tanított tantárgyak'
            : 'Tanult tantárgyak'),
        DecoratedBox(
          decoration: BoxDecoration(
            color: Colors.white,
            borderRadius: BorderRadius.circular(12),
            border: Border.all(color: Colors.black12),
          ),
          child: Padding(
            padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
            child: Wrap(
              spacing: 8,
              runSpacing: 8,
              children: _subjects.map((s) {
                final selected = _selectedSubjects.contains(s);
                return FilterChip(
                  label: Text(
                    s,
                    style: TextStyle(
                      fontFamily: 'Candal',
                      fontWeight: FontWeight.bold,
                      color: selected
                          ? Colors.white
                          : AppColors.loginMainTextColor,
                    ),
                  ),
                  selected: selected,
                  selectedColor: AppColors.loginMainTextColor,
                  checkmarkColor: Colors.white,
                  backgroundColor: Colors.white,
                  side: BorderSide(color: Colors.grey.shade300),
                  onSelected: (_) {
                    setState(() {
                      if (selected) {
                        _selectedSubjects.remove(s);
                      } else {
                        _selectedSubjects.add(s);
                      }
                    });
                  },
                );
              }).toList(),
            ),
          ),
        ),
      ],
    );
  }

  // Step 5: Preferences
  Widget _buildPreferencesStep() {
    TextStyle titleStyle = const TextStyle(
      fontFamily: 'Candal',
      fontWeight: FontWeight.bold,
      color: AppColors.loginMainTextColor,
      fontSize: 13,
    );

    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        _sectionTitle('Beállítások (Preferenciák)'),
        Container(
          decoration: BoxDecoration(
            color: Colors.white,
            borderRadius: BorderRadius.circular(12),
            border: Border.all(color: Colors.black12),
          ),
          child: Column(
            children: [
              SwitchListTile(
                dense: true,
                title: Text('Saját intézmény előnyben', style: titleStyle),
                value: prioritiseUsersFromInstitution,
                onChanged: (v) => setState(() => prioritiseUsersFromInstitution = v),
                thumbColor: WidgetStateProperty.resolveWith((states) {
                  if (states.contains(WidgetState.selected)) {
                    return AppColors.loginMainTextColor;
                  }
                  return Colors.grey.shade400;
                }),
                trackColor: WidgetStateProperty.resolveWith((states) {
                  if (states.contains(WidgetState.selected)) {
                    return AppColors.loginMainTextColor.withValues(alpha: 0.5);
                  }
                  return Colors.grey.shade300;
                }),
              ),
              Divider(height: 1, color: Colors.grey.shade300),
              SwitchListTile(
                dense: true,
                title: Text('Oktatói jegyzetek előnyben', style: titleStyle),
                value: prioritiseInstructorNotes,
                onChanged: (v) => setState(() => prioritiseInstructorNotes = v),
                thumbColor: WidgetStateProperty.resolveWith((states) {
                  if (states.contains(WidgetState.selected)) {
                    return AppColors.loginMainTextColor;
                  }
                  return Colors.grey.shade400;
                }),
                trackColor: WidgetStateProperty.resolveWith((states) {
                  if (states.contains(WidgetState.selected)) {
                    return AppColors.loginMainTextColor.withValues(alpha: 0.5);
                  }
                  return Colors.grey.shade300;
                }),
              ),
              Divider(height: 1, color: Colors.grey.shade300),
              SwitchListTile(
                dense: true,
                title: Text('Saját jegyzetek privát', style: titleStyle),
                value: privateMyNotes,
                onChanged: (v) => setState(() => privateMyNotes = v),
                thumbColor: WidgetStateProperty.resolveWith((states) {
                  if (states.contains(WidgetState.selected)) {
                    return AppColors.loginMainTextColor;
                  }
                  return Colors.grey.shade400;
                }),
                trackColor: WidgetStateProperty.resolveWith((states) {
                  if (states.contains(WidgetState.selected)) {
                    return AppColors.loginMainTextColor.withValues(alpha: 0.5);
                  }
                  return Colors.grey.shade300;
                }),
              ),
              Divider(height: 1, color: Colors.grey.shade300),
              SwitchListTile(
                dense: true,
                title: Text('Magasan értékelt jegyzetek előnyben', style: titleStyle),
                value: prioritiseRatedNotes,
                onChanged: (v) => setState(() => prioritiseRatedNotes = v),
                thumbColor: WidgetStateProperty.resolveWith((states) {
                  if (states.contains(WidgetState.selected)) {
                    return AppColors.loginMainTextColor;
                  }
                  return Colors.grey.shade400;
                }),
                trackColor: WidgetStateProperty.resolveWith((states) {
                  if (states.contains(WidgetState.selected)) {
                    return AppColors.loginMainTextColor.withValues(alpha: 0.5);
                  }
                  return Colors.grey.shade300;
                }),
              ),
              Divider(height: 1, color: Colors.grey.shade300),
              SwitchListTile(
                dense: true,
                title: Text('Követett felhasználók előnyben', style: titleStyle),
                value: prioritiseFollowedUsers,
                onChanged: (v) => setState(() => prioritiseFollowedUsers = v),
                thumbColor: WidgetStateProperty.resolveWith((states) {
                  if (states.contains(WidgetState.selected)) {
                    return AppColors.loginMainTextColor;
                  }
                  return Colors.grey.shade400;
                }),
                trackColor: WidgetStateProperty.resolveWith((states) {
                  if (states.contains(WidgetState.selected)) {
                    return AppColors.loginMainTextColor.withValues(alpha: 0.5);
                  }
                  return Colors.grey.shade300;
                }),
              ),
            ],
          ),
        ),
      ],
    );
  }

  // Step 6: Summary (design-only mapping to backend model)
  Widget _buildSummaryStep() {
    final roleLabel = _userType == null
        ? 'Nincs kiválasztva'
        : _userType == UserType.simple
            ? 'Egyszerű felhasználó'
            : _userType == UserType.student
                ? 'Diák'
                : 'Oktató';

    Widget row(String label, String value) {
      return Padding(
        padding: const EdgeInsets.symmetric(vertical: 6.0),
        child: Row(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            SizedBox(
              width: 150,
              child: Text(
                label,
                style: const TextStyle(
                  fontFamily: 'Candal',
                  fontWeight: FontWeight.bold,
                  fontSize: 12,
                  color: AppColors.loginMainTextColor,
                ),
              ),
            ),
            Expanded(
              child: Text(
                value.isEmpty ? '—' : value,
                style: TextStyle(
                  fontFamily: 'Candal',
                  fontWeight: FontWeight.bold,
                  fontSize: 12,
                  color: AppColors.loginMainTextColor.withValues(alpha: 0.85),
                ),
              ),
            ),
          ],
        ),
      );
    }

    return Column(
      crossAxisAlignment: CrossAxisAlignment.stretch,
      children: [
        _sectionTitle('Összegzés – Ellenőrizd az adataid'),
        const SizedBox(height: 4),
        Container(
          decoration: BoxDecoration(
            color: Colors.white,
            borderRadius: BorderRadius.circular(16),
            border: Border.all(color: Colors.black12),
          ),
          padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 12),
          child: Column(
            children: [
              row('Szerep', roleLabel),
              row('Felhasználónév', _usernameController.text.trim()),
              row('Név', _nameController.text.trim()),
              row('Email', _emailController.text.trim()),
              if (_userType == UserType.student || _userType == UserType.instructor)
                row('Intézmény', _selectedInstitution ?? ''),
              if (_userType == UserType.student)
                row('Évfolyam', _gradeController.text.trim()),
              if (_userType == UserType.student || _userType == UserType.instructor)
                row(
                  _userType == UserType.instructor ? 'Tanított tárgyak' : 'Tanult tárgyak',
                  _selectedSubjects.isEmpty
                      ? ''
                      : _selectedSubjects.join(', '),
                ),
              row(
                'Preferencia: Intézmény',
                prioritiseUsersFromInstitution ? 'Igen' : 'Nem',
              ),
              row(
                'Preferencia: Oktatói jegyzetek',
                prioritiseInstructorNotes ? 'Igen' : 'Nem',
              ),
              row(
                'Preferencia: Privát jegyzetek',
                privateMyNotes ? 'Igen' : 'Nem',
              ),
              row(
                'Preferencia: Értékelt jegyzetek',
                prioritiseRatedNotes ? 'Igen' : 'Nem',
              ),
              row(
                'Preferencia: Követettek előnyben',
                prioritiseFollowedUsers ? 'Igen' : 'Nem',
              ),
            ],
          ),
        ),
        const SizedBox(height: 16),
        Text(
          'Megjegyzés: a jelszó a szerveren kerül majd hash-elésre. A követések (UserFollows) és tantárgyak az első bejelentkezés után finomíthatók.',
          style: TextStyle(
            fontFamily: 'Candal',
            fontWeight: FontWeight.bold,
            fontSize: 11,
            height: 1.25,
            color: AppColors.loginMainTextColor.withValues(alpha: 0.7),
          ),
        ),
      ],
    );
  }

  // Nav helpers
  void _goNext() {
    final steps = _steps;
    if (_currentStep < steps.length - 1) {
      setState(() => _currentStep++);
    } else {
      // Show info notification for unimplemented registration logic
      final svc = NotificationProvider.of(context);
      svc.show(
        title: 'Regisztráció',
        message: 'A regisztráció funkció még nincs implementálva.',
        type: AppNotificationType.info,
        duration: const Duration(seconds: 4),
      );
    }
  }

  void _goBack() {
    if (_currentStep > 0) {
      setState(() => _currentStep--);
    }
  }

  Widget _stepHeader(double boxWidth) {
    final steps = _steps;
    return Column(
      crossAxisAlignment: CrossAxisAlignment.stretch,
      children: [
        Center(
          child: Wrap(
            spacing: 10,
            runSpacing: 10,
            children: [
              for (int i = 0; i < steps.length; i++)
                AnimatedContainer(
                  duration: const Duration(milliseconds: 200),
                  width: i == _currentStep ? 12 : 10,
                  height: i == _currentStep ? 12 : 10,
                  decoration: BoxDecoration(
                    color: i == _currentStep
                        ? AppColors.loginMainTextColor
                        : Colors.white,
                    shape: BoxShape.circle,
                    border: Border.all(
                      color: i == _currentStep
                          ? AppColors.loginMainTextColor
                          : Colors.grey.shade400,
                      width: 2,
                    ),
                    boxShadow: const [
                      BoxShadow(
                        color: Colors.black12,
                        blurRadius: 6,
                        offset: Offset(0, 2),
                      ),
                    ],
                  ),
                ),
            ],
          ),
        ),
        const SizedBox(height: 12),
      ],
    );
  }

  @override
  Widget build(BuildContext context) {
    final size = MediaQuery.of(context).size;
    final boxWidth = size.width * 0.95 > 800 ? 800.0 : size.width * 0.95;
    final titleFontSize = (boxWidth * 0.08).clamp(26.0, 48.0);
    final titleTop = -titleFontSize * 0.7;

    return Scaffold(
      body: Stack(
        children: [
          Positioned.fill(
            child: Image(
              image: const AssetImage('assets/images/NoteShareBackground.png'),
              fit: BoxFit.cover,
            ),
          ),
          Center(
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                SizedBox(
                  width: boxWidth,
                  child: Stack(
                    clipBehavior: Clip.none,
                    alignment: Alignment.topCenter,
                    children: [
                      DecoratedBox(
                        decoration: BoxDecoration(
                          color: AppColors.loginBoxBackgroundColor,
                          borderRadius: const BorderRadius.all(
                            Radius.circular(24),
                          ),
                          boxShadow: const [
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
                            crossAxisAlignment: CrossAxisAlignment.stretch,
                            children: [
                              _stepHeader(boxWidth),
                              AnimatedSwitcher(
                                duration: const Duration(milliseconds: 200),
                                child: SingleChildScrollView(
                                  key: ValueKey<int>(_currentStep),
                                  child: _steps[_currentStep].builder(),
                                ),
                              ),
                              const SizedBox(height: 12),
                              Row(
                                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                                children: [
                                  TextButton(
                                    onPressed: _currentStep == 0 ? null : _goBack,
                                    style: TextButton.styleFrom(
                                      foregroundColor: AppColors.loginMainTextColor,
                                    ),
                                    child: const Text(
                                      'Vissza',
                                      style: TextStyle(
                                        fontFamily: 'Candal',
                                        fontWeight: FontWeight.bold,
                                      ),
                                    ),
                                  ),
                                  SizedBox(
                                    width: 200,
                                    child: ElevatedButton(
                    onPressed: (_currentStep == 0 && _userType == null)
                      ? null
                      : _goNext,
                                      style: ElevatedButton.styleFrom(
                                        padding: const EdgeInsets.symmetric(vertical: 12),
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
                                      child: Text(
                                        _currentStep == _steps.length - 1
                                            ? 'Regisztráció'
                                            : 'Következő',
                                        style: const TextStyle(color: Colors.white),
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
                                  shadows: const [
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
                const SizedBox(height: 24),
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
                      padding: const EdgeInsets.symmetric(
                        horizontal: 12.0,
                        vertical: 12.0,
                      ),
                      child: Row(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          const Text(
                            'Már van fiókod? ',
                            style: TextStyle(
                              fontFamily: 'Candal',
                              fontWeight: FontWeight.bold,
                              fontSize: 12,
                              color: AppColors.loginMainTextColor,
                            ),
                          ),
                          TextButton(
                            onPressed: () => Navigator.of(context).pop(),
                            style: TextButton.styleFrom(
                              foregroundColor: Colors.blue,
                              padding: EdgeInsets.zero,
                              minimumSize: Size.zero,
                              tapTargetSize: MaterialTapTargetSize.shrinkWrap,
                            ),
                            child: const Text(
                              'Jelentkezz be!',
                              style: TextStyle(
                                fontFamily: 'Candal',
                                fontWeight: FontWeight.bold,
                                fontSize: 12,
                                color: Colors.blue,
                                decoration: TextDecoration.underline,
                              ),
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

// Removed numbered/text step badges per request – using simple dot indicators instead.
