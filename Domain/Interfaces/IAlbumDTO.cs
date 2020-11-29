using System;

namespace Domain.Interfaces
{
	public interface IAlbumDTO : IDTO
	{
		int KataloskiBroj {get; set;}
		int GodinaIzdanja {get; set;}
	}
}
