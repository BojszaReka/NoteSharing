//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class CollectionCreateDTO {
  /// Returns a new [CollectionCreateDTO] instance.
  CollectionCreateDTO({
    this.userID,
    this.name,
    this.title,
    this.private,
  });

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? userID;

  String? name;

  String? title;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  bool? private;

  @override
  bool operator ==(Object other) => identical(this, other) || other is CollectionCreateDTO &&
    other.userID == userID &&
    other.name == name &&
    other.title == title &&
    other.private == private;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (userID == null ? 0 : userID!.hashCode) +
    (name == null ? 0 : name!.hashCode) +
    (title == null ? 0 : title!.hashCode) +
    (private == null ? 0 : private!.hashCode);

  @override
  String toString() => 'CollectionCreateDTO[userID=$userID, name=$name, title=$title, private=$private]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.userID != null) {
      json[r'userID'] = this.userID;
    } else {
      json[r'userID'] = null;
    }
    if (this.name != null) {
      json[r'name'] = this.name;
    } else {
      json[r'name'] = null;
    }
    if (this.title != null) {
      json[r'title'] = this.title;
    } else {
      json[r'title'] = null;
    }
    if (this.private != null) {
      json[r'private'] = this.private;
    } else {
      json[r'private'] = null;
    }
    return json;
  }

  /// Returns a new [CollectionCreateDTO] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static CollectionCreateDTO? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "CollectionCreateDTO[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "CollectionCreateDTO[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return CollectionCreateDTO(
        userID: mapValueOfType<String>(json, r'userID'),
        name: mapValueOfType<String>(json, r'name'),
        title: mapValueOfType<String>(json, r'title'),
        private: mapValueOfType<bool>(json, r'private'),
      );
    }
    return null;
  }

  static List<CollectionCreateDTO> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <CollectionCreateDTO>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = CollectionCreateDTO.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, CollectionCreateDTO> mapFromJson(dynamic json) {
    final map = <String, CollectionCreateDTO>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = CollectionCreateDTO.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of CollectionCreateDTO-objects as value to a dart map
  static Map<String, List<CollectionCreateDTO>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<CollectionCreateDTO>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = CollectionCreateDTO.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

