using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;

namespace Persistence.Models
{
	public class Izvodjac : IDbIzvodjac
	{
		public int IzvodjacId {get; set;}
		public string Naziv {get; set;}
		
		public List<Album> Albumi {get; set;}
		public List<Fonogram> Fonogrami {get; set;}
	}
}
