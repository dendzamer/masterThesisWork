using System;
using Domain.Interfaces;

namespace Domain.DTOs
{
	public class AlbumDTO : IAlbumDTO
	{
		public string Naziv {get; set;}
		public int KataloskiBroj {get; set;}
		public int GodinaIzdanja {get; set;}

	}
}

