# openapi.api.UserApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiUserFollowPost**](UserApi.md#apiuserfollowpost) | **POST** /api/User/follow | Adds a one sided following relationship between two users.
[**apiUserIdDelete**](UserApi.md#apiuseriddelete) | **DELETE** /api/User/{id} | Deletes a user by their unique identifier.
[**apiUserIdIdGet**](UserApi.md#apiuserididget) | **GET** /api/User/id/{id} | Retrieves a user by their unique identifier.
[**apiUserPut**](UserApi.md#apiuserput) | **PUT** /api/User | This endpoint is for adding additional user information or modifying the existing one.  Only the fields in class_library.DTO.UserUpdateDTO that are provided (not null) will be updated; all others will remain unchanged.  The &#x60;ID&#x60; field is required to identify the user to update.
[**apiUserUsernameUserNameGet**](UserApi.md#apiuserusernameusernameget) | **GET** /api/User/username/{userName} | Retrieves a user by their username.


# **apiUserFollowPost**
> apiUserFollowPost(userFollowDTO)

Adds a one sided following relationship between two users.

### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getUserApi();
final UserFollowDTO userFollowDTO = ; // UserFollowDTO | The user follow data transfer object.    <b>Properties of class_library.DTO.UserFollowDTO:</b><list type=\"bullet\"><item><description>`FollowerUserID` (System.Guid): The unique identifier of the user who is following.</description></item><item><description>`FollowingUserID` (System.Guid): The unique identifier of the user being followed.</description></item></list>

try {
    api.apiUserFollowPost(userFollowDTO);
} catch on DioException (e) {
    print('Exception when calling UserApi->apiUserFollowPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userFollowDTO** | [**UserFollowDTO**](UserFollowDTO.md)| The user follow data transfer object.    <b>Properties of class_library.DTO.UserFollowDTO:</b><list type=\"bullet\"><item><description>`FollowerUserID` (System.Guid): The unique identifier of the user who is following.</description></item><item><description>`FollowingUserID` (System.Guid): The unique identifier of the user being followed.</description></item></list> | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiUserIdDelete**
> apiUserIdDelete(id)

Deletes a user by their unique identifier.

### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getUserApi();
final String id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | The unique identifier of the user to delete.

try {
    api.apiUserIdDelete(id);
} catch on DioException (e) {
    print('Exception when calling UserApi->apiUserIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**| The unique identifier of the user to delete. | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiUserIdIdGet**
> apiUserIdIdGet(id)

Retrieves a user by their unique identifier.

### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getUserApi();
final String id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | The unique identifier of the user.

try {
    api.apiUserIdIdGet(id);
} catch on DioException (e) {
    print('Exception when calling UserApi->apiUserIdIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**| The unique identifier of the user. | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiUserPut**
> apiUserPut(userUpdateDTO)

This endpoint is for adding additional user information or modifying the existing one.  Only the fields in class_library.DTO.UserUpdateDTO that are provided (not null) will be updated; all others will remain unchanged.  The `ID` field is required to identify the user to update.

### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getUserApi();
final UserUpdateDTO userUpdateDTO = ; // UserUpdateDTO | The user update data transfer object. Except for `ID`, all properties should be null unless they are to be changed.

try {
    api.apiUserPut(userUpdateDTO);
} catch on DioException (e) {
    print('Exception when calling UserApi->apiUserPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userUpdateDTO** | [**UserUpdateDTO**](UserUpdateDTO.md)| The user update data transfer object. Except for `ID`, all properties should be null unless they are to be changed. | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiUserUsernameUserNameGet**
> apiUserUsernameUserNameGet(userName)

Retrieves a user by their username.

### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getUserApi();
final String userName = userName_example; // String | The username of the user.

try {
    api.apiUserUsernameUserNameGet(userName);
} catch on DioException (e) {
    print('Exception when calling UserApi->apiUserUsernameUserNameGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userName** | **String**| The username of the user. | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

