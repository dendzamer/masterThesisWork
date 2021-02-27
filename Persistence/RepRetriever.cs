using Domain.Interfaces;
using Persistence.Models;
using Persistence.Converters;
using Persistence.RepTools;
using Persistence.RepTools.Retrieve;

namespace Persistence
{
	public class RepRetriever : IRepository
	{
		private IViewable _viewable;


		public void Album(IDTO idto)
		{
			Album album = RetrieveAlbum.GetById(idto.Id);

			_viewable = DbModelsToViewable.ConvertToAlbumViewable(album);
		}

		public void Fonogram(IDTO idto)
		{
			Fonogram fonogram = RetrieveFonogram.GetById(idto.Id);

			_viewable = DbModelsToViewable.ConvertToFonogramViewable(fonogram);
		}

		public void Izvodjac(IDTO idto)
		{
			Izvodjac izvodjac = RetrieveIzvodjac.GetById(idto.Id);

			_viewable = DbModelsToViewable.ConvertToIzvodjacViewable(izvodjac);
		}

		public IViewable GetViewable()
		{
			return _viewable;
		}

		
	}
}
