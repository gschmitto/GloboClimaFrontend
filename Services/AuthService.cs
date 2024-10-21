using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;

namespace GloboClimaFrontend.Services
{
    public class AuthService
    {
        private readonly ILocalStorageService _localStorage;
        private bool _isLoggedIn;

        public AuthService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<bool> IsLoggedInAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _isLoggedIn = !string.IsNullOrEmpty(token);
            return _isLoggedIn;
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("authToken");
            _isLoggedIn = false;
        }

        public bool IsLoggedIn => _isLoggedIn;
    }
}
