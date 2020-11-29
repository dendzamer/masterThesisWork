using System;
using Domain.Interfaces;

namespace Domain.Interfaces
{
	public interface IViewModel
	{
		int Id {get; set;}
		string Naziv {get; set;}

		void SetData(IViewable data);

	}
}
