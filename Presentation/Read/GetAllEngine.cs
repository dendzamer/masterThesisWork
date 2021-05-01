using System;
using System.Collections.Generic;
using Domain.Interfaces;
using DataInjector;

namespace Presentation.Read
{
	public class GetAllEngine
	{
		private List<IViewModel> _view;
		private InjectSRU _inject;

		public GetAllEngine()
		{
			_inject = new InjectSRU();
		}

		public bool DoRetrieve(int input)
		{
			try
			{
				_view = _inject.GetAll(input);
				return true;
			}

			catch (Exception ex)
			{
				Console.Clear();
				Console.WriteLine(ex.Message);
				Console.WriteLine("Pritisnite enter za povratak na prethodni meni.");
				Console.ReadLine();
				return false;
			}
		}

		public List<IViewModel> GetViewModels()
		{
			return _view;
		}

	}
}
