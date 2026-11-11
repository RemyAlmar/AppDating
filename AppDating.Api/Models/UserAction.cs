using System.ComponentModel.DataAnnotations;

namespace AppDating.Api.Models
{
	public class UserAction
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int UserId { get; set; }
		[Required]
		public DateOnly ActionDate { get; set; }
		public int DailyLimit { get; set; } = 10;
		public int CurrentDailyCount { get; set; } = 0;
		public int BonusCredits { get; set; } = 0;
	}
}
