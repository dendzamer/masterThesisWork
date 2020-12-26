using System;
using System.Collections.Generic;
using Persistence.Interfaces;
using Persistence.Models;

namespace Persistence.Interfaces
{
	public interface IDbAlbum : IDb
	{
		int AlbumId {get; set;}
		int GodinaIzdanja {get; set;}
		string KataloskiBroj {get; set;}

		List<Fonogram> Fonogrami {get; set;}
	}
}
