using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Presentation
{
	public static class ShowLists
	{
		static public void Album(List<IAlbumViewModel> input)
		{
			Console.WriteLine("*************************************************************");
			foreach (var album in input)
			{
				Console.WriteLine("-----------------------------------------------------");
				Console.WriteLine("Id: {0} Naziv: {1}", album.Id, album.Naziv);
				Console.WriteLine("Godina izdanja: {0}", album.GodinaIzdanja);
				Console.WriteLine("Kataloski broj: {0}", album.KataloskiBroj);
				Console.WriteLine("Fonogrami: {0}", album.Fonogrami);
				Console.WriteLine("Izvodjaci: {0}", album.Izvodjaci);
			}
			Console.WriteLine("*************************************************************");
			Console.WriteLine("Pritisnite Enter za povratak na prethodni meni.");
			Console.ReadLine();
		}

                static public void Fonogram(List<IFonogramViewModel> input)
                {
                        Console.WriteLine("*************************************************************");
                        foreach (var fonogram in input)
			{
				Console.WriteLine("-----------------------------------------------------");
				Console.WriteLine("Id: {0} Naziv: {1}", fonogram.Id, fonogram.Naziv);
				Console.WriteLine("Naziv albuma: {0}", fonogram.AlbumNaziv);
				Console.WriteLine("Godina izdanja: {0}", fonogram.GodinaIzdanja);
				Console.WriteLine("Kataloski broj: {0}", fonogram.KataloskiBroj);
				Console.WriteLine("Izvodjaci: {0}", fonogram.Izvodjaci);
			}
                        Console.WriteLine("*************************************************************");
                        Console.WriteLine("Pritisnite Enter za povratak na prethodni meni.");
                        Console.ReadLine();
                }  

		static public void Izvodjac(List<IIzvodjacViewModel> input)
		{
			Console.WriteLine("*************************************************************");
			foreach (var izvodjac in input)
			{
				Console.WriteLine("-----------------------------------------------------");
				Console.WriteLine("Id: {0} Naziv: {1}", izvodjac.Id, izvodjac.Naziv);
				Console.WriteLine("Fonogrami: {0}", izvodjac.Fonogrami);
				Console.WriteLine("Albumi: {0}", izvodjac.Albumi);
			}
			Console.WriteLine("*************************************************************");
			Console.WriteLine("Pritisnite Enter za povratak na prethodni meni.");
			Console.ReadLine();
		}
	}
}



