using System;
using Read.Enums;
using Read.Interfaces;
using Presentation.Interfaces;

namespace Presentation.Read
{
	public class ReadMenu : IMenu
	{
		private MenuEnum _menu;
		private IReader _reader;
		private bool _finishedBool;

		public void ChooseOption()
		{
			_finishedBool = false;

			Console.Clear();

			while (_finishedBool == false)
			{
				Console.WriteLine();
                                Console.WriteLine("-------------------------------------------------------------------------------------------");
                                Console.WriteLine("Glavni meni za pretragu unosa:");
                                Console.WriteLine("-------------------------------------------------------------------------------------------");
                                Console.WriteLine(Options.Menu());

				string myOption = Console.ReadLine().ToLower().Replace(" ","");

				if (Enum.TryParse(myOption, out _menu))
				{
					callSwitch(_menu);
				}

				else
				{
					Console.Clear();
					Console.WriteLine("Odaberite validnu opciju!");
				}

			}
		}

		private void callSwitch(MenuEnum input)
		{
			switch(input)
			{
				case MenuEnum.album:
					Album();
					break;
				case MenuEnum.fonogram:
					Fonogram();
					break;
				case MenuEnum.izvodjac:
					Izvodjac();
					break;
				case MenuEnum.povratak:
					_finishedBool = true;
					break;
				default:
					Console.Clear();
					Console.WriteLine("Odaberite validnu opciju!");
					break;
			}
		}

		private void Album()
		{
			_reader = new ReadAlbum();
			_reader.ChooseOption();
			Console.Clear();
		}

		private void Fonogram()
		{
			_reader = new ReadFonogram();
			_reader.ChooseOption();
			Console.Clear();
		}

		private void Izvodjac()
		{
			_reader = new ReadIzvodjac();
			_reader.ChooseOption();
			Console.Clear();
		}
	}
}
