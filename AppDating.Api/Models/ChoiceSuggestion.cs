namespace AppDating.Api.Models
{
	public class ChoiceSuggestion
	{

		public int Id { get; set; }
		public int ChoiceId { get; set; }
		public Choice Choice { get; set; } = null!;
		public int SuggestedUserId { get; set; }
		public User SuggestedUser { get; set; } = null!;
	}
}
