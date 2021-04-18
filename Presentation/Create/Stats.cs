using System;
using Domain.DTOs;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Presentation.Create
{
	public class Stats
	{
		static public void AlbumStats(AlbumDTO input)
		{
			Console.WriteLine("Naziv: {0}", input.Naziv);
			Console.WriteLine("Kataloski broj: {0}", input.KataloskiBroj);
			Console.WriteLine("Godina izdanja: {0}", input.GodinaIzdanja);
		}

		static public void FonogramStats(FonogramDTO input, Dictionary<int, string> izvodjaci, string nazivAlbuma)
		{
			Console.WriteLine("Naziv: {0}", input.Naziv);
			Console.WriteLine("Kataloski broj: {0}", input.KataloskiBroj);
			Console.WriteLine("Godina izdanja: {0}", input.GodinaIzdanja);
			Console.WriteLine("Album Id: {0} Naziv albuma: {1}", input.AlbumId, nazivAlbuma);
			Console.WriteLine("Trenutno uneti izvodjaci: \n");

			foreach (var izvodjac in izvodjaci)
			{
				Console.WriteLine("ID: {0} Naziv: {1}", izvodjac.Key, izvodjac.Value);
			}
		}

		static public void IzvodjacStats(IzvodjacDTO input)
		{
			Console.WriteLine("Naziv: {0}", input.Naziv);
		}

		static public void AddIzvodjacStats(Dictionary<int, string> izvodjaci)
		{
			Console.WriteLine("Trenutno uneti izvodjaci: \n");
			foreach (var izvodjac in izvodjaci)
			{
				Console.WriteLine("ID: {0} Naziv: {1}", izvodjac.Key, izvodjac.Value);
			}
		}

		static public void AddAlbumStats(IAlbumViewModel input)
		{
			Console.WriteLine("Id broj: {0}", input.Id);
			Console.WriteLine("Naziv: {0}", input.Naziv);
			Console.WriteLine("Kataloski broj: {0}", input.KataloskiBroj);
			Console.WriteLine("Godina izdanja: {0}", input.GodinaIzdanja);
		}
	}
}
