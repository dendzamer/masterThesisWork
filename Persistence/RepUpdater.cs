using Domain.Interfaces;
using Persistence.Models;
using Persistence.Converters;
using Persistence.RepTools;

namespace Persistence
{
	public class RepUpdater : IRepository
	{
		private IViewable _viewable;

		public void Album(IDTO idto)
		{
			Album album = DtoToDbModels.ConvertToAlbum(idto as IAlbumDTO);
			album = Updater.UpdateAlbum(album);

			_viewable = DbModelsToViewable.ConvertToAlbumViewable(album);
		}

		public void Fonogram(IDTO idto)
		{
			Fonogram fonogram = DtoToDbModels.ConvertToFonogram(idto as IFonogramDTO);
			fonogram = Updater.UpdateFonogram(fonogram);

			_viewable = DbModelsToViewable.ConvertToFonogramViewable(fonogram);
		}

		public void Izvodjac(IDTO idto)
		{
			Izvodjac izvodjac = DtoToDbModels.ConvertToIzvodjac(idto as IDTO);
			izvodjac = Updater.UpdateIzvodjac(izvodjac);

			_viewable = DbModelsToViewable.ConvertToIzvodjacViewable(izvodjac);
		}

		public IViewable GetViewable()
		{
			return _viewable;
		}
	} 
}
