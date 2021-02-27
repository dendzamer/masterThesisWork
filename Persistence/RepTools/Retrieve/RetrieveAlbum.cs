using System;
using System.Collections.Generic;
using System.Linq;
using Persistence.Models;
using Microsoft.EntityFrameworkCore;


namespace Persistence.RepTools.Retrieve
{
	public class RetrieveAlbum
	{
		public static Album GetById(int input)
		{
			using (var db = new BazaContext())
			{
				IQueryable<Album> albumi = db.Albumi;
				IQueryable<Fonogram> fonogrami = db.Fonogrami.Include(p => p.Izvodjaci);

				Album album = albumi.Single(p => p.AlbumId == input);


				//Nakon ovoga sto sledi Entityframework je sam uspeo da skapira koji fonogram pripada ovom albumu. Navodno je bilo dovoljno samo da filtriram 'fonogrami' query i uspeo je sam da poveze. Mislim da se ovo zove Lazy loading ali nisam jos sasvim siguran.

				List<Fonogram> fonogramiUAlbumu = new List<Fonogram>();

				foreach(Fonogram instanca in fonogrami)
				{
					if (instanca.AlbumId == album.AlbumId)
					{
						fonogramiUAlbumu.Add(instanca);
					}
				}

				return album;
			}
		}

		public static Album AlbumWithoutFonogram(int input)
		{
			using (var db = new BazaContext())
			{
				Album album = db.Albumi.Single(p => p.AlbumId == input);

				return album;
			}
		}
	}
}
