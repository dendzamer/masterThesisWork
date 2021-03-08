using System;
using Domain.DTOs;
using Domain.Interfaces;
using System.Collections.Generic;

namespace DataInjector
{
	public class InjectSRU
	{
		private SaveReadUpdate _sru;
		private Search _search;
		private GetAll _getAll;
		private ISearcher _mySearchRepository;
		private IRepAll _myGetAllRepository;
		private IRepository _myRepository;

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

		public IViewModel DeleteData(IDTO inputDto)
		{
			_myRepository = RepCreator.GetRepDeleter();
			
			_sru = new SaveReadUpdate(inputDto, _myRepository);

			return _sru.GetViewModel();
		}

		public List<IViewModel> SearchData(IDTO inputDto)
		{
			_mySearchRepository = RepCreator.GetRepSearcher();

			_search = new Search(inputDto, _mySearchRepository);

			return _search.GetViewModel();
		}

		public List<IViewModel> GetAll(int input)
		{
			_myGetAllRepository = RepCreator.GetRepAll();

			_getAll = new GetAll(input, _myGetAllRepository);

			return _getAll.GetViewModel();
		}
	}
}
