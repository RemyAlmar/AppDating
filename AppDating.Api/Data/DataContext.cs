using AppDating.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AppDating.Api.Data
{
	public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
	{
		public DbSet<Choice> Choices { get; set; }
		public DbSet<Match> Matches { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserAction> UserActions { get; set; }
		public DbSet<UserLike> UserLikes { get; set; }
		public DbSet<UserLimits> UserTalkings { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
		}
	}
}