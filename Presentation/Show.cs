using System;
using Domain.Interfaces;

namespace Presentation
{
	public static class Show
	{
		static public void ShowSaved(IViewModel input)
		{
			if (input is IAlbumViewModel)
			{
				ShowAlbum(input as IAlbumViewModel);
			}

			else if (input is IFonogramViewModel)
			{
				ShowFonogram(input as IFonogramViewModel);
			}

			else
			{
				ShowIzvodjac(input as IIzvodjacViewModel);
			}
		}

		static private void ShowAlbum(IAlbumViewModel album)
		{
			Console.Clear();
			Console.WriteLine("Obrada je zavrsena za sledeci album:");
			Console.WriteLine("-----------------------------------------------------");
			Console.WriteLine("Id: {0} Naziv: {1}", album.Id, album.Naziv);
			Console.WriteLine("Godina izdanja: {0}", album.GodinaIzdanja);
			Console.WriteLine("Kataloski broj: {0}", album.KataloskiBroj);
			Console.WriteLine("Fonogrami: {0}", album.Fonogrami);
			Console.WriteLine("Izvodjaci: {0}", album.Izvodjaci);
			Console.WriteLine("-----------------------------------------------------");
			Console.WriteLine("Pritisnite Enter za povratak na prethodni meni.");
			Console.ReadLine();
		}

		static private void ShowFonogram(IFonogramViewModel fonogram)
		{
			Console.Clear();
			Console.WriteLine("Obrada je zavrsena za sledeci fonogram:");
			Console.WriteLine("-----------------------------------------------------");
			Console.WriteLine("Id: {0} Naziv: {1}", fonogram.Id, fonogram.Naziv);
			Console.WriteLine("Naziv albuma: {0}", fonogram.AlbumNaziv);
			Console.WriteLine("Godina izdanja: {0}", fonogram.GodinaIzdanja);
			Console.WriteLine("Kataloski broj: {0}", fonogram.KataloskiBroj);
			Console.WriteLine("Izvodjaci: {0}", fonogram.Izvodjaci);
			Console.WriteLine("-----------------------------------------------------");
			Console.WriteLine("Pritisnite Enter za povratak na prethodni meni.");
			Console.ReadLine();
		}

		static private void ShowIzvodjac(IIzvodjacViewModel izvodjac)
		{
			Console.Clear();
			Console.WriteLine("Obrada je zavrsena za sledeceg izvodjaca:");
			Console.WriteLine("-----------------------------------------------------");
			Console.WriteLine("Id: {0} Naziv: {1}", izvodjac.Id, izvodjac.Naziv);
			Console.WriteLine("Fonogrami: {0}", izvodjac.Fonogrami);
			Console.WriteLine("Albumi: {0}", izvodjac.Albumi);
			Console.WriteLine("-----------------------------------------------------");
			Console.WriteLine("Pritisnite Enter za povratak na prethodni meni.");
			Console.ReadLine();
		}
	}
}

