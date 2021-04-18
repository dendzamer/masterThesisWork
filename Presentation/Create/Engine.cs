using System;
using DataInjector;
using Domain.Interfaces;

namespace Presentation.Create
{
	public class Engine
	{
		private IViewModel _view;
		private InjectSRU _inject;

		public Engine()
		{
			_inject = new InjectSRU();
		}

		public bool DoSave(IDTO input)
		{
			try
			{
				_view = _inject.SaveData(input);
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

		public IViewModel GetViewModel()
		{
			return _view;
		}
	}
}
