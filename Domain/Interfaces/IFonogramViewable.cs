using System;
using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
	public interface IFonogramViewable : IViewable
	{
		List<Izvodjac> Izvodjaci {get; set;}
		int GodinaIzdanja {get; set;}
		int KataloskiBroj {get; set;}
	}
}
