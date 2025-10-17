import 'package:test/test.dart';
import 'package:openapi/openapi.dart';


/// tests for UserApi
void main() {
  final instance = Openapi().getUserApi();

  group(UserApi, () {
    // Adds a one sided following relationship between two users.
    //
    //Future apiUserFollowPost({ UserFollowDTO userFollowDTO }) async
    test('test apiUserFollowPost', () async {
      // TODO
    });

    // Deletes a user by their unique identifier.
    //
    //Future apiUserIdDelete(String id) async
    test('test apiUserIdDelete', () async {
      // TODO
    });

    // Retrieves a user by their unique identifier.
    //
    //Future apiUserIdIdGet(String id) async
    test('test apiUserIdIdGet', () async {
      // TODO
    });

    // This endpoint is for adding additional user information or modifying the existing one.  Only the fields in class_library.DTO.UserUpdateDTO that are provided (not null) will be updated; all others will remain unchanged.  The `ID` field is required to identify the user to update.
    //
    //Future apiUserPut({ UserUpdateDTO userUpdateDTO }) async
    test('test apiUserPut', () async {
      // TODO
    });

    // Retrieves a user by their username.
    //
    //Future apiUserUsernameUserNameGet(String userName) async
    test('test apiUserUsernameUserNameGet', () async {
      // TODO
    });

  });
}
