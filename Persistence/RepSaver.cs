using System;
using System.Collections.Generic;
using Domain.Models;
using Domain.DTOs;
using Domain.Interfaces;

namespace Persistence
{
	public class RepSaver : IRepository
	{
		private IViewable _viewable;

		public void Album(IDTO idto)
		{
			AlbumDTO album = idto as AlbumDTO;
			Album albumModel = new Album();
			albumModel.Naziv = album.Naziv;
			albumModel.Fonogrami = new List<Fonogram>();
			albumModel.Id = 111;
			albumModel.Izvodjaci = new List<Izvodjac>();
			albumModel.GodinaIzdanja = album.GodinaIzdanja;
			albumModel.KataloskiBroj = album.KataloskiBroj;

			_viewable = albumModel;
		}
		
		public void Fonogram(IDTO idto)
		{
			FonogramDTO fonogram = idto as FonogramDTO;
			Fonogram fonogramModel = new Fonogram();
			fonogramModel.Naziv = fonogram.Naziv;
			fonogramModel.Id = 112;
			fonogramModel.Izvodjaci = new List<Izvodjac>();
			fonogramModel.GodinaIzdanja = fonogram.GodinaIzdanja;
			fonogramModel.KataloskiBroj = fonogram.KataloskiBroj;	

			_viewable = fonogramModel;
		}
		
		public void Izvodjac(IDTO idto)
		{
			IDTO izvodjac = idto;
			Izvodjac izvodjacModel = new Izvodjac();
			izvodjacModel.Naziv = izvodjac.Naziv;
			izvodjacModel.Id = 113;
			izvodjacModel.Albumi = new List<Album>();
			izvodjacModel.Fonogrami = new List<Fonogram>();

			_viewable = izvodjacModel;
		}

		public IViewable GetViewable()
		{
			return _viewable;
		}
	}
}
