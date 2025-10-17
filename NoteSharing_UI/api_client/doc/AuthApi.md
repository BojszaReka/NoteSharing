# openapi.api.AuthApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiAuthLoginPost**](AuthApi.md#apiauthloginpost) | **POST** /api/Auth/login | Authenticates a user using their email and password.      Required fields in class_library.DTO.LoginDTO:&lt;list type&#x3D;\&quot;bullet\&quot;&gt;&lt;item&gt;&lt;description&gt;&lt;b&gt;Email&lt;/b&gt;: string, must be a valid email address (required)&lt;/description&gt;&lt;/item&gt;&lt;item&gt;&lt;description&gt;&lt;b&gt;Password&lt;/b&gt;: string (required)&lt;/description&gt;&lt;/item&gt;&lt;/list&gt;
[**apiAuthRefreshPost**](AuthApi.md#apiauthrefreshpost) | **POST** /api/Auth/refresh | Refreshes the user&#39;s authentication tokens using a valid refresh token.      Required field in class_library.DTO.RefreshTokenDTO:&lt;list type&#x3D;\&quot;bullet\&quot;&gt;&lt;item&gt;&lt;description&gt;&lt;b&gt;RefreshToken&lt;/b&gt;: string (required)&lt;/description&gt;&lt;/item&gt;&lt;/list&gt;
[**apiAuthRegisterPost**](AuthApi.md#apiauthregisterpost) | **POST** /api/Auth/register | Registers a new user with basic credentials (Name, Email, Password).  This endpoint is intended for simple user registration and does not accept additional user data.  To add more user information, use a different endpoint.      Required fields in class_library.DTO.RegisterDTO:&lt;list type&#x3D;\&quot;bullet\&quot;&gt;&lt;item&gt;&lt;description&gt;&lt;b&gt;UserName&lt;/b&gt;: string (required)&lt;/description&gt;&lt;/item&gt;&lt;item&gt;&lt;description&gt;&lt;b&gt;Email&lt;/b&gt;: string, must be a valid email address (required)&lt;/description&gt;&lt;/item&gt;&lt;item&gt;&lt;description&gt;&lt;b&gt;Password&lt;/b&gt;: string (required)&lt;/description&gt;&lt;/item&gt;&lt;/list&gt;
[**apiAuthTestGet**](AuthApi.md#apiauthtestget) | **GET** /api/Auth/test | Test endpoint to confirm if the authentication mechanism is working.      This endpoint requires a valid JWT access token in the Authorization header.  If the token is valid, it returns basic user details extracted from the token.


# **apiAuthLoginPost**
> apiAuthLoginPost(loginDTO)

Authenticates a user using their email and password.      Required fields in class_library.DTO.LoginDTO:<list type=\"bullet\"><item><description><b>Email</b>: string, must be a valid email address (required)</description></item><item><description><b>Password</b>: string (required)</description></item></list>

### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAuthApi();
final LoginDTO loginDTO = ; // LoginDTO | The login credentials for the user.

try {
    api.apiAuthLoginPost(loginDTO);
} catch on DioException (e) {
    print('Exception when calling AuthApi->apiAuthLoginPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **loginDTO** | [**LoginDTO**](LoginDTO.md)| The login credentials for the user. | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiAuthRefreshPost**
> apiAuthRefreshPost(refreshTokenDTO)

Refreshes the user's authentication tokens using a valid refresh token.      Required field in class_library.DTO.RefreshTokenDTO:<list type=\"bullet\"><item><description><b>RefreshToken</b>: string (required)</description></item></list>

### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAuthApi();
final RefreshTokenDTO refreshTokenDTO = ; // RefreshTokenDTO | The refresh token data for the user.

try {
    api.apiAuthRefreshPost(refreshTokenDTO);
} catch on DioException (e) {
    print('Exception when calling AuthApi->apiAuthRefreshPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **refreshTokenDTO** | [**RefreshTokenDTO**](RefreshTokenDTO.md)| The refresh token data for the user. | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiAuthRegisterPost**
> apiAuthRegisterPost(registerDTO)

Registers a new user with basic credentials (Name, Email, Password).  This endpoint is intended for simple user registration and does not accept additional user data.  To add more user information, use a different endpoint.      Required fields in class_library.DTO.RegisterDTO:<list type=\"bullet\"><item><description><b>UserName</b>: string (required)</description></item><item><description><b>Email</b>: string, must be a valid email address (required)</description></item><item><description><b>Password</b>: string (required)</description></item></list>

### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAuthApi();
final RegisterDTO registerDTO = ; // RegisterDTO | The registration data for the new user.

try {
    api.apiAuthRegisterPost(registerDTO);
} catch on DioException (e) {
    print('Exception when calling AuthApi->apiAuthRegisterPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **registerDTO** | [**RegisterDTO**](RegisterDTO.md)| The registration data for the new user. | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiAuthTestGet**
> apiAuthTestGet()

Test endpoint to confirm if the authentication mechanism is working.      This endpoint requires a valid JWT access token in the Authorization header.  If the token is valid, it returns basic user details extracted from the token.

<b>Authorization:</b> Bearer token required.  <b>Response:</b><list type=\"bullet\"><item><description><b>message</b>: Confirmation that authentication is successful.</description></item><item><description><b>userDetails</b>: Object containing `id`, `name`, `email`, and `role` from the token claims.</description></item></list>

### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAuthApi();

try {
    api.apiAuthTestGet();
} catch on DioException (e) {
    print('Exception when calling AuthApi->apiAuthTestGet: $e\n');
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

