namespace AppDating.Api.Models
{
	public class Message
	{
		public int Id { get; set; }
		public int SenderId { get; set; }
		public User SourceUser { get; set; } = null!;
		public int ReceiverId { get; set; }
		public User ReceiverUser { get; set; } = null!;

		public required string Content { get; set; } = string.Empty;
		public DateTime Timestamp { get; set; } = DateTime.UtcNow;
	}
}
