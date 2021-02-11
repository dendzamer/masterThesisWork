using System;
using Domain.Interfaces;
using Domain.Converters;
using Domain.ViewModels;

namespace Domain.Facade
{
	public class AppRetrieveService
	{
		private IRepository _repository;

		public AppRetrieveService(IRepository repository)
		{
			_repository = repository;
		}

		public IViewModel RetrieveAlbum(IDTO idto)
		{
			_repository.Album(idto);

			return ConvertToViewModel.GetAlbumViewModel(_repository.GetViewable());
		}

		public IViewModel RetrieveFonogram(IDTO idto)
		{
			_repository.Fonogram(idto);

			return ConvertToViewModel.GetFonogramViewModel(_repository.GetViewable());
		}

		public IViewModel RetrieveIzvodjac(IDTO idto)
		{
			_repository.Izvodjac(idto);

			return ConvertToViewModel.GetIzvodjacViewModel(_repository.GetViewable());
		}

	}
}
