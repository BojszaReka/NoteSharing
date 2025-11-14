//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'subject_create_dto.g.dart';

/// SubjectCreateDTO
///
/// Properties:
/// * [name] 
/// * [institutionID] 
/// * [instructorID] 
@BuiltValue()
abstract class SubjectCreateDTO implements Built<SubjectCreateDTO, SubjectCreateDTOBuilder> {
  @BuiltValueField(wireName: r'name')
  String get name;

  @BuiltValueField(wireName: r'institutionID')
  String get institutionID;

  @BuiltValueField(wireName: r'instructorID')
  String? get instructorID;

  SubjectCreateDTO._();

  factory SubjectCreateDTO([void updates(SubjectCreateDTOBuilder b)]) = _$SubjectCreateDTO;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(SubjectCreateDTOBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<SubjectCreateDTO> get serializer => _$SubjectCreateDTOSerializer();
}

class _$SubjectCreateDTOSerializer implements PrimitiveSerializer<SubjectCreateDTO> {
  @override
  final Iterable<Type> types = const [SubjectCreateDTO, _$SubjectCreateDTO];

  @override
  final String wireName = r'SubjectCreateDTO';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    SubjectCreateDTO object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    yield r'name';
    yield serializers.serialize(
      object.name,
      specifiedType: const FullType(String),
    );
    yield r'institutionID';
    yield serializers.serialize(
      object.institutionID,
      specifiedType: const FullType(String),
    );
    if (object.instructorID != null) {
      yield r'instructorID';
      yield serializers.serialize(
        object.instructorID,
        specifiedType: const FullType.nullable(String),
      );
    }
  }

  @override
  Object serialize(
    Serializers serializers,
    SubjectCreateDTO object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required SubjectCreateDTOBuilder result,
    required List<Object?> unhandled,
  }) {
    for (var i = 0; i < serializedList.length; i += 2) {
      final key = serializedList[i] as String;
      final value = serializedList[i + 1];
      switch (key) {
        case r'name':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.name = valueDes;
          break;
        case r'institutionID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.institutionID = valueDes;
          break;
        case r'instructorID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.instructorID = valueDes;
          break;
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  SubjectCreateDTO deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = SubjectCreateDTOBuilder();
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

