using AppDating.Api.Models;

namespace AppDating.Api.Services
{
	public interface IAuthService
	{
		Task<User> Register(string username, string email, string password);
		Task<User?> Login(string email, string password);
		Task<bool> UserExists(string email);
	}
}
