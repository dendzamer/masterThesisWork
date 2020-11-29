using System;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain.DTOs
{
	public class FonogramDTO : IFonogramDTO
	{
		public string Naziv {get; set;}
		public int KataloskiBroj {get; set;}
		public int GodinaIzdanja {get; set;}
		public List<int> IzvodjacId {get; set;}
		public int AlbumId {get; set;}

		public FonogramDTO()
		{
			IzvodjacId = new List<int>();
		}

	}
}
