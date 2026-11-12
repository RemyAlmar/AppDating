namespace AppDating.Api.DTOs
{
	public class UserDto
	{
		public int Id { get; set; }
		public string Email { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
		public string Token { get; set; } = string.Empty;
	}
}
