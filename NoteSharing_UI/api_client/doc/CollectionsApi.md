# openapi.api.CollectionsApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiCollectionsCollectionIdAddNoteNoteIdPost**](CollectionsApi.md#apicollectionscollectionidaddnotenoteidpost) | **POST** /api/Collections/{collectionId}/addNote/{noteId} | 
[**apiCollectionsCollectionIdRemoveNoteNoteIdDelete**](CollectionsApi.md#apicollectionscollectionidremovenotenoteiddelete) | **DELETE** /api/Collections/{collectionId}/removeNote/{noteId} | 
[**apiCollectionsCollectionIdSetPrivateIsPrivatePost**](CollectionsApi.md#apicollectionscollectionidsetprivateisprivatepost) | **POST** /api/Collections/{collectionId}/setPrivate/{isPrivate} | 
[**apiCollectionsCreateCollectionPost**](CollectionsApi.md#apicollectionscreatecollectionpost) | **POST** /api/Collections/createCollection | 
[**apiCollectionsGetCollectionIdGet**](CollectionsApi.md#apicollectionsgetcollectionidget) | **GET** /api/Collections/getCollection/{id} | 
[**apiCollectionsGetCollectionsUserIdGet**](CollectionsApi.md#apicollectionsgetcollectionsuseridget) | **GET** /api/Collections/getCollections/{userId} | 
[**apiCollectionsModifyCollectionPut**](CollectionsApi.md#apicollectionsmodifycollectionput) | **PUT** /api/Collections/modifyCollection | 


# **apiCollectionsCollectionIdAddNoteNoteIdPost**
> apiCollectionsCollectionIdAddNoteNoteIdPost(collectionId, noteId)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = CollectionsApi();
final collectionId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
final noteId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiCollectionsCollectionIdAddNoteNoteIdPost(collectionId, noteId);
} catch (e) {
    print('Exception when calling CollectionsApi->apiCollectionsCollectionIdAddNoteNoteIdPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **collectionId** | **String**|  | 
 **noteId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiCollectionsCollectionIdRemoveNoteNoteIdDelete**
> apiCollectionsCollectionIdRemoveNoteNoteIdDelete(collectionId, noteId)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = CollectionsApi();
final collectionId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
final noteId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiCollectionsCollectionIdRemoveNoteNoteIdDelete(collectionId, noteId);
} catch (e) {
    print('Exception when calling CollectionsApi->apiCollectionsCollectionIdRemoveNoteNoteIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **collectionId** | **String**|  | 
 **noteId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiCollectionsCollectionIdSetPrivateIsPrivatePost**
> apiCollectionsCollectionIdSetPrivateIsPrivatePost(collectionId, isPrivate)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = CollectionsApi();
final collectionId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
final isPrivate = true; // bool | 

try {
    api_instance.apiCollectionsCollectionIdSetPrivateIsPrivatePost(collectionId, isPrivate);
} catch (e) {
    print('Exception when calling CollectionsApi->apiCollectionsCollectionIdSetPrivateIsPrivatePost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **collectionId** | **String**|  | 
 **isPrivate** | **bool**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiCollectionsCreateCollectionPost**
> apiCollectionsCreateCollectionPost(collectionCreateDTO)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = CollectionsApi();
final collectionCreateDTO = CollectionCreateDTO(); // CollectionCreateDTO | 

try {
    api_instance.apiCollectionsCreateCollectionPost(collectionCreateDTO);
} catch (e) {
    print('Exception when calling CollectionsApi->apiCollectionsCreateCollectionPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **collectionCreateDTO** | [**CollectionCreateDTO**](CollectionCreateDTO.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiCollectionsGetCollectionIdGet**
> apiCollectionsGetCollectionIdGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = CollectionsApi();
final id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiCollectionsGetCollectionIdGet(id);
} catch (e) {
    print('Exception when calling CollectionsApi->apiCollectionsGetCollectionIdGet: $e\n');
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

# **apiCollectionsGetCollectionsUserIdGet**
> apiCollectionsGetCollectionsUserIdGet(userId)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = CollectionsApi();
final userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiCollectionsGetCollectionsUserIdGet(userId);
} catch (e) {
    print('Exception when calling CollectionsApi->apiCollectionsGetCollectionsUserIdGet: $e\n');
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

# **apiCollectionsModifyCollectionPut**
> apiCollectionsModifyCollectionPut(collectionViewDTO)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = CollectionsApi();
final collectionViewDTO = CollectionViewDTO(); // CollectionViewDTO | 

try {
    api_instance.apiCollectionsModifyCollectionPut(collectionViewDTO);
} catch (e) {
    print('Exception when calling CollectionsApi->apiCollectionsModifyCollectionPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **collectionViewDTO** | [**CollectionViewDTO**](CollectionViewDTO.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

