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
	}
}
