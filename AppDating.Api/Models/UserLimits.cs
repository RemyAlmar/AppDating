namespace AppDating.Api.Models
{
	public class UserLimits
	{
		public int UserId { get; set; }
		public int MaxSlots { get; set; } = 3;
		public int CurrentSlotsUsed { get; set; } = 0;
	}
}
