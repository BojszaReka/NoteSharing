# openapi.api.NoteApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiNoteAddReviewPost**](NoteApi.md#apinoteaddreviewpost) | **POST** /api/Note/addReview | 
[**apiNoteCreateNotePost**](NoteApi.md#apinotecreatenotepost) | **POST** /api/Note/createNote | 
[**apiNoteDeleteNoteIdDelete**](NoteApi.md#apinotedeletenoteiddelete) | **DELETE** /api/Note/deleteNote/{id} | 
[**apiNoteGetAllNotesGet**](NoteApi.md#apinotegetallnotesget) | **GET** /api/Note/getAllNotes | 
[**apiNoteGetNoteIdGet**](NoteApi.md#apinotegetnoteidget) | **GET** /api/Note/getNote/{id} | 
[**apiNoteModifyNotePut**](NoteApi.md#apinotemodifynoteput) | **PUT** /api/Note/modifyNote | 


# **apiNoteAddReviewPost**
> apiNoteAddReviewPost(noteRatingCreateDTO)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = NoteApi();
final noteRatingCreateDTO = NoteRatingCreateDTO(); // NoteRatingCreateDTO | 

try {
    api_instance.apiNoteAddReviewPost(noteRatingCreateDTO);
} catch (e) {
    print('Exception when calling NoteApi->apiNoteAddReviewPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **noteRatingCreateDTO** | [**NoteRatingCreateDTO**](NoteRatingCreateDTO.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiNoteCreateNotePost**
> apiNoteCreateNotePost(noteCreateDTO)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = NoteApi();
final noteCreateDTO = NoteCreateDTO(); // NoteCreateDTO | 

try {
    api_instance.apiNoteCreateNotePost(noteCreateDTO);
} catch (e) {
    print('Exception when calling NoteApi->apiNoteCreateNotePost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **noteCreateDTO** | [**NoteCreateDTO**](NoteCreateDTO.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiNoteDeleteNoteIdDelete**
> apiNoteDeleteNoteIdDelete(id)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = NoteApi();
final id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiNoteDeleteNoteIdDelete(id);
} catch (e) {
    print('Exception when calling NoteApi->apiNoteDeleteNoteIdDelete: $e\n');
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

# **apiNoteGetAllNotesGet**
> apiNoteGetAllNotesGet()



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = NoteApi();

try {
    api_instance.apiNoteGetAllNotesGet();
} catch (e) {
    print('Exception when calling NoteApi->apiNoteGetAllNotesGet: $e\n');
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

# **apiNoteGetNoteIdGet**
> apiNoteGetNoteIdGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = NoteApi();
final id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiNoteGetNoteIdGet(id);
} catch (e) {
    print('Exception when calling NoteApi->apiNoteGetNoteIdGet: $e\n');
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

# **apiNoteModifyNotePut**
> apiNoteModifyNotePut(noteUpdateDTO)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = NoteApi();
final noteUpdateDTO = NoteUpdateDTO(); // NoteUpdateDTO | 

try {
    api_instance.apiNoteModifyNotePut(noteUpdateDTO);
} catch (e) {
    print('Exception when calling NoteApi->apiNoteModifyNotePut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **noteUpdateDTO** | [**NoteUpdateDTO**](NoteUpdateDTO.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

