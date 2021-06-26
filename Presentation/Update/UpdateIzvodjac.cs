using System;
using Presentation;
using Domain.DTOs;
using Domain.Interfaces;
using Presentation.Update.Enums;
using Presentation.Read;
using Presentation.Update.Interfaces;

namespace Presentation.Update
{
	public class UpdateIzvodjac : IUpdater
	{
	
		private IzvodjacDTO _izvodjac;
		private bool _doneBool = false;
		private IzvodjacEnum _izbor;
		private LoadDTO _load;
		private Engine _engine;
		private ReadIzvodjac _read;

		public UpdateIzvodjac()
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
                                Console.WriteLine("Ispravka izvodjaca:");
                                Console.WriteLine("-------------------------------------------------------------------------------------------");
                                Stats.IzvodjacStats(_izvodjac);
                                Console.WriteLine("-------------------------------------------------------------------------------------------");

				Console.WriteLine(Options.Izvodjac());

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

		private void callSwitch(IzvodjacEnum input)
		{
			switch(input)
			{
				case IzvodjacEnum.ucitaj:
					loadIzvodjac();
					break;
				case IzvodjacEnum.naziv:
					naziv();
					break;
				case IzvodjacEnum.pretrazi:
					search();
					break;
				case IzvodjacEnum.sacuvaj:
					executeUpdate();
					break;
				case IzvodjacEnum.napusti:
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

		private void naziv()
		{
			if (_izvodjac.Id == 0)
			{
				Console.Clear();
				Console.WriteLine("Izvodjac nije ucitan! Pritisnite Enter za povratak na prethodni meni.");
				Console.ReadLine();
				Console.Clear();
				return;
			}			

			Console.Clear();
			Stats.IzvodjacStats(_izvodjac);
			Console.WriteLine("-------------------------------------------------------------------------------------------");
			Console.WriteLine("Unesite novi naziv izvodjaca i pritisnite Enter. Za povratak na prethodni meni ukucajte znak \'*\' i pritisnite enter.");
			Console.WriteLine("-------------------------------------------------------------------------------------------");

			string naziv = Console.ReadLine().ToUpper();


			if (naziv == "*")
			{
				Console.Clear();
				return;
			}
			else if (naziv == "" || naziv == null)
			{
				Console.Clear();
				Console.WriteLine("Neispravan unos! Pritisnite Enter za povrataka na prethodni meni!");
				Console.ReadLine();
				Console.Clear();
			}
			else
			{
				_izvodjac.Naziv = naziv;
				Console.Clear();
			}
		}

		private void search()
		{
			_read.ChooseOption();
			Console.Clear();
		}

		private void executeUpdate()
		{
			if (_izvodjac.Id != 0)
			{
				if (_engine.DoSave(_izvodjac))
				{
					Show.ShowSaved(_engine.GetViewModel());
					Console.Clear();
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
	}
}
