using System;
using Presentation.Update.Enums;
using Presentation.Update.Interfaces;
using Presentation.Interfaces;

namespace Presentation.Update
{
	public class UpdateMenu : IMenu
	{
		private MenuEnum _izbor;
		private IUpdater _updater;
		private bool _finishedBool;

		public void ChooseOption()
		{
			_finishedBool = false;

			Console.Clear();

			while (_finishedBool == false)
			{
				Console.WriteLine();
                                Console.WriteLine("-------------------------------------------------------------------------------------------");
                                Console.WriteLine("Glavni meni za ispravku unosa:");
                                Console.WriteLine("-------------------------------------------------------------------------------------------");
                                Console.WriteLine(Options.Menu());

				string myOption = Console.ReadLine().ToLower().Replace(" ","");

				if (Enum.TryParse(myOption, out _izbor))
				{
					callSwitch(_izbor);
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
			_updater = new UpdateAlbum();
			_updater.ChooseOption();
			Console.Clear();
		}

		private void fonogram()
		{
			_updater = new UpdateFonogram();
			_updater.ChooseOption();
			Console.Clear();
		}

		private void izvodjac()
		{
			_updater = new UpdateIzvodjac();
			_updater.ChooseOption();
			Console.Clear();
		}
	}
}
