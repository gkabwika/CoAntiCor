using Microsoft.AspNetCore.Authorization;

namespace CoAntiCor.Services;

[AllowAnonymous]
public class AuthService
{
    private readonly HttpClient _http;
    private readonly JwtAuthenticationStateProvider _authProvider;

    public AuthService(IHttpClientFactory factory, JwtAuthenticationStateProvider provider)
    {
        _http = factory.CreateClient("Api");
        _authProvider = provider;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var response = await _http.PostAsJsonAsync("api/auth/login", new { email, password });

        if (!response.IsSuccessStatusCode)
            return false;

        var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
        await _authProvider.LoginAsync(result!.Token);

        return true;
    }

    public async Task LogoutAsync() => await _authProvider.LogoutAsync();
}

public class LoginResponse
{
    public string Token { get; set; } = default!;
}