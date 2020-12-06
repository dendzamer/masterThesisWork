using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain.Models
{
	public class Album : IAlbumViewable
	{
		public int Id {get; set;}
		public string Naziv {get; set;}
		public int GodinaIzdanja {get; set;}
		public string KataloskiBroj {get; set;}
		public List<Izvodjac> Izvodjaci {get; set;}
		public List<Fonogram> Fonogrami {get; set;}

		public Album()
		{
			Izvodjaci = new List<Izvodjac>();
			Fonogrami = new List<Fonogram>();
		}


	}
}
