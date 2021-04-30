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
	}
}



