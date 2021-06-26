using System;
using Presentation;
using Domain.DTOs;
using Domain.Interfaces;
using Presentation.Delete.Enums;
using Presentation.Delete.Interfaces;
using Presentation.Read;

namespace Presentation.Delete
{
	public class DeleteFonogram : IDeleter
	{
		private FonogramDTO _fonogram;
		private bool _doneBool = false;
		private DeleteEnum _izbor;
		private LoadDTO _load;
		private Engine _engine;
		private ReadFonogram _read;

		public DeleteFonogram()
		{
			_fonogram = new FonogramDTO();
			_load = new LoadDTO();
			_engine = new Engine();
			_read = new ReadFonogram();
		}

		public void ChooseOption()
		{
			_doneBool = false;

			Console.Clear();
			while(_doneBool == false)
			{
                                Console.WriteLine("-------------------------------------------------------------------------------------------");
                                Console.WriteLine("Brisanje fonograma:");
                                Console.WriteLine("-------------------------------------------------------------------------------------------");
                                Stats.FonogramStats(_fonogram);
                                Console.WriteLine("-------------------------------------------------------------------------------------------");

				Console.WriteLine(Options.Fonogram());

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

		public void callSwitch(DeleteEnum input)
		{
			switch(input)
			{
				case DeleteEnum.ucitaj:
					loadFonogram();
					break;
				case DeleteEnum.izbrisi:
					executeDelete();
					break;
				case DeleteEnum.pretrazi:
					search();
					break;
				case DeleteEnum.napusti:
					_doneBool = true;
					break;
				default:
					Console.Clear();
					Console.WriteLine("Odaberite validnu opciju!");
					break;
			}
		}

		private void loadFonogram()
		{
			_load.LoadFonogram(_fonogram);
			Console.Clear();
		}

		private void executeDelete()
		{
			Console.Clear();
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                        Stats.FonogramStats(_fonogram);
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                        Console.WriteLine("Da li ste sigurni da zelite da izbrisete navedeni fonogram? Fonogram ce biti trajno obrisan! \nDa odustanete ukucajte \'ne\' i pritisnite enter. \nZa nastavak ukucajte bilo sta drugo i pritisnite enter.");

                        string odgovor = Console.ReadLine().Trim().ToLower();

                        if (odgovor == "ne")
                        {
				Console.Clear();
                                return;
                        }

			if (_fonogram.Id != 0)
			{
				if (_engine.DoDelete(_fonogram))
				{
					Console.Clear();
					Console.WriteLine("FONOGRAM JE IZBRISAN! Pritisnite enter za povratak na prethodni meni.");
					Console.ReadLine();
					Console.Clear();
					_fonogram = new FonogramDTO();
				}
			}

			else
			{
                                Console.Clear();
                                Console.WriteLine("Fonogram nije ucitan! Pritisnite Enter za povratak na prethodni meni.");
                                Console.ReadLine();
                                Console.Clear();
			}
		}

                private void search()
                {
                        _read.ChooseOption();
                        Console.Clear();
                }
	}
}
