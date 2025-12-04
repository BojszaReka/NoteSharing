//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class NoteRatingCreateDTO {
  /// Returns a new [NoteRatingCreateDTO] instance.
  NoteRatingCreateDTO({
    this.noteID,
    this.userID,
    this.stars,
    this.review,
  });

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? noteID;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? userID;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? stars;

  String? review;

  @override
  bool operator ==(Object other) => identical(this, other) || other is NoteRatingCreateDTO &&
    other.noteID == noteID &&
    other.userID == userID &&
    other.stars == stars &&
    other.review == review;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (noteID == null ? 0 : noteID!.hashCode) +
    (userID == null ? 0 : userID!.hashCode) +
    (stars == null ? 0 : stars!.hashCode) +
    (review == null ? 0 : review!.hashCode);

  @override
  String toString() => 'NoteRatingCreateDTO[noteID=$noteID, userID=$userID, stars=$stars, review=$review]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.noteID != null) {
      json[r'noteID'] = this.noteID;
    } else {
      json[r'noteID'] = null;
    }
    if (this.userID != null) {
      json[r'userID'] = this.userID;
    } else {
      json[r'userID'] = null;
    }
    if (this.stars != null) {
      json[r'stars'] = this.stars;
    } else {
      json[r'stars'] = null;
    }
    if (this.review != null) {
      json[r'review'] = this.review;
    } else {
      json[r'review'] = null;
    }
    return json;
  }

  /// Returns a new [NoteRatingCreateDTO] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static NoteRatingCreateDTO? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "NoteRatingCreateDTO[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "NoteRatingCreateDTO[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return NoteRatingCreateDTO(
        noteID: mapValueOfType<String>(json, r'noteID'),
        userID: mapValueOfType<String>(json, r'userID'),
        stars: mapValueOfType<int>(json, r'stars'),
        review: mapValueOfType<String>(json, r'review'),
      );
    }
    return null;
  }

  static List<NoteRatingCreateDTO> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <NoteRatingCreateDTO>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = NoteRatingCreateDTO.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, NoteRatingCreateDTO> mapFromJson(dynamic json) {
    final map = <String, NoteRatingCreateDTO>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = NoteRatingCreateDTO.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of NoteRatingCreateDTO-objects as value to a dart map
  static Map<String, List<NoteRatingCreateDTO>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<NoteRatingCreateDTO>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = NoteRatingCreateDTO.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

