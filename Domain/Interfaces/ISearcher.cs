using System;
using Domain.DTOs;
using System.Collections.Generic;

namespace Domain.Interfaces
{
	public interface ISearcher
	{
		void Album(IDTO idto);
		void Fonogram(IDTO idto);
		void Izvodjac(IDTO idto);

		List<IViewable> GetViewable();
	}
}
