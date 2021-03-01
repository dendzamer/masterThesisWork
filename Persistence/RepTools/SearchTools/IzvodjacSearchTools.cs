using System;
using Persistence.Models;
using Persistence.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Persistence.RepTools.SearchTools
{
	public class IzvodjacSearchTools
	{
		static public List<IDb> ByNaziv(string input)
		{
			using (var db = new BazaContext())
			{
				IQueryable<Izvodjac> izvodjaci = db.Izvodjaci.Include(p => p.Fonogrami);

				List<Izvodjac> filtriraniIzvodjaci = izvodjaci.Where(p => p.Naziv.Contains(input)).ToList();

				List<IDb> finalIzvodjaci = new List<IDb>();

				foreach(var element in filtriraniIzvodjaci)
				{
					finalIzvodjaci.Add(element);
				}

				return finalIzvodjaci;
			}
		}
	}
}
