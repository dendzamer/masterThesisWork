using System;
using Persistence.Models;
using Domain.Interfaces;
using System.Linq;
using Persistence.RepTools.Retrieve;

namespace Persistence.Converters
{
	public class DtoToDbModels
	{
		public Album ConvertToAlbum(IAlbumDTO input)
		{
			Album album = new Album();
			album.AlbumId = input.Id;
			album.Naziv = input.Naziv;
			album.GodinaIzdanja = input.GodinaIzdanja;
			album.KataloskiBroj = input.KataloskiBroj;

			return album;
		}

		public Izvodjac ConvertToIzvodjac(IDTO input)
		{
			Izvodjac izvodjac = new Izvodjac();
			izvodjac.IzvodjacId = input.Id;
			izvodjac.Naziv = input.Naziv;

			return izvodjac;
		}

		public Fonogram ConvertToFonogram(IFonogramDTO input)
		{
			Fonogram fonogram = new Fonogram();
			fonogram.FonogramId = input.Id;
			fonogram.Naziv = input.Naziv;
			fonogram.GodinaIzdanja = input.GodinaIzdanja;
			fonogram.KataloskiBroj = input.KataloskiBroj;
			fonogram.AlbumId = input.AlbumId;


			foreach (int izvodjacId in input.IzvodjacId)
				{
					RetrieveIzvodjac _retrieve = new RetrieveIzvodjac();
					Izvodjac izvodjac = _retrieve.IzvodjacWithoutFonogram(izvodjacId);

					//Izvodjac izvodjac = new Izvodjac(){IzvodjacId = izvodjacId};

					fonogram.Izvodjaci.Add(izvodjac);
				}


			return fonogram;
		}
	}
}
