using System;
using Persistence.Interfaces;
using Domain.Models;
using Domain.Interfaces;

namespace Persistence.Converters
{
	public class DbModelsToViewable
	{
		public static IViewable ConvertToAlbumViewable(IDbAlbum input)
		{
			IAlbumViewable album = new Album();

			album.Id = input.AlbumId;
			album.Naziv = input.Naziv;
			album.GodinaIzdanja = input.GodinaIzdanja;
			album.KataloskiBroj = input.KataloskiBroj;

			foreach (var fonogram in input.Fonogrami)
			{
				album.Fonogrami.Add(ConvertToFonogramViewable(fonogram) as Fonogram);
			}

			foreach (var izvodjac in input.Izvodjaci)
			{
				album.Izvodjaci.Add(ConvertToIzvodjacViewable(izvodjac) as Izvodjac);
			}

			return album;
		}
		
		public static IViewable ConvertToFonogramViewable(IDbFonogram input)
		{
			IFonogramViewable fonogram = new Fonogram();

			fonogram.Id = input.FonogramId;
			fonogram.Naziv = input.Naziv;
			fonogram.GodinaIzdanja = input.GodinaIzdanja;
			fonogram.KataloskiBroj = input.KataloskiBroj;

			foreach (var izvodjac in input.Izvodjaci)
			{
				fonogram.Izvodjaci.Add(ConvertToIzvodjacViewable(izvodjac) as Izvodjac);
			}

			return fonogram;
		}

		public static IViewable ConvertToIzvodjacViewable(IDbIzvodjac input)
		{
			IIzvodjacViewable izvodjac = new Izvodjac();

			izvodjac.Id = input.IzvodjacId;
			izvodjac.Naziv = input.Naziv;

			foreach (var album in input.Albumi)
			{
				izvodjac.Albumi.Add(ConvertToAlbumViewable(album) as Album);
			}

			foreach (var fonogram in input.Fonogrami)
			{
				izvodjac.Fonogrami.Add(ConvertToFonogramViewable(fonogram) as Fonogram);
			}

			return izvodjac;
		}
	}
}

