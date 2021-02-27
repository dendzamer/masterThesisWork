using System;

namespace Domain.Interfaces
{
	public interface IFonogramViewModel : IViewModel
	{
		string Izvodjaci {get; set;}
		int GodinaIzdanja {get; set;}
		string KataloskiBroj {get; set;}
		string AlbumNaziv {get; set;}
	}


}
