//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class UserUpdateDTO {
  /// Returns a new [UserUpdateDTO] instance.
  UserUpdateDTO({
    required this.id,
    this.userName,
    this.name,
    this.email,
    this.password,
    this.userType,
    this.institutionID,
    this.grade,
  });

  String id;

  String? userName;

  String? name;

  String? email;

  String? password;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  EUserType? userType;

  String? institutionID;

  String? grade;

  @override
  bool operator ==(Object other) => identical(this, other) || other is UserUpdateDTO &&
    other.id == id &&
    other.userName == userName &&
    other.name == name &&
    other.email == email &&
    other.password == password &&
    other.userType == userType &&
    other.institutionID == institutionID &&
    other.grade == grade;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (id.hashCode) +
    (userName == null ? 0 : userName!.hashCode) +
    (name == null ? 0 : name!.hashCode) +
    (email == null ? 0 : email!.hashCode) +
    (password == null ? 0 : password!.hashCode) +
    (userType == null ? 0 : userType!.hashCode) +
    (institutionID == null ? 0 : institutionID!.hashCode) +
    (grade == null ? 0 : grade!.hashCode);

  @override
  String toString() => 'UserUpdateDTO[id=$id, userName=$userName, name=$name, email=$email, password=$password, userType=$userType, institutionID=$institutionID, grade=$grade]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
      json[r'id'] = this.id;
    if (this.userName != null) {
      json[r'userName'] = this.userName;
    } else {
      json[r'userName'] = null;
    }
    if (this.name != null) {
      json[r'name'] = this.name;
    } else {
      json[r'name'] = null;
    }
    if (this.email != null) {
      json[r'email'] = this.email;
    } else {
      json[r'email'] = null;
    }
    if (this.password != null) {
      json[r'password'] = this.password;
    } else {
      json[r'password'] = null;
    }
    if (this.userType != null) {
      json[r'userType'] = this.userType;
    } else {
      json[r'userType'] = null;
    }
    if (this.institutionID != null) {
      json[r'institutionID'] = this.institutionID;
    } else {
      json[r'institutionID'] = null;
    }
    if (this.grade != null) {
      json[r'grade'] = this.grade;
    } else {
      json[r'grade'] = null;
    }
    return json;
  }

  /// Returns a new [UserUpdateDTO] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static UserUpdateDTO? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "UserUpdateDTO[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "UserUpdateDTO[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return UserUpdateDTO(
        id: mapValueOfType<String>(json, r'id')!,
        userName: mapValueOfType<String>(json, r'userName'),
        name: mapValueOfType<String>(json, r'name'),
        email: mapValueOfType<String>(json, r'email'),
        password: mapValueOfType<String>(json, r'password'),
        userType: EUserType.fromJson(json[r'userType']),
        institutionID: mapValueOfType<String>(json, r'institutionID'),
        grade: mapValueOfType<String>(json, r'grade'),
      );
    }
    return null;
  }

  static List<UserUpdateDTO> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <UserUpdateDTO>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = UserUpdateDTO.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, UserUpdateDTO> mapFromJson(dynamic json) {
    final map = <String, UserUpdateDTO>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = UserUpdateDTO.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of UserUpdateDTO-objects as value to a dart map
  static Map<String, List<UserUpdateDTO>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<UserUpdateDTO>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = UserUpdateDTO.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
    'id',
  };
}

