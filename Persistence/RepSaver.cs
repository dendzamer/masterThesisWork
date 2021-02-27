using System;
using System.Collections.Generic;
using Domain.DTOs;
using Domain.Interfaces;
using Persistence.Models;
using Persistence.Converters;
using Persistence.RepTools;

namespace Persistence
{
	public class RepSaver : IRepository
	{
		private IViewable _viewable;
		private Saver _saver;

		public RepSaver()
		{
			_saver = new Saver();
		}

		public void Album(IDTO idto)
		{
			Album album = DtoToDbModels.ConvertToAlbum(idto as IAlbumDTO);
			_saver.SaveAlbum(album);

			_viewable = DbModelsToViewable.ConvertToAlbumViewable(album);
		
		}
		
		public void Fonogram(IDTO idto)
		{
			Fonogram fonogram = DtoToDbModels.ConvertToFonogram(idto as IFonogramDTO);
			Fonogram newFonogram = _saver.SaveFonogram(fonogram);

			_viewable = DbModelsToViewable.ConvertToFonogramViewable(newFonogram);
		}

		
		public void Izvodjac(IDTO idto)
		{
			Izvodjac izvodjac = DtoToDbModels.ConvertToIzvodjac(idto as IDTO);
			_saver.SaveIzvodjac(izvodjac);

			_viewable = DbModelsToViewable.ConvertToIzvodjacViewable(izvodjac);
		}

		public IViewable GetViewable()
		{
			return _viewable;
		}
	}
}
