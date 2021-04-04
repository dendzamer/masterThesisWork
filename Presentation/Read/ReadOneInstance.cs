using System;
using DataInjector;
using Domain.Interfaces;
using Domain.DTOs;

namespace Presentation.Read
{
	public class ReadOneInstance
	{
		private IViewModel _view;
		private InjectSRU _inject;

		public ReadOneInstance()
		{
			_inject = new InjectSRU();
		}
		
		public bool DoSearch(IDTO input)
		{
			try
			{
				_view = _inject.ReadData(input);
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
