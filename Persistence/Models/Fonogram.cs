using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Models
{
	public class Fonogram
	{
		public int FonogramId {get; set;}
		public string Naziv {get; set;}
		public int GodinaIzdanja {get; set;}
		public string KataloskiBroj {get; set;}

		public List<Izvodjac> Izvodjaci {get; set;} = new List<Izvodjac>();

		public int AlbumId {get; set;}
		public Album Album {get; set;}
	}
}
