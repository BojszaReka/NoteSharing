//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'register_dto.g.dart';

/// RegisterDTO
///
/// Properties:
/// * [userName] 
/// * [email] 
/// * [password] 
@BuiltValue()
abstract class RegisterDTO implements Built<RegisterDTO, RegisterDTOBuilder> {
  @BuiltValueField(wireName: r'userName')
  String get userName;

  @BuiltValueField(wireName: r'email')
  String get email;

  @BuiltValueField(wireName: r'password')
  String get password;

  RegisterDTO._();

  factory RegisterDTO([void updates(RegisterDTOBuilder b)]) = _$RegisterDTO;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(RegisterDTOBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<RegisterDTO> get serializer => _$RegisterDTOSerializer();
}

class _$RegisterDTOSerializer implements PrimitiveSerializer<RegisterDTO> {
  @override
  final Iterable<Type> types = const [RegisterDTO, _$RegisterDTO];

  @override
  final String wireName = r'RegisterDTO';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    RegisterDTO object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    yield r'userName';
    yield serializers.serialize(
      object.userName,
      specifiedType: const FullType(String),
    );
    yield r'email';
    yield serializers.serialize(
      object.email,
      specifiedType: const FullType(String),
    );
    yield r'password';
    yield serializers.serialize(
      object.password,
      specifiedType: const FullType(String),
    );
  }

  @override
  Object serialize(
    Serializers serializers,
    RegisterDTO object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required RegisterDTOBuilder result,
    required List<Object?> unhandled,
  }) {
    for (var i = 0; i < serializedList.length; i += 2) {
      final key = serializedList[i] as String;
      final value = serializedList[i + 1];
      switch (key) {
        case r'userName':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.userName = valueDes;
          break;
        case r'email':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.email = valueDes;
          break;
        case r'password':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.password = valueDes;
          break;
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  RegisterDTO deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = RegisterDTOBuilder();
    final serializedList = (serialized as Iterable<Object?>).toList();
    final unhandled = <Object?>[];
    _deserializeProperties(
      serializers,
      serialized,
      specifiedType: specifiedType,
      serializedList: serializedList,
      unhandled: unhandled,
      result: result,
    );
    return result.build();
  }
}

