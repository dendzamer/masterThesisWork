using System;
using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Converters;
using Domain.ViewModels;

namespace Domain.Facade
{
	public class AppMainService
	{
		private IRepository _repository;

		public AppMainService(IRepository repository)
		{
			_repository = repository;
		}

		public IViewModel Album(IDTO idto)
		{
			_repository.Album(idto);

			return ConvertToViewModel.GetAlbumViewModel(_repository.GetViewable());
		}

		public IViewModel Fonogram(IDTO idto)
		{
			_repository.Fonogram(idto);

			return ConvertToViewModel.GetFonogramViewModel(_repository.GetViewable());
		}

		public IViewModel Izvodjac(IDTO idto)
		{
			_repository.Izvodjac(idto);

			return ConvertToViewModel.GetIzvodjacViewModel(_repository.GetViewable());
		}
		
	}
}
