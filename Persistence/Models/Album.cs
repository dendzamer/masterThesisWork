using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Models
{
	public class Album
	{
		public int AlbumId {get; set;}
		public string Naziv {get; set;}
		public int GodinaIzdanja {get; set;}
		public string KataloskiBroj {get; set;}

		public List<Fonogram> Fonogrami {get; set;} = new List<Fonogram>();
		public List<Izvodjac> Izvodjaci {get; set;} = new List<Izvodjac>();
	}
}
