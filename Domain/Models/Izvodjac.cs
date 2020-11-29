using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain.Models
{
    public class Izvodjac : IIzvodjacViewable
    {
	    public int Id {get; set;}
	    public string Naziv {get; set;}
	    public List<Album> Albumi {get; set;}
	    public List<Fonogram> Fonogrami {get; set;}

	    public Izvodjac()
	    {
		    Albumi = new List<Album>();
		    Fonogrami = new List<Fonogram>();
	    }
    }
}
