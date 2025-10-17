// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'e_user_type.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

const EUserType _$number1 = const EUserType._('number1');
const EUserType _$number2 = const EUserType._('number2');
const EUserType _$number3 = const EUserType._('number3');

EUserType _$valueOf(String name) {
  switch (name) {
    case 'number1':
      return _$number1;
    case 'number2':
      return _$number2;
    case 'number3':
      return _$number3;
    default:
      throw ArgumentError(name);
  }
}

final BuiltSet<EUserType> _$values = BuiltSet<EUserType>(const <EUserType>[
  _$number1,
  _$number2,
  _$number3,
]);

class _$EUserTypeMeta {
  const _$EUserTypeMeta();
  EUserType get number1 => _$number1;
  EUserType get number2 => _$number2;
  EUserType get number3 => _$number3;
  EUserType valueOf(String name) => _$valueOf(name);
  BuiltSet<EUserType> get values => _$values;
}

abstract class _$EUserTypeMixin {
  // ignore: non_constant_identifier_names
  _$EUserTypeMeta get EUserType => const _$EUserTypeMeta();
}

Serializer<EUserType> _$eUserTypeSerializer = _$EUserTypeSerializer();

class _$EUserTypeSerializer implements PrimitiveSerializer<EUserType> {
  static const Map<String, Object> _toWire = const <String, Object>{
    'number1': 1,
    'number2': 2,
    'number3': 3,
  };
  static const Map<Object, String> _fromWire = const <Object, String>{
    1: 'number1',
    2: 'number2',
    3: 'number3',
  };

  @override
  final Iterable<Type> types = const <Type>[EUserType];
  @override
  final String wireName = 'EUserType';

  @override
  Object serialize(Serializers serializers, EUserType object,
          {FullType specifiedType = FullType.unspecified}) =>
      _toWire[object.name] ?? object.name;

  @override
  EUserType deserialize(Serializers serializers, Object serialized,
          {FullType specifiedType = FullType.unspecified}) =>
      EUserType.valueOf(
          _fromWire[serialized] ?? (serialized is String ? serialized : ''));
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
