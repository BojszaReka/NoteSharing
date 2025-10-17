// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user_update_dto.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$UserUpdateDTO extends UserUpdateDTO {
  @override
  final String id;
  @override
  final String? userName;
  @override
  final String? name;
  @override
  final String? email;
  @override
  final String? password;
  @override
  final EUserType? userType;
  @override
  final String? institutionID;
  @override
  final String? grade;

  factory _$UserUpdateDTO([void Function(UserUpdateDTOBuilder)? updates]) =>
      (UserUpdateDTOBuilder()..update(updates))._build();

  _$UserUpdateDTO._(
      {required this.id,
      this.userName,
      this.name,
      this.email,
      this.password,
      this.userType,
      this.institutionID,
      this.grade})
      : super._();
  @override
  UserUpdateDTO rebuild(void Function(UserUpdateDTOBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  UserUpdateDTOBuilder toBuilder() => UserUpdateDTOBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is UserUpdateDTO &&
        id == other.id &&
        userName == other.userName &&
        name == other.name &&
        email == other.email &&
        password == other.password &&
        userType == other.userType &&
        institutionID == other.institutionID &&
        grade == other.grade;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, id.hashCode);
    _$hash = $jc(_$hash, userName.hashCode);
    _$hash = $jc(_$hash, name.hashCode);
    _$hash = $jc(_$hash, email.hashCode);
    _$hash = $jc(_$hash, password.hashCode);
    _$hash = $jc(_$hash, userType.hashCode);
    _$hash = $jc(_$hash, institutionID.hashCode);
    _$hash = $jc(_$hash, grade.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'UserUpdateDTO')
          ..add('id', id)
          ..add('userName', userName)
          ..add('name', name)
          ..add('email', email)
          ..add('password', password)
          ..add('userType', userType)
          ..add('institutionID', institutionID)
          ..add('grade', grade))
        .toString();
  }
}

class UserUpdateDTOBuilder
    implements Builder<UserUpdateDTO, UserUpdateDTOBuilder> {
  _$UserUpdateDTO? _$v;

  String? _id;
  String? get id => _$this._id;
  set id(String? id) => _$this._id = id;

  String? _userName;
  String? get userName => _$this._userName;
  set userName(String? userName) => _$this._userName = userName;

  String? _name;
  String? get name => _$this._name;
  set name(String? name) => _$this._name = name;

  String? _email;
  String? get email => _$this._email;
  set email(String? email) => _$this._email = email;

  String? _password;
  String? get password => _$this._password;
  set password(String? password) => _$this._password = password;

  EUserType? _userType;
  EUserType? get userType => _$this._userType;
  set userType(EUserType? userType) => _$this._userType = userType;

  String? _institutionID;
  String? get institutionID => _$this._institutionID;
  set institutionID(String? institutionID) =>
      _$this._institutionID = institutionID;

  String? _grade;
  String? get grade => _$this._grade;
  set grade(String? grade) => _$this._grade = grade;

  UserUpdateDTOBuilder() {
    UserUpdateDTO._defaults(this);
  }

  UserUpdateDTOBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _id = $v.id;
      _userName = $v.userName;
      _name = $v.name;
      _email = $v.email;
      _password = $v.password;
      _userType = $v.userType;
      _institutionID = $v.institutionID;
      _grade = $v.grade;
      _$v = null;
    }
    return this;
  }

  @override
  void replace(UserUpdateDTO other) {
    _$v = other as _$UserUpdateDTO;
  }

  @override
  void update(void Function(UserUpdateDTOBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  UserUpdateDTO build() => _build();

  _$UserUpdateDTO _build() {
    final _$result = _$v ??
        _$UserUpdateDTO._(
          id: BuiltValueNullFieldError.checkNotNull(id, r'UserUpdateDTO', 'id'),
          userName: userName,
          name: name,
          email: email,
          password: password,
          userType: userType,
          institutionID: institutionID,
          grade: grade,
        );
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
