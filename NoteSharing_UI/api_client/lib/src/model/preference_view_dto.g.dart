// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'preference_view_dto.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$PreferenceViewDTO extends PreferenceViewDTO {
  @override
  final String? id;
  @override
  final bool? prioritiseUsersFromInstitution;
  @override
  final bool? prioritiseInstructorNotes;
  @override
  final bool? privateMyNotes;
  @override
  final bool? prioritiseRatedNotes;
  @override
  final bool? prioritiseFollowedUsers;

  factory _$PreferenceViewDTO(
          [void Function(PreferenceViewDTOBuilder)? updates]) =>
      (PreferenceViewDTOBuilder()..update(updates))._build();

  _$PreferenceViewDTO._(
      {this.id,
      this.prioritiseUsersFromInstitution,
      this.prioritiseInstructorNotes,
      this.privateMyNotes,
      this.prioritiseRatedNotes,
      this.prioritiseFollowedUsers})
      : super._();
  @override
  PreferenceViewDTO rebuild(void Function(PreferenceViewDTOBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  PreferenceViewDTOBuilder toBuilder() =>
      PreferenceViewDTOBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is PreferenceViewDTO &&
        id == other.id &&
        prioritiseUsersFromInstitution ==
            other.prioritiseUsersFromInstitution &&
        prioritiseInstructorNotes == other.prioritiseInstructorNotes &&
        privateMyNotes == other.privateMyNotes &&
        prioritiseRatedNotes == other.prioritiseRatedNotes &&
        prioritiseFollowedUsers == other.prioritiseFollowedUsers;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, id.hashCode);
    _$hash = $jc(_$hash, prioritiseUsersFromInstitution.hashCode);
    _$hash = $jc(_$hash, prioritiseInstructorNotes.hashCode);
    _$hash = $jc(_$hash, privateMyNotes.hashCode);
    _$hash = $jc(_$hash, prioritiseRatedNotes.hashCode);
    _$hash = $jc(_$hash, prioritiseFollowedUsers.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'PreferenceViewDTO')
          ..add('id', id)
          ..add(
              'prioritiseUsersFromInstitution', prioritiseUsersFromInstitution)
          ..add('prioritiseInstructorNotes', prioritiseInstructorNotes)
          ..add('privateMyNotes', privateMyNotes)
          ..add('prioritiseRatedNotes', prioritiseRatedNotes)
          ..add('prioritiseFollowedUsers', prioritiseFollowedUsers))
        .toString();
  }
}

class PreferenceViewDTOBuilder
    implements Builder<PreferenceViewDTO, PreferenceViewDTOBuilder> {
  _$PreferenceViewDTO? _$v;

  String? _id;
  String? get id => _$this._id;
  set id(String? id) => _$this._id = id;

  bool? _prioritiseUsersFromInstitution;
  bool? get prioritiseUsersFromInstitution =>
      _$this._prioritiseUsersFromInstitution;
  set prioritiseUsersFromInstitution(bool? prioritiseUsersFromInstitution) =>
      _$this._prioritiseUsersFromInstitution = prioritiseUsersFromInstitution;

  bool? _prioritiseInstructorNotes;
  bool? get prioritiseInstructorNotes => _$this._prioritiseInstructorNotes;
  set prioritiseInstructorNotes(bool? prioritiseInstructorNotes) =>
      _$this._prioritiseInstructorNotes = prioritiseInstructorNotes;

  bool? _privateMyNotes;
  bool? get privateMyNotes => _$this._privateMyNotes;
  set privateMyNotes(bool? privateMyNotes) =>
      _$this._privateMyNotes = privateMyNotes;

  bool? _prioritiseRatedNotes;
  bool? get prioritiseRatedNotes => _$this._prioritiseRatedNotes;
  set prioritiseRatedNotes(bool? prioritiseRatedNotes) =>
      _$this._prioritiseRatedNotes = prioritiseRatedNotes;

  bool? _prioritiseFollowedUsers;
  bool? get prioritiseFollowedUsers => _$this._prioritiseFollowedUsers;
  set prioritiseFollowedUsers(bool? prioritiseFollowedUsers) =>
      _$this._prioritiseFollowedUsers = prioritiseFollowedUsers;

  PreferenceViewDTOBuilder() {
    PreferenceViewDTO._defaults(this);
  }

  PreferenceViewDTOBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _id = $v.id;
      _prioritiseUsersFromInstitution = $v.prioritiseUsersFromInstitution;
      _prioritiseInstructorNotes = $v.prioritiseInstructorNotes;
      _privateMyNotes = $v.privateMyNotes;
      _prioritiseRatedNotes = $v.prioritiseRatedNotes;
      _prioritiseFollowedUsers = $v.prioritiseFollowedUsers;
      _$v = null;
    }
    return this;
  }

  @override
  void replace(PreferenceViewDTO other) {
    _$v = other as _$PreferenceViewDTO;
  }

  @override
  void update(void Function(PreferenceViewDTOBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  PreferenceViewDTO build() => _build();

  _$PreferenceViewDTO _build() {
    final _$result = _$v ??
        _$PreferenceViewDTO._(
          id: id,
          prioritiseUsersFromInstitution: prioritiseUsersFromInstitution,
          prioritiseInstructorNotes: prioritiseInstructorNotes,
          privateMyNotes: privateMyNotes,
          prioritiseRatedNotes: prioritiseRatedNotes,
          prioritiseFollowedUsers: prioritiseFollowedUsers,
        );
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
