using AppDating.Api.Enum;

namespace AppDating.Api.Models
{
	public class User
	{
		public int Id { get; set; }
		public required string UserName { get; set; }

		public UserCredentials Credentials { get; set; } = new();
		public UserProfile Profile { get; set; } = new();

		public ICollection<UserLike> LikedUsers { get; set; } = [];
		public ICollection<UserLike> LikedByUsers { get; set; } = [];
		public ICollection<Message> MessageSent { get; set; } = [];
		public ICollection<Message> MessageReceived { get; set; } = [];
		public ICollection<Choice> Choices { get; set; } = [];
	}
	public class UserCredentials
	{
		public byte[] PasswordHash { get; set; } = new byte[0];
		public byte[] PasswordSalt { get; set; } = new byte[0];
	}

	public class UserProfile
	{
		public int Age { get; set; }
		public string? Bio { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime DateOfBirth { get; set; }
		public GenderIdentity GenderIdentity { get; set; }
		public Sexe Sexe { get; set; }
	}
}
