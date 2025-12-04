# openapi.api.InstitutionApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiInstitutionGet**](InstitutionApi.md#apiinstitutionget) | **GET** /api/Institution | Retrieves all active institutions.
[**apiInstitutionIdDelete**](InstitutionApi.md#apiinstitutioniddelete) | **DELETE** /api/Institution/{id} | Deletes (sets inactive) an institution record by its unique identifier.
[**apiInstitutionIdGet**](InstitutionApi.md#apiinstitutionidget) | **GET** /api/Institution/{id} | Retrieves a specific institution by its unique identifier.
[**apiInstitutionPost**](InstitutionApi.md#apiinstitutionpost) | **POST** /api/Institution | Creates a new institution record.
[**apiInstitutionPut**](InstitutionApi.md#apiinstitutionput) | **PUT** /api/Institution | Updates an existing institution record.


# **apiInstitutionGet**
> apiInstitutionGet()

Retrieves all active institutions.

### Example
```dart
import 'package:openapi/api.dart';

final api_instance = InstitutionApi();

try {
    api_instance.apiInstitutionGet();
} catch (e) {
    print('Exception when calling InstitutionApi->apiInstitutionGet: $e\n');
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiInstitutionIdDelete**
> apiInstitutionIdDelete(id)

Deletes (sets inactive) an institution record by its unique identifier.

### Example
```dart
import 'package:openapi/api.dart';

final api_instance = InstitutionApi();
final id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | The unique identifier of the institution to delete.

try {
    api_instance.apiInstitutionIdDelete(id);
} catch (e) {
    print('Exception when calling InstitutionApi->apiInstitutionIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**| The unique identifier of the institution to delete. | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiInstitutionIdGet**
> apiInstitutionIdGet(id)

Retrieves a specific institution by its unique identifier.

### Example
```dart
import 'package:openapi/api.dart';

final api_instance = InstitutionApi();
final id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | The unique identifier of the institution to retrieve.

try {
    api_instance.apiInstitutionIdGet(id);
} catch (e) {
    print('Exception when calling InstitutionApi->apiInstitutionIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**| The unique identifier of the institution to retrieve. | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiInstitutionPost**
> apiInstitutionPost(institutionCreateDTO)

Creates a new institution record.

### Example
```dart
import 'package:openapi/api.dart';

final api_instance = InstitutionApi();
final institutionCreateDTO = InstitutionCreateDTO(); // InstitutionCreateDTO | The data transfer object containing details of the institution to be created.

try {
    api_instance.apiInstitutionPost(institutionCreateDTO);
} catch (e) {
    print('Exception when calling InstitutionApi->apiInstitutionPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **institutionCreateDTO** | [**InstitutionCreateDTO**](InstitutionCreateDTO.md)| The data transfer object containing details of the institution to be created. | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiInstitutionPut**
> apiInstitutionPut(institutionViewDTO)

Updates an existing institution record.

### Example
```dart
import 'package:openapi/api.dart';

final api_instance = InstitutionApi();
final institutionViewDTO = InstitutionViewDTO(); // InstitutionViewDTO | The institution data transfer object containing updated values.

try {
    api_instance.apiInstitutionPut(institutionViewDTO);
} catch (e) {
    print('Exception when calling InstitutionApi->apiInstitutionPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **institutionViewDTO** | [**InstitutionViewDTO**](InstitutionViewDTO.md)| The institution data transfer object containing updated values. | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

