using System;

namespace Domain.Interfaces
{
	public interface IFonogramViewModel : IViewModel
	{
		string Izvodjaci {get; set;}
		int GodinaIzdanja {get; set;}
		int KataloskiBroj {get; set;}
	}


}
