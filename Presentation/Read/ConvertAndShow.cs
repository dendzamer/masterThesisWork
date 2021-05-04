using System;
using System.Collections.Generic;
using Domain.Interfaces;
using Presentation;

namespace Presentation.Read
{
	public class ConvertAndShow
	{
		static public void Album(List<IViewModel> input)
		{
			List<IAlbumViewModel> output = new List<IAlbumViewModel>();

			foreach (var model in input)
			{
				output.Add(model as IAlbumViewModel);
			}

			ShowLists.Album(output);
		}

		static public void Fonogram(List<IViewModel> input)
		{
			List<IFonogramViewModel> output = new List<IFonogramViewModel>();

			foreach (var model in input)
			{
				output.Add(model as IFonogramViewModel);
			}

			ShowLists.Fonogram(output);
		}

		static public void Izvodjac(List<IViewModel> input)
		{
			List<IIzvodjacViewModel> output = new List<IIzvodjacViewModel>();

			foreach (var model in input)
			{
				output.Add(model as IIzvodjacViewModel);
			}

			ShowLists.Izvodjac(output);
		}
	}
}
