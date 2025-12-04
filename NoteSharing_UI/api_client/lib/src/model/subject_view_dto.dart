//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'subject_view_dto.g.dart';

/// SubjectViewDTO
///
/// Properties:
/// * [id] 
/// * [name] 
/// * [institutionID] 
/// * [instructorID] 
@BuiltValue()
abstract class SubjectViewDTO implements Built<SubjectViewDTO, SubjectViewDTOBuilder> {
  @BuiltValueField(wireName: r'id')
  String? get id;

  @BuiltValueField(wireName: r'name')
  String? get name;

  @BuiltValueField(wireName: r'institutionID')
  String? get institutionID;

  @BuiltValueField(wireName: r'instructorID')
  String? get instructorID;

  SubjectViewDTO._();

  factory SubjectViewDTO([void updates(SubjectViewDTOBuilder b)]) = _$SubjectViewDTO;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(SubjectViewDTOBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<SubjectViewDTO> get serializer => _$SubjectViewDTOSerializer();
}

class _$SubjectViewDTOSerializer implements PrimitiveSerializer<SubjectViewDTO> {
  @override
  final Iterable<Type> types = const [SubjectViewDTO, _$SubjectViewDTO];

  @override
  final String wireName = r'SubjectViewDTO';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    SubjectViewDTO object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    if (object.id != null) {
      yield r'id';
      yield serializers.serialize(
        object.id,
        specifiedType: const FullType(String),
      );
    }
    if (object.name != null) {
      yield r'name';
      yield serializers.serialize(
        object.name,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.institutionID != null) {
      yield r'institutionID';
      yield serializers.serialize(
        object.institutionID,
        specifiedType: const FullType(String),
      );
    }
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
    SubjectViewDTO object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required SubjectViewDTOBuilder result,
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
        case r'name':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
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
  SubjectViewDTO deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = SubjectViewDTOBuilder();
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

