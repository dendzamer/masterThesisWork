using System;
using System.Linq;
using Persistence.Models;
using Persistence.RepTools.Retrieve;
using Microsoft.EntityFrameworkCore;

namespace Persistence.RepTools
{
	public static class Deleter
	{
		static public Album DeleteAlbum(int input)
		{
			using (var db = new BazaContext())
			{
				Album album = db.Albumi.Single(p => p.AlbumId == input);
				db.Albumi.Remove(album);
				db.SaveChanges();

				return album;
			}
		}

		static public Fonogram DeleteFonogram(int input)
		{
			using (var db = new BazaContext())
			{
				Fonogram fonogram = db.Fonogrami.Single(p => p.FonogramId == input);
				db.Fonogrami.Remove(fonogram);
				db.SaveChanges();

				return fonogram;
			}
		}

		static public Izvodjac DeleteIzvodjac(int input)
		{
			using (var db = new BazaContext())
			{
				Izvodjac izvodjac = db.Izvodjaci.Single(p => p.IzvodjacId == input);
				db.Izvodjaci.Remove(izvodjac);
				db.SaveChanges();

				return izvodjac;
			}
		}
	}
}
