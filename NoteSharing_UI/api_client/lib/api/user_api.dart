//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class UserApi {
  UserApi([ApiClient? apiClient]) : apiClient = apiClient ?? defaultApiClient;

  final ApiClient apiClient;

  /// Adds a one sided following relationship between two users.
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [UserFollowDTO] userFollowDTO:
  ///   The user follow data transfer object.    <b>Properties of class_library.DTO.UserFollowDTO:</b><list type=\"bullet\"><item><description>`FollowerUserID` (System.Guid): The unique identifier of the user who is following.</description></item><item><description>`FollowingUserID` (System.Guid): The unique identifier of the user being followed.</description></item></list>
  Future<Response> apiUserFollowPostWithHttpInfo({ UserFollowDTO? userFollowDTO, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/User/follow';

    // ignore: prefer_final_locals
    Object? postBody = userFollowDTO;

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

  /// Adds a one sided following relationship between two users.
  ///
  /// Parameters:
  ///
  /// * [UserFollowDTO] userFollowDTO:
  ///   The user follow data transfer object.    <b>Properties of class_library.DTO.UserFollowDTO:</b><list type=\"bullet\"><item><description>`FollowerUserID` (System.Guid): The unique identifier of the user who is following.</description></item><item><description>`FollowingUserID` (System.Guid): The unique identifier of the user being followed.</description></item></list>
  Future<void> apiUserFollowPost({ UserFollowDTO? userFollowDTO, }) async {
    final response = await apiUserFollowPostWithHttpInfo( userFollowDTO: userFollowDTO, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Deletes a user by their unique identifier.
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [String] id (required):
  ///   The unique identifier of the user to delete.
  Future<Response> apiUserIdDeleteWithHttpInfo(String id,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/User/{id}'
      .replaceAll('{id}', id);

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    const contentTypes = <String>[];


    return apiClient.invokeAPI(
      path,
      'DELETE',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Deletes a user by their unique identifier.
  ///
  /// Parameters:
  ///
  /// * [String] id (required):
  ///   The unique identifier of the user to delete.
  Future<void> apiUserIdDelete(String id,) async {
    final response = await apiUserIdDeleteWithHttpInfo(id,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Retrieves a user by their unique identifier.
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [String] id (required):
  ///   The unique identifier of the user.
  Future<Response> apiUserIdIdGetWithHttpInfo(String id,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/User/id/{id}'
      .replaceAll('{id}', id);

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

  /// Retrieves a user by their unique identifier.
  ///
  /// Parameters:
  ///
  /// * [String] id (required):
  ///   The unique identifier of the user.
  Future<void> apiUserIdIdGet(String id,) async {
    final response = await apiUserIdIdGetWithHttpInfo(id,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// This endpoint is for adding additional user information or modifying the existing one.  Only the fields in class_library.DTO.UserUpdateDTO that are provided (not null) will be updated; all others will remain unchanged.  The `ID` field is required to identify the user to update.
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [UserUpdateDTO] userUpdateDTO:
  ///   The user update data transfer object. Except for `ID`, all properties should be null unless they are to be changed.
  Future<Response> apiUserPutWithHttpInfo({ UserUpdateDTO? userUpdateDTO, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/User';

    // ignore: prefer_final_locals
    Object? postBody = userUpdateDTO;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    const contentTypes = <String>['application/json', 'application/json-patch+json', 'text/json', 'application/*+json'];


    return apiClient.invokeAPI(
      path,
      'PUT',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// This endpoint is for adding additional user information or modifying the existing one.  Only the fields in class_library.DTO.UserUpdateDTO that are provided (not null) will be updated; all others will remain unchanged.  The `ID` field is required to identify the user to update.
  ///
  /// Parameters:
  ///
  /// * [UserUpdateDTO] userUpdateDTO:
  ///   The user update data transfer object. Except for `ID`, all properties should be null unless they are to be changed.
  Future<void> apiUserPut({ UserUpdateDTO? userUpdateDTO, }) async {
    final response = await apiUserPutWithHttpInfo( userUpdateDTO: userUpdateDTO, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Retrieves a user by their username.
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [String] userName (required):
  ///   The username of the user.
  Future<Response> apiUserUsernameUserNameGetWithHttpInfo(String userName,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/User/username/{userName}'
      .replaceAll('{userName}', userName);

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

  /// Retrieves a user by their username.
  ///
  /// Parameters:
  ///
  /// * [String] userName (required):
  ///   The username of the user.
  Future<void> apiUserUsernameUserNameGet(String userName,) async {
    final response = await apiUserUsernameUserNameGetWithHttpInfo(userName,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }
}
