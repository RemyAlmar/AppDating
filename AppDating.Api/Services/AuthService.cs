using AppDating.Api.Data;
using AppDating.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AppDating.Api.Services
{
	public class AuthService : IAuthService
	{
		private readonly DataContext _context;
		private readonly IConfiguration _configuration;
		public AuthService(DataContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}

		public async Task<User?> Login(string email, string password)
		{
			User? user = await _context.Users.FirstOrDefaultAsync(u => u.Credentials.Email == email.ToLower());

			if (user == null) return null;

			using HMACSHA512 hmac = new(user.Credentials.PasswordSalt);
			var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

			for (int i = 0; i < computedHash.Length; i++)
			{
				if (computedHash[i] != user.Credentials.PasswordHash[i]) return null;
			}
			return user;
		}

		public async Task<User> Register(string username, string email, string password)
		{
			using HMACSHA512 hmac = new();
			User user = new()
			{
				UserName = username,
				Credentials = new UserCredentials
				{
					Email = email.ToLower(),
					PasswordSalt = hmac.Key,
					PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password))
				}
			};

			_context.Users.Add(user);
			await _context.SaveChangesAsync();

			return user;
		}

		public async Task<bool> UserExists(string email)
		{
			return await _context.Users.AnyAsync(x => x.Credentials.Email == email.ToLower());
		}

		public string CreateToken(User user)
		{
			List<Claim> claims = new()
			{
				new(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new(ClaimTypes.Name, user.UserName),
			};

			string? tokenKey = _configuration.GetSection("AppSettings:Token").Value;

			if (string.IsNullOrEmpty(tokenKey))
				throw new Exception("La clé secrète du token est introuvable");

			SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(tokenKey));
			SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha512Signature);
			SecurityTokenDescriptor tokenDescriptor = new()
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddDays(7),
				SigningCredentials = creds,
			};

			JwtSecurityTokenHandler tokenHandler = new();
			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
	}
}
