using System;
using Persistence.Models;
using Persistence.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Persistence.RepTools.SearchTools
{
	public class AlbumSearchTools
	{
		static public List<IDb> ByNaziv(string input)
		{
			using (var db = new BazaContext())
			{
				IQueryable<Album> albumi = db.Albumi;
				IQueryable<Fonogram> fonogrami = db.Fonogrami.Include(p => p.Izvodjaci);
				List<Fonogram> fonogramiUAlbumu = new List<Fonogram>();

				foreach (var album in albumi)
				{
					foreach(var fonogram in fonogrami)
					{
						if (fonogram.AlbumId == album.AlbumId)
						{
							fonogramiUAlbumu.Add(fonogram);
						}

					}
				}

				List<Album> filtriraniAlbumi = albumi.Where(p => p.Naziv.Contains(input)).ToList();
				if (filtriraniAlbumi.Any() == false)
				{
					throw new Exception("Nema unosa sa tim nazivom!");
				}


				List<IDb> finalAlbumi = new List<IDb>();

				foreach(var element in filtriraniAlbumi)
				{
					finalAlbumi.Add(element);
				}

				return finalAlbumi;
			}
		}

		static public List<IDb> ByKataloskiBroj(string input)
		{
			using (var db = new BazaContext())
			{
				IQueryable<Album> albumi = db.Albumi;
				IQueryable<Fonogram> fonogrami = db.Fonogrami.Include(p => p.Izvodjaci);
				List<Fonogram> fonogramiUAlbumu = new List<Fonogram>();

				foreach (var album in albumi)
				{
					foreach(var fonogram in fonogrami)
					{
						if (fonogram.AlbumId == album.AlbumId)
						{
							fonogramiUAlbumu.Add(fonogram);
						}

					}
				}

				List<Album> filtriraniAlbumi = albumi.Where(p => p.KataloskiBroj.Contains(input)).ToList();
				if (filtriraniAlbumi.Any() == false)
				{
					throw new Exception("Nema unosa sa tim kataloskim brojem!");
				}

				List<IDb> finalAlbumi = new List<IDb>();

				foreach(var element in filtriraniAlbumi)
				{
					finalAlbumi.Add(element);
				}

				return finalAlbumi;
			}
		}

		static public List<IDb> ByGodinaIzdanja(int input)
		{
			using (var db = new BazaContext())
			{
				IQueryable<Album> albumi = db.Albumi;
				IQueryable<Fonogram> fonogrami = db.Fonogrami.Include(p => p.Izvodjaci);
				List<Fonogram> fonogramiUAlbumu = new List<Fonogram>();

				foreach (var album in albumi)
				{
					foreach(var fonogram in fonogrami)
					{
						if (fonogram.AlbumId == album.AlbumId)
						{
							fonogramiUAlbumu.Add(fonogram);
						}

					}
				}

				List<Album> filtriraniAlbumi = albumi.Where(p => p.GodinaIzdanja == input).ToList();
				if (filtriraniAlbumi.Any() == false)
				{
					throw new Exception("Nema unosa sa tom godinom izdanja!");
				}

				List<IDb> finalAlbumi = new List<IDb>();

				foreach(var element in filtriraniAlbumi)
				{
					finalAlbumi.Add(element);
				}

				return finalAlbumi;
			}
		}
	}
}
