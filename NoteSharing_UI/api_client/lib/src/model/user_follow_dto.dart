//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'user_follow_dto.g.dart';

/// UserFollowDTO
///
/// Properties:
/// * [followerUserID] 
/// * [followedUserID] 
@BuiltValue()
abstract class UserFollowDTO implements Built<UserFollowDTO, UserFollowDTOBuilder> {
  @BuiltValueField(wireName: r'followerUserID')
  String? get followerUserID;

  @BuiltValueField(wireName: r'followedUserID')
  String? get followedUserID;

  UserFollowDTO._();

  factory UserFollowDTO([void updates(UserFollowDTOBuilder b)]) = _$UserFollowDTO;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(UserFollowDTOBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<UserFollowDTO> get serializer => _$UserFollowDTOSerializer();
}

class _$UserFollowDTOSerializer implements PrimitiveSerializer<UserFollowDTO> {
  @override
  final Iterable<Type> types = const [UserFollowDTO, _$UserFollowDTO];

  @override
  final String wireName = r'UserFollowDTO';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    UserFollowDTO object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    if (object.followerUserID != null) {
      yield r'followerUserID';
      yield serializers.serialize(
        object.followerUserID,
        specifiedType: const FullType(String),
      );
    }
    if (object.followedUserID != null) {
      yield r'followedUserID';
      yield serializers.serialize(
        object.followedUserID,
        specifiedType: const FullType(String),
      );
    }
  }

  @override
  Object serialize(
    Serializers serializers,
    UserFollowDTO object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required UserFollowDTOBuilder result,
    required List<Object?> unhandled,
  }) {
    for (var i = 0; i < serializedList.length; i += 2) {
      final key = serializedList[i] as String;
      final value = serializedList[i + 1];
      switch (key) {
        case r'followerUserID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.followerUserID = valueDes;
          break;
        case r'followedUserID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.followedUserID = valueDes;
          break;
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  UserFollowDTO deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = UserFollowDTOBuilder();
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

