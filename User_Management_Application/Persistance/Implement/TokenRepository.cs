using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using User_Management_Application.Persistance.Contract;

namespace User_Management_Application.Persistance.Implement
{
	public class TokenRepository : ITokenRepository
	{
		private readonly IConfiguration configuration;

		public TokenRepository(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
		public string CreateJWTToken(IdentityUser user, List<string> roles)
		{
			var claims = new List<Claim>();

			claims.Add(new Claim(ClaimTypes.Email, user.Email));

			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
			var cerdentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var Token = new JwtSecurityToken(
				configuration["JWT:Issuer"],

				configuration["JWT:Audience"],
				claims,
				expires: DateTime.Now.AddMinutes(15),
				signingCredentials: cerdentials);

			return new JwtSecurityTokenHandler().WriteToken(Token);
		}
	}
}
