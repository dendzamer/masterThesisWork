using System;
using Domain.Interfaces;
using Domain.Models;
using System.Linq;

namespace Domain.ViewModels
{
	public class FonogramViewModel : IFonogramViewModel
	{
		public int Id {get; set;}
		public string Naziv {get; set;}
		public string Izvodjaci {get; set;}
		public int GodinaIzdanja {get; set;}
		public int KataloskiBroj {get; set;}
		
		public void SetData(IViewable data)
		{
			IFonogramViewable fonogram = data as IFonogramViewable;
			Id = fonogram.Id;
			Naziv = fonogram.Naziv;
			SetIzvodjaci(fonogram);
			GodinaIzdanja = fonogram.GodinaIzdanja;
			KataloskiBroj = fonogram.KataloskiBroj;
		}
		
		private void SetIzvodjaci(IFonogramViewable fonogram)
		{
			if (fonogram.Izvodjaci.Any())
			{
				foreach(Izvodjac izvodjac in fonogram.Izvodjaci)
				{
					Izvodjaci += String.Format($"\n{izvodjac.Naziv}");
				}
			}
			else
				Izvodjaci = "Jos nema unosa";
		}



	}
}
