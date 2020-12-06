using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Models
{
	public class BazaContext : DbContext
	{
		public DbSet<Album> Albumi {get; set;}
		public DbSet<Fonogram> Fonogrami {get; set;}
		public DbSet<Izvodjac> Izvodjaci {get; set;}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite("Data Source=baza.db");
	}
}
