// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'institution_view_dto.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$InstitutionViewDTO extends InstitutionViewDTO {
  @override
  final String? id;
  @override
  final String? name;

  factory _$InstitutionViewDTO(
          [void Function(InstitutionViewDTOBuilder)? updates]) =>
      (InstitutionViewDTOBuilder()..update(updates))._build();

  _$InstitutionViewDTO._({this.id, this.name}) : super._();
  @override
  InstitutionViewDTO rebuild(
          void Function(InstitutionViewDTOBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  InstitutionViewDTOBuilder toBuilder() =>
      InstitutionViewDTOBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is InstitutionViewDTO && id == other.id && name == other.name;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, id.hashCode);
    _$hash = $jc(_$hash, name.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'InstitutionViewDTO')
          ..add('id', id)
          ..add('name', name))
        .toString();
  }
}

class InstitutionViewDTOBuilder
    implements Builder<InstitutionViewDTO, InstitutionViewDTOBuilder> {
  _$InstitutionViewDTO? _$v;

  String? _id;
  String? get id => _$this._id;
  set id(String? id) => _$this._id = id;

  String? _name;
  String? get name => _$this._name;
  set name(String? name) => _$this._name = name;

  InstitutionViewDTOBuilder() {
    InstitutionViewDTO._defaults(this);
  }

  InstitutionViewDTOBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _id = $v.id;
      _name = $v.name;
      _$v = null;
    }
    return this;
  }

  @override
  void replace(InstitutionViewDTO other) {
    _$v = other as _$InstitutionViewDTO;
  }

  @override
  void update(void Function(InstitutionViewDTOBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  InstitutionViewDTO build() => _build();

  _$InstitutionViewDTO _build() {
    final _$result = _$v ??
        _$InstitutionViewDTO._(
          id: id,
          name: name,
        );
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
