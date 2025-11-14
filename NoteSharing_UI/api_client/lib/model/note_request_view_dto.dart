//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class NoteRequestViewDTO {
  /// Returns a new [NoteRequestViewDTO] instance.
  NoteRequestViewDTO({
    this.id,
    this.creatorUserID,
    this.subjectID,
    this.topic,
    this.description,
    this.status,
    this.createdAt,
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
  String? creatorUserID;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? subjectID;

  String? topic;

  String? description;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  ERequestStatus? status;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  DateTime? createdAt;

  @override
  bool operator ==(Object other) => identical(this, other) || other is NoteRequestViewDTO &&
    other.id == id &&
    other.creatorUserID == creatorUserID &&
    other.subjectID == subjectID &&
    other.topic == topic &&
    other.description == description &&
    other.status == status &&
    other.createdAt == createdAt;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (id == null ? 0 : id!.hashCode) +
    (creatorUserID == null ? 0 : creatorUserID!.hashCode) +
    (subjectID == null ? 0 : subjectID!.hashCode) +
    (topic == null ? 0 : topic!.hashCode) +
    (description == null ? 0 : description!.hashCode) +
    (status == null ? 0 : status!.hashCode) +
    (createdAt == null ? 0 : createdAt!.hashCode);

  @override
  String toString() => 'NoteRequestViewDTO[id=$id, creatorUserID=$creatorUserID, subjectID=$subjectID, topic=$topic, description=$description, status=$status, createdAt=$createdAt]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.id != null) {
      json[r'id'] = this.id;
    } else {
      json[r'id'] = null;
    }
    if (this.creatorUserID != null) {
      json[r'creatorUserID'] = this.creatorUserID;
    } else {
      json[r'creatorUserID'] = null;
    }
    if (this.subjectID != null) {
      json[r'subjectID'] = this.subjectID;
    } else {
      json[r'subjectID'] = null;
    }
    if (this.topic != null) {
      json[r'topic'] = this.topic;
    } else {
      json[r'topic'] = null;
    }
    if (this.description != null) {
      json[r'description'] = this.description;
    } else {
      json[r'description'] = null;
    }
    if (this.status != null) {
      json[r'status'] = this.status;
    } else {
      json[r'status'] = null;
    }
    if (this.createdAt != null) {
      json[r'createdAt'] = this.createdAt!.toUtc().toIso8601String();
    } else {
      json[r'createdAt'] = null;
    }
    return json;
  }

  /// Returns a new [NoteRequestViewDTO] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static NoteRequestViewDTO? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "NoteRequestViewDTO[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "NoteRequestViewDTO[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return NoteRequestViewDTO(
        id: mapValueOfType<String>(json, r'id'),
        creatorUserID: mapValueOfType<String>(json, r'creatorUserID'),
        subjectID: mapValueOfType<String>(json, r'subjectID'),
        topic: mapValueOfType<String>(json, r'topic'),
        description: mapValueOfType<String>(json, r'description'),
        status: ERequestStatus.fromJson(json[r'status']),
        createdAt: mapDateTime(json, r'createdAt', r''),
      );
    }
    return null;
  }

  static List<NoteRequestViewDTO> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <NoteRequestViewDTO>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = NoteRequestViewDTO.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, NoteRequestViewDTO> mapFromJson(dynamic json) {
    final map = <String, NoteRequestViewDTO>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = NoteRequestViewDTO.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of NoteRequestViewDTO-objects as value to a dart map
  static Map<String, List<NoteRequestViewDTO>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<NoteRequestViewDTO>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = NoteRequestViewDTO.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

