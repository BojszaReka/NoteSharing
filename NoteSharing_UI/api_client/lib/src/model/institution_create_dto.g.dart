// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'institution_create_dto.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$InstitutionCreateDTO extends InstitutionCreateDTO {
  @override
  final String name;

  factory _$InstitutionCreateDTO(
          [void Function(InstitutionCreateDTOBuilder)? updates]) =>
      (InstitutionCreateDTOBuilder()..update(updates))._build();

  _$InstitutionCreateDTO._({required this.name}) : super._();
  @override
  InstitutionCreateDTO rebuild(
          void Function(InstitutionCreateDTOBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  InstitutionCreateDTOBuilder toBuilder() =>
      InstitutionCreateDTOBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is InstitutionCreateDTO && name == other.name;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, name.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'InstitutionCreateDTO')
          ..add('name', name))
        .toString();
  }
}

class InstitutionCreateDTOBuilder
    implements Builder<InstitutionCreateDTO, InstitutionCreateDTOBuilder> {
  _$InstitutionCreateDTO? _$v;

  String? _name;
  String? get name => _$this._name;
  set name(String? name) => _$this._name = name;

  InstitutionCreateDTOBuilder() {
    InstitutionCreateDTO._defaults(this);
  }

  InstitutionCreateDTOBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _name = $v.name;
      _$v = null;
    }
    return this;
  }

  @override
  void replace(InstitutionCreateDTO other) {
    _$v = other as _$InstitutionCreateDTO;
  }

  @override
  void update(void Function(InstitutionCreateDTOBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  InstitutionCreateDTO build() => _build();

  _$InstitutionCreateDTO _build() {
    final _$result = _$v ??
        _$InstitutionCreateDTO._(
          name: BuiltValueNullFieldError.checkNotNull(
              name, r'InstitutionCreateDTO', 'name'),
        );
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
