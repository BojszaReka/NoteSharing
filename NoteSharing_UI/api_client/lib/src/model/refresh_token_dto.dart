//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'refresh_token_dto.g.dart';

/// RefreshTokenDTO
///
/// Properties:
/// * [refreshToken] 
@BuiltValue()
abstract class RefreshTokenDTO implements Built<RefreshTokenDTO, RefreshTokenDTOBuilder> {
  @BuiltValueField(wireName: r'refreshToken')
  String get refreshToken;

  RefreshTokenDTO._();

  factory RefreshTokenDTO([void updates(RefreshTokenDTOBuilder b)]) = _$RefreshTokenDTO;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(RefreshTokenDTOBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<RefreshTokenDTO> get serializer => _$RefreshTokenDTOSerializer();
}

class _$RefreshTokenDTOSerializer implements PrimitiveSerializer<RefreshTokenDTO> {
  @override
  final Iterable<Type> types = const [RefreshTokenDTO, _$RefreshTokenDTO];

  @override
  final String wireName = r'RefreshTokenDTO';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    RefreshTokenDTO object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    yield r'refreshToken';
    yield serializers.serialize(
      object.refreshToken,
      specifiedType: const FullType(String),
    );
  }

  @override
  Object serialize(
    Serializers serializers,
    RefreshTokenDTO object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required RefreshTokenDTOBuilder result,
    required List<Object?> unhandled,
  }) {
    for (var i = 0; i < serializedList.length; i += 2) {
      final key = serializedList[i] as String;
      final value = serializedList[i + 1];
      switch (key) {
        case r'refreshToken':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.refreshToken = valueDes;
          break;
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  RefreshTokenDTO deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = RefreshTokenDTOBuilder();
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

