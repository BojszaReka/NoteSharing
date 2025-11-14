# openapi.api.NoteRequestApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiNoteRequestAddAnswerPost**](NoteRequestApi.md#apinoterequestaddanswerpost) | **POST** /api/NoteRequest/addAnswer | 
[**apiNoteRequestChangeAnswerStatusAnswerIdNewStatusPost**](NoteRequestApi.md#apinoterequestchangeanswerstatusansweridnewstatuspost) | **POST** /api/NoteRequest/changeAnswerStatus/{answerId}/{newStatus} | 
[**apiNoteRequestChangeRequestStatusRequestIdNewStatusPost**](NoteRequestApi.md#apinoterequestchangerequeststatusrequestidnewstatuspost) | **POST** /api/NoteRequest/changeRequestStatus/{requestId}/{newStatus} | 
[**apiNoteRequestCreateRequestPost**](NoteRequestApi.md#apinoterequestcreaterequestpost) | **POST** /api/NoteRequest/createRequest | 
[**apiNoteRequestGetRelevantRequestUserIdGet**](NoteRequestApi.md#apinoterequestgetrelevantrequestuseridget) | **GET** /api/NoteRequest/getRelevantRequest/{userId} | 
[**apiNoteRequestGetRequestUserIdGet**](NoteRequestApi.md#apinoterequestgetrequestuseridget) | **GET** /api/NoteRequest/getRequest/{userId} | 
[**apiNoteRequestModifyRequestPut**](NoteRequestApi.md#apinoterequestmodifyrequestput) | **PUT** /api/NoteRequest/modifyRequest | 
[**apiNoteRequestViewAnswersByNoteNoteIdGet**](NoteRequestApi.md#apinoterequestviewanswersbynotenoteidget) | **GET** /api/NoteRequest/viewAnswers/byNote/{noteId} | 
[**apiNoteRequestViewAnswersByUserUserIdGet**](NoteRequestApi.md#apinoterequestviewanswersbyuseruseridget) | **GET** /api/NoteRequest/viewAnswers/byUser/{userId} | 


# **apiNoteRequestAddAnswerPost**
> apiNoteRequestAddAnswerPost(noteRequestAnswerCreateDTO)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = NoteRequestApi();
final noteRequestAnswerCreateDTO = NoteRequestAnswerCreateDTO(); // NoteRequestAnswerCreateDTO | 

try {
    api_instance.apiNoteRequestAddAnswerPost(noteRequestAnswerCreateDTO);
} catch (e) {
    print('Exception when calling NoteRequestApi->apiNoteRequestAddAnswerPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **noteRequestAnswerCreateDTO** | [**NoteRequestAnswerCreateDTO**](NoteRequestAnswerCreateDTO.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiNoteRequestChangeAnswerStatusAnswerIdNewStatusPost**
> apiNoteRequestChangeAnswerStatusAnswerIdNewStatusPost(answerId, newStatus)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = NoteRequestApi();
final answerId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
final newStatus = ; // EAnswerStatus | 

try {
    api_instance.apiNoteRequestChangeAnswerStatusAnswerIdNewStatusPost(answerId, newStatus);
} catch (e) {
    print('Exception when calling NoteRequestApi->apiNoteRequestChangeAnswerStatusAnswerIdNewStatusPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **answerId** | **String**|  | 
 **newStatus** | [**EAnswerStatus**](.md)|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiNoteRequestChangeRequestStatusRequestIdNewStatusPost**
> apiNoteRequestChangeRequestStatusRequestIdNewStatusPost(requestId, newStatus)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = NoteRequestApi();
final requestId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
final newStatus = ; // ERequestStatus | 

try {
    api_instance.apiNoteRequestChangeRequestStatusRequestIdNewStatusPost(requestId, newStatus);
} catch (e) {
    print('Exception when calling NoteRequestApi->apiNoteRequestChangeRequestStatusRequestIdNewStatusPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **requestId** | **String**|  | 
 **newStatus** | [**ERequestStatus**](.md)|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiNoteRequestCreateRequestPost**
> apiNoteRequestCreateRequestPost(noteRequestCreateDTO)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = NoteRequestApi();
final noteRequestCreateDTO = NoteRequestCreateDTO(); // NoteRequestCreateDTO | 

try {
    api_instance.apiNoteRequestCreateRequestPost(noteRequestCreateDTO);
} catch (e) {
    print('Exception when calling NoteRequestApi->apiNoteRequestCreateRequestPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **noteRequestCreateDTO** | [**NoteRequestCreateDTO**](NoteRequestCreateDTO.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiNoteRequestGetRelevantRequestUserIdGet**
> apiNoteRequestGetRelevantRequestUserIdGet(userId)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = NoteRequestApi();
final userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiNoteRequestGetRelevantRequestUserIdGet(userId);
} catch (e) {
    print('Exception when calling NoteRequestApi->apiNoteRequestGetRelevantRequestUserIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiNoteRequestGetRequestUserIdGet**
> apiNoteRequestGetRequestUserIdGet(userId)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = NoteRequestApi();
final userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiNoteRequestGetRequestUserIdGet(userId);
} catch (e) {
    print('Exception when calling NoteRequestApi->apiNoteRequestGetRequestUserIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiNoteRequestModifyRequestPut**
> apiNoteRequestModifyRequestPut(noteRequestViewDTO)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = NoteRequestApi();
final noteRequestViewDTO = NoteRequestViewDTO(); // NoteRequestViewDTO | 

try {
    api_instance.apiNoteRequestModifyRequestPut(noteRequestViewDTO);
} catch (e) {
    print('Exception when calling NoteRequestApi->apiNoteRequestModifyRequestPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **noteRequestViewDTO** | [**NoteRequestViewDTO**](NoteRequestViewDTO.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiNoteRequestViewAnswersByNoteNoteIdGet**
> apiNoteRequestViewAnswersByNoteNoteIdGet(noteId)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = NoteRequestApi();
final noteId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiNoteRequestViewAnswersByNoteNoteIdGet(noteId);
} catch (e) {
    print('Exception when calling NoteRequestApi->apiNoteRequestViewAnswersByNoteNoteIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **noteId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiNoteRequestViewAnswersByUserUserIdGet**
> apiNoteRequestViewAnswersByUserUserIdGet(userId)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = NoteRequestApi();
final userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiNoteRequestViewAnswersByUserUserIdGet(userId);
} catch (e) {
    print('Exception when calling NoteRequestApi->apiNoteRequestViewAnswersByUserUserIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

