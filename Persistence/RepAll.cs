using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Interfaces;
using Persistence.Converters;
using Persistence.RepTools;
using Persistence.Models;

namespace Persistence
{
	public class RepAll : IRepAll
	{
		private List<IViewable> _viewable;

		public RepAll()
		{
			_viewable = new List<IViewable>();
		}

		public void Album()
		{
			List<Album> albumi = GetAll.GetAlbumi();

			foreach (var element in albumi)
			{
				_viewable.Add(DbModelsToViewable.ConvertToAlbumViewable(element));
			}
			
		}

		public void Fonogram()
		{
			List<Fonogram> fonogrami = GetAll.GetFonogrami();

			foreach (var element in fonogrami)
			{
				_viewable.Add(DbModelsToViewable.ConvertToFonogramViewable(element));
			}
		}

		public void Izvodjac()
		{
			List<Izvodjac> izvodjaci = GetAll.GetIzvodjaci();

			foreach (var element in izvodjaci)
			{
				_viewable.Add(DbModelsToViewable.ConvertToIzvodjacViewable(element));
			}

		}

		public List<IViewable> GetViewable()
		{
			return _viewable;
		}
	}
}
