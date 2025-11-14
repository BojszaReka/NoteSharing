//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class InstitutionApi {
  InstitutionApi([ApiClient? apiClient]) : apiClient = apiClient ?? defaultApiClient;

  final ApiClient apiClient;

  /// Retrieves all active institutions.
  ///
  /// Note: This method returns the HTTP [Response].
  Future<Response> apiInstitutionGetWithHttpInfo() async {
    // ignore: prefer_const_declarations
    final path = r'/api/Institution';

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

  /// Retrieves all active institutions.
  Future<void> apiInstitutionGet() async {
    final response = await apiInstitutionGetWithHttpInfo();
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Deletes (sets inactive) an institution record by its unique identifier.
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [String] id (required):
  ///   The unique identifier of the institution to delete.
  Future<Response> apiInstitutionIdDeleteWithHttpInfo(String id,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Institution/{id}'
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

  /// Deletes (sets inactive) an institution record by its unique identifier.
  ///
  /// Parameters:
  ///
  /// * [String] id (required):
  ///   The unique identifier of the institution to delete.
  Future<void> apiInstitutionIdDelete(String id,) async {
    final response = await apiInstitutionIdDeleteWithHttpInfo(id,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Retrieves a specific institution by its unique identifier.
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [String] id (required):
  ///   The unique identifier of the institution to retrieve.
  Future<Response> apiInstitutionIdGetWithHttpInfo(String id,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Institution/{id}'
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

  /// Retrieves a specific institution by its unique identifier.
  ///
  /// Parameters:
  ///
  /// * [String] id (required):
  ///   The unique identifier of the institution to retrieve.
  Future<void> apiInstitutionIdGet(String id,) async {
    final response = await apiInstitutionIdGetWithHttpInfo(id,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Creates a new institution record.
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [InstitutionCreateDTO] institutionCreateDTO:
  ///   The data transfer object containing details of the institution to be created.
  Future<Response> apiInstitutionPostWithHttpInfo({ InstitutionCreateDTO? institutionCreateDTO, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Institution';

    // ignore: prefer_final_locals
    Object? postBody = institutionCreateDTO;

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

  /// Creates a new institution record.
  ///
  /// Parameters:
  ///
  /// * [InstitutionCreateDTO] institutionCreateDTO:
  ///   The data transfer object containing details of the institution to be created.
  Future<void> apiInstitutionPost({ InstitutionCreateDTO? institutionCreateDTO, }) async {
    final response = await apiInstitutionPostWithHttpInfo( institutionCreateDTO: institutionCreateDTO, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Updates an existing institution record.
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [InstitutionViewDTO] institutionViewDTO:
  ///   The institution data transfer object containing updated values.
  Future<Response> apiInstitutionPutWithHttpInfo({ InstitutionViewDTO? institutionViewDTO, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Institution';

    // ignore: prefer_final_locals
    Object? postBody = institutionViewDTO;

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

  /// Updates an existing institution record.
  ///
  /// Parameters:
  ///
  /// * [InstitutionViewDTO] institutionViewDTO:
  ///   The institution data transfer object containing updated values.
  Future<void> apiInstitutionPut({ InstitutionViewDTO? institutionViewDTO, }) async {
    final response = await apiInstitutionPutWithHttpInfo( institutionViewDTO: institutionViewDTO, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }
}
