using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using _23crbcyr.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace _23crbcyr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

		/// <summary>
		/// generate jwt token only with a valid email
		/// </summary>
		/// <param name="data">json object with one attr(email)</param>
		/// <returns></returns>
        [HttpPost]
        public string GetRandomToken([FromBody]User data)
        {
            if (Helpers.IsValidEmail(data.email) == false)
                return null;

			var varJwtSecretKey = _config["JwtSecretKey"];
			var varSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(varJwtSecretKey));

			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
			new Claim(ClaimTypes.NameIdentifier, data.email.ToString()),
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(varSecurityKey, SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

		/// <summary>
		/// validate a token
		/// </summary>
		/// <param name="token">token</param>
		/// <returns></returns>
		[HttpGet]
		public bool ValidateCurrentToken(string token)
		{
			var varJwtSecretKey = _config["JwtSecretKey"];
			var varSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(varJwtSecretKey));

			var tokenHandler = new JwtSecurityTokenHandler();
			try
			{
				tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					ValidateIssuer = false,
					ValidateAudience = false,
					IssuerSigningKey = varSecurityKey
				}, out SecurityToken validatedToken);
			}
			catch
			{
				return false;
			}
			return true;
		}
	}
}