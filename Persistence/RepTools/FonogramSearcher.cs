using System;
using System.Collections.Generic;
using Domain.Interfaces;
using Persistence.Interfaces;
using Persistence.RepTools.SearchTools;
using Persistence.Converters;

namespace Persistence.RepTools
{
	public class FonogramSearcher
	{
		private List<IViewable> _viewableFonograms;
		private List<IDb> _dbFonograms;
		private IFonogramDTO _localDTO;

		public FonogramSearcher(IDTO idto)
		{
			_viewableFonograms = new List<IViewable>();

			_localDTO = idto as IFonogramDTO;

			determineTypeOfSearch(_localDTO);
			convertToViewable();
		}

		private void determineTypeOfSearch(IFonogramDTO input)
		{
			if (input.Naziv != null)
			{
				_dbFonograms = FonogramSearchTools.ByNaziv(input.Naziv);
			}

			else if (input.KataloskiBroj != null)
			{
				_dbFonograms = FonogramSearchTools.ByKataloskiBroj(input.KataloskiBroj);
			}

			else
			{
				_dbFonograms = FonogramSearchTools.ByGodinaIzdanja(input.GodinaIzdanja);
			}
		}

		private void convertToViewable()
		{
			foreach (var element in _dbFonograms)
			{
				_viewableFonograms.Add(DbModelsToViewable.ConvertToFonogramViewable(element as IDbFonogram));
			}
		}

		public List<IViewable> GetViewable()
		{
			return _viewableFonograms;
		}

	}
}
