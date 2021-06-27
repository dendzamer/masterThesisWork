using System;
using Presentation.Interfaces;
using Presentation.Enums;
using Presentation.Create;
using Presentation.Read;
using Presentation.Update;
using Presentation.Delete;

namespace Presentation
{
	class MainMenu
	{

		private MainMenuEnum _izbor;
		private IMenu _menu;
		private bool _finishedBool;

		public void ChooseOption()
		{
			_finishedBool = false;

			Console.Clear();

			while(_finishedBool == false)
			{
				Console.WriteLine(Title.Text());
				Console.WriteLine();
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Console.WriteLine("Glavni meni aplikacije:");
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Console.WriteLine(MainOptions.Options());

				string myOption = Console.ReadLine().ToLower().Replace(" ", "");

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

		private void callSwitch(MainMenuEnum input)
		{
			switch(input)
			{
				case MainMenuEnum.kreiraj:
					create();
					break;
				case MainMenuEnum.pretrazi:
					search();
					break;
				case MainMenuEnum.ispravi:
					update();
					break;
				case MainMenuEnum.izbrisi:
					delete();
					break;
				case MainMenuEnum.pomoc:
					help();
					break;
				case MainMenuEnum.napusti:
					_finishedBool = true;
					break;
				default:
					Console.Clear();
					Console.WriteLine("Odaberite validnu opciju!");
					break;
			}
		}

		private void create()
		{
			_menu = new CreateMenu();
			_menu.ChooseOption();
			Console.Clear();
		}

		private void search()
		{
			_menu = new ReadMenu();
			_menu.ChooseOption();
			Console.Clear();
		}

		private void update()
		{
			_menu = new UpdateMenu();
			_menu.ChooseOption();
			Console.Clear();
		}

		private void delete()
		{
			_menu = new DeleteMenu();
			_menu.ChooseOption();
			Console.Clear();
		}

		private void help()
		{
			Help.BasicHelp();
			Console.Clear();
		}
	}
}

