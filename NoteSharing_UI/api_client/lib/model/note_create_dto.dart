//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class NoteCreateDTO {
  /// Returns a new [NoteCreateDTO] instance.
  NoteCreateDTO({
    this.authorUserID,
    this.content,
    this.title,
    this.description,
    this.subjectID,
    this.institutionID,
  });

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? authorUserID;

  String? content;

  String? title;

  String? description;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? subjectID;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? institutionID;

  @override
  bool operator ==(Object other) => identical(this, other) || other is NoteCreateDTO &&
    other.authorUserID == authorUserID &&
    other.content == content &&
    other.title == title &&
    other.description == description &&
    other.subjectID == subjectID &&
    other.institutionID == institutionID;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (authorUserID == null ? 0 : authorUserID!.hashCode) +
    (content == null ? 0 : content!.hashCode) +
    (title == null ? 0 : title!.hashCode) +
    (description == null ? 0 : description!.hashCode) +
    (subjectID == null ? 0 : subjectID!.hashCode) +
    (institutionID == null ? 0 : institutionID!.hashCode);

  @override
  String toString() => 'NoteCreateDTO[authorUserID=$authorUserID, content=$content, title=$title, description=$description, subjectID=$subjectID, institutionID=$institutionID]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.authorUserID != null) {
      json[r'authorUserID'] = this.authorUserID;
    } else {
      json[r'authorUserID'] = null;
    }
    if (this.content != null) {
      json[r'content'] = this.content;
    } else {
      json[r'content'] = null;
    }
    if (this.title != null) {
      json[r'title'] = this.title;
    } else {
      json[r'title'] = null;
    }
    if (this.description != null) {
      json[r'description'] = this.description;
    } else {
      json[r'description'] = null;
    }
    if (this.subjectID != null) {
      json[r'subjectID'] = this.subjectID;
    } else {
      json[r'subjectID'] = null;
    }
    if (this.institutionID != null) {
      json[r'institutionID'] = this.institutionID;
    } else {
      json[r'institutionID'] = null;
    }
    return json;
  }

  /// Returns a new [NoteCreateDTO] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static NoteCreateDTO? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "NoteCreateDTO[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "NoteCreateDTO[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return NoteCreateDTO(
        authorUserID: mapValueOfType<String>(json, r'authorUserID'),
        content: mapValueOfType<String>(json, r'content'),
        title: mapValueOfType<String>(json, r'title'),
        description: mapValueOfType<String>(json, r'description'),
        subjectID: mapValueOfType<String>(json, r'subjectID'),
        institutionID: mapValueOfType<String>(json, r'institutionID'),
      );
    }
    return null;
  }

  static List<NoteCreateDTO> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <NoteCreateDTO>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = NoteCreateDTO.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, NoteCreateDTO> mapFromJson(dynamic json) {
    final map = <String, NoteCreateDTO>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = NoteCreateDTO.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of NoteCreateDTO-objects as value to a dart map
  static Map<String, List<NoteCreateDTO>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<NoteCreateDTO>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = NoteCreateDTO.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

