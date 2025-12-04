// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user_follow_dto.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$UserFollowDTO extends UserFollowDTO {
  @override
  final String? followerUserID;
  @override
  final String? followedUserID;

  factory _$UserFollowDTO([void Function(UserFollowDTOBuilder)? updates]) =>
      (UserFollowDTOBuilder()..update(updates))._build();

  _$UserFollowDTO._({this.followerUserID, this.followedUserID}) : super._();
  @override
  UserFollowDTO rebuild(void Function(UserFollowDTOBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  UserFollowDTOBuilder toBuilder() => UserFollowDTOBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is UserFollowDTO &&
        followerUserID == other.followerUserID &&
        followedUserID == other.followedUserID;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, followerUserID.hashCode);
    _$hash = $jc(_$hash, followedUserID.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'UserFollowDTO')
          ..add('followerUserID', followerUserID)
          ..add('followedUserID', followedUserID))
        .toString();
  }
}

class UserFollowDTOBuilder
    implements Builder<UserFollowDTO, UserFollowDTOBuilder> {
  _$UserFollowDTO? _$v;

  String? _followerUserID;
  String? get followerUserID => _$this._followerUserID;
  set followerUserID(String? followerUserID) =>
      _$this._followerUserID = followerUserID;

  String? _followedUserID;
  String? get followedUserID => _$this._followedUserID;
  set followedUserID(String? followedUserID) =>
      _$this._followedUserID = followedUserID;

  UserFollowDTOBuilder() {
    UserFollowDTO._defaults(this);
  }

  UserFollowDTOBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _followerUserID = $v.followerUserID;
      _followedUserID = $v.followedUserID;
      _$v = null;
    }
    return this;
  }

  @override
  void replace(UserFollowDTO other) {
    _$v = other as _$UserFollowDTO;
  }

  @override
  void update(void Function(UserFollowDTOBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  UserFollowDTO build() => _build();

  _$UserFollowDTO _build() {
    final _$result = _$v ??
        _$UserFollowDTO._(
          followerUserID: followerUserID,
          followedUserID: followedUserID,
        );
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
