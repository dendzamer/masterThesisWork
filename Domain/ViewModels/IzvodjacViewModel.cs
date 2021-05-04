using System;
using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Models;
using System.Linq;

namespace Domain.ViewModels
{
	public class IzvodjacViewModel : IIzvodjacViewModel
	{
		public int Id {get; set;}
		public string Naziv {get; set;}
		public string Albumi {get; set;}
		public string Fonogrami {get; set;}

		public void SetData(IViewable data)
		{
			IIzvodjacViewable izvodjac = data as IIzvodjacViewable;
			Id = izvodjac.Id;
			Naziv = izvodjac.Naziv;
			SetAlbumi(izvodjac);
			SetFonogrami(izvodjac);
		}

		private void SetAlbumi(IIzvodjacViewable izvodjac)
		{
			if (izvodjac.Albumi.Any())
			{
				foreach (Album album in izvodjac.Albumi)
				{
					Albumi += String.Format($"\n\t ID: {album.Id} Naziv: {album.Naziv}");
				}
			}
			else
				Albumi = "Jos nema unosa";
		}

		private void SetFonogrami(IIzvodjacViewable izvodjac)
		{
			if (izvodjac.Fonogrami.Any())
			{
				foreach (Fonogram fonogram in izvodjac.Fonogrami)
				{
					Fonogrami += String.Format($"\n\tID: {fonogram.Id} Naziv: {fonogram.Naziv}");
				}
			}
			else
				Fonogrami = "Jos nema unosa";
		}
	}
}
