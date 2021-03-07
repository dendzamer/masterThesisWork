using System;
using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Converters;
using Domain.ViewModels;

namespace Domain.Facade
{
	public class AppGetAllService
	{
		private IRepAll _repository;
		private List<IViewable> _viewableList;
		private List<IViewModel> _returnModels;

		public AppGetAllService(IRepAll repository)
		{
			_repository = repository;
			_viewableList = new List<IViewable>();
			_returnModels = new List<IViewModel>();
		}

		public List<IViewModel> GetAlbums()
		{
			_repository.Album();
			_viewableList = _repository.GetViewable();

			foreach(var element in _viewableList)
			{
				_returnModels.Add(ConvertToViewModel.GetAlbumViewModel(element));
			}

			return _returnModels;
		}
		
		public List<IViewModel> GetFonogram()
		{
			_repository.Fonogram();
			_viewableList = _repository.GetViewable();

			foreach(var element in _viewableList)
			{
				_returnModels.Add(ConvertToViewModel.GetFonogramViewModel(element));
			}

			return _returnModels;
		}
		
		public List<IViewModel> GetIzvodjac()
		{
			_repository.Izvodjac();
			_viewableList = _repository.GetViewable();

			foreach(var element in _viewableList)
			{
				_returnModels.Add(ConvertToViewModel.GetIzvodjacViewModel(element));
			}

			return _returnModels;
		}

	}
}
