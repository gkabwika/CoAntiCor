using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using CoAntiCor.Core.Constant;
using CoAntiCor.Core.Domain;
using CoAntiCor.Infrastructure.Context;
using CoAntiCor.Infrastructure.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace CoAntiCor.API.V1.Controllers
{
    /// <summary>
    /// 4. Token refresh + silent re‑authentication. We’ll use a DelegatingHandler to:
    /// Attach the JWT to every API call
    /// Refresh the token silently when it’s near expiry
    /// a) Backend: refresh endpoint
    /// </summary>
    [ApiController]
    //[Route("api/auth")]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Core.Domain.ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokens;
        private readonly CoAntiCorDbContext _db;

        public AuthController(UserManager<Core.Domain.ApplicationUser> userManager, IConfiguration config, ITokenService tokens, CoAntiCorDbContext db)
        {
            _userManager = userManager;
            _config = config;
            _db = db;
            _tokens = tokens;
        }
        [HttpGet("check-username/{username}")]
        public async Task<IActionResult> CheckUsername(string username)
        {
            // Vérification asynchrone en base de données
            bool exists = await _db.Users.AnyAsync(u => u.UserName == username);
            return Ok(new { IsTaken = exists });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = new Core.Domain.ApplicationUser { UserName = dto.Email, Email = dto.Email };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            // Assign default role if needed
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                return Unauthorized();
            //TODO
            var roles = await _userManager.GetRolesAsync(user);
            var token = GenerateJwtToken(user, roles);
            var token2 = GenerateJwtAsync(user);
            return Ok(new { token2 });
        }

        private string GenerateJwtToken(Core.Domain.ApplicationUser user, IList<string> roles)
        {
            var jwtSection = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id),
                new(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new(ClaimTypes.NameIdentifier, user.Id)
            };
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var token = new JwtSecurityToken(
                issuer: jwtSection["Issuer"],
                audience: jwtSection["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<string> GenerateJwtAsync(Core.Domain.ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            // Load allowed scopes for regulators/executives
            var allowedOffices = await _db.RegulatorOfficePermissions
                .Where(x => x.UserId.ToString() == user.Id)
                .Select(x => x.OfficeId)
                .ToListAsync();

            var allowedProvinces = await _db.RegulatorProvincePermissions
                .Where(x => x.UserId.ToString() == user.Id)
                .Select(x => x.ProvinceCode)
                .ToListAsync();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                new Claim(CustomClaimTypes.BrokerOfficeId, user.BrokerOfficeId?.ToString() ?? string.Empty),
                new Claim(CustomClaimTypes.Province, user.ProvinceCode ?? string.Empty)
            };

            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            if (allowedOffices.Any())
                claims.Add(new Claim(CustomClaimTypes.AllowedOffices, string.Join(",", allowedOffices)));

            if (allowedProvinces.Any())
                claims.Add(new Claim(CustomClaimTypes.AllowedProvinces, string.Join(",", allowedProvinces)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost("refreshold")]
        public ActionResult<string> Refreshold([FromBody] RefreshRequest request)
        {
            //(You can wire your own refresh token logic here.)
            // Validate refresh token, issue new JWT
            // return Ok(newJwt);
            throw new NotImplementedException();
        }
        [HttpPost("refresh")]
        public ActionResult<string> Refresh([FromBody] RefreshRequest request)
        {
            var principal = _tokens.ValidateRefreshToken(request.RefreshToken);
            if (principal == null)
                return Unauthorized();

            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var jwt = _tokens.GenerateAccessToken(userId, tenantId: "T1");

            return Ok(jwt);
        }
        
        /// <summary>
        /// We’ll use a DelegatingHandler to: Attach the JWT to every API call
        /// Refresh the token silently when it’s near expiry
        /// </summary>
        public class RefreshRequest
        {
            public string RefreshToken { get; set; } = default!;         
        }
        public class LoginRequest
        { 
            public string Username { get; set; } = default!; 
            public string Password { get; set; } = default!;
        }
    }

    public record RegisterDto(string Email, string Password);
    public record LoginDto(string Email, string Password);

    public interface ITokenService
    {
        string GenerateAccessToken(string userId, string tenantId);
        string GenerateRefreshToken(string userId);
        ClaimsPrincipal? ValidateRefreshToken(string token);
    }

}
