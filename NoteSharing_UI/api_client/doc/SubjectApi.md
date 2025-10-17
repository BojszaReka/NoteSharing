# openapi.api.SubjectApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiSubjectGet**](SubjectApi.md#apisubjectget) | **GET** /api/Subject | 
[**apiSubjectIdDelete**](SubjectApi.md#apisubjectiddelete) | **DELETE** /api/Subject/{id} | 
[**apiSubjectIdGet**](SubjectApi.md#apisubjectidget) | **GET** /api/Subject/{id} | 
[**apiSubjectPost**](SubjectApi.md#apisubjectpost) | **POST** /api/Subject | 
[**apiSubjectPut**](SubjectApi.md#apisubjectput) | **PUT** /api/Subject | 


# **apiSubjectGet**
> apiSubjectGet()



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getSubjectApi();

try {
    api.apiSubjectGet();
} catch on DioException (e) {
    print('Exception when calling SubjectApi->apiSubjectGet: $e\n');
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

# **apiSubjectIdDelete**
> apiSubjectIdDelete(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getSubjectApi();
final String id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api.apiSubjectIdDelete(id);
} catch on DioException (e) {
    print('Exception when calling SubjectApi->apiSubjectIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiSubjectIdGet**
> apiSubjectIdGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getSubjectApi();
final String id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api.apiSubjectIdGet(id);
} catch on DioException (e) {
    print('Exception when calling SubjectApi->apiSubjectIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiSubjectPost**
> apiSubjectPost(subjectCreateDTO)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getSubjectApi();
final SubjectCreateDTO subjectCreateDTO = ; // SubjectCreateDTO | 

try {
    api.apiSubjectPost(subjectCreateDTO);
} catch on DioException (e) {
    print('Exception when calling SubjectApi->apiSubjectPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **subjectCreateDTO** | [**SubjectCreateDTO**](SubjectCreateDTO.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiSubjectPut**
> apiSubjectPut(subjectViewDTO)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getSubjectApi();
final SubjectViewDTO subjectViewDTO = ; // SubjectViewDTO | 

try {
    api.apiSubjectPut(subjectViewDTO);
} catch on DioException (e) {
    print('Exception when calling SubjectApi->apiSubjectPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **subjectViewDTO** | [**SubjectViewDTO**](SubjectViewDTO.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

