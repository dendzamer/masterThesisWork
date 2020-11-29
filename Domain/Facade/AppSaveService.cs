using System;
using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Converters;
using Domain.ViewModels;

namespace Domain.Facade
{
	public class AppSaveService
	{
		private IRepository _repository;

		public AppSaveService(IRepository repository)
		{
			_repository = repository;
		}

		public IViewModel SaveAlbum(IDTO idto)
		{
			//pozvati SaveAlbum metod iz _repository
			_repository.Album(idto);

			return ConvertToViewModel.GetAlbumViewModel(_repository.GetViewable());
		}

		public IViewModel SaveFonogram(IDTO idto)
		{
			_repository.Fonogram(idto);

			return ConvertToViewModel.GetFonogramViewModel(_repository.GetViewable());
		}

		public IViewModel SaveIzvodjac(IDTO idto)
		{
			_repository.Izvodjac(idto);

			return ConvertToViewModel.GetIzvodjacViewModel(_repository.GetViewable());
		}
	}
}

