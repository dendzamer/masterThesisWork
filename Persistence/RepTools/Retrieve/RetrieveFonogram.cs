using System;
using System.Collections.Generic;
using System.Linq;
using Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.RepTools.Retrieve
{
	public class RetrieveFonogram
	{
		public Fonogram GetById(int input)
		{
			using (var db = new BazaContext())
			{
				IQueryable<Fonogram> fonogrami = db.Fonogrami.Include(p => p.Izvodjaci);

				Fonogram fonogram = fonogrami.Single(p => p.FonogramId == input);

				return fonogram;
			}

		}
	}
}
