using System;
using Microsoft.EntityFrameworkCore;
using TestAPI.model;

namespace TestAPI.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<SuperHero> SuperHeroes { get; set; }
	}
}

