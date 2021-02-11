using System;
using Persistence.Interfaces;
using Domain.Models;
using Domain.Interfaces;
using Persistence.RepTools.Retrieve;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Converters
{
	public class DbModelsToViewable
	{
		public IViewable ConvertToAlbumViewable(IDbAlbum input)
		{
			IAlbumViewable album = populateAlbum(input);

			foreach (var fonogram in input.Fonogrami)
			{
				album.Fonogrami.Add(populateFonogram(fonogram) as Fonogram);
		 	}

			foreach (var fonogram in input.Fonogrami)
			{
				foreach (var izvodjac in fonogram.Izvodjaci)
				{
					if (!album.Izvodjaci.Any(element => element.Id == izvodjac.IzvodjacId))
					album.Izvodjaci.Add(populateIzvodjac(izvodjac) as Izvodjac);
				}
			}

			return album;
		}

		public IViewable ConvertToFonogramViewable(IDbFonogram input)
		{
			IFonogramViewable fonogram = populateFonogram(input);

			foreach (var izvodjac in input.Izvodjaci)
			{
				fonogram.Izvodjaci.Add(populateIzvodjac(izvodjac) as Izvodjac);
			}

			return fonogram;
		}
		
		public IViewable ConvertToIzvodjacViewable(IDbIzvodjac input)
		{
			IIzvodjacViewable izvodjac = populateIzvodjac(input);
			RetrieveAlbum _retrieve = new RetrieveAlbum();

			foreach (var fonogram in input.Fonogrami)
			{
				izvodjac.Fonogrami.Add(populateFonogram(fonogram) as Fonogram);
			}

			foreach (var fonogram in input.Fonogrami)
			{
				if (!izvodjac.Albumi.Any(element => element.Id == fonogram.AlbumId))
				{
					IDbAlbum album = _retrieve.AlbumWithoutFonogram(fonogram.AlbumId);
				
					izvodjac.Albumi.Add(populateAlbum(album) as Album);
				}
			}

			return izvodjac;
		}

		
		private IAlbumViewable populateAlbum(IDbAlbum input)
		{
			IAlbumViewable album = new Album();

			album.Id = input.AlbumId;
			album.Naziv = input.Naziv;
			album.GodinaIzdanja = input.GodinaIzdanja;
			album.KataloskiBroj = input.KataloskiBroj;

			return album;
		}

		private IFonogramViewable populateFonogram(IDbFonogram input)
		{
			IFonogramViewable fonogram = new Fonogram();

			fonogram.Id = input.FonogramId;
			fonogram.Naziv = input.Naziv;
			fonogram.GodinaIzdanja = input.GodinaIzdanja;
			fonogram.KataloskiBroj = input.KataloskiBroj;

			return fonogram;
		}
		
		private IIzvodjacViewable populateIzvodjac(IDbIzvodjac input)
		{
			IIzvodjacViewable izvodjac = new Izvodjac();

			izvodjac.Id = input.IzvodjacId;
			izvodjac.Naziv = input.Naziv;

			return izvodjac;
		}
	}
}

