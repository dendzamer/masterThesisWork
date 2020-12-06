using System;
using Domain.Interfaces;

namespace Domain.DTOs
{
	public class AlbumDTO : IAlbumDTO
	{
		public string Naziv {get; set;}
		public string KataloskiBroj {get; set;}
		public int GodinaIzdanja {get; set;}

	}
}

