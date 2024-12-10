using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("decode")]
        public IActionResult DecodeToken([FromBody] TokenRequest request)
        {
            if (string.IsNullOrEmpty(request.Token))
            {
                return BadRequest("Token is required.");
            }

            var secretsPath = "/home/secrets.json";
            var secrets = JObject.Parse(System.IO.File.ReadAllText(secretsPath));
            var signingKey = secrets["JWT"]?["SigningKey"]?.ToString();

            if (string.IsNullOrEmpty(signingKey))
            {
                return StatusCode(500, "Signing key not found.");
            }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)),
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["JWT:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["JWT:Audience"],
                    ValidateLifetime = false
                };

                var principal = tokenHandler.ValidateToken(request.Token, validationParameters, out var validatedToken);

                if (validatedToken is JwtSecurityToken jwtToken)
                {
                    var claims = jwtToken.Claims.Select(c => new { c.Type, c.Value }).ToList();
                    return Ok(new { Valid = true, Claims = claims });
                }

                return Unauthorized("Invalid token.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }

    public class TokenRequest
    {
        public string Token { get; set; }
    }
}
