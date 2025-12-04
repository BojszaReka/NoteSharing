import 'package:flutter/material.dart';
import 'package:notesharing_ui/application/configs/app_colors.dart';
import 'package:notesharing_ui/common/services/mock_auth_service.dart';
import 'package:notesharing_ui/features/preferences/preferences_page.dart';
import 'package:notesharing_ui/features/note_upload/note_upload_page.dart';
import 'package:notesharing_ui/features/note_detail/note_detail_page.dart';
import 'package:notesharing_ui/features/profile/profile_page.dart';

class MainPage extends StatefulWidget {
  const MainPage({super.key});

  @override
  State<MainPage> createState() => _MainPageState();
}

class _MainPageState extends State<MainPage> {
  final _authService = MockAuthService();
  late Map<String, String?> _userData;
  bool _isLoading = true;
  int? _expandedIndex;
  final ScrollController _scrollController = ScrollController();
  double _scrollOffset = 0;

  // Mock notes created by the user
  late List<_MockNote> _myNotes;

  @override
  void initState() {
    super.initState();
    _myNotes = []; // Initialize empty first
    _loadUserData();
    _scrollController.addListener(() {
      final o = _scrollController.offset;
      if ((o - _scrollOffset).abs() > 1) {
        setState(() => _scrollOffset = o);
      }
    });
  }

  void _initializeMockNotes() {
    _myNotes = [
      _MockNote(
        id: '1',
        title: 'Differenciálszámítás Alapjai',
        author: _userData['name'] ?? 'Én',
        subject: 'Matematika',
        minutesAgo: 45,
        score: 12,
        userVote: 0,
        preview: 'Alapvető deriválási szabályok és alkalmazásai...',
        description: 'Részletes leírás a differenciálszámítás alapvető fogalmairól, a derivált definíciójáról, és a legfontosabb deriválási szabályokról. Tartalmazható gyakorlati példák és megoldások.',
        imageUrls: [],
        institution: 'ELTE',
        isStudent: true,
        isOwn: true,
      ),
      _MockNote(
        id: '2',
        title: 'Integrálszámítás - Határozatlan Integrál',
        author: _userData['name'] ?? 'Én',
        subject: 'Matematika',
        minutesAgo: 120,
        score: 8,
        userVote: 0,
        preview: 'Az antiderivált fogalma és a határozatlan integrál...',
        description: 'Megismerkedünk az integrálszámítás alapjaival, az antiderivált fogalmával és a határozatlan integrál tulajdonságaival. Részletesen tárgyaljuk az alapvető integrálási szabályokat.',
        imageUrls: [],
        institution: 'ELTE',
        isStudent: true,
        isOwn: true,
      ),
      _MockNote(
        id: '3',
        title: 'Fizika - Mechanika Alapok',
        author: _userData['name'] ?? 'Én',
        subject: 'Fizika',
        minutesAgo: 240,
        score: 15,
        userVote: 0,
        preview: 'Kinematika és dinamika alapelvei...',
        description: 'Részletes magyarázat a klasszikus mechanika alapelveiről, beleértve a kinematikát, dinamikát, erőket és mozgásokat. Sok gyakorlati feladat megoldásával.',
        imageUrls: [],
        institution: 'ELTE',
        isStudent: true,
        isOwn: true,
      ),
    ];
  }

  Future<void> _loadUserData() async {
    final userData = await _authService.getCurrentUser();
    if (!mounted) return;
    setState(() {
      _userData = userData;
      _initializeMockNotes();
      _isLoading = false;
    });
  }

  Future<void> _logout() async {
    await _authService.logout();
    if (!mounted) return;
    Navigator.of(context).pushReplacementNamed('/login');
  }

  void _toggleExpand(int index) {
    setState(() {
      _expandedIndex = (_expandedIndex == index) ? null : index;
    });
  }

  void _vote(int index, int delta) {
    setState(() {
      final current = _myNotes[index];
      int newScore = current.score;
      int newVote;
      if (current.userVote == delta) {
        newScore -= delta;
        newVote = 0;
      } else {
        if (current.userVote != 0) {
          newScore -= current.userVote;
        }
        newVote = delta;
        newScore += delta;
      }
      _myNotes[index] = current.copyWith(score: newScore, userVote: newVote);
    });
  }

  @override
  void dispose() {
    _scrollController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    if (_isLoading) {
      return Scaffold(
        body: Stack(
          children: [
            Positioned.fill(
              child: Image(
                image: const AssetImage('assets/images/NoteShareBackground.png'),
                fit: BoxFit.cover,
              ),
            ),
            const Center(
              child: CircularProgressIndicator(),
            ),
          ],
        ),
      );
    }

    return Scaffold(
      body: Stack(
        children: [
          Positioned.fill(
            child: Image(
              image: const AssetImage('assets/images/NoteShareBackground.png'),
              fit: BoxFit.cover,
            ),
          ),
          CustomScrollView(
            controller: _scrollController,
            slivers: [
              SliverAppBar(
                floating: true,
                snap: true,
                elevation: 0,
                backgroundColor: Colors.transparent,
                flexibleSpace: Padding(
                  padding: const EdgeInsets.fromLTRB(16, 12, 16, 0),
                  child: SafeArea(
                    child: Row(
                      children: [
                        Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          mainAxisSize: MainAxisSize.min,
                          children: [
                            Text(
                              'Saját Jegyzetek',
                              style: const TextStyle(
                                fontFamily: 'Candal',
                                fontWeight: FontWeight.bold,
                                fontSize: 22,
                                color: AppColors.loginMainTextColor,
                              ),
                            ),
                            Text(
                              _userData['name'] ?? 'Felhasználó',
                              style: TextStyle(
                                fontFamily: 'Candal',
                                fontWeight: FontWeight.bold,
                                fontSize: 12,
                                color: AppColors.loginMainTextColor.withOpacity(0.6),
                              ),
                            ),
                          ],
                        ),
                        const Spacer(),
                        IconButton(
                          tooltip: 'Beállítások',
                          onPressed: () {
                            Navigator.of(context).push(
                              MaterialPageRoute(
                                builder: (_) => const PreferencesPage(),
                              ),
                            );
                          },
                          icon: const Icon(Icons.settings, color: AppColors.loginMainTextColor),
                        ),
                        IconButton(
                          tooltip: 'Kijelentkezés',
                          onPressed: _logout,
                          icon: const Icon(Icons.logout, color: AppColors.loginMainTextColor),
                        ),
                      ],
                    ),
                  ),
                ),
              ),
              SliverPadding(
                padding: const EdgeInsets.fromLTRB(16, 8, 16, 90),
                sliver: SliverList.builder(
                  itemCount: _myNotes.length,
                  itemBuilder: (context, index) => _noteCard(_myNotes[index], index),
                ),
              ),
            ],
          ),
        ],
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          Navigator.of(context).push(
            MaterialPageRoute(
              builder: (_) => const NoteUploadPage(),
            ),
          ).then((_) {
            // Refresh notes after upload
            setState(() {});
          });
        },
        backgroundColor: AppColors.loginMainTextColor,
        shape: const CircleBorder(),
        child: const Icon(Icons.add, size: 28, color: Colors.white),
      ),
    );
  }

  Widget _noteCard(_MockNote note, int index) {
    final expanded = _expandedIndex == index;
    return Container(
      margin: const EdgeInsets.only(bottom: 16),
      decoration: BoxDecoration(
        color: AppColors.loginBoxBackgroundColor,
        borderRadius: BorderRadius.circular(20),
        boxShadow: const [
          BoxShadow(
            color: Colors.black12,
            blurRadius: 14,
            offset: Offset(0, 6),
          ),
        ],
        border: Border.all(color: Colors.black12),
      ),
      child: InkWell(
        borderRadius: BorderRadius.circular(20),
        onTap: () {
          if (!expanded) {
            Navigator.of(context).push(
              MaterialPageRoute(
                builder: (_) => NoteDetailPage(
                  noteId: note.id,
                  title: note.title,
                  author: note.author,
                  authorId: '1',
                  subject: note.subject,
                  institution: note.institution ?? 'ELTE',
                  score: note.score,
                  preview: note.preview,
                  content: note.description,
                  minutesAgo: note.minutesAgo,
                ),
              ),
            );
          } else {
            _toggleExpand(index);
          }
        },
        child: AnimatedSize(
          duration: const Duration(milliseconds: 220),
          curve: Curves.easeInOut,
          child: Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 14),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Row(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    // Vote column
                    Column(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        _voteButton(
                          icon: Icons.arrow_upward,
                          active: note.userVote == 1,
                          onTap: () => _vote(index, 1),
                        ),
                        const SizedBox(height: 2),
                        AnimatedSwitcher(
                          duration: const Duration(milliseconds: 180),
                          transitionBuilder: (child, anim) => ScaleTransition(
                            scale: CurvedAnimation(parent: anim, curve: Curves.easeOutBack),
                            child: child,
                          ),
                          child: Text(
                            note.score.toString(),
                            key: ValueKey<int>(note.score),
                            style: const TextStyle(
                              fontFamily: 'Candal',
                              fontWeight: FontWeight.bold,
                              fontSize: 12,
                              color: AppColors.loginMainTextColor,
                            ),
                          ),
                        ),
                        const SizedBox(height: 2),
                        _voteButton(
                          icon: Icons.arrow_downward,
                          active: note.userVote == -1,
                          onTap: () => _vote(index, -1),
                        ),
                      ],
                    ),
                    const SizedBox(width: 12),
                    GestureDetector(
                      onTap: () {
                        Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (_) => ProfilePage(
                              userId: '1',
                              userName: note.author,
                              isOwnProfile: note.isOwn,
                            ),
                          ),
                        );
                      },
                      child: CircleAvatar(
                        radius: 20,
                        backgroundColor: AppColors.loginMainTextColor.withOpacity(0.12),
                        child: Text(
                          note.author.substring(0, 1),
                          style: const TextStyle(
                            fontFamily: 'Candal',
                            fontWeight: FontWeight.bold,
                            color: AppColors.loginMainTextColor,
                          ),
                        ),
                      ),
                    ),
                    const SizedBox(width: 12),
                    Expanded(
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Text(
                            note.title,
                            style: const TextStyle(
                              fontFamily: 'Candal',
                              fontWeight: FontWeight.bold,
                              fontSize: 16,
                              color: AppColors.loginMainTextColor,
                            ),
                          ),
                          const SizedBox(height: 4),
                          Wrap(
                            spacing: 10,
                            runSpacing: 4,
                            crossAxisAlignment: WrapCrossAlignment.center,
                            children: [
                              _metaChip(Icons.person_outline, note.author),
                              if (note.isStudent == true && note.institution != null)
                                _filledBadge(Icons.school, note.institution!),
                              if (note.isStudent == true)
                                _filledBadge(Icons.book_outlined, note.subject)
                              else
                                _metaChip(Icons.book_outlined, note.subject),
                              _metaChip(Icons.access_time, '${note.minutesAgo}p'),
                            ],
                          ),
                        ],
                      ),
                    ),
                    Row(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        IconButton(
                          tooltip: 'Szerkesztés',
                          onPressed: () {
                            ScaffoldMessenger.of(context).showSnackBar(
                              const SnackBar(
                                content: Text('Jegyzet szerkesztésének funkciója hamarosan...'),
                                duration: Duration(seconds: 2),
                              ),
                            );
                          },
                          icon: const Icon(Icons.edit, color: AppColors.loginMainTextColor),
                        ),
                        IconButton(
                          tooltip: expanded ? 'Bezárás' : 'Részletek',
                          onPressed: () => _toggleExpand(index),
                          icon: Icon(
                            expanded ? Icons.expand_less : Icons.expand_more,
                            color: AppColors.loginMainTextColor,
                          ),
                        ),
                      ],
                    ),
                  ],
                ),
                const SizedBox(height: 12),
                Text(
                  expanded ? note.description : note.preview,
                  style: TextStyle(
                    fontFamily: 'Candal',
                    fontWeight: FontWeight.bold,
                    height: 1.25,
                    fontSize: 12.5,
                    color: AppColors.loginMainTextColor.withOpacity(0.8),
                  ),
                  maxLines: expanded ? null : 4,
                  overflow: expanded ? TextOverflow.visible : TextOverflow.ellipsis,
                ),
                AnimatedSwitcher(
                  duration: const Duration(milliseconds: 220),
                  switchInCurve: Curves.easeOut,
                  switchOutCurve: Curves.easeIn,
                  transitionBuilder: (child, anim) => FadeTransition(
                    opacity: anim,
                    child: SizeTransition(
                      sizeFactor: anim,
                      axisAlignment: -1,
                      child: child,
                    ),
                  ),
                  child: expanded
                      ? Padding(
                          padding: const EdgeInsets.only(top: 12),
                          child: Wrap(
                            spacing: 8,
                            runSpacing: 6,
                            children: [
                              _infoBadge(Icons.visibility, '${_derivedViews(note.score)} megtekintés'),
                              _infoBadge(Icons.cloud_download_outlined, '${_derivedDownloads(note.score)} letöltés'),
                              _infoBadge(Icons.comment_outlined, '${_derivedComments(note.score)} hozzászólás'),
                            ],
                          ),
                        )
                      : const SizedBox.shrink(),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _metaChip(IconData icon, String text) {
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 4),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(40),
        border: Border.all(color: Colors.black12),
      ),
      child: Row(
        mainAxisSize: MainAxisSize.min,
        children: [
          Icon(icon, size: 14, color: AppColors.loginMainTextColor),
          const SizedBox(width: 4),
          Text(
            text,
            style: const TextStyle(
              fontFamily: 'Candal',
              fontWeight: FontWeight.bold,
              fontSize: 11,
              color: AppColors.loginMainTextColor,
              letterSpacing: 0.25,
            ),
          )
        ],
      ),
    );
  }

  Widget _infoBadge(IconData icon, String text) {
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 6),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(40),
        border: Border.all(color: Colors.black12),
      ),
      child: Row(
        mainAxisSize: MainAxisSize.min,
        children: [
          Icon(icon, size: 14, color: AppColors.loginMainTextColor.withOpacity(0.75)),
          const SizedBox(width: 6),
          Text(
            text,
            style: const TextStyle(
              fontFamily: 'Candal',
              fontWeight: FontWeight.bold,
              fontSize: 11,
              color: AppColors.loginMainTextColor,
              letterSpacing: 0.25,
            ),
          ),
        ],
      ),
    );
  }

  Widget _filledBadge(IconData icon, String text) {
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 6),
      decoration: BoxDecoration(
        color: AppColors.loginMainTextColor.withOpacity(0.10),
        borderRadius: BorderRadius.circular(40),
        border: Border.all(color: AppColors.loginMainTextColor.withOpacity(0.25)),
      ),
      child: Row(
        mainAxisSize: MainAxisSize.min,
        children: [
          Icon(icon, size: 14, color: AppColors.loginMainTextColor),
          const SizedBox(width: 6),
          Text(
            text,
            style: const TextStyle(
              fontFamily: 'Candal',
              fontWeight: FontWeight.bold,
              fontSize: 11,
              color: AppColors.loginMainTextColor,
              letterSpacing: 0.25,
            ),
          ),
        ],
      ),
    );
  }

  Widget _voteButton({required IconData icon, required bool active, required VoidCallback onTap}) {
    return InkWell(
      borderRadius: BorderRadius.circular(10),
      onTap: onTap,
      child: AnimatedScale(
        duration: const Duration(milliseconds: 140),
        scale: active ? 1.15 : 1.0,
        curve: Curves.easeOutBack,
        child: AnimatedContainer(
          duration: const Duration(milliseconds: 180),
          curve: Curves.easeOut,
          padding: const EdgeInsets.all(4),
          decoration: BoxDecoration(
            color: active
                ? AppColors.loginMainTextColor.withOpacity(0.18)
                : AppColors.loginMainTextColor.withOpacity(0.03),
            borderRadius: BorderRadius.circular(10),
            border: Border.all(
              color: active
                  ? AppColors.loginMainTextColor.withOpacity(0.35)
                  : AppColors.loginMainTextColor.withOpacity(0.10),
              width: 1,
            ),
          ),
          child: Icon(
            icon,
            size: 18,
            color: active
                ? AppColors.loginMainTextColor
                : AppColors.loginMainTextColor.withOpacity(0.55),
          ),
        ),
      ),
    );
  }
}

class _MockNote {
  final String id;
  final String title;
  final String author;
  final String subject;
  final int minutesAgo;
  int score;
  int userVote;
  final String preview;
  final List<String> imageUrls;
  final String description;
  final String? institution;
  final bool isStudent;
  final bool isOwn;

  _MockNote({
    required this.id,
    required this.title,
    required this.author,
    required this.subject,
    required this.minutesAgo,
    required this.score,
    required this.userVote,
    required this.preview,
    this.imageUrls = const [],
    this.description = '',
    this.institution,
    this.isStudent = false,
    this.isOwn = false,
  });

  _MockNote copyWith({
    int? score,
    int? userVote,
  }) =>
      _MockNote(
        id: id,
        title: title,
        author: author,
        subject: subject,
        minutesAgo: minutesAgo,
        score: score ?? this.score,
        userVote: userVote ?? this.userVote,
        preview: preview,
        imageUrls: imageUrls,
        description: description,
        institution: institution,
        isStudent: isStudent,
        isOwn: isOwn,
      );
}

int _derivedViews(int score) => (score.abs() * 3) + 120;
int _derivedDownloads(int score) => score.abs() + 10;
int _derivedComments(int score) => ((score % 7).abs()) + 5;
