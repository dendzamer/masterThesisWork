using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain.Models
{
	public class Album : Fonogram, IAlbumViewable
	{
		public List<Fonogram> Fonogrami {get; set;}

		public Album()
		{
			Izvodjaci = new List<Izvodjac>();
			Fonogrami = new List<Fonogram>();
		}


	}
}
