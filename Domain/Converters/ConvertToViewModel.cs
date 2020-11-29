using System;
using Domain.Interfaces;
using Domain.ViewModels;

namespace Domain.Converters
{
	public static class ConvertToViewModel
	{
		static public AlbumViewModel GetAlbumViewModel(IViewable data)
		{
			AlbumViewModel albumview = new AlbumViewModel();
			albumview.SetData(data);
			return albumview;

			//ovde treba obaviti konverziju iz album u albumview
		}

		static public FonogramViewModel GetFonogramViewModel(IViewable data)
		{
			FonogramViewModel fonogramview = new FonogramViewModel();
			fonogramview.SetData(data);
			return fonogramview;

			// prvo odratiti interface segregation neophodan za gornju metodu
		}

		static public IzvodjacViewModel GetIzvodjacViewModel(IViewable data)
		{
			IzvodjacViewModel izvodjacview = new IzvodjacViewModel();
			izvodjacview.SetData(data);
			return izvodjacview;
		}
		
	}
}
