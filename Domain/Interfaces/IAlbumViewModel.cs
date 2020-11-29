using System;

namespace Domain.Interfaces
{
	public interface IAlbumViewModel : IViewModel
	{
		string Izvodjaci {get; set;}
		string Fonogrami {get; set;}
		int GodinaIzdanja {get; set;}
		int KataloskiBroj {get; set;}
	}
}
