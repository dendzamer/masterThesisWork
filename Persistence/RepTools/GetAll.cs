using System;
using System.Collections.Generic;
using System.Linq;
using Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.RepTools
{
	public class GetAll
	{
		static public List<Album> GetAlbumi()
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

				List<Album> povratniAlbumi = albumi.ToList();

				return povratniAlbumi;
			}
		}

		static public List<Fonogram> GetFonogrami()
		{
			using (var db = new BazaContext())
			{
				IQueryable<Fonogram> fonogrami = db.Fonogrami.Include(p => p.Izvodjaci);
				List<Fonogram> povratniFonogrami = fonogrami.ToList();

				return povratniFonogrami;
			}
		}

		static public List<Izvodjac> GetIzvodjaci()
		{
			using (var db = new BazaContext())
			{
				IQueryable<Izvodjac> izvodjaci = db.Izvodjaci.Include(p => p.Fonogrami);
				List<Izvodjac> povratniIzvodjaci = izvodjaci.ToList();

				return povratniIzvodjaci;
			}
		}
	}
}
