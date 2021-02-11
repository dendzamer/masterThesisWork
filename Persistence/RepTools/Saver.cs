using System;
using Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using static System.Console;

namespace Persistence.RepTools
{
	public class Saver
	{
		public void SaveAlbum(Album input)
		{
			using (var db = new BazaContext())
			{
				db.Database.EnsureCreated();
				db.Albumi.Add(input);
				db.SaveChanges();
			}
		}

		public void SaveIzvodjac(Izvodjac input)
		{
			using (var db = new BazaContext())
			{
				db.Database.EnsureCreated();
				db.Izvodjaci.Add(input);
				db.SaveChanges();
			}
		}

		public Fonogram SaveFonogram(Fonogram input)
		{
			using (var db = new BazaContext())
			{

				Fonogram fonogram = input;
				Album album = db.Albumi.Single(p => p.AlbumId == input.AlbumId);
				album.Fonogrami.Add(fonogram);
				db.SaveChanges();

				return fonogram;
			}
		}
	}
}
