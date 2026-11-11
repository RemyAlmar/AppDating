using AppDating.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppDating.Api.Configurations
{
	public class UserLikeConfiguration : IEntityTypeConfiguration<UserLike>
	{
		public void Configure(EntityTypeBuilder<UserLike> builder)
		{
			builder.HasKey(k => new { k.SourceUserId, k.TargetUserId });

			builder.HasOne(ul => ul.SourceUser)
				.WithMany(ul => ul.LikedUsers)
				.HasForeignKey(ul => ul.SourceUserId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(ul => ul.TargetUser)
				.WithMany(ul => ul.LikedByUsers)
				.HasForeignKey(ul => ul.TargetUserId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
