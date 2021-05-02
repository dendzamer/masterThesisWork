using System;
using Persistence.Models;
using Persistence.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Persistence.RepTools.SearchTools
{
	public class FonogramSearchTools
	{
		static public List<IDb> ByNaziv(string input)
		{
			using (var db = new BazaContext())
			{
				IQueryable<Fonogram> fonogrami = db.Fonogrami.Include(p => p.Izvodjaci);

				List<Fonogram> filtriraniFonogrami = fonogrami.Where(p => p.Naziv.Contains(input)).ToList();
				if (filtriraniFonogrami.Any() == false)
				{
					throw new Exception("Nema unosa sa tim nazivom!");
				}

				List<IDb> finalFonogrami = new List<IDb>();

				foreach(var element in filtriraniFonogrami)
				{
					finalFonogrami.Add(element);
				}

				return finalFonogrami;
			}
		}

		static public List<IDb> ByKataloskiBroj(string input)
		{
			using (var db = new BazaContext())
			{
				IQueryable<Fonogram> fonogrami = db.Fonogrami.Include(p => p.Izvodjaci);

				List<Fonogram> filtriraniFonogrami = fonogrami.Where(p => p.KataloskiBroj.Contains(input)).ToList();
				if (filtriraniFonogrami.Any() == false)
				{
					throw new Exception("Nema unosa sa tim kataloskim brojem!");
				}

				List<IDb> finalFonogrami = new List<IDb>();

				foreach(var element in filtriraniFonogrami)
				{
					finalFonogrami.Add(element);
				}

				return finalFonogrami;
			}
		}

		static public List<IDb> ByGodinaIzdanja(int input)
		{
			using (var db = new BazaContext())
			{
				IQueryable<Fonogram> fonogrami = db.Fonogrami.Include(p => p.Izvodjaci);

				List<Fonogram> filtriraniFonogrami = fonogrami.Where(p => p.GodinaIzdanja == input).ToList();
				if (filtriraniFonogrami.Any() == false)
				{
					throw new Exception("Nema unosa sa tom godinom izdanja!");
				}

				List<IDb> finalFonogrami = new List<IDb>();

				foreach(var element in filtriraniFonogrami)
				{
					finalFonogrami.Add(element);
				}

				return finalFonogrami;
			}
		}


	}
}
