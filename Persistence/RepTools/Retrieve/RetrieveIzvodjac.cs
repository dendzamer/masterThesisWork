using System;
using System.Collections.Generic;
using System.Linq;
using Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.RepTools.Retrieve
{
	public class RetrieveIzvodjac
	{
		public static Izvodjac GetById(int input)
		{
			using (var db = new BazaContext())
			{
				IQueryable<Izvodjac> izvodjaci = db.Izvodjaci.Include(p => p.Fonogrami);

				Izvodjac izvodjac;

				try 
				{
					izvodjac = izvodjaci.Single(p => p.IzvodjacId == input);
					db.SaveChanges();
				}

				catch (Exception ex)
				{
					throw new Exception("Ne postoji unos sa tim ID brojem!", ex);
				}

				return izvodjac;
			}
		}

		public static Izvodjac IzvodjacWithoutFonogram(int input)
		{
			using (var db = new BazaContext())
			{
				IQueryable<Izvodjac> izvodjaci = db.Izvodjaci;

				Izvodjac izvodjac;

				try 
				{
					izvodjac = izvodjaci.Single(p => p.IzvodjacId == input);
					db.SaveChanges();
				}

				catch (Exception ex)
				{
					throw new Exception("Ne postoji unos sa tim ID brojem!", ex);
				}				

				return izvodjac;
			}
		}

	
	}
}
