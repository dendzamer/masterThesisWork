using System;
using System.Collections.Generic;
using System.Linq;
using Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.RepTools.Retrieve
{
	public class RetrieveIzvodjac
	{
		public Izvodjac GetById(int input)
		{
			using (var db = new BazaContext())
			{
				IQueryable<Izvodjac> izvodjaci = db.Izvodjaci.Include(p => p.Fonogrami);

				Izvodjac izvodjac = izvodjaci.Single(p => p.IzvodjacId == input);
				db.SaveChanges();
				
				return izvodjac;
			}
		}

		public Izvodjac IzvodjacWithoutFonogram(int input)
		{
			using (var db = new BazaContext())
			{
				IQueryable<Izvodjac> izvodjaci = db.Izvodjaci;

				Izvodjac izvodjac = izvodjaci.Single(p => p.IzvodjacId == input);
				db.SaveChanges();

				return izvodjac;
			}
		}

	
	}
}
