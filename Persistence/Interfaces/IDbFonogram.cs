using System;
using System.Collections.Generic;
using Persistence.Models;

namespace Persistence.Interfaces
{
	public interface IDbFonogram : IDb
	{
		int FonogramId {get; set;}
		int GodinaIzdanja {get; set;}
		string KataloskiBroj {get; set;}

		List<Izvodjac> Izvodjaci {get; set;}
	}
}
