using System;
using Presentation.Delete.Enums;
using Presentation.Delete.Interfaces;
using Presentation.Interfaces;

namespace Presentation.Delete
{
	public class DeleteMenu : IMenu
	{
		private MenuEnum _menu;
		private IDeleter _deleter;
		private bool _finishedBool;

		public void ChooseOption()
		{
			_finishedBool = false;

			Console.Clear();

			while (_finishedBool == false)
			{
				Console.WriteLine();
                                Console.WriteLine("-------------------------------------------------------------------------------------------");
                                Console.WriteLine("Glavni meni za brisanje unosa:");
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
					album();
					break;
				case MenuEnum.fonogram:
					fonogram();
					break;
				case MenuEnum.izvodjac:
					izvodjac();
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

		private void album()
		{
			_deleter = new DeleteAlbum();
			_deleter.ChooseOption();
			Console.Clear();
		}

		private void fonogram()
		{
			_deleter = new DeleteFonogram();
			_deleter.ChooseOption();
			Console.Clear();
		}

		private void izvodjac()
		{
			_deleter = new DeleteIzvodjac();
			_deleter.ChooseOption();
			Console.Clear();
		}
	}
}
