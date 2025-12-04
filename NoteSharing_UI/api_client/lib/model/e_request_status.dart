//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class ERequestStatus {
  /// Instantiate a new enum with the provided [value].
  const ERequestStatus._(this.value);

  /// The underlying value of this enum member.
  final int value;

  @override
  String toString() => value.toString();

  int toJson() => value;

  static const number0 = ERequestStatus._(0);
  static const number1 = ERequestStatus._(1);
  static const number2 = ERequestStatus._(2);
  static const number3 = ERequestStatus._(3);

  /// List of all possible values in this [enum][ERequestStatus].
  static const values = <ERequestStatus>[
    number0,
    number1,
    number2,
    number3,
  ];

  static ERequestStatus? fromJson(dynamic value) => ERequestStatusTypeTransformer().decode(value);

  static List<ERequestStatus> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <ERequestStatus>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = ERequestStatus.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }
}

/// Transformation class that can [encode] an instance of [ERequestStatus] to int,
/// and [decode] dynamic data back to [ERequestStatus].
class ERequestStatusTypeTransformer {
  factory ERequestStatusTypeTransformer() => _instance ??= const ERequestStatusTypeTransformer._();

  const ERequestStatusTypeTransformer._();

  int encode(ERequestStatus data) => data.value;

  /// Decodes a [dynamic value][data] to a ERequestStatus.
  ///
  /// If [allowNull] is true and the [dynamic value][data] cannot be decoded successfully,
  /// then null is returned. However, if [allowNull] is false and the [dynamic value][data]
  /// cannot be decoded successfully, then an [UnimplementedError] is thrown.
  ///
  /// The [allowNull] is very handy when an API changes and a new enum value is added or removed,
  /// and users are still using an old app with the old code.
  ERequestStatus? decode(dynamic data, {bool allowNull = true}) {
    if (data != null) {
      switch (data) {
        case 0: return ERequestStatus.number0;
        case 1: return ERequestStatus.number1;
        case 2: return ERequestStatus.number2;
        case 3: return ERequestStatus.number3;
        default:
          if (!allowNull) {
            throw ArgumentError('Unknown enum value to decode: $data');
          }
      }
    }
    return null;
  }

  /// Singleton [ERequestStatusTypeTransformer] instance.
  static ERequestStatusTypeTransformer? _instance;
}

