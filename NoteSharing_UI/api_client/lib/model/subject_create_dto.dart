//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class SubjectCreateDTO {
  /// Returns a new [SubjectCreateDTO] instance.
  SubjectCreateDTO({
    required this.name,
    required this.institutionID,
    this.instructorID,
  });

  String name;

  String institutionID;

  String? instructorID;

  @override
  bool operator ==(Object other) => identical(this, other) || other is SubjectCreateDTO &&
    other.name == name &&
    other.institutionID == institutionID &&
    other.instructorID == instructorID;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (name.hashCode) +
    (institutionID.hashCode) +
    (instructorID == null ? 0 : instructorID!.hashCode);

  @override
  String toString() => 'SubjectCreateDTO[name=$name, institutionID=$institutionID, instructorID=$instructorID]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
      json[r'name'] = this.name;
      json[r'institutionID'] = this.institutionID;
    if (this.instructorID != null) {
      json[r'instructorID'] = this.instructorID;
    } else {
      json[r'instructorID'] = null;
    }
    return json;
  }

  /// Returns a new [SubjectCreateDTO] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static SubjectCreateDTO? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "SubjectCreateDTO[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "SubjectCreateDTO[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return SubjectCreateDTO(
        name: mapValueOfType<String>(json, r'name')!,
        institutionID: mapValueOfType<String>(json, r'institutionID')!,
        instructorID: mapValueOfType<String>(json, r'instructorID'),
      );
    }
    return null;
  }

  static List<SubjectCreateDTO> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <SubjectCreateDTO>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = SubjectCreateDTO.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, SubjectCreateDTO> mapFromJson(dynamic json) {
    final map = <String, SubjectCreateDTO>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = SubjectCreateDTO.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of SubjectCreateDTO-objects as value to a dart map
  static Map<String, List<SubjectCreateDTO>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<SubjectCreateDTO>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = SubjectCreateDTO.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
    'name',
    'institutionID',
  };
}

