using System;
using Domain.DTOs;

namespace Domain.Interfaces
{
	public interface IRepository
	{
		void Album(IDTO idto);
		void Fonogram(IDTO idto);
		void Izvodjac(IDTO idto);

		IViewable GetViewable();
	}
}

