namespace AppDating.Api.Models
{
	public class Match
	{
		public int UserId_A { get; set; }
		public User User_A { get; set; } = null!;
		public int UserId_B { get; set; }
		public User User_B { get; set; } = null!;
		public bool IsActive { get; set; } = true;
		public DateTime MatchedAt { get; set; } = DateTime.UtcNow;
	}
}
