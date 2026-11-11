using AppDating.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppDating.Api.Configurations
{
	public class ChoiceSuggestionConfiguration : IEntityTypeConfiguration<ChoiceSuggestion>
	{
		public void Configure(EntityTypeBuilder<ChoiceSuggestion> builder)
		{
			builder.HasOne(cs => cs.Choice)
				.WithMany(c => c.ChoicesSuggestions)
				.HasForeignKey(cs => cs.ChoiceId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(cs => cs.SuggestedUser)
				.WithMany()
				.HasForeignKey(cs => cs.SuggestedUserId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
