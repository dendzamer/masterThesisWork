using System;
using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
	public interface IAlbumViewable : IViewable
	{
		List<Fonogram> Fonogrami {get; set;}
		List<Izvodjac> Izvodjaci {get; set;}
		string KataloskiBroj {get; set;}
		int GodinaIzdanja {get; set;}
	}
}
