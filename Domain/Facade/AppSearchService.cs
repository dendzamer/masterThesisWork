using System;
using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Converters;
using Domain.ViewModels;

namespace Domain.Facade
{
	public class AppSearchService
	{
		private ISearcher _repository;
		private List<IViewable> _viewableList;
		private List<IViewModel> _returnModels;

		public AppSearchService(ISearcher repository)
		{
			_repository = repository;
			_viewableList = new List<IViewable>();
			_returnModels = new List<IViewModel>();
		}

		public List<IViewModel> SearchAlbum(IDTO idto)
		{
			_repository.Album(idto);
			_viewableList = _repository.GetViewable();

			foreach(var element in _viewableList)
			{
				_returnModels.Add(ConvertToViewModel.GetAlbumViewModel(element));
			}

			return _returnModels;
		}

		public List<IViewModel> SearchFonogram(IDTO idto)
		{
			_repository.Fonogram(idto);
			_viewableList = _repository.GetViewable();

			foreach (var element in _viewableList)
			{
				_returnModels.Add(ConvertToViewModel.GetFonogramViewModel(element));
			}

			return _returnModels;
		}

		public List<IViewModel> SearchIzvodjac(IDTO idto)
		{
			_repository.Izvodjac(idto);
			_viewableList = _repository.GetViewable();

			foreach (var element in _viewableList)
			{
				_returnModels.Add(ConvertToViewModel.GetIzvodjacViewModel(element));
			}

			return _returnModels;
		}
	}

}

