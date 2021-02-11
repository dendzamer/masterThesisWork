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
		private DtoToDbModels _toDBModels;
		private DbModelsToViewable _toViewable;

		public RepRetriever()
		{
			_toDBModels = new DtoToDbModels();
			_toViewable = new DbModelsToViewable();

		}

		public void Album(IDTO idto)
		{
			RetrieveAlbum _retrieve = new RetrieveAlbum();
			Album album = _retrieve.GetById(idto.Id);

			_viewable = _toViewable.ConvertToAlbumViewable(album);
		}

		public void Fonogram(IDTO idto)
		{
			RetrieveFonogram _retrieve = new RetrieveFonogram();
			Fonogram fonogram = _retrieve.GetById(idto.Id);

			_viewable = _toViewable.ConvertToFonogramViewable(fonogram);
		}

		public void Izvodjac(IDTO idto)
		{
			RetrieveIzvodjac _retrieve = new RetrieveIzvodjac();
			Izvodjac izvodjac = _retrieve.GetById(idto.Id);

			_viewable = _toViewable.ConvertToIzvodjacViewable(izvodjac);
		}

		public IViewable GetViewable()
		{
			return _viewable;
		}

		
	}
}
