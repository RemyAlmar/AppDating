using AppDating.Api.Enum;

namespace AppDating.Api.Models
{
	public class User
	{
		public int ID { get; set; }
		public required string UserName { get; set; }
		public int Age { get; set; }
		public GenderIdentity GenderIdentity { get; set; }
		public Sexe Sexe { get; set; }

	}
}
