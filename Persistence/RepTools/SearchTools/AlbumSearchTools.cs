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
				IQueryable<Album> albumi = db.Albumi.Include(p => p.Fonogrami);

				List<Album> filtriraniAlbumi = albumi.Where(p => p.Naziv.Contains(input)).ToList();

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
				IQueryable<Album> albumi = db.Albumi.Include(p => p.Fonogrami);

				List<Album> filtriraniAlbumi = albumi.Where(p => p.KataloskiBroj.Contains(input)).ToList();

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
				IQueryable<Album> albumi = db.Albumi.Include(p => p.Fonogrami);

				List<Album> filtriraniAlbumi = albumi.Where(p => p.GodinaIzdanja == input).ToList();

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
