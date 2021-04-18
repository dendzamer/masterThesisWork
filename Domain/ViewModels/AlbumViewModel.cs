using System;
using Domain.Interfaces;
using Domain.Models;
using System.Linq;

namespace Domain.ViewModels
{
	public class AlbumViewModel : IAlbumViewModel
	{
		public int Id {get; set;}
		public string Naziv {get; set;}
		public string Izvodjaci {get; set;}
		public int GodinaIzdanja {get; set;}
		public string KataloskiBroj {get; set;}
		public string Fonogrami {get; set;}

		public void SetData(IViewable data)
		{
			IAlbumViewable album = data as IAlbumViewable;
			Id = album.Id;
			Naziv = album.Naziv;
			SetIzvodjaci(album);
			GodinaIzdanja = album.GodinaIzdanja;
			KataloskiBroj = album.KataloskiBroj;
			SetFonogrami(album);

		}

		private void SetIzvodjaci(IAlbumViewable album)
		{
			if (album.Izvodjaci.Any())
			{
				foreach(Izvodjac izvodjac in album.Izvodjaci)
				{
					Izvodjaci += String.Format($"\n{izvodjac.Naziv}");
				}
			}
			else
				Izvodjaci = "Jos nema unosa";
		}

		private void SetFonogrami(IAlbumViewable album)
		{
			if(album.Fonogrami.Any())
			{
				foreach (Fonogram fonogram in album.Fonogrami)
				{
					Fonogrami += String.Format($"\n{fonogram.Naziv}");
				}
			}
			else
				Fonogrami = "Jos nema unosa";
		}

	}
}
