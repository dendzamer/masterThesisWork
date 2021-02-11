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
		private DtoToDbModels _toDBModels;
		private DbModelsToViewable _toViewable;
		private Saver _saver;

		public RepSaver()
		{
			_toDBModels = new DtoToDbModels();
			_toViewable = new DbModelsToViewable();
			_saver = new Saver();

		}

		public void Album(IDTO idto)
		{
			Album album = _toDBModels.ConvertToAlbum(idto as IAlbumDTO);
			_saver.SaveAlbum(album);

			_viewable = _toViewable.ConvertToAlbumViewable(album);
		
		}
		
		public void Fonogram(IDTO idto)
		{
			Fonogram fonogram = _toDBModels.ConvertToFonogram(idto as IFonogramDTO);
			Fonogram newFonogram = _saver.SaveFonogram(fonogram);

			_viewable = _toViewable.ConvertToFonogramViewable(newFonogram);
		}

		
		public void Izvodjac(IDTO idto)
		{
			Izvodjac izvodjac = _toDBModels.ConvertToIzvodjac(idto as IDTO);
			_saver.SaveIzvodjac(izvodjac);

			_viewable = _toViewable.ConvertToIzvodjacViewable(izvodjac);
		}

		public IViewable GetViewable()
		{
			return _viewable;
		}
	}
}
