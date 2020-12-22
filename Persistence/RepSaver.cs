using System;
using System.Collections.Generic;
using Domain.DTOs;
using Domain.Interfaces;
using Persistence.Models;
using Persistence.Converters;
using Persistence.RepTools;
using static System.Console;

namespace Persistence
{
	public class RepSaver : IRepository
	{
		private IViewable _viewable;

		public void Album(IDTO idto)
		{
			Album album = DtoToDbModels.ConvertToAlbum(idto as IAlbumDTO);
			album = Saver.SaveAlbum(album);
			WriteLine("{0}, {1}, {2}, {3}", album.AlbumId, album.Naziv, album.GodinaIzdanja, album.KataloskiBroj);

			_viewable = DbModelsToViewable.ConvertToAlbumViewable(album);
		
		}
		
		public void Fonogram(IDTO idto)
		{
			

		}
		
		public void Izvodjac(IDTO idto)
		{

		}

		public IViewable GetViewable()
		{
			return _viewable;
		}
	}
}
