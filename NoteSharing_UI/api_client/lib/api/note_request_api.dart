//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class NoteRequestApi {
  NoteRequestApi([ApiClient? apiClient]) : apiClient = apiClient ?? defaultApiClient;

  final ApiClient apiClient;

  /// Performs an HTTP 'POST /api/NoteRequest/addAnswer' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [NoteRequestAnswerCreateDTO] noteRequestAnswerCreateDTO:
  Future<Response> apiNoteRequestAddAnswerPostWithHttpInfo({ NoteRequestAnswerCreateDTO? noteRequestAnswerCreateDTO, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/NoteRequest/addAnswer';

    // ignore: prefer_final_locals
    Object? postBody = noteRequestAnswerCreateDTO;

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

  /// Parameters:
  ///
  /// * [NoteRequestAnswerCreateDTO] noteRequestAnswerCreateDTO:
  Future<void> apiNoteRequestAddAnswerPost({ NoteRequestAnswerCreateDTO? noteRequestAnswerCreateDTO, }) async {
    final response = await apiNoteRequestAddAnswerPostWithHttpInfo( noteRequestAnswerCreateDTO: noteRequestAnswerCreateDTO, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'POST /api/NoteRequest/changeAnswerStatus/{answerId}/{newStatus}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] answerId (required):
  ///
  /// * [EAnswerStatus] newStatus (required):
  Future<Response> apiNoteRequestChangeAnswerStatusAnswerIdNewStatusPostWithHttpInfo(String answerId, EAnswerStatus newStatus,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/NoteRequest/changeAnswerStatus/{answerId}/{newStatus}'
      .replaceAll('{answerId}', answerId)
      .replaceAll('{newStatus}', newStatus.toString());

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    const contentTypes = <String>[];


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

  /// Parameters:
  ///
  /// * [String] answerId (required):
  ///
  /// * [EAnswerStatus] newStatus (required):
  Future<void> apiNoteRequestChangeAnswerStatusAnswerIdNewStatusPost(String answerId, EAnswerStatus newStatus,) async {
    final response = await apiNoteRequestChangeAnswerStatusAnswerIdNewStatusPostWithHttpInfo(answerId, newStatus,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'POST /api/NoteRequest/changeRequestStatus/{requestId}/{newStatus}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] requestId (required):
  ///
  /// * [ERequestStatus] newStatus (required):
  Future<Response> apiNoteRequestChangeRequestStatusRequestIdNewStatusPostWithHttpInfo(String requestId, ERequestStatus newStatus,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/NoteRequest/changeRequestStatus/{requestId}/{newStatus}'
      .replaceAll('{requestId}', requestId)
      .replaceAll('{newStatus}', newStatus.toString());

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    const contentTypes = <String>[];


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

  /// Parameters:
  ///
  /// * [String] requestId (required):
  ///
  /// * [ERequestStatus] newStatus (required):
  Future<void> apiNoteRequestChangeRequestStatusRequestIdNewStatusPost(String requestId, ERequestStatus newStatus,) async {
    final response = await apiNoteRequestChangeRequestStatusRequestIdNewStatusPostWithHttpInfo(requestId, newStatus,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'POST /api/NoteRequest/createRequest' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [NoteRequestCreateDTO] noteRequestCreateDTO:
  Future<Response> apiNoteRequestCreateRequestPostWithHttpInfo({ NoteRequestCreateDTO? noteRequestCreateDTO, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/NoteRequest/createRequest';

    // ignore: prefer_final_locals
    Object? postBody = noteRequestCreateDTO;

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

  /// Parameters:
  ///
  /// * [NoteRequestCreateDTO] noteRequestCreateDTO:
  Future<void> apiNoteRequestCreateRequestPost({ NoteRequestCreateDTO? noteRequestCreateDTO, }) async {
    final response = await apiNoteRequestCreateRequestPostWithHttpInfo( noteRequestCreateDTO: noteRequestCreateDTO, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'GET /api/NoteRequest/getRelevantRequest/{userId}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] userId (required):
  Future<Response> apiNoteRequestGetRelevantRequestUserIdGetWithHttpInfo(String userId,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/NoteRequest/getRelevantRequest/{userId}'
      .replaceAll('{userId}', userId);

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

  /// Parameters:
  ///
  /// * [String] userId (required):
  Future<void> apiNoteRequestGetRelevantRequestUserIdGet(String userId,) async {
    final response = await apiNoteRequestGetRelevantRequestUserIdGetWithHttpInfo(userId,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'GET /api/NoteRequest/getRequest/{userId}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] userId (required):
  Future<Response> apiNoteRequestGetRequestUserIdGetWithHttpInfo(String userId,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/NoteRequest/getRequest/{userId}'
      .replaceAll('{userId}', userId);

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

  /// Parameters:
  ///
  /// * [String] userId (required):
  Future<void> apiNoteRequestGetRequestUserIdGet(String userId,) async {
    final response = await apiNoteRequestGetRequestUserIdGetWithHttpInfo(userId,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'PUT /api/NoteRequest/modifyRequest' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [NoteRequestViewDTO] noteRequestViewDTO:
  Future<Response> apiNoteRequestModifyRequestPutWithHttpInfo({ NoteRequestViewDTO? noteRequestViewDTO, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/NoteRequest/modifyRequest';

    // ignore: prefer_final_locals
    Object? postBody = noteRequestViewDTO;

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

  /// Parameters:
  ///
  /// * [NoteRequestViewDTO] noteRequestViewDTO:
  Future<void> apiNoteRequestModifyRequestPut({ NoteRequestViewDTO? noteRequestViewDTO, }) async {
    final response = await apiNoteRequestModifyRequestPutWithHttpInfo( noteRequestViewDTO: noteRequestViewDTO, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'GET /api/NoteRequest/viewAnswers/byNote/{noteId}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] noteId (required):
  Future<Response> apiNoteRequestViewAnswersByNoteNoteIdGetWithHttpInfo(String noteId,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/NoteRequest/viewAnswers/byNote/{noteId}'
      .replaceAll('{noteId}', noteId);

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

  /// Parameters:
  ///
  /// * [String] noteId (required):
  Future<void> apiNoteRequestViewAnswersByNoteNoteIdGet(String noteId,) async {
    final response = await apiNoteRequestViewAnswersByNoteNoteIdGetWithHttpInfo(noteId,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'GET /api/NoteRequest/viewAnswers/byUser/{userId}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] userId (required):
  Future<Response> apiNoteRequestViewAnswersByUserUserIdGetWithHttpInfo(String userId,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/NoteRequest/viewAnswers/byUser/{userId}'
      .replaceAll('{userId}', userId);

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

  /// Parameters:
  ///
  /// * [String] userId (required):
  Future<void> apiNoteRequestViewAnswersByUserUserIdGet(String userId,) async {
    final response = await apiNoteRequestViewAnswersByUserUserIdGetWithHttpInfo(userId,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }
}
