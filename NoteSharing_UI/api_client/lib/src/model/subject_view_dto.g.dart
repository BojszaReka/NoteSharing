// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'subject_view_dto.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$SubjectViewDTO extends SubjectViewDTO {
  @override
  final String? id;
  @override
  final String? name;
  @override
  final String? institutionID;
  @override
  final String? instructorID;

  factory _$SubjectViewDTO([void Function(SubjectViewDTOBuilder)? updates]) =>
      (SubjectViewDTOBuilder()..update(updates))._build();

  _$SubjectViewDTO._(
      {this.id, this.name, this.institutionID, this.instructorID})
      : super._();
  @override
  SubjectViewDTO rebuild(void Function(SubjectViewDTOBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  SubjectViewDTOBuilder toBuilder() => SubjectViewDTOBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is SubjectViewDTO &&
        id == other.id &&
        name == other.name &&
        institutionID == other.institutionID &&
        instructorID == other.instructorID;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, id.hashCode);
    _$hash = $jc(_$hash, name.hashCode);
    _$hash = $jc(_$hash, institutionID.hashCode);
    _$hash = $jc(_$hash, instructorID.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'SubjectViewDTO')
          ..add('id', id)
          ..add('name', name)
          ..add('institutionID', institutionID)
          ..add('instructorID', instructorID))
        .toString();
  }
}

class SubjectViewDTOBuilder
    implements Builder<SubjectViewDTO, SubjectViewDTOBuilder> {
  _$SubjectViewDTO? _$v;

  String? _id;
  String? get id => _$this._id;
  set id(String? id) => _$this._id = id;

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

  SubjectViewDTOBuilder() {
    SubjectViewDTO._defaults(this);
  }

  SubjectViewDTOBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _id = $v.id;
      _name = $v.name;
      _institutionID = $v.institutionID;
      _instructorID = $v.instructorID;
      _$v = null;
    }
    return this;
  }

  @override
  void replace(SubjectViewDTO other) {
    _$v = other as _$SubjectViewDTO;
  }

  @override
  void update(void Function(SubjectViewDTOBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  SubjectViewDTO build() => _build();

  _$SubjectViewDTO _build() {
    final _$result = _$v ??
        _$SubjectViewDTO._(
          id: id,
          name: name,
          institutionID: institutionID,
          instructorID: instructorID,
        );
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
