using System;
using Presentation;
using Presentation.Create;
using Presentation.Create.Interfaces;
using Create.Enums;

namespace Presentation.Create
{
	public class CreateMenu
	{
		private MenuEnum _menu;
		private Engine _engine;
		private ICreator _creator;
		private bool _finishedBool;

		public CreateMenu()
		{
			_engine = new Engine();
		}

		public void ChooseOption()
		{
			_finishedBool = false;

			Console.Clear();

			while (_finishedBool == false)
			{
                                Console.WriteLine("-------------------------------------------------------------------------------------------");
				Console.WriteLine("Glavni meni za kreiranje novih unosa:");
                                Console.WriteLine("-------------------------------------------------------------------------------------------");
                                Console.WriteLine(Options.MenuOptions());

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
					SaveAlbum();
					break;
				case MenuEnum.fonogram:
					SaveFonogram();
					break;
				case MenuEnum.izvodjac:
					SaveIzvodjac();
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

		private void SaveAlbum()
		{
			_creator = new CreateAlbum();

			ExecuteSave();
		}

		private void SaveFonogram()
		{
			_creator = new CreateFonogram();

			ExecuteSave();
		}

		private void SaveIzvodjac()
		{
			_creator = new CreateIzvodjac();

			ExecuteSave();
		}

		private void ExecuteSave()
		{
			bool _doneBool = false;

			while (_doneBool == false)
			{
				if (_creator.PopulateEntries() == true)
				{
					if (_engine.DoSave(_creator.GetDto()) == true)
					{
						_doneBool = true;
						Show.ShowSaved(_engine.GetViewModel());
						Console.Clear();
					}
				}

				else 
				{
					_doneBool = true;
					Console.Clear();
				}
			}
		}
	}
}
