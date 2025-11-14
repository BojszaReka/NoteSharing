//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class NoteApi {
  NoteApi([ApiClient? apiClient]) : apiClient = apiClient ?? defaultApiClient;

  final ApiClient apiClient;

  /// Performs an HTTP 'POST /api/Note/addReview' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [NoteRatingCreateDTO] noteRatingCreateDTO:
  Future<Response> apiNoteAddReviewPostWithHttpInfo({ NoteRatingCreateDTO? noteRatingCreateDTO, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Note/addReview';

    // ignore: prefer_final_locals
    Object? postBody = noteRatingCreateDTO;

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
  /// * [NoteRatingCreateDTO] noteRatingCreateDTO:
  Future<void> apiNoteAddReviewPost({ NoteRatingCreateDTO? noteRatingCreateDTO, }) async {
    final response = await apiNoteAddReviewPostWithHttpInfo( noteRatingCreateDTO: noteRatingCreateDTO, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'POST /api/Note/createNote' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [NoteCreateDTO] noteCreateDTO:
  Future<Response> apiNoteCreateNotePostWithHttpInfo({ NoteCreateDTO? noteCreateDTO, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Note/createNote';

    // ignore: prefer_final_locals
    Object? postBody = noteCreateDTO;

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
  /// * [NoteCreateDTO] noteCreateDTO:
  Future<void> apiNoteCreateNotePost({ NoteCreateDTO? noteCreateDTO, }) async {
    final response = await apiNoteCreateNotePostWithHttpInfo( noteCreateDTO: noteCreateDTO, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'DELETE /api/Note/deleteNote/{id}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] id (required):
  Future<Response> apiNoteDeleteNoteIdDeleteWithHttpInfo(String id,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Note/deleteNote/{id}'
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

  /// Parameters:
  ///
  /// * [String] id (required):
  Future<void> apiNoteDeleteNoteIdDelete(String id,) async {
    final response = await apiNoteDeleteNoteIdDeleteWithHttpInfo(id,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'GET /api/Note/getAllNotes' operation and returns the [Response].
  Future<Response> apiNoteGetAllNotesGetWithHttpInfo() async {
    // ignore: prefer_const_declarations
    final path = r'/api/Note/getAllNotes';

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

  Future<void> apiNoteGetAllNotesGet() async {
    final response = await apiNoteGetAllNotesGetWithHttpInfo();
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'GET /api/Note/getNote/{id}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] id (required):
  Future<Response> apiNoteGetNoteIdGetWithHttpInfo(String id,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Note/getNote/{id}'
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

  /// Parameters:
  ///
  /// * [String] id (required):
  Future<void> apiNoteGetNoteIdGet(String id,) async {
    final response = await apiNoteGetNoteIdGetWithHttpInfo(id,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'PUT /api/Note/modifyNote' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [NoteUpdateDTO] noteUpdateDTO:
  Future<Response> apiNoteModifyNotePutWithHttpInfo({ NoteUpdateDTO? noteUpdateDTO, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Note/modifyNote';

    // ignore: prefer_final_locals
    Object? postBody = noteUpdateDTO;

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
  /// * [NoteUpdateDTO] noteUpdateDTO:
  Future<void> apiNoteModifyNotePut({ NoteUpdateDTO? noteUpdateDTO, }) async {
    final response = await apiNoteModifyNotePutWithHttpInfo( noteUpdateDTO: noteUpdateDTO, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }
}
