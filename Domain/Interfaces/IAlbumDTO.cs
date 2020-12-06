using System;

namespace Domain.Interfaces
{
	public interface IAlbumDTO : IDTO
	{
		string KataloskiBroj {get; set;}
		int GodinaIzdanja {get; set;}
	}
}
