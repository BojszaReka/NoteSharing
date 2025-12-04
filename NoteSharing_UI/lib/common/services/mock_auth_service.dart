import 'package:flutter_secure_storage/flutter_secure_storage.dart';

class MockAuthService {
  final _storage = const FlutterSecureStorage();
  
  // Mock user data
  static final _mockUsers = {
    'test@example.com': 'password123',
    'user@notesharing.com': 'secure123',
  };

  static final _mockUserData = {
    'test@example.com': {
      'id': '123e4567-e89b-12d3-a456-426614174000',
      'name': 'Test User',
      'email': 'test@example.com',
      'accessToken': 'mock_token_12345',
      'refreshToken': 'mock_refresh_token_12345',
    },
    'user@notesharing.com': {
      'id': '123e4567-e89b-12d3-a456-426614174001',
      'name': 'John Doe',
      'email': 'user@notesharing.com',
      'accessToken': 'mock_token_67890',
      'refreshToken': 'mock_refresh_token_67890',
    },
  };

  Future<Map<String, dynamic>?> login(String email, String password) async {
    // Simulate network delay
    await Future.delayed(const Duration(milliseconds: 500));

    if (_mockUsers[email] == password) {
      final userData = _mockUserData[email]!;
      
      // Store tokens securely
      await _storage.write(key: 'accessToken', value: userData['accessToken'] as String);
      await _storage.write(key: 'refreshToken', value: userData['refreshToken'] as String);
      await _storage.write(key: 'userId', value: userData['id'] as String);
      await _storage.write(key: 'userEmail', value: email);
      await _storage.write(key: 'userName', value: userData['name'] as String);
      
      return userData;
    }
    
    return null;
  }

  Future<void> logout() async {
    await _storage.delete(key: 'accessToken');
    await _storage.delete(key: 'refreshToken');
    await _storage.delete(key: 'userId');
    await _storage.delete(key: 'userEmail');
    await _storage.delete(key: 'userName');
  }

  Future<Map<String, String?>> getCurrentUser() async {
    final email = await _storage.read(key: 'userEmail');
    final name = await _storage.read(key: 'userName');
    final id = await _storage.read(key: 'userId');
    
    if (email != null) {
      return {
        'id': id,
        'name': name,
        'email': email,
      };
    }
    
    return {};
  }

  Future<bool> isLoggedIn() async {
    final token = await _storage.read(key: 'accessToken');
    return token != null;
  }
}
