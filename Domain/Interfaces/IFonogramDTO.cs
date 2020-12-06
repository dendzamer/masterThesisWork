using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
	public interface IFonogramDTO : IDTO
	{
		string KataloskiBroj {get; set;}
		int GodinaIzdanja {get; set;}
		int AlbumId {get; set;}
		List<int> IzvodjacId {get; set;}
	}
}
