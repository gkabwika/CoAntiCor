using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CoAntiCor.Services;

/// <summary>
/// This provider:
/// Stores the JWT in ProtectedLocalStorage
///Parses claims from the token
/// Notifies Blazor when authentication changes
/// Works with your API’s /api/auth/login and /api/auth/register
/// </summary>
public class JwtAuthenticationStateProvider : AuthenticationStateProvider
{
    private const string TokenKey = "coanticor_token";
    private readonly ProtectedLocalStorage _localStorage;
    private readonly JwtSecurityTokenHandler _tokenHandler = new();
    private ClaimsPrincipal _currentUser = new(new ClaimsIdentity());
    private string? _currentToken;
    private bool _initialized;

    public JwtAuthenticationStateProvider(ProtectedLocalStorage localStorage)
    {
        _localStorage = localStorage;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
        => Task.FromResult(new AuthenticationState(_currentUser));

    public async Task InitializeAsync()
    {
        if (_initialized)
            return;

        _initialized = true;

        var tokenResult = await _localStorage.GetAsync<string>(TokenKey);
        var token = tokenResult.Success ? tokenResult.Value : null;

        if (!string.IsNullOrWhiteSpace(token) && !IsExpired(token))
        {
            _currentToken = token;
            _currentUser = BuildPrincipalFromToken(token);
        }
        else
        {
            _currentToken = null;
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
    }

    public async Task SetTokenAsync(string? token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            await _localStorage.DeleteAsync(TokenKey);
            _currentToken = null;
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        }
        else
        {
            await _localStorage.SetAsync(TokenKey, token);
            _currentToken = token;
            _currentUser = BuildPrincipalFromToken(token);
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
    }

    public string? GetCurrentToken() => _currentToken;

    public bool IsTokenNearExpiry(TimeSpan threshold)
    {
        if (string.IsNullOrWhiteSpace(_currentToken))
            return false;

        var jwt = _tokenHandler.ReadJwtToken(_currentToken);
        return jwt.ValidTo <= DateTime.UtcNow.Add(threshold);
    }

    private ClaimsPrincipal BuildPrincipalFromToken(string token)
    {
        var jwt = _tokenHandler.ReadJwtToken(token);
        var identity = new ClaimsIdentity(jwt.Claims, "jwt");
        return new ClaimsPrincipal(identity);
    }

    private bool IsExpired(string token)
    {
        var jwt = _tokenHandler.ReadJwtToken(token);
        return jwt.ValidTo <= DateTime.UtcNow;
    }
    public async Task LoginAsync(string token)
    {
        await _localStorage.SetAsync(TokenKey, token);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task LogoutAsync()
    {
        await _localStorage.DeleteAsync(TokenKey);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}