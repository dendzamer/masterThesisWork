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
				try
				{
					db.Albumi.Add(input);
					db.SaveChanges();
				}

				catch (Exception ex)
				{
					throw new Exception("Desila se greska! Pokusajte ponovo!", ex);
				}
			}
		}

		public void SaveIzvodjac(Izvodjac input)
		{
			using (var db = new BazaContext())
			{
				db.Database.EnsureCreated();

				try
				{
					db.Izvodjaci.Add(input);
					db.SaveChanges();
				}

				catch (Exception ex)
				{
					throw new Exception("Desila se greska! Pokusajte ponovo!", ex);
				}
			}
		}

		public Fonogram SaveFonogram(Fonogram input)
		{
			using (var db = new BazaContext())
			{

				Fonogram fonogram = input;
				try
				{
					Album album = db.Albumi.Single(p => p.AlbumId == input.AlbumId);
					album.Fonogrami.Add(fonogram);
					db.SaveChanges();
				}

				catch (Exception ex)
				{
					throw new Exception("Desila se greska! Pokusajte ponovo!", ex);
				}

				return fonogram;
			}
		}
	}
}
