//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class PreferenceViewDTO {
  /// Returns a new [PreferenceViewDTO] instance.
  PreferenceViewDTO({
    this.id,
    this.prioritiseUsersFromInstitution,
    this.prioritiseInstructorNotes,
    this.privateMyNotes,
    this.prioritiseRatedNotes,
    this.prioritiseFollowedUsers,
  });

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? id;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  bool? prioritiseUsersFromInstitution;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  bool? prioritiseInstructorNotes;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  bool? privateMyNotes;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  bool? prioritiseRatedNotes;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  bool? prioritiseFollowedUsers;

  @override
  bool operator ==(Object other) => identical(this, other) || other is PreferenceViewDTO &&
    other.id == id &&
    other.prioritiseUsersFromInstitution == prioritiseUsersFromInstitution &&
    other.prioritiseInstructorNotes == prioritiseInstructorNotes &&
    other.privateMyNotes == privateMyNotes &&
    other.prioritiseRatedNotes == prioritiseRatedNotes &&
    other.prioritiseFollowedUsers == prioritiseFollowedUsers;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (id == null ? 0 : id!.hashCode) +
    (prioritiseUsersFromInstitution == null ? 0 : prioritiseUsersFromInstitution!.hashCode) +
    (prioritiseInstructorNotes == null ? 0 : prioritiseInstructorNotes!.hashCode) +
    (privateMyNotes == null ? 0 : privateMyNotes!.hashCode) +
    (prioritiseRatedNotes == null ? 0 : prioritiseRatedNotes!.hashCode) +
    (prioritiseFollowedUsers == null ? 0 : prioritiseFollowedUsers!.hashCode);

  @override
  String toString() => 'PreferenceViewDTO[id=$id, prioritiseUsersFromInstitution=$prioritiseUsersFromInstitution, prioritiseInstructorNotes=$prioritiseInstructorNotes, privateMyNotes=$privateMyNotes, prioritiseRatedNotes=$prioritiseRatedNotes, prioritiseFollowedUsers=$prioritiseFollowedUsers]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.id != null) {
      json[r'id'] = this.id;
    } else {
      json[r'id'] = null;
    }
    if (this.prioritiseUsersFromInstitution != null) {
      json[r'prioritiseUsersFromInstitution'] = this.prioritiseUsersFromInstitution;
    } else {
      json[r'prioritiseUsersFromInstitution'] = null;
    }
    if (this.prioritiseInstructorNotes != null) {
      json[r'prioritiseInstructorNotes'] = this.prioritiseInstructorNotes;
    } else {
      json[r'prioritiseInstructorNotes'] = null;
    }
    if (this.privateMyNotes != null) {
      json[r'privateMyNotes'] = this.privateMyNotes;
    } else {
      json[r'privateMyNotes'] = null;
    }
    if (this.prioritiseRatedNotes != null) {
      json[r'prioritiseRatedNotes'] = this.prioritiseRatedNotes;
    } else {
      json[r'prioritiseRatedNotes'] = null;
    }
    if (this.prioritiseFollowedUsers != null) {
      json[r'prioritiseFollowedUsers'] = this.prioritiseFollowedUsers;
    } else {
      json[r'prioritiseFollowedUsers'] = null;
    }
    return json;
  }

  /// Returns a new [PreferenceViewDTO] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static PreferenceViewDTO? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "PreferenceViewDTO[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "PreferenceViewDTO[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return PreferenceViewDTO(
        id: mapValueOfType<String>(json, r'id'),
        prioritiseUsersFromInstitution: mapValueOfType<bool>(json, r'prioritiseUsersFromInstitution'),
        prioritiseInstructorNotes: mapValueOfType<bool>(json, r'prioritiseInstructorNotes'),
        privateMyNotes: mapValueOfType<bool>(json, r'privateMyNotes'),
        prioritiseRatedNotes: mapValueOfType<bool>(json, r'prioritiseRatedNotes'),
        prioritiseFollowedUsers: mapValueOfType<bool>(json, r'prioritiseFollowedUsers'),
      );
    }
    return null;
  }

  static List<PreferenceViewDTO> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <PreferenceViewDTO>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = PreferenceViewDTO.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, PreferenceViewDTO> mapFromJson(dynamic json) {
    final map = <String, PreferenceViewDTO>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = PreferenceViewDTO.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of PreferenceViewDTO-objects as value to a dart map
  static Map<String, List<PreferenceViewDTO>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<PreferenceViewDTO>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = PreferenceViewDTO.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

