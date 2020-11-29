using System;

namespace Domain.Interfaces
{
	public interface IIzvodjacViewModel : IViewModel
	{
		string Albumi {get; set;}
		string Fonogrami {get; set;}
	}
}
