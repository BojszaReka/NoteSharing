import 'package:test/test.dart';
import 'package:openapi/openapi.dart';


/// tests for InstitutionApi
void main() {
  final instance = Openapi().getInstitutionApi();

  group(InstitutionApi, () {
    // Retrieves all active institutions.
    //
    //Future apiInstitutionGet() async
    test('test apiInstitutionGet', () async {
      // TODO
    });

    // Deletes (sets inactive) an institution record by its unique identifier.
    //
    //Future apiInstitutionIdDelete(String id) async
    test('test apiInstitutionIdDelete', () async {
      // TODO
    });

    // Retrieves a specific institution by its unique identifier.
    //
    //Future apiInstitutionIdGet(String id) async
    test('test apiInstitutionIdGet', () async {
      // TODO
    });

    // Creates a new institution record.
    //
    //Future apiInstitutionPost({ InstitutionCreateDTO institutionCreateDTO }) async
    test('test apiInstitutionPost', () async {
      // TODO
    });

    // Updates an existing institution record.
    //
    //Future apiInstitutionPut({ InstitutionViewDTO institutionViewDTO }) async
    test('test apiInstitutionPut', () async {
      // TODO
    });

  });
}
