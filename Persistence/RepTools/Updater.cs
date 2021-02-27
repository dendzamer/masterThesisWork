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
				IQueryable<Album> albumi = db.Albumi.Include(p => p.Fonogrami);
				Album album = db.Albumi.Single(p => p.AlbumId == input.AlbumId);

				album.Naziv = input.Naziv;
				album.GodinaIzdanja = input.GodinaIzdanja;
				album.KataloskiBroj = input.KataloskiBroj;

				db.SaveChanges();

				return RetrieveAlbum.GetById(album.AlbumId);
			}
		}

		static public Fonogram UpdateFonogram(Fonogram input)
		{
			using (var db = new BazaContext())
			{

				IQueryable<Fonogram> fonogrami = db.Fonogrami.Include(p => p.Izvodjaci);
				Fonogram fonogram = fonogrami.Single(p => p.FonogramId == input.FonogramId);
				

				fonogram.Naziv = input.Naziv;
				fonogram.GodinaIzdanja = input.GodinaIzdanja;
				fonogram.KataloskiBroj = input.KataloskiBroj;
				fonogram.AlbumId = input.AlbumId;
				db.SaveChanges();

				return fonogram;
			}
		}

		static public Izvodjac UpdateIzvodjac(Izvodjac input)
		{
			using (var db = new BazaContext())
			{
				IQueryable<Izvodjac> izvodjaci = db.Izvodjaci.Include(p => p.Fonogrami);
				Izvodjac izvodjac = izvodjaci.Single(p => p.IzvodjacId == input.IzvodjacId);

				izvodjac.Naziv = input.Naziv;

				db.SaveChanges();

				return izvodjac;
			}
		}
	}
}
