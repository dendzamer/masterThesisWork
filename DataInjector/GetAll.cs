using System;
using Domain.Facade;
using Domain.Interfaces;
using System.Collections.Generic;

namespace DataInjector
{
	public class GetAll
	{

		private List<IViewModel> _resultViewModels;
		private IRepAll _repository;
		private AppGetAllService _localService;

		public GetAll(int inputInt, IRepAll inputRepository)
		{
			_repository = inputRepository;
			_localService = new AppGetAllService(_repository);
			evaluateInput(inputInt);
		}

		private void evaluateInput(int input)
		{
			if (input == 0)
			{
				_resultViewModels = _localService.GetAlbums();
			}

			else if (input == 1)
			{
				_resultViewModels = _localService.GetFonogram();
			}

			else
			{
				_resultViewModels = _localService.GetIzvodjac();
			}
		}

		public List<IViewModel> GetViewModel()
		{
			return _resultViewModels;
		}
			


	}
}
