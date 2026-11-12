using AppDating.Api.DTOs;
using AppDating.Api.Models;
using AppDating.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppDating.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController(IAuthService authService) : ControllerBase
	{
		[HttpPost("register")]
		public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
		{
			if (await authService.UserExists(registerDto.Email))
			{
				return BadRequest("Cet e-mail est déjà utilisé");
			}

			User? user = await authService.Register(registerDto.UserName, registerDto.Email, registerDto.Password);

			return new UserDto
			{
				Id = user.Id,
				Email = user.Credentials.Email,
				UserName = user.UserName,
			};
		}

		[HttpPost("login")]
		public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
		{
			User? user = await authService.Login(loginDto.Email, loginDto.Password);

			if (user == null)
			{
				bool userExist = await authService.UserExists(loginDto.Email);
				if (!userExist)
					return Unauthorized("Aucun utilisateur possédant cet e-mail n'a été trouvé");

				return Unauthorized("Mot de passe incorrect");
			}

			return new UserDto
			{
				Id = user.Id,
				Email = user.Credentials.Email,
				UserName = user.UserName,
			};
		}
	}
}