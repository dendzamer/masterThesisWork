using System;
using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
	public interface IIzvodjacViewable : IViewable
	{
		List<Album> Albumi {get; set;}
		List<Fonogram> Fonogrami {get; set;}
	}
}
