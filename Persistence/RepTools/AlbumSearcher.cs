using System;
using System.Collections.Generic;
using Domain.Interfaces;
using Persistence.Interfaces;
using Persistence.RepTools.SearchTools;
using Persistence.Converters;

namespace Persistence.RepTools
{
	public class AlbumSearcher
	{
		private List<IViewable> _viewableAlbums;
		private List<IDb> _dbAlbums;
		private IAlbumDTO _localDTO;

		public AlbumSearcher(IDTO idto)
		{
			_viewableAlbums = new List<IViewable>();

			_localDTO = idto as IAlbumDTO;

			determineTypeOfSearch(_localDTO);
			convertToViewable();
		}

		private void determineTypeOfSearch(IAlbumDTO input)
		{
			if (input.Naziv != null)
			{
				_dbAlbums = AlbumSearchTools.ByNaziv(input.Naziv);
			}

			else if (input.KataloskiBroj != null)
			{
				_dbAlbums = AlbumSearchTools.ByKataloskiBroj(input.KataloskiBroj);
			}

			else
			{
				_dbAlbums = AlbumSearchTools.ByGodinaIzdanja(input.GodinaIzdanja);
			}
		}

		private void convertToViewable() 
		{
			foreach(var element in _dbAlbums)
			{
				_viewableAlbums.Add(DbModelsToViewable.ConvertToAlbumViewable(element as IDbAlbum));
			}
		}

		public List<IViewable> GetViewable()
		{
			return _viewableAlbums;
		}
	}
}
