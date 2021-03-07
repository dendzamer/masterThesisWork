using System;
using Domain.DTOs;
using Domain.Facade;
using Domain.Interfaces;
using System.Collections.Generic;

namespace DataInjector
{
	public class Search
	{
		private List<IViewModel> _resultViewModels;
		private ISearcher _repository;
		private AppSearchService _localService;

		public Search(IDTO inputDTO, ISearcher inputRepository)
		{
			_repository = inputRepository;
			_localService = new AppSearchService(_repository);
			evaluateInput(inputDTO);
		}

		private void evaluateInput(IDTO myDto)
		{
			if (myDto is IAlbumDTO)
			{
				_resultViewModels = _localService.SearchAlbum(myDto);
			}

			else if (myDto is IFonogramDTO)
			{
				_resultViewModels = _localService.SearchFonogram(myDto);
			}

			else
			{
				_resultViewModels = _localService.SearchIzvodjac(myDto);
			}
		}

		public List<IViewModel> GetViewModel()
		{
			return _resultViewModels;
		}


	}
}
