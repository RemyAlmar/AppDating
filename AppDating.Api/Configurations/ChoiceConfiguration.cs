using AppDating.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppDating.Api.Configurations
{
	public class ChoiceConfiguration : IEntityTypeConfiguration<Choice>
	{
		public void Configure(EntityTypeBuilder<Choice> builder)
		{
			builder.HasOne(c => c.UserChoice)
				.WithMany(u => u.Choices)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(c => c.ChoosenUser)
				.WithMany()
				.HasForeignKey(c => c.ChoosenUserId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
