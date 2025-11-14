import 'package:flutter/material.dart';
import 'package:notesharing_ui/application/configs/app_colors.dart';

class NoteUploadPage extends StatefulWidget {
  const NoteUploadPage({super.key});

  @override
  State<NoteUploadPage> createState() => _NoteUploadPageState();
}

class _NoteUploadPageState extends State<NoteUploadPage> {
  final _formKey = GlobalKey<FormState>();
  final _titleController = TextEditingController();
  final _descriptionController = TextEditingController();
  final _contentController = TextEditingController();
  
  String _selectedSubject = 'Matematika';
  String _selectedInstitution = 'Eötvös Loránd Tudományegyetem';
  bool _isPrivate = false;
  bool _isUploading = false;

  final List<String> _subjects = [
    'Matematika',
    'Fizika',
    'Kémia',
    'Biológia',
    'Történelem',
    'Irodalom',
    'Angol',
    'Francia',
    'Német',
    'Számítástechnika',
  ];

  final List<String> _institutions = [
    'Eötvös Loránd Tudományegyetem',
    'Budapesti Műszaki és Gazdaságtudományi Egyetem',
    'Szegedi Tudományegyetem',
    'Debreceni Egyetem',
    'Pécsi Tudományegyetem',
  ];

  @override
  void dispose() {
    _titleController.dispose();
    _descriptionController.dispose();
    _contentController.dispose();
    super.dispose();
  }

  Widget _inputField({
    required String label,
    TextEditingController? controller,
    int maxLines = 1,
    String? Function(String?)? validator,
  }) {
    return TextFormField(
      controller: controller,
      maxLines: maxLines,
      decoration: InputDecoration(
        labelText: label,
        labelStyle: const TextStyle(
          color: AppColors.loginMainTextColor,
          fontFamily: 'Candal',
          fontWeight: FontWeight.bold,
          fontSize: 12,
        ),
        filled: true,
        fillColor: Colors.white,
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(12)),
        contentPadding: const EdgeInsets.symmetric(
          horizontal: 16,
          vertical: 14,
        ),
      ),
      style: const TextStyle(
        color: AppColors.loginMainTextColor,
        fontFamily: 'Candal',
        fontWeight: FontWeight.bold,
        fontSize: 13,
      ),
      validator: validator,
    );
  }

  Future<void> _uploadNote() async {
    if (!_formKey.currentState!.validate()) {
      return;
    }

    setState(() => _isUploading = true);

    try {
      await Future.delayed(const Duration(seconds: 2));

      if (!mounted) return;

      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(
          content: Text('Jegyzet sikeresen feltöltve'),
          duration: Duration(seconds: 2),
        ),
      );

      Navigator.of(context).pop();
    } catch (e) {
      if (!mounted) return;
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Hiba a feltöltés során: $e'),
          duration: const Duration(seconds: 3),
        ),
      );
    } finally {
      if (mounted) {
        setState(() => _isUploading = false);
      }
    }
  }

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
                                'Jegyzet Feltöltés',
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
                      // Form card
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
                            padding: const EdgeInsets.all(24.0),
                            child: Form(
                              key: _formKey,
                              child: Column(
                                crossAxisAlignment: CrossAxisAlignment.stretch,
                                children: [
                                  _inputField(
                                    label: 'Jegyzet Címe',
                                    controller: _titleController,
                                    validator: (value) {
                                      if (value?.isEmpty ?? true) {
                                        return 'A cím megadása kötelező';
                                      }
                                      if (value!.length < 5) {
                                        return 'Legalább 5 karakter';
                                      }
                                      return null;
                                    },
                                  ),
                                  const SizedBox(height: 12),
                                  _inputField(
                                    label: 'Rövid Leírás',
                                    controller: _descriptionController,
                                    maxLines: 3,
                                    validator: (value) {
                                      if (value?.isEmpty ?? true) {
                                        return 'A leírás megadása kötelező';
                                      }
                                      return null;
                                    },
                                  ),
                                  const SizedBox(height: 12),
                                  _inputField(
                                    label: 'Jegyzet Tartalma',
                                    controller: _contentController,
                                    maxLines: 8,
                                    validator: (value) {
                                      if (value?.isEmpty ?? true) {
                                        return 'A tartalom megadása kötelező';
                                      }
                                      if (value!.length < 20) {
                                        return 'Legalább 20 karakter';
                                      }
                                      return null;
                                    },
                                  ),
                                  const SizedBox(height: 12),
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
                                        value: _selectedSubject,
                                        isExpanded: true,
                                        isDense: true,
                                        items: _subjects.map((subject) {
                                          return DropdownMenuItem(
                                            value: subject,
                                            child: Padding(
                                              padding: const EdgeInsets.symmetric(horizontal: 12.0),
                                              child: Text(
                                                subject,
                                                style: const TextStyle(
                                                  fontFamily: 'Candal',
                                                  fontWeight: FontWeight.bold,
                                                  fontSize: 13,
                                                  color: AppColors.loginMainTextColor,
                                                ),
                                              ),
                                            ),
                                          );
                                        }).toList(),
                                        onChanged: (value) {
                                          setState(() => _selectedSubject = value ?? 'Matematika');
                                        },
                                      ),
                                    ),
                                  ),
                                  const SizedBox(height: 12),
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
                                        value: _selectedInstitution,
                                        isExpanded: true,
                                        isDense: true,
                                        items: _institutions.map((institution) {
                                          return DropdownMenuItem(
                                            value: institution,
                                            child: Padding(
                                              padding: const EdgeInsets.symmetric(horizontal: 12.0),
                                              child: Text(
                                                institution,
                                                style: const TextStyle(
                                                  fontFamily: 'Candal',
                                                  fontWeight: FontWeight.bold,
                                                  fontSize: 13,
                                                  color: AppColors.loginMainTextColor,
                                                ),
                                              ),
                                            ),
                                          );
                                        }).toList(),
                                        onChanged: (value) {
                                          setState(() => _selectedInstitution = value ?? 'Eötvös Loránd Tudományegyetem');
                                        },
                                      ),
                                    ),
                                  ),
                                  const SizedBox(height: 12),
                                  InkWell(
                                    onTap: () {
                                      setState(() => _isPrivate = !_isPrivate);
                                    },
                                    child: Row(
                                      children: [
                                        Checkbox(
                                          value: _isPrivate,
                                          onChanged: (value) {
                                            setState(() => _isPrivate = value ?? false);
                                          },
                                          activeColor: AppColors.loginMainTextColor,
                                        ),
                                        const Expanded(
                                          child: Text(
                                            'Saját Jegyzet (csak számomra látható)',
                                            style: TextStyle(
                                              fontFamily: 'Candal',
                                              fontWeight: FontWeight.bold,
                                              fontSize: 12,
                                              color: AppColors.loginMainTextColor,
                                            ),
                                          ),
                                        ),
                                      ],
                                    ),
                                  ),
                                  const SizedBox(height: 20),
                                  ElevatedButton(
                                    onPressed: _isUploading ? null : _uploadNote,
                                    style: ElevatedButton.styleFrom(
                                      backgroundColor: AppColors.loginMainTextColor,
                                      padding: const EdgeInsets.symmetric(vertical: 14),
                                      shape: RoundedRectangleBorder(
                                        borderRadius: BorderRadius.circular(12),
                                      ),
                                    ),
                                    child: _isUploading
                                        ? const SizedBox(
                                            height: 20,
                                            width: 20,
                                            child: CircularProgressIndicator(
                                              strokeWidth: 2,
                                              valueColor: AlwaysStoppedAnimation<Color>(
                                                Colors.white,
                                              ),
                                            ),
                                          )
                                        : const Text(
                                            'Feltöltés',
                                            style: TextStyle(
                                              fontFamily: 'Candal',
                                              fontWeight: FontWeight.bold,
                                              color: Colors.white,
                                            ),
                                          ),
                                  ),
                                ],
                              ),
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
