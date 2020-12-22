using System;
using Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.RepTools
{
	public class Saver
	{
		static public Album SaveAlbum(Album input)
		{
			using (var db = new BazaContext())
			{
				db.Database.EnsureCreated();
				db.Albumi.Add(input);
				db.SaveChanges();

				return input;
			}
		}
	}
}
