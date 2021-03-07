using System;
using Domain.DTOs;
using Domain.Facade;
using Domain.Interfaces;

namespace DataInjector
{
	public class SaveReadUpdate
	{
		private IViewModel _resultViewModel;
		private IRepository _repository;
		private AppMainService _localService;

		public SaveReadUpdate(IDTO inputDTO, IRepository inputRepository)
		{
			_repository = inputRepository;
			_localService = new AppMainService(_repository);
			evaluateInput(inputDTO);
		}

		private void evaluateInput(IDTO myDto)
		{
			if (myDto is IAlbumDTO)
			{
				_resultViewModel = _localService.Album(myDto);
			}

			else if (myDto is IFonogramDTO)
			{
				_resultViewModel = _localService.Fonogram(myDto);
			}

			else
			{
				_resultViewModel = _localService.Izvodjac(myDto);
			}
		}

		public IViewModel GetViewModel()
		{
			return _resultViewModel;
		}

	}
}
