// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'refresh_token_dto.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$RefreshTokenDTO extends RefreshTokenDTO {
  @override
  final String refreshToken;

  factory _$RefreshTokenDTO([void Function(RefreshTokenDTOBuilder)? updates]) =>
      (RefreshTokenDTOBuilder()..update(updates))._build();

  _$RefreshTokenDTO._({required this.refreshToken}) : super._();
  @override
  RefreshTokenDTO rebuild(void Function(RefreshTokenDTOBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  RefreshTokenDTOBuilder toBuilder() => RefreshTokenDTOBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is RefreshTokenDTO && refreshToken == other.refreshToken;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, refreshToken.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'RefreshTokenDTO')
          ..add('refreshToken', refreshToken))
        .toString();
  }
}

class RefreshTokenDTOBuilder
    implements Builder<RefreshTokenDTO, RefreshTokenDTOBuilder> {
  _$RefreshTokenDTO? _$v;

  String? _refreshToken;
  String? get refreshToken => _$this._refreshToken;
  set refreshToken(String? refreshToken) => _$this._refreshToken = refreshToken;

  RefreshTokenDTOBuilder() {
    RefreshTokenDTO._defaults(this);
  }

  RefreshTokenDTOBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _refreshToken = $v.refreshToken;
      _$v = null;
    }
    return this;
  }

  @override
  void replace(RefreshTokenDTO other) {
    _$v = other as _$RefreshTokenDTO;
  }

  @override
  void update(void Function(RefreshTokenDTOBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  RefreshTokenDTO build() => _build();

  _$RefreshTokenDTO _build() {
    final _$result = _$v ??
        _$RefreshTokenDTO._(
          refreshToken: BuiltValueNullFieldError.checkNotNull(
              refreshToken, r'RefreshTokenDTO', 'refreshToken'),
        );
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
