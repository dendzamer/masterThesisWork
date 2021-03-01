using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Interfaces;
using Persistence.Converters;
using Persistence.RepTools;

namespace Persistence
{
	public class RepSearcher : ISearcher
	{

		private List<IViewable> _viewable;

		public RepSearcher()
		{
			_viewable = new List<IViewable>();
		}

		public void Album(IDTO idto)
		{

			AlbumSearcher aSearch = new AlbumSearcher(idto);

			_viewable = aSearch.GetViewable();
		}

		public void Fonogram(IDTO idto)
		{
			FonogramSearcher fSearch = new FonogramSearcher(idto);

			_viewable = fSearch.GetViewable();
		}

		public void Izvodjac(IDTO idto)
		{
			IzvodjacSearcher iSearch = new IzvodjacSearcher(idto);

			_viewable = iSearch.GetViewable();
		}


		public List<IViewable> GetViewable()
		{
			return _viewable;
		}
	}
}
