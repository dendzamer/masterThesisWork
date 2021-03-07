using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain.Interfaces
{
	public interface IRepAll
	{
		void Album();

		void Fonogram();

		void Izvodjac();

		List<IViewable> GetViewable();

	}
}
