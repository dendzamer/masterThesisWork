using System;

namespace Domain.Interfaces
{
	public interface IAlbumViewModel : IViewModel
	{
		string Izvodjaci {get; set;}
		string Fonogrami {get; set;}
		int GodinaIzdanja {get; set;}
		string KataloskiBroj {get; set;}
	}
}
