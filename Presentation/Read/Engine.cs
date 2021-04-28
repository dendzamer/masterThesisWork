using System;
using DataInjector;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Presentation.Read
{
	public class Engine
	{
		private List<IViewModel> _view;
		private InjectSRU _inject;

		public Engine()
		{
			_inject = new InjectSRU();
		}

		public bool DoSave(IDTO input)
		{
			try
			{
				_view = _inject.SearchData(input);
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
