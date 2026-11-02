using AppDating.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AppDating.Api.Data
{
	public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
	{
		public DbSet<User> Users { get; set; }
	}
}
