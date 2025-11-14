//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_import

import 'package:one_of_serializer/any_of_serializer.dart';
import 'package:one_of_serializer/one_of_serializer.dart';
import 'package:built_collection/built_collection.dart';
import 'package:built_value/json_object.dart';
import 'package:built_value/serializer.dart';
import 'package:built_value/standard_json_plugin.dart';
import 'package:built_value/iso_8601_date_time_serializer.dart';
import 'package:openapi/src/date_serializer.dart';
import 'package:openapi/src/model/date.dart';

import 'package:openapi/src/model/e_user_type.dart';
import 'package:openapi/src/model/institution_create_dto.dart';
import 'package:openapi/src/model/institution_view_dto.dart';
import 'package:openapi/src/model/login_dto.dart';
import 'package:openapi/src/model/preference_view_dto.dart';
import 'package:openapi/src/model/refresh_token_dto.dart';
import 'package:openapi/src/model/register_dto.dart';
import 'package:openapi/src/model/subject_create_dto.dart';
import 'package:openapi/src/model/subject_view_dto.dart';
import 'package:openapi/src/model/user_follow_dto.dart';
import 'package:openapi/src/model/user_update_dto.dart';

part 'serializers.g.dart';

@SerializersFor([
  EUserType,
  InstitutionCreateDTO,
  InstitutionViewDTO,
  LoginDTO,
  PreferenceViewDTO,
  RefreshTokenDTO,
  RegisterDTO,
  SubjectCreateDTO,
  SubjectViewDTO,
  UserFollowDTO,
  UserUpdateDTO,
])
Serializers serializers = (_$serializers.toBuilder()
      ..add(const OneOfSerializer())
      ..add(const AnyOfSerializer())
      ..add(const DateSerializer())
      ..add(Iso8601DateTimeSerializer())
    ).build();

Serializers standardSerializers =
    (serializers.toBuilder()..addPlugin(StandardJsonPlugin())).build();
