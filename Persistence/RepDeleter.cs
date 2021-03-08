using System;
using System.Collections.Generic;
using Domain.DTOs;
using Domain.Interfaces;
using Persistence.Models;
using Persistence.Converters;
using Persistence.RepTools;

namespace Persistence
{
	public class RepDeleter : IRepository
	{
		private IViewable _viewable;
		
		public void Album(IDTO idto)
		{
			Album album = Deleter.DeleteAlbum(idto.Id);

			_viewable = DbModelsToViewable.ConvertToAlbumViewable(album);
		}

		public void Fonogram(IDTO idto)
		{
			Fonogram fonogram = Deleter.DeleteFonogram(idto.Id);

			_viewable = DbModelsToViewable.ConvertToFonogramViewable(fonogram);
		}

		public void Izvodjac(IDTO idto)
		{
			Izvodjac izvodjac = Deleter.DeleteIzvodjac(idto.Id);

			_viewable = DbModelsToViewable.ConvertToIzvodjacViewable(izvodjac);
		}

		public IViewable GetViewable()
		{
			return _viewable;
		}

	}
}
