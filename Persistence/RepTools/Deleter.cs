using System;
using System.Linq;
using Persistence.Models;
using Persistence.RepTools.Retrieve;
using Microsoft.EntityFrameworkCore;

namespace Persistence.RepTools
{
	public static class Deleter
	{
		static public Album DeleteAlbum(int input)
		{
			using (var db = new BazaContext())
			{
				try
				{
					Album album = db.Albumi.Single(p => p.AlbumId == input);
					db.Albumi.Remove(album);
					db.SaveChanges();

					return album;
				}

                                catch(Exception ex)
                                {
                                        throw new Exception("Nesto nije u redu sa bazom podataka! Pokusajte ponovo...", ex);
                                }
			}
		}

		static public Fonogram DeleteFonogram(int input)
		{
			using (var db = new BazaContext())
			{
				try
				{
					Fonogram fonogram = db.Fonogrami.Single(p => p.FonogramId == input);
					db.Fonogrami.Remove(fonogram);
					db.SaveChanges();

					return fonogram;
				}

                                catch(Exception ex)
                                {
                                        throw new Exception("Nesto nije u redu sa bazom podataka! Pokusajte ponovo...", ex);
                                }
			}
		}

		static public Izvodjac DeleteIzvodjac(int input)
		{
			using (var db = new BazaContext())
			{
				try
				{
					Izvodjac izvodjac = db.Izvodjaci.Single(p => p.IzvodjacId == input);
					db.Izvodjaci.Remove(izvodjac);
					db.SaveChanges();

					return izvodjac;
				}

                                catch(Exception ex)
                                {
                                        throw new Exception("Nesto nije u redu sa bazom podataka! Pokusajte ponovo...", ex);
                                }
			}
		}
	}
}
