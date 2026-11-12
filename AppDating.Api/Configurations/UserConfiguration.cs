using AppDating.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppDating.Api.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(u => u.Id);

			// Indique à EF Core que ces objets font partie de la même table
			builder.OwnsOne(u => u.Credentials, creds =>
			{
				creds.Property(c => c.Email).HasColumnName("Email").IsRequired();
				creds.HasIndex(c => c.Email).IsUnique();
				creds.Property(c => c.PasswordHash).HasColumnName("PasswordHash");
				creds.Property(c => c.PasswordSalt).HasColumnName("PasswordSalt");
			});

			builder.OwnsOne(u => u.Profile, prof =>
			{
				prof.Property(p => p.Age).HasColumnName("Age");
				prof.Property(p => p.Bio).HasColumnName("Bio");
				prof.Property(p => p.CreatedAt).HasColumnName("CreatedAt");
				prof.Property(p => p.DateOfBirth).HasColumnName("DateOfBirth");
				prof.Property(p => p.GenderIdentity).HasColumnName("Gender");
				prof.Property(p => p.Sexe).HasColumnName("Sexe");
			});
		}
	}
}