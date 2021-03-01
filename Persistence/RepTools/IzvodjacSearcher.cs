using System;
using System.Collections.Generic;
using Domain.Interfaces;
using Persistence.Interfaces;
using Persistence.RepTools.SearchTools;
using Persistence.Converters;

namespace Persistence.RepTools
{
	public class IzvodjacSearcher
	{
		private List<IViewable> _viewableIzvodjac;
		private List<IDb> _dbIzvodjac;
		private IDTO _localDTO;

		public IzvodjacSearcher(IDTO idto)
		{
			_viewableIzvodjac = new List<IViewable>();
			_localDTO = idto;

			doSearch(_localDTO);
			convertToViewable();
		}

		private void doSearch(IDTO input)
		{
			_dbIzvodjac = IzvodjacSearchTools.ByNaziv(input.Naziv);
		}

		private void convertToViewable()
		{
			foreach(var element in _dbIzvodjac)
			{
				_viewableIzvodjac.Add(DbModelsToViewable.ConvertToIzvodjacViewable(element as IDbIzvodjac));
			}
		}

		public List<IViewable> GetViewable()
		{
			return _viewableIzvodjac;

		}
	}
}
