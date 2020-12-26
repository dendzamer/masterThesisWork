using System;
using Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace Persistence.RepTools
{
	public class Saver
	{
		static public void SaveAlbum(Album input)
		{
			using (var db = new BazaContext())
			{
				db.Database.EnsureCreated();
				db.Albumi.Add(input);
				db.SaveChanges();
			}
		}

		static public void SaveIzvodjac(Izvodjac input)
		{
			using (var db = new BazaContext())
			{
				db.Database.EnsureCreated();
				db.Izvodjaci.Add(input);
				db.SaveChanges();
			}
		}

		static public void SaveFonogram(Fonogram input)
		{
			using (var db = new BazaContext())
			{
				db.Database.EnsureCreated();
				Album album = db.Albumi.Single(p => p.AlbumId == input.AlbumId);
				album.Fonogrami.Add(input);
				db.SaveChanges();
			}
		}
	}
}
