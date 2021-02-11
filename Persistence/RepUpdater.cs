using Domain.Interfaces;
using Persistence.Models;
using Persistence.Converters;
using Persistence.RepTools;

namespace Persistence
{
	public class RepUpdater : IRepository
	{
		private IViewable _viewable;
		private DtoToDbModels _toDBModels;
		private DbModelsToViewable _toViewable;

		public RepUpdater()
		{
			_toDBModels = new DtoToDbModels();
			_toViewable = new DbModelsToViewable();

		}
		

		public void Album(IDTO idto)
		{
			Album album = _toDBModels.ConvertToAlbum(idto as IAlbumDTO);
			album = Updater.UpdateAlbum(album);

			_viewable = _toViewable.ConvertToAlbumViewable(album);
		}

		public void Fonogram(IDTO idto)
		{
			Fonogram fonogram = _toDBModels.ConvertToFonogram(idto as IFonogramDTO);
			fonogram = Updater.UpdateFonogram(fonogram);

			_viewable = _toViewable.ConvertToFonogramViewable(fonogram);
		}

		public void Izvodjac(IDTO idto)
		{
			Izvodjac izvodjac = _toDBModels.ConvertToIzvodjac(idto as IDTO);
			izvodjac = Updater.UpdateIzvodjac(izvodjac);

			_viewable = _toViewable.ConvertToIzvodjacViewable(izvodjac);
		}

		public IViewable GetViewable()
		{
			return _viewable;
		}
	} 
}
