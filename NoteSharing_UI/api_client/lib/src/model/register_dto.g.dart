// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'register_dto.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$RegisterDTO extends RegisterDTO {
  @override
  final String userName;
  @override
  final String email;
  @override
  final String password;

  factory _$RegisterDTO([void Function(RegisterDTOBuilder)? updates]) =>
      (RegisterDTOBuilder()..update(updates))._build();

  _$RegisterDTO._(
      {required this.userName, required this.email, required this.password})
      : super._();
  @override
  RegisterDTO rebuild(void Function(RegisterDTOBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  RegisterDTOBuilder toBuilder() => RegisterDTOBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is RegisterDTO &&
        userName == other.userName &&
        email == other.email &&
        password == other.password;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, userName.hashCode);
    _$hash = $jc(_$hash, email.hashCode);
    _$hash = $jc(_$hash, password.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'RegisterDTO')
          ..add('userName', userName)
          ..add('email', email)
          ..add('password', password))
        .toString();
  }
}

class RegisterDTOBuilder implements Builder<RegisterDTO, RegisterDTOBuilder> {
  _$RegisterDTO? _$v;

  String? _userName;
  String? get userName => _$this._userName;
  set userName(String? userName) => _$this._userName = userName;

  String? _email;
  String? get email => _$this._email;
  set email(String? email) => _$this._email = email;

  String? _password;
  String? get password => _$this._password;
  set password(String? password) => _$this._password = password;

  RegisterDTOBuilder() {
    RegisterDTO._defaults(this);
  }

  RegisterDTOBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _userName = $v.userName;
      _email = $v.email;
      _password = $v.password;
      _$v = null;
    }
    return this;
  }

  @override
  void replace(RegisterDTO other) {
    _$v = other as _$RegisterDTO;
  }

  @override
  void update(void Function(RegisterDTOBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  RegisterDTO build() => _build();

  _$RegisterDTO _build() {
    final _$result = _$v ??
        _$RegisterDTO._(
          userName: BuiltValueNullFieldError.checkNotNull(
              userName, r'RegisterDTO', 'userName'),
          email: BuiltValueNullFieldError.checkNotNull(
              email, r'RegisterDTO', 'email'),
          password: BuiltValueNullFieldError.checkNotNull(
              password, r'RegisterDTO', 'password'),
        );
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
