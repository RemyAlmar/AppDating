namespace AppDating.Api.Models
{
	public class Choice
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public User UserChoice { get; set; } = null!;
		public List<ChoiceSuggestion> ChoicesSuggestions { get; set; } = [];
		public int? ChoosenUserId { get; set; }
		public User? ChoosenUser { get; set; }
		public DateTime Timestamp { get; set; } = DateTime.Now;
	}
}
