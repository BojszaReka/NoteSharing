//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class EAnswerStatus {
  /// Instantiate a new enum with the provided [value].
  const EAnswerStatus._(this.value);

  /// The underlying value of this enum member.
  final int value;

  @override
  String toString() => value.toString();

  int toJson() => value;

  static const number0 = EAnswerStatus._(0);
  static const number1 = EAnswerStatus._(1);
  static const number2 = EAnswerStatus._(2);
  static const number3 = EAnswerStatus._(3);

  /// List of all possible values in this [enum][EAnswerStatus].
  static const values = <EAnswerStatus>[
    number0,
    number1,
    number2,
    number3,
  ];

  static EAnswerStatus? fromJson(dynamic value) => EAnswerStatusTypeTransformer().decode(value);

  static List<EAnswerStatus> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <EAnswerStatus>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = EAnswerStatus.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }
}

/// Transformation class that can [encode] an instance of [EAnswerStatus] to int,
/// and [decode] dynamic data back to [EAnswerStatus].
class EAnswerStatusTypeTransformer {
  factory EAnswerStatusTypeTransformer() => _instance ??= const EAnswerStatusTypeTransformer._();

  const EAnswerStatusTypeTransformer._();

  int encode(EAnswerStatus data) => data.value;

  /// Decodes a [dynamic value][data] to a EAnswerStatus.
  ///
  /// If [allowNull] is true and the [dynamic value][data] cannot be decoded successfully,
  /// then null is returned. However, if [allowNull] is false and the [dynamic value][data]
  /// cannot be decoded successfully, then an [UnimplementedError] is thrown.
  ///
  /// The [allowNull] is very handy when an API changes and a new enum value is added or removed,
  /// and users are still using an old app with the old code.
  EAnswerStatus? decode(dynamic data, {bool allowNull = true}) {
    if (data != null) {
      switch (data) {
        case 0: return EAnswerStatus.number0;
        case 1: return EAnswerStatus.number1;
        case 2: return EAnswerStatus.number2;
        case 3: return EAnswerStatus.number3;
        default:
          if (!allowNull) {
            throw ArgumentError('Unknown enum value to decode: $data');
          }
      }
    }
    return null;
  }

  /// Singleton [EAnswerStatusTypeTransformer] instance.
  static EAnswerStatusTypeTransformer? _instance;
}

