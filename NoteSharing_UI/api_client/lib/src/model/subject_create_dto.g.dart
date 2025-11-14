// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'subject_create_dto.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$SubjectCreateDTO extends SubjectCreateDTO {
  @override
  final String name;
  @override
  final String institutionID;
  @override
  final String? instructorID;

  factory _$SubjectCreateDTO(
          [void Function(SubjectCreateDTOBuilder)? updates]) =>
      (SubjectCreateDTOBuilder()..update(updates))._build();

  _$SubjectCreateDTO._(
      {required this.name, required this.institutionID, this.instructorID})
      : super._();
  @override
  SubjectCreateDTO rebuild(void Function(SubjectCreateDTOBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  SubjectCreateDTOBuilder toBuilder() =>
      SubjectCreateDTOBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is SubjectCreateDTO &&
        name == other.name &&
        institutionID == other.institutionID &&
        instructorID == other.instructorID;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, name.hashCode);
    _$hash = $jc(_$hash, institutionID.hashCode);
    _$hash = $jc(_$hash, instructorID.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'SubjectCreateDTO')
          ..add('name', name)
          ..add('institutionID', institutionID)
          ..add('instructorID', instructorID))
        .toString();
  }
}

class SubjectCreateDTOBuilder
    implements Builder<SubjectCreateDTO, SubjectCreateDTOBuilder> {
  _$SubjectCreateDTO? _$v;

  String? _name;
  String? get name => _$this._name;
  set name(String? name) => _$this._name = name;

  String? _institutionID;
  String? get institutionID => _$this._institutionID;
  set institutionID(String? institutionID) =>
      _$this._institutionID = institutionID;

  String? _instructorID;
  String? get instructorID => _$this._instructorID;
  set instructorID(String? instructorID) => _$this._instructorID = instructorID;

  SubjectCreateDTOBuilder() {
    SubjectCreateDTO._defaults(this);
  }

  SubjectCreateDTOBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _name = $v.name;
      _institutionID = $v.institutionID;
      _instructorID = $v.instructorID;
      _$v = null;
    }
    return this;
  }

  @override
  void replace(SubjectCreateDTO other) {
    _$v = other as _$SubjectCreateDTO;
  }

  @override
  void update(void Function(SubjectCreateDTOBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  SubjectCreateDTO build() => _build();

  _$SubjectCreateDTO _build() {
    final _$result = _$v ??
        _$SubjectCreateDTO._(
          name: BuiltValueNullFieldError.checkNotNull(
              name, r'SubjectCreateDTO', 'name'),
          institutionID: BuiltValueNullFieldError.checkNotNull(
              institutionID, r'SubjectCreateDTO', 'institutionID'),
          instructorID: instructorID,
        );
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
