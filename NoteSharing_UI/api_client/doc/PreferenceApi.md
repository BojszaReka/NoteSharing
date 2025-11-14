# openapi.api.PreferenceApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiPreferenceIdDelete**](PreferenceApi.md#apipreferenceiddelete) | **DELETE** /api/Preference/{id} | 
[**apiPreferenceIdGet**](PreferenceApi.md#apipreferenceidget) | **GET** /api/Preference/{id} | 
[**apiPreferencePost**](PreferenceApi.md#apipreferencepost) | **POST** /api/Preference | 
[**apiPreferencePut**](PreferenceApi.md#apipreferenceput) | **PUT** /api/Preference | 


# **apiPreferenceIdDelete**
> apiPreferenceIdDelete(id)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = PreferenceApi();
final id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiPreferenceIdDelete(id);
} catch (e) {
    print('Exception when calling PreferenceApi->apiPreferenceIdDelete: $e\n');
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

# **apiPreferenceIdGet**
> apiPreferenceIdGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = PreferenceApi();
final id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiPreferenceIdGet(id);
} catch (e) {
    print('Exception when calling PreferenceApi->apiPreferenceIdGet: $e\n');
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

# **apiPreferencePost**
> apiPreferencePost(preferenceViewDTO)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = PreferenceApi();
final preferenceViewDTO = PreferenceViewDTO(); // PreferenceViewDTO | 

try {
    api_instance.apiPreferencePost(preferenceViewDTO);
} catch (e) {
    print('Exception when calling PreferenceApi->apiPreferencePost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **preferenceViewDTO** | [**PreferenceViewDTO**](PreferenceViewDTO.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiPreferencePut**
> apiPreferencePut(preferenceViewDTO)



### Example
```dart
import 'package:openapi/api.dart';

final api_instance = PreferenceApi();
final preferenceViewDTO = PreferenceViewDTO(); // PreferenceViewDTO | 

try {
    api_instance.apiPreferencePut(preferenceViewDTO);
} catch (e) {
    print('Exception when calling PreferenceApi->apiPreferencePut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **preferenceViewDTO** | [**PreferenceViewDTO**](PreferenceViewDTO.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

