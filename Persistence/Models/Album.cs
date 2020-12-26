using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;

namespace Persistence.Models
{
	public class Album : IDbAlbum
	{
		public int AlbumId {get; set;}
		public string Naziv {get; set;}
		public int GodinaIzdanja {get; set;}
		public string KataloskiBroj {get; set;}

		public List<Fonogram> Fonogrami {get; set;} = new List<Fonogram>();
	}
}
