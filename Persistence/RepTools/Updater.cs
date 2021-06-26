using System;
using System.Linq;
using Persistence.Models;
using Persistence.RepTools.Retrieve;
using Microsoft.EntityFrameworkCore;

namespace Persistence.RepTools
{
	public static class Updater
	{
		static public Album UpdateAlbum(Album input)
		{
			using (var db = new BazaContext())
			{
				try
				{
					IQueryable<Album> albumi = db.Albumi.Include(p => p.Fonogrami);
					Album album = db.Albumi.Single(p => p.AlbumId == input.AlbumId);

					album.Naziv = input.Naziv;
					album.GodinaIzdanja = input.GodinaIzdanja;
					album.KataloskiBroj = input.KataloskiBroj;

					db.SaveChanges();

					return RetrieveAlbum.GetById(album.AlbumId);
				}

				catch(Exception ex)
				{
					throw new Exception("Nesto nije u redu sa bazom podataka! Pokusajte ponovo...", ex);
				}
			}
		}

		static public Fonogram UpdateFonogram(Fonogram input)
		{
			using (var db = new BazaContext())
			{

				try
				{
					IQueryable<Fonogram> fonogrami = db.Fonogrami.Include(p => p.Izvodjaci);
					Fonogram fonogram = fonogrami.Single(p => p.FonogramId == input.FonogramId);


					fonogram.Naziv = input.Naziv;
					fonogram.GodinaIzdanja = input.GodinaIzdanja;
					fonogram.KataloskiBroj = input.KataloskiBroj;
					db.SaveChanges();

					return fonogram;
				}

				catch(Exception ex)
				{
					throw new Exception("Nesto nije u redu sa bazom podataka! Pokusajte ponovo...", ex);
				}
			}
		}

		static public Izvodjac UpdateIzvodjac(Izvodjac input)
		{
			using (var db = new BazaContext())
			{
				try
				{
				IQueryable<Izvodjac> izvodjaci = db.Izvodjaci.Include(p => p.Fonogrami);
				Izvodjac izvodjac = izvodjaci.Single(p => p.IzvodjacId == input.IzvodjacId);

				izvodjac.Naziv = input.Naziv;

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
