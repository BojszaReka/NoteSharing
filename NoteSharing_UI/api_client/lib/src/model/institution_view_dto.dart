//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'institution_view_dto.g.dart';

/// InstitutionViewDTO
///
/// Properties:
/// * [id] 
/// * [name] 
@BuiltValue()
abstract class InstitutionViewDTO implements Built<InstitutionViewDTO, InstitutionViewDTOBuilder> {
  @BuiltValueField(wireName: r'id')
  String? get id;

  @BuiltValueField(wireName: r'name')
  String? get name;

  InstitutionViewDTO._();

  factory InstitutionViewDTO([void updates(InstitutionViewDTOBuilder b)]) = _$InstitutionViewDTO;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(InstitutionViewDTOBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<InstitutionViewDTO> get serializer => _$InstitutionViewDTOSerializer();
}

class _$InstitutionViewDTOSerializer implements PrimitiveSerializer<InstitutionViewDTO> {
  @override
  final Iterable<Type> types = const [InstitutionViewDTO, _$InstitutionViewDTO];

  @override
  final String wireName = r'InstitutionViewDTO';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    InstitutionViewDTO object, {
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
  }

  @override
  Object serialize(
    Serializers serializers,
    InstitutionViewDTO object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required InstitutionViewDTOBuilder result,
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
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  InstitutionViewDTO deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = InstitutionViewDTOBuilder();
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

