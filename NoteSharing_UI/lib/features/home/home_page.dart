import 'package:flutter/material.dart';
import 'package:notesharing_ui/application/configs/app_colors.dart';
import 'package:notesharing_ui/common/notifications/notification_service.dart';
import 'package:notesharing_ui/common/notifications/app_notification.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  int _currentIndex = 0; // 0 = Feed, 1 = Search, 2 = Favorites, 3 = Profile
  int? _expandedIndex; // which note is expanded
  // Initialize immediately so hot reload after adding this field doesn't cause LateInitializationError
  final ScrollController _scrollController = ScrollController();
  double _scrollOffset = 0;

  final _mockNotes = List.generate(12, (i) {
    final imageSets = <List<String>>[
      ['https://picsum.photos/seed/a$i/800/400'],
      [
        'https://picsum.photos/seed/b$i/800/400',
        'https://picsum.photos/seed/c$i/800/400'
      ],
      [
        'https://picsum.photos/seed/d$i/800/400',
        'https://picsum.photos/seed/e$i/400/400',
        'https://picsum.photos/seed/f$i/400/400'
      ],
      [], // no images
    ];
    final images = imageSets[i % imageSets.length];
    final institutions = ['BME', 'ELTE', 'Szeged', 'Debrecen'];
    final bool isInstructor = i % 3 == 0; // keep existing pattern
    final String? institution = isInstructor ? null : institutions[i % institutions.length];
    return _MockNote(
      title: 'Jegyzet címe ${i + 1}',
      author: isInstructor ? 'Oktató Péter' : 'Hallgató #${(i % 7) + 1}',
      subject: ['Matematika', 'Fizika', 'Adatbázisok', 'Programozás'][i % 4],
      minutesAgo: (i + 1) * 7,
      score: (i + 1) * 5 - (i % 4) * 2,
      userVote: 0,
      preview: 'Ez egy rövid kivonat a jegyzet tartalmából. A teljes szöveg a jegyzet megnyitásakor érhető el... (mock data)',
      description: 'Részletes leírás a jegyzetről. Tartalmazhat tananyagra vonatkozó strukturált pontokat, fogalmak definícióját, és ajánlott gyakorló feladatokat. Ez csak példa adat a UI demonstrálásához. Index: $i',
      imageUrls: images,
      institution: institution,
      isStudent: !isInstructor,
    );
  });

  @override
  void initState() {
    super.initState();
    _scrollController.addListener(() {
      final o = _scrollController.offset;
      if ((o - _scrollOffset).abs() > 1) {
        setState(() => _scrollOffset = o);
      }
    });
  }

  @override
  void dispose() {
    _scrollController.dispose();
    super.dispose();
  }

  void _showNotImplemented(String feature) {
    final svc = NotificationProvider.of(context);
    svc.show(
      title: feature,
      message: 'Ez a funkció még nincs implementálva.',
      type: AppNotificationType.info,
      duration: const Duration(seconds: 4),
    );
  }

  void _onFabPressed() => _demoNotifications();

  Future<void> _demoNotifications() async {
    final svc = NotificationProvider.of(context);
    svc.show(
      title: 'Információ',
      message: 'Ez egy példa információs értesítés.',
      type: AppNotificationType.info,
      duration: const Duration(seconds: 3),
    );
    await Future.delayed(const Duration(milliseconds: 350));

    svc.show(
      title: 'Siker',
      message: 'A művelet sikeresen végrehajtva.',
      type: AppNotificationType.success,
      duration: const Duration(seconds: 3),
    );
    await Future.delayed(const Duration(milliseconds: 350));

    svc.show(
      title: 'Hiba',
      message: 'Valami hiba történt (példa).',
      type: AppNotificationType.error,
      duration: const Duration(seconds: 4),
    );
  }

  void _onNavTap(int index) {
    setState(() => _currentIndex = index);
  }

  Widget _buildBody() {
    switch (_currentIndex) {
      case 0:
        return _buildFeed();
      case 1:
        return _placeholder('Keresés');
      case 2:
        return _placeholder('Kedvencek');
      case 3:
        return _placeholder('Profil');
      default:
        return const SizedBox();
    }
  }

  Widget _placeholder(String label) {
    return Center(
      child: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          Icon(Icons.pending, color: AppColors.loginMainTextColor, size: 48),
          const SizedBox(height: 12),
            Text(
            '$label (hamarosan)',
            style: const TextStyle(
              fontFamily: 'Candal',
              fontWeight: FontWeight.bold,
              fontSize: 16,
              color: AppColors.loginMainTextColor,
            ),
          ),
          const SizedBox(height: 8),
          TextButton(
            onPressed: () => _showNotImplemented(label),
            style: TextButton.styleFrom(foregroundColor: AppColors.loginMainTextColor),
            child: const Text(
              'Értesíts, ha kész',
              style: TextStyle(fontFamily: 'Candal', fontWeight: FontWeight.bold),
            ),
          ),
        ],
      ),
    );
  }

  Widget _buildFeed() {
    return CustomScrollView(
      controller: _scrollController,
      slivers: [
        SliverAppBar(
          floating: true,
          snap: true,
          elevation: 0,
          backgroundColor: Colors.transparent,
          flexibleSpace: Padding(
            padding: const EdgeInsets.fromLTRB(16, 8, 16, 0),
            child: Row(
              children: [
                Text(
                  'Jegyzetek',
                  style: const TextStyle(
                    fontFamily: 'Candal',
                    fontWeight: FontWeight.bold,
                    fontSize: 24,
                    color: AppColors.loginMainTextColor,
                  ),
                ),
                const Spacer(),
                IconButton(
                  tooltip: 'Szűrők',
                  onPressed: () => _showNotImplemented('Szűrők'),
                  icon: const Icon(Icons.tune, color: AppColors.loginMainTextColor),
                ),
              ],
            ),
          ),
        ),
        SliverPadding(
          padding: const EdgeInsets.fromLTRB(16, 8, 16, 90),
          sliver: SliverList.builder(
            itemCount: _mockNotes.length,
            itemBuilder: (context, index) => _noteCard(_mockNotes[index], index),
          ),
        ),
      ],
    );
  }

  void _toggleExpand(int index) {
    setState(() {
      _expandedIndex = (_expandedIndex == index) ? null : index;
    });
  }

  void _vote(int index, int delta) {
    setState(() {
      final current = _mockNotes[index];
      int newScore = current.score;
      int newVote;
      if (current.userVote == delta) {
        // undo
        newScore -= delta;
        newVote = 0;
      } else {
        if (current.userVote != 0) {
          newScore -= current.userVote; // remove previous effect
        }
        newVote = delta;
        newScore += delta;
      }
      _mockNotes[index] = current.copyWith(score: newScore, userVote: newVote);
    });
  }

  void _shareNote(_MockNote note) {
    _showNotImplemented('Megosztás: ${note.title}');
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
        onTap: () => _toggleExpand(index),
        child: AnimatedSize(
          duration: const Duration(milliseconds: 220),
          curve: Curves.easeInOut,
          child: Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 14),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
              if (note.imageUrls.isNotEmpty) ...[
                _buildImages(note),
                const SizedBox(height: 12),
              ],
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
                  CircleAvatar(
                    radius: 20,
                    backgroundColor: AppColors.loginMainTextColor.withValues(alpha: 0.12),
                    child: Text(
                      note.author.substring(0, 1),
                      style: const TextStyle(
                        fontFamily: 'Candal',
                        fontWeight: FontWeight.bold,
                        color: AppColors.loginMainTextColor,
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
                        tooltip: 'Megosztás',
                        onPressed: () => _shareNote(note),
                        icon: const Icon(Icons.share, color: AppColors.loginMainTextColor),
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
                  color: AppColors.loginMainTextColor.withValues(alpha: 0.8),
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
              )
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

  BottomAppBar _buildBottomBar() {
    return BottomAppBar(
      shape: const CircularNotchedRectangle(),
      // Darker blue variant background
      color: AppColors.loginMainTextColor.withValues(alpha: 0.93),
      elevation: 0,
      notchMargin: 8,
      child: SafeArea(
        top: false,
        child: Container(
          // Use original intended height; internal padding & smaller nav item content prevents overflow
          height: 60,
          // Create a subtle visual separation from content above
          margin: const EdgeInsets.only(top: 3),
          padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 4),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              _navItem(icon: Icons.home_outlined, label: 'Feed', index: 0),
              _navItem(icon: Icons.search, label: 'Keresés', index: 1),
              const SizedBox(width: 56), // FAB gap
              _navItem(icon: Icons.favorite_border, label: 'Kedv.', index: 2),
              _navItem(icon: Icons.person_outline, label: 'Profil', index: 3),
            ],
          ),
        ),
      ),
    );
  }

  Widget _navItem({required IconData icon, required String label, required int index}) {
    final bool active = _currentIndex == index;
    // On dark bar use white for better contrast
    final Color baseColor = Colors.white;
    return InkWell(
      borderRadius: BorderRadius.circular(12),
      onTap: () => _onNavTap(index),
      child: Padding(
        // Smaller vertical padding & icon/text sizes to avoid bottom overflow while keeping bar height
        padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 4),
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            Icon(icon, size: 20, color: active ? baseColor : baseColor.withValues(alpha: 0.55)),
            const SizedBox(height: 1),
            Text(
              label,
              style: TextStyle(
                fontFamily: 'Candal',
                fontWeight: FontWeight.bold,
                fontSize: 10,
                color: active ? baseColor : baseColor.withValues(alpha: 0.55),
              ),
            ),
          ],
        ),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.transparent,
      extendBody: true,
      body: Stack(
        children: [
          Positioned.fill(
            child: Image(
              image: const AssetImage('assets/images/NoteShareBackground.png'),
              fit: BoxFit.cover,
            ),
          ),
          _buildBody(),
        ],
      ),
      floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
      floatingActionButton: SizedBox(
        width: 66,
        height: 66,
        child: FloatingActionButton(
          onPressed: _onFabPressed,
          backgroundColor: AppColors.loginMainTextColor,
          elevation: 6,
          shape: const CircleBorder(),
          child: const Icon(Icons.add, size: 30, color: Colors.white),
        ),
      ),
      bottomNavigationBar: _buildBottomBar(),
    );
  }
}

class _MockNote {
  final String title;
  final String author;
  final String subject;
  final int minutesAgo;
  int score;
  int userVote; // -1,0,1
  final String preview;
  final List<String> imageUrls;
  final String description;
  final String? institution;
  final bool isStudent;
  _MockNote({
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
  });

  _MockNote copyWith({
    int? score,
    int? userVote,
  }) => _MockNote(
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
      );
}

Widget _imageNetwork(String url, {BorderRadius? radius}) {
  final img = Image.network(
    url,
    fit: BoxFit.cover,
    errorBuilder: (_, __, ___) => Container(
      color: Colors.grey.shade200,
      alignment: Alignment.center,
      child: const Icon(Icons.image_not_supported, color: Colors.grey),
    ),
  );
  if (radius != null) {
    return ClipRRect(borderRadius: radius, child: img);
  }
  return img;
}

extension on _HomePageState {
  Widget _buildImages(_MockNote note) {
    final count = note.imageUrls.length;
    if (count == 1) {
      return ClipRRect(
        borderRadius: BorderRadius.circular(14),
        child: AspectRatio(
          aspectRatio: 16 / 9,
          child: _imageNetwork(note.imageUrls.first),
        ),
      );
    }
    if (count == 2) {
      return SizedBox(
        height: 160,
        child: Row(
          children: [
            Expanded(
              child: ClipRRect(
                borderRadius: BorderRadius.circular(14),
                child: _imageNetwork(note.imageUrls[0]),
              ),
            ),
            const SizedBox(width: 8),
            Expanded(
              child: ClipRRect(
                borderRadius: BorderRadius.circular(14),
                child: _imageNetwork(note.imageUrls[1]),
              ),
            ),
          ],
        ),
      );
    }
    // 3 or more
    return SizedBox(
      height: 180,
      child: Row(
        children: [
          Expanded(
            flex: 2,
            child: ClipRRect(
              borderRadius: BorderRadius.circular(14),
              child: _imageNetwork(note.imageUrls[0]),
            ),
          ),
          const SizedBox(width: 8),
          Expanded(
            flex: 1,
            child: Column(
              children: [
                Expanded(
                  child: ClipRRect(
                    borderRadius: BorderRadius.circular(14),
                    child: _imageNetwork(note.imageUrls[1]),
                  ),
                ),
                const SizedBox(height: 8),
                Expanded(
                  child: Stack(
                    fit: StackFit.expand,
                    children: [
                      ClipRRect(
                        borderRadius: BorderRadius.circular(14),
                        child: _imageNetwork(note.imageUrls[2]),
                      ),
                      if (count > 3)
                        Container(
                          decoration: BoxDecoration(
                            color: Colors.black54,
                            borderRadius: BorderRadius.circular(14),
                          ),
                          alignment: Alignment.center,
                          child: Text(
                            '+${count - 3}',
                            style: const TextStyle(
                              fontFamily: 'Candal',
                              fontWeight: FontWeight.bold,
                              fontSize: 18,
                              color: Colors.white,
                            ),
                          ),
                        ),
                    ],
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

extension _ExtraWidgets on _HomePageState {
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
                ? AppColors.loginMainTextColor.withValues(alpha: 0.18)
                : AppColors.loginMainTextColor.withValues(alpha: 0.03),
            borderRadius: BorderRadius.circular(10),
            border: Border.all(
              color: active
                  ? AppColors.loginMainTextColor.withValues(alpha: 0.35)
                  : AppColors.loginMainTextColor.withValues(alpha: 0.10),
              width: 1,
            ),
          ),
          child: Icon(
            icon,
            size: 18,
            color: active
                ? AppColors.loginMainTextColor
                : AppColors.loginMainTextColor.withValues(alpha: 0.55),
          ),
        ),
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
          Icon(icon, size: 14, color: AppColors.loginMainTextColor.withValues(alpha: 0.75)),
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
        color: AppColors.loginMainTextColor.withValues(alpha: 0.10),
        borderRadius: BorderRadius.circular(40),
        border: Border.all(color: AppColors.loginMainTextColor.withValues(alpha: 0.25)),
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
}

// Derived metric helpers (avoid null & keep logic centralized)
int _derivedViews(int score) => (score.abs() * 3) + 120;
int _derivedDownloads(int score) => score.abs() + 10;
int _derivedComments(int score) => ((score % 7).abs()) + 5;
