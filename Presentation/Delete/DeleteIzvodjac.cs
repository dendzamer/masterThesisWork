using System;
using Presentation;
using Domain.DTOs;
using Domain.Interfaces;
using Presentation.Delete.Enums;
using Presentation.Delete.Interfaces;
using Presentation.Read;

namespace Presentation.Delete
{
	public class DeleteIzvodjac : IDeleter
	{
		private IzvodjacDTO _izvodjac;
		private bool _doneBool = false;
		private DeleteEnum _izbor;
		private LoadDTO _load;
		private Engine _engine;
		private ReadIzvodjac _read;

		public DeleteIzvodjac()
		{
			_izvodjac = new IzvodjacDTO();
			_load = new LoadDTO();
			_engine = new Engine();
			_read = new ReadIzvodjac();
		}

		public void ChooseOption()
		{
			_doneBool = false;

			Console.Clear();
			while(_doneBool == false)
			{
                                Console.WriteLine("-------------------------------------------------------------------------------------------");
                                Console.WriteLine("Brisanje izvodjaca:");
                                Console.WriteLine("-------------------------------------------------------------------------------------------");
                                Stats.IzvodjacStats(_izvodjac);
                                Console.WriteLine("-------------------------------------------------------------------------------------------");

				Console.WriteLine(Options.Izvodjac());

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
					loadIzvodjac();
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

		private void loadIzvodjac()
		{
			_load.LoadIzvodjac(_izvodjac);
			Console.Clear();
		}

		private void executeDelete()
		{
			Console.Clear();
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                        Stats.IzvodjacStats(_izvodjac);
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                        Console.WriteLine("Da li ste sigurni da zelite da izbrisete navedenog izvodjaca? izvodjac ce biti trajno obrisan! \nDa odustanete ukucajte \'ne\' i pritisnite enter. \nZa nastavak ukucajte bilo sta drugo i pritisnite enter.");
                        
                        string odgovor = Console.ReadLine().Trim().ToLower();

                        if (odgovor == "ne")
                        {
				Console.Clear();
                                return;
                        }

			if (_izvodjac.Id != 0)
			{
				if (_engine.DoDelete(_izvodjac))
				{
					Console.Clear();
					Console.WriteLine("IZVODJAC JE IZBRISAN! Pritisnite enter za povratak na prethodni meni.");
					Console.ReadLine();
					Console.Clear();
					_izvodjac = new IzvodjacDTO();
				}
			}

			else
			{
                                Console.Clear();
                                Console.WriteLine("Izvodjac nije ucitan! Pritisnite Enter za povratak na prethodni meni.");
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
