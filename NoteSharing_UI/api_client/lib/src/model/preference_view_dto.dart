//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'preference_view_dto.g.dart';

/// PreferenceViewDTO
///
/// Properties:
/// * [id] 
/// * [prioritiseUsersFromInstitution] 
/// * [prioritiseInstructorNotes] 
/// * [privateMyNotes] 
/// * [prioritiseRatedNotes] 
/// * [prioritiseFollowedUsers] 
@BuiltValue()
abstract class PreferenceViewDTO implements Built<PreferenceViewDTO, PreferenceViewDTOBuilder> {
  @BuiltValueField(wireName: r'id')
  String? get id;

  @BuiltValueField(wireName: r'prioritiseUsersFromInstitution')
  bool? get prioritiseUsersFromInstitution;

  @BuiltValueField(wireName: r'prioritiseInstructorNotes')
  bool? get prioritiseInstructorNotes;

  @BuiltValueField(wireName: r'privateMyNotes')
  bool? get privateMyNotes;

  @BuiltValueField(wireName: r'prioritiseRatedNotes')
  bool? get prioritiseRatedNotes;

  @BuiltValueField(wireName: r'prioritiseFollowedUsers')
  bool? get prioritiseFollowedUsers;

  PreferenceViewDTO._();

  factory PreferenceViewDTO([void updates(PreferenceViewDTOBuilder b)]) = _$PreferenceViewDTO;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(PreferenceViewDTOBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<PreferenceViewDTO> get serializer => _$PreferenceViewDTOSerializer();
}

class _$PreferenceViewDTOSerializer implements PrimitiveSerializer<PreferenceViewDTO> {
  @override
  final Iterable<Type> types = const [PreferenceViewDTO, _$PreferenceViewDTO];

  @override
  final String wireName = r'PreferenceViewDTO';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    PreferenceViewDTO object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    if (object.id != null) {
      yield r'id';
      yield serializers.serialize(
        object.id,
        specifiedType: const FullType(String),
      );
    }
    if (object.prioritiseUsersFromInstitution != null) {
      yield r'prioritiseUsersFromInstitution';
      yield serializers.serialize(
        object.prioritiseUsersFromInstitution,
        specifiedType: const FullType(bool),
      );
    }
    if (object.prioritiseInstructorNotes != null) {
      yield r'prioritiseInstructorNotes';
      yield serializers.serialize(
        object.prioritiseInstructorNotes,
        specifiedType: const FullType(bool),
      );
    }
    if (object.privateMyNotes != null) {
      yield r'privateMyNotes';
      yield serializers.serialize(
        object.privateMyNotes,
        specifiedType: const FullType(bool),
      );
    }
    if (object.prioritiseRatedNotes != null) {
      yield r'prioritiseRatedNotes';
      yield serializers.serialize(
        object.prioritiseRatedNotes,
        specifiedType: const FullType(bool),
      );
    }
    if (object.prioritiseFollowedUsers != null) {
      yield r'prioritiseFollowedUsers';
      yield serializers.serialize(
        object.prioritiseFollowedUsers,
        specifiedType: const FullType(bool),
      );
    }
  }

  @override
  Object serialize(
    Serializers serializers,
    PreferenceViewDTO object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required PreferenceViewDTOBuilder result,
    required List<Object?> unhandled,
  }) {
    for (var i = 0; i < serializedList.length; i += 2) {
      final key = serializedList[i] as String;
      final value = serializedList[i + 1];
      switch (key) {
        case r'id':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.id = valueDes;
          break;
        case r'prioritiseUsersFromInstitution':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(bool),
          ) as bool;
          result.prioritiseUsersFromInstitution = valueDes;
          break;
        case r'prioritiseInstructorNotes':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(bool),
          ) as bool;
          result.prioritiseInstructorNotes = valueDes;
          break;
        case r'privateMyNotes':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(bool),
          ) as bool;
          result.privateMyNotes = valueDes;
          break;
        case r'prioritiseRatedNotes':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(bool),
          ) as bool;
          result.prioritiseRatedNotes = valueDes;
          break;
        case r'prioritiseFollowedUsers':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(bool),
          ) as bool;
          result.prioritiseFollowedUsers = valueDes;
          break;
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  PreferenceViewDTO deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = PreferenceViewDTOBuilder();
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

