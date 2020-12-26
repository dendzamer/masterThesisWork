using System;
using System.Collections.Generic;
using System.Linq;
using Persistence.Models;

namespace Persistence.RepTools.Retrieve
{
	public static class RetrieveIzvodjac
	{
		public static Izvodjac GetById(int input)
		{
			using (var db = new BazaContext())
			{
				Izvodjac izvodjac = db.Izvodjaci.Single(p => p.IzvodjacId == input);
				db.SaveChanges();
				
				return izvodjac;
			}
		}
	}
}
