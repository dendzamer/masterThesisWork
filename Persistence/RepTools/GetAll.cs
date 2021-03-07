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
				IQueryable<Izvodjac> izvodjaci = db.Izvodjaci;
				List<Izvodjac> povratniIzvodjaci = izvodjaci.ToList();

				return povratniIzvodjaci;
			}
		}
	}
}
