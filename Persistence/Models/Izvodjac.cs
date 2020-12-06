using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Models
{
	public class Izvodjac
	{
		public int IzvodjacId {get; set;}
		public string Naziv {get; set;}
		
		public List<Album> Albumi {get; set;}
		public List<Fonogram> Fonogrami {get; set;}
	}
}
