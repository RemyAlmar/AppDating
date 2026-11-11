using AppDating.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppDating.Api.Configurations
{
	public class UserLimitsConfiguration : IEntityTypeConfiguration<UserLimits>
	{
		public void Configure(EntityTypeBuilder<UserLimits> builder)
		{
			builder.HasKey(ul => ul.UserId);
		}
	}
}
