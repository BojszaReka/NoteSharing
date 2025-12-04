//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

import 'dart:async';

import 'package:built_value/json_object.dart';
import 'package:built_value/serializer.dart';
import 'package:dio/dio.dart';

import 'package:openapi/src/model/login_dto.dart';
import 'package:openapi/src/model/refresh_token_dto.dart';
import 'package:openapi/src/model/register_dto.dart';

class AuthApi {

  final Dio _dio;

  final Serializers _serializers;

  const AuthApi(this._dio, this._serializers);

  /// Authenticates a user using their email and password.      Required fields in class_library.DTO.LoginDTO:&lt;list type&#x3D;\&quot;bullet\&quot;&gt;&lt;item&gt;&lt;description&gt;&lt;b&gt;Email&lt;/b&gt;: string, must be a valid email address (required)&lt;/description&gt;&lt;/item&gt;&lt;item&gt;&lt;description&gt;&lt;b&gt;Password&lt;/b&gt;: string (required)&lt;/description&gt;&lt;/item&gt;&lt;/list&gt;
  /// 
  ///
  /// Parameters:
  /// * [loginDTO] - The login credentials for the user.
  /// * [cancelToken] - A [CancelToken] that can be used to cancel the operation
  /// * [headers] - Can be used to add additional headers to the request
  /// * [extras] - Can be used to add flags to the request
  /// * [validateStatus] - A [ValidateStatus] callback that can be used to determine request success based on the HTTP status of the response
  /// * [onSendProgress] - A [ProgressCallback] that can be used to get the send progress
  /// * [onReceiveProgress] - A [ProgressCallback] that can be used to get the receive progress
  ///
  /// Returns a [Future]
  /// Throws [DioException] if API call or serialization fails
  Future<Response<void>> apiAuthLoginPost({ 
    LoginDTO? loginDTO,
    CancelToken? cancelToken,
    Map<String, dynamic>? headers,
    Map<String, dynamic>? extra,
    ValidateStatus? validateStatus,
    ProgressCallback? onSendProgress,
    ProgressCallback? onReceiveProgress,
  }) async {
    final _path = r'/api/Auth/login';
    final _options = Options(
      method: r'POST',
      headers: <String, dynamic>{
        ...?headers,
      },
      extra: <String, dynamic>{
        'secure': <Map<String, String>>[],
        ...?extra,
      },
      contentType: 'application/json',
      validateStatus: validateStatus,
    );

    dynamic _bodyData;

    try {
      const _type = FullType(LoginDTO);
      _bodyData = loginDTO == null ? null : _serializers.serialize(loginDTO, specifiedType: _type);

    } catch(error, stackTrace) {
      throw DioException(
         requestOptions: _options.compose(
          _dio.options,
          _path,
        ),
        type: DioExceptionType.unknown,
        error: error,
        stackTrace: stackTrace,
      );
    }

    final _response = await _dio.request<Object>(
      _path,
      data: _bodyData,
      options: _options,
      cancelToken: cancelToken,
      onSendProgress: onSendProgress,
      onReceiveProgress: onReceiveProgress,
    );

    return _response;
  }

  /// Refreshes the user&#39;s authentication tokens using a valid refresh token.      Required field in class_library.DTO.RefreshTokenDTO:&lt;list type&#x3D;\&quot;bullet\&quot;&gt;&lt;item&gt;&lt;description&gt;&lt;b&gt;RefreshToken&lt;/b&gt;: string (required)&lt;/description&gt;&lt;/item&gt;&lt;/list&gt;
  /// 
  ///
  /// Parameters:
  /// * [refreshTokenDTO] - The refresh token data for the user.
  /// * [cancelToken] - A [CancelToken] that can be used to cancel the operation
  /// * [headers] - Can be used to add additional headers to the request
  /// * [extras] - Can be used to add flags to the request
  /// * [validateStatus] - A [ValidateStatus] callback that can be used to determine request success based on the HTTP status of the response
  /// * [onSendProgress] - A [ProgressCallback] that can be used to get the send progress
  /// * [onReceiveProgress] - A [ProgressCallback] that can be used to get the receive progress
  ///
  /// Returns a [Future]
  /// Throws [DioException] if API call or serialization fails
  Future<Response<void>> apiAuthRefreshPost({ 
    RefreshTokenDTO? refreshTokenDTO,
    CancelToken? cancelToken,
    Map<String, dynamic>? headers,
    Map<String, dynamic>? extra,
    ValidateStatus? validateStatus,
    ProgressCallback? onSendProgress,
    ProgressCallback? onReceiveProgress,
  }) async {
    final _path = r'/api/Auth/refresh';
    final _options = Options(
      method: r'POST',
      headers: <String, dynamic>{
        ...?headers,
      },
      extra: <String, dynamic>{
        'secure': <Map<String, String>>[],
        ...?extra,
      },
      contentType: 'application/json',
      validateStatus: validateStatus,
    );

    dynamic _bodyData;

    try {
      const _type = FullType(RefreshTokenDTO);
      _bodyData = refreshTokenDTO == null ? null : _serializers.serialize(refreshTokenDTO, specifiedType: _type);

    } catch(error, stackTrace) {
      throw DioException(
         requestOptions: _options.compose(
          _dio.options,
          _path,
        ),
        type: DioExceptionType.unknown,
        error: error,
        stackTrace: stackTrace,
      );
    }

    final _response = await _dio.request<Object>(
      _path,
      data: _bodyData,
      options: _options,
      cancelToken: cancelToken,
      onSendProgress: onSendProgress,
      onReceiveProgress: onReceiveProgress,
    );

    return _response;
  }

  /// Registers a new user with basic credentials (Name, Email, Password).  This endpoint is intended for simple user registration and does not accept additional user data.  To add more user information, use a different endpoint.      Required fields in class_library.DTO.RegisterDTO:&lt;list type&#x3D;\&quot;bullet\&quot;&gt;&lt;item&gt;&lt;description&gt;&lt;b&gt;UserName&lt;/b&gt;: string (required)&lt;/description&gt;&lt;/item&gt;&lt;item&gt;&lt;description&gt;&lt;b&gt;Email&lt;/b&gt;: string, must be a valid email address (required)&lt;/description&gt;&lt;/item&gt;&lt;item&gt;&lt;description&gt;&lt;b&gt;Password&lt;/b&gt;: string (required)&lt;/description&gt;&lt;/item&gt;&lt;/list&gt;
  /// 
  ///
  /// Parameters:
  /// * [registerDTO] - The registration data for the new user.
  /// * [cancelToken] - A [CancelToken] that can be used to cancel the operation
  /// * [headers] - Can be used to add additional headers to the request
  /// * [extras] - Can be used to add flags to the request
  /// * [validateStatus] - A [ValidateStatus] callback that can be used to determine request success based on the HTTP status of the response
  /// * [onSendProgress] - A [ProgressCallback] that can be used to get the send progress
  /// * [onReceiveProgress] - A [ProgressCallback] that can be used to get the receive progress
  ///
  /// Returns a [Future]
  /// Throws [DioException] if API call or serialization fails
  Future<Response<void>> apiAuthRegisterPost({ 
    RegisterDTO? registerDTO,
    CancelToken? cancelToken,
    Map<String, dynamic>? headers,
    Map<String, dynamic>? extra,
    ValidateStatus? validateStatus,
    ProgressCallback? onSendProgress,
    ProgressCallback? onReceiveProgress,
  }) async {
    final _path = r'/api/Auth/register';
    final _options = Options(
      method: r'POST',
      headers: <String, dynamic>{
        ...?headers,
      },
      extra: <String, dynamic>{
        'secure': <Map<String, String>>[],
        ...?extra,
      },
      contentType: 'application/json',
      validateStatus: validateStatus,
    );

    dynamic _bodyData;

    try {
      const _type = FullType(RegisterDTO);
      _bodyData = registerDTO == null ? null : _serializers.serialize(registerDTO, specifiedType: _type);

    } catch(error, stackTrace) {
      throw DioException(
         requestOptions: _options.compose(
          _dio.options,
          _path,
        ),
        type: DioExceptionType.unknown,
        error: error,
        stackTrace: stackTrace,
      );
    }

    final _response = await _dio.request<Object>(
      _path,
      data: _bodyData,
      options: _options,
      cancelToken: cancelToken,
      onSendProgress: onSendProgress,
      onReceiveProgress: onReceiveProgress,
    );

    return _response;
  }

  /// Test endpoint to confirm if the authentication mechanism is working.      This endpoint requires a valid JWT access token in the Authorization header.  If the token is valid, it returns basic user details extracted from the token.
  /// &lt;b&gt;Authorization:&lt;/b&gt; Bearer token required.  &lt;b&gt;Response:&lt;/b&gt;&lt;list type&#x3D;\&quot;bullet\&quot;&gt;&lt;item&gt;&lt;description&gt;&lt;b&gt;message&lt;/b&gt;: Confirmation that authentication is successful.&lt;/description&gt;&lt;/item&gt;&lt;item&gt;&lt;description&gt;&lt;b&gt;userDetails&lt;/b&gt;: Object containing &#x60;id&#x60;, &#x60;name&#x60;, &#x60;email&#x60;, and &#x60;role&#x60; from the token claims.&lt;/description&gt;&lt;/item&gt;&lt;/list&gt;
  ///
  /// Parameters:
  /// * [cancelToken] - A [CancelToken] that can be used to cancel the operation
  /// * [headers] - Can be used to add additional headers to the request
  /// * [extras] - Can be used to add flags to the request
  /// * [validateStatus] - A [ValidateStatus] callback that can be used to determine request success based on the HTTP status of the response
  /// * [onSendProgress] - A [ProgressCallback] that can be used to get the send progress
  /// * [onReceiveProgress] - A [ProgressCallback] that can be used to get the receive progress
  ///
  /// Returns a [Future]
  /// Throws [DioException] if API call or serialization fails
  Future<Response<void>> apiAuthTestGet({ 
    CancelToken? cancelToken,
    Map<String, dynamic>? headers,
    Map<String, dynamic>? extra,
    ValidateStatus? validateStatus,
    ProgressCallback? onSendProgress,
    ProgressCallback? onReceiveProgress,
  }) async {
    final _path = r'/api/Auth/test';
    final _options = Options(
      method: r'GET',
      headers: <String, dynamic>{
        ...?headers,
      },
      extra: <String, dynamic>{
        'secure': <Map<String, String>>[],
        ...?extra,
      },
      validateStatus: validateStatus,
    );

    final _response = await _dio.request<Object>(
      _path,
      options: _options,
      cancelToken: cancelToken,
      onSendProgress: onSendProgress,
      onReceiveProgress: onReceiveProgress,
    );

    return _response;
  }

}
