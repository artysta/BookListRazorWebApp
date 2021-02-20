using Microsoft.EntityFrameworkCore;
using BookListMVCApp.Models;

namespace BookListMVCApp.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Category> Category { get; set; }
		public DbSet<Book> Book { get; set; }
	}
}
