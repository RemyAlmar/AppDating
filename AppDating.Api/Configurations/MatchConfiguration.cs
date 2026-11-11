using AppDating.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppDating.Api.Configurations
{
	public class MatchConfiguration : IEntityTypeConfiguration<Match>
	{
		public void Configure(EntityTypeBuilder<Match> builder)
		{
			builder.HasKey(m => new { m.UserId_A, m.UserId_B });

			builder.HasOne(m => m.User_A)
				.WithMany()
				.HasForeignKey(m => m.UserId_A)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(m => m.User_B)
				.WithMany()
				.HasForeignKey(m => m.UserId_B)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
