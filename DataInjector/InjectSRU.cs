using System;
using Domain.DTOs;
using Domain.Interfaces;

namespace DataInjector
{
	public class InjectSRU
	{
		SaveReadUpdate _sru;
		IRepository _myRepository;

		public IViewModel SaveData(IDTO inputDto)
		{
			_myRepository = RepCreator.GetRepSaver();
			
			_sru = new SaveReadUpdate(inputDto, _myRepository);

			return _sru.GetViewModel();
		}

		public IViewModel ReadData(IDTO inputDto)
		{
			_myRepository = RepCreator.GetRepRetriever();

			_sru = new SaveReadUpdate(inputDto, _myRepository);

			return _sru.GetViewModel();
		}

		public IViewModel UpdateData(IDTO inputDto)
		{
			_myRepository = RepCreator.GetRepUpdater();

			_sru = new SaveReadUpdate(inputDto, _myRepository);

			return _sru.GetViewModel();
		}
	}
}
