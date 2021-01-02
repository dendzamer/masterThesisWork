using System;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain.DTOs
{
	public class FonogramDTO : IFonogramDTO
	{
		public int Id {get; set;}
		public string Naziv {get; set;}
		public string KataloskiBroj {get; set;}
		public int GodinaIzdanja {get; set;}
		public List<int> IzvodjacId {get; set;}
		public int AlbumId {get; set;}

		public FonogramDTO()
		{
			IzvodjacId = new List<int>();
		}

	}
}
