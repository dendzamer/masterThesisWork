using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain.Models
{
	public class Fonogram : IFonogramViewable
	{
		public int Id {get; set;}
		public string Naziv {get; set;}
		public List<Izvodjac> Izvodjaci {get; set;}
		public int GodinaIzdanja {get; set;}
		public string KataloskiBroj {get; set;}
		public string AlbumNaziv {get; set;}

		public Fonogram()
		{
			Izvodjaci = new List<Izvodjac>();
		}



	}
}
