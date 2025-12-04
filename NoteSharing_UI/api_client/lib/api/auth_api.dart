//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class AuthApi {
  AuthApi([ApiClient? apiClient]) : apiClient = apiClient ?? defaultApiClient;

  final ApiClient apiClient;

  /// Authenticates a user using their email and password.      Required fields in class_library.DTO.LoginDTO:<list type=\"bullet\"><item><description><b>Email</b>: string, must be a valid email address (required)</description></item><item><description><b>Password</b>: string (required)</description></item></list>
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [LoginDTO] loginDTO:
  ///   The login credentials for the user.
  Future<Response> apiAuthLoginPostWithHttpInfo({ LoginDTO? loginDTO, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Auth/login';

    // ignore: prefer_final_locals
    Object? postBody = loginDTO;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    const contentTypes = <String>['application/json', 'application/json-patch+json', 'text/json', 'application/*+json'];


    return apiClient.invokeAPI(
      path,
      'POST',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Authenticates a user using their email and password.      Required fields in class_library.DTO.LoginDTO:<list type=\"bullet\"><item><description><b>Email</b>: string, must be a valid email address (required)</description></item><item><description><b>Password</b>: string (required)</description></item></list>
  ///
  /// Parameters:
  ///
  /// * [LoginDTO] loginDTO:
  ///   The login credentials for the user.
  Future<void> apiAuthLoginPost({ LoginDTO? loginDTO, }) async {
    final response = await apiAuthLoginPostWithHttpInfo( loginDTO: loginDTO, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Refreshes the user's authentication tokens using a valid refresh token.      Required field in class_library.DTO.RefreshTokenDTO:<list type=\"bullet\"><item><description><b>RefreshToken</b>: string (required)</description></item></list>
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [RefreshTokenDTO] refreshTokenDTO:
  ///   The refresh token data for the user.
  Future<Response> apiAuthRefreshPostWithHttpInfo({ RefreshTokenDTO? refreshTokenDTO, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Auth/refresh';

    // ignore: prefer_final_locals
    Object? postBody = refreshTokenDTO;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    const contentTypes = <String>['application/json', 'application/json-patch+json', 'text/json', 'application/*+json'];


    return apiClient.invokeAPI(
      path,
      'POST',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Refreshes the user's authentication tokens using a valid refresh token.      Required field in class_library.DTO.RefreshTokenDTO:<list type=\"bullet\"><item><description><b>RefreshToken</b>: string (required)</description></item></list>
  ///
  /// Parameters:
  ///
  /// * [RefreshTokenDTO] refreshTokenDTO:
  ///   The refresh token data for the user.
  Future<void> apiAuthRefreshPost({ RefreshTokenDTO? refreshTokenDTO, }) async {
    final response = await apiAuthRefreshPostWithHttpInfo( refreshTokenDTO: refreshTokenDTO, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Registers a new user with basic credentials (Name, Email, Password).  This endpoint is intended for simple user registration and does not accept additional user data.  To add more user information, use a different endpoint.      Required fields in class_library.DTO.RegisterDTO:<list type=\"bullet\"><item><description><b>UserName</b>: string (required)</description></item><item><description><b>Email</b>: string, must be a valid email address (required)</description></item><item><description><b>Password</b>: string (required)</description></item></list>
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [RegisterDTO] registerDTO:
  ///   The registration data for the new user.
  Future<Response> apiAuthRegisterPostWithHttpInfo({ RegisterDTO? registerDTO, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Auth/register';

    // ignore: prefer_final_locals
    Object? postBody = registerDTO;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    const contentTypes = <String>['application/json', 'application/json-patch+json', 'text/json', 'application/*+json'];


    return apiClient.invokeAPI(
      path,
      'POST',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Registers a new user with basic credentials (Name, Email, Password).  This endpoint is intended for simple user registration and does not accept additional user data.  To add more user information, use a different endpoint.      Required fields in class_library.DTO.RegisterDTO:<list type=\"bullet\"><item><description><b>UserName</b>: string (required)</description></item><item><description><b>Email</b>: string, must be a valid email address (required)</description></item><item><description><b>Password</b>: string (required)</description></item></list>
  ///
  /// Parameters:
  ///
  /// * [RegisterDTO] registerDTO:
  ///   The registration data for the new user.
  Future<void> apiAuthRegisterPost({ RegisterDTO? registerDTO, }) async {
    final response = await apiAuthRegisterPostWithHttpInfo( registerDTO: registerDTO, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Test endpoint to confirm if the authentication mechanism is working.      This endpoint requires a valid JWT access token in the Authorization header.  If the token is valid, it returns basic user details extracted from the token.
  ///
  /// <b>Authorization:</b> Bearer token required.  <b>Response:</b><list type=\"bullet\"><item><description><b>message</b>: Confirmation that authentication is successful.</description></item><item><description><b>userDetails</b>: Object containing `id`, `name`, `email`, and `role` from the token claims.</description></item></list>
  ///
  /// Note: This method returns the HTTP [Response].
  Future<Response> apiAuthTestGetWithHttpInfo() async {
    // ignore: prefer_const_declarations
    final path = r'/api/Auth/test';

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    const contentTypes = <String>[];


    return apiClient.invokeAPI(
      path,
      'GET',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Test endpoint to confirm if the authentication mechanism is working.      This endpoint requires a valid JWT access token in the Authorization header.  If the token is valid, it returns basic user details extracted from the token.
  ///
  /// <b>Authorization:</b> Bearer token required.  <b>Response:</b><list type=\"bullet\"><item><description><b>message</b>: Confirmation that authentication is successful.</description></item><item><description><b>userDetails</b>: Object containing `id`, `name`, `email`, and `role` from the token claims.</description></item></list>
  Future<void> apiAuthTestGet() async {
    final response = await apiAuthTestGetWithHttpInfo();
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }
}
