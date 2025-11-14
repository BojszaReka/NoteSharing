//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class CollectionsApi {
  CollectionsApi([ApiClient? apiClient]) : apiClient = apiClient ?? defaultApiClient;

  final ApiClient apiClient;

  /// Performs an HTTP 'POST /api/Collections/{collectionId}/addNote/{noteId}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] collectionId (required):
  ///
  /// * [String] noteId (required):
  Future<Response> apiCollectionsCollectionIdAddNoteNoteIdPostWithHttpInfo(String collectionId, String noteId,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Collections/{collectionId}/addNote/{noteId}'
      .replaceAll('{collectionId}', collectionId)
      .replaceAll('{noteId}', noteId);

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
  /// * [String] collectionId (required):
  ///
  /// * [String] noteId (required):
  Future<void> apiCollectionsCollectionIdAddNoteNoteIdPost(String collectionId, String noteId,) async {
    final response = await apiCollectionsCollectionIdAddNoteNoteIdPostWithHttpInfo(collectionId, noteId,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'DELETE /api/Collections/{collectionId}/removeNote/{noteId}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] collectionId (required):
  ///
  /// * [String] noteId (required):
  Future<Response> apiCollectionsCollectionIdRemoveNoteNoteIdDeleteWithHttpInfo(String collectionId, String noteId,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Collections/{collectionId}/removeNote/{noteId}'
      .replaceAll('{collectionId}', collectionId)
      .replaceAll('{noteId}', noteId);

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
  /// * [String] collectionId (required):
  ///
  /// * [String] noteId (required):
  Future<void> apiCollectionsCollectionIdRemoveNoteNoteIdDelete(String collectionId, String noteId,) async {
    final response = await apiCollectionsCollectionIdRemoveNoteNoteIdDeleteWithHttpInfo(collectionId, noteId,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'POST /api/Collections/{collectionId}/setPrivate/{isPrivate}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] collectionId (required):
  ///
  /// * [bool] isPrivate (required):
  Future<Response> apiCollectionsCollectionIdSetPrivateIsPrivatePostWithHttpInfo(String collectionId, bool isPrivate,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Collections/{collectionId}/setPrivate/{isPrivate}'
      .replaceAll('{collectionId}', collectionId)
      .replaceAll('{isPrivate}', isPrivate.toString());

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
  /// * [String] collectionId (required):
  ///
  /// * [bool] isPrivate (required):
  Future<void> apiCollectionsCollectionIdSetPrivateIsPrivatePost(String collectionId, bool isPrivate,) async {
    final response = await apiCollectionsCollectionIdSetPrivateIsPrivatePostWithHttpInfo(collectionId, isPrivate,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'POST /api/Collections/createCollection' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [CollectionCreateDTO] collectionCreateDTO:
  Future<Response> apiCollectionsCreateCollectionPostWithHttpInfo({ CollectionCreateDTO? collectionCreateDTO, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Collections/createCollection';

    // ignore: prefer_final_locals
    Object? postBody = collectionCreateDTO;

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
  /// * [CollectionCreateDTO] collectionCreateDTO:
  Future<void> apiCollectionsCreateCollectionPost({ CollectionCreateDTO? collectionCreateDTO, }) async {
    final response = await apiCollectionsCreateCollectionPostWithHttpInfo( collectionCreateDTO: collectionCreateDTO, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'GET /api/Collections/getCollection/{id}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] id (required):
  Future<Response> apiCollectionsGetCollectionIdGetWithHttpInfo(String id,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Collections/getCollection/{id}'
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
  Future<void> apiCollectionsGetCollectionIdGet(String id,) async {
    final response = await apiCollectionsGetCollectionIdGetWithHttpInfo(id,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'GET /api/Collections/getCollections/{userId}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] userId (required):
  Future<Response> apiCollectionsGetCollectionsUserIdGetWithHttpInfo(String userId,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Collections/getCollections/{userId}'
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
  Future<void> apiCollectionsGetCollectionsUserIdGet(String userId,) async {
    final response = await apiCollectionsGetCollectionsUserIdGetWithHttpInfo(userId,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'PUT /api/Collections/modifyCollection' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [CollectionViewDTO] collectionViewDTO:
  Future<Response> apiCollectionsModifyCollectionPutWithHttpInfo({ CollectionViewDTO? collectionViewDTO, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Collections/modifyCollection';

    // ignore: prefer_final_locals
    Object? postBody = collectionViewDTO;

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
  /// * [CollectionViewDTO] collectionViewDTO:
  Future<void> apiCollectionsModifyCollectionPut({ CollectionViewDTO? collectionViewDTO, }) async {
    final response = await apiCollectionsModifyCollectionPutWithHttpInfo( collectionViewDTO: collectionViewDTO, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }
}
