using System;
using Domain.Interfaces;
using Domain.DTOs;
using Read.Enums;
using Read.Interfaces;

namespace Presentation.Read
{
	public class ReadIzvodjac : IReader
	{
		private IDTO _izvodjac;
		private bool _doneBool;
		private Engine _engine;
		private GetAllEngine _allEngine;
		private IzvodjacEnum _izbor;

		public ReadIzvodjac()
		{
			_engine = new Engine();
			_allEngine = new GetAllEngine();
		}

		public void ChooseOption()
		{
			Console.Clear();
			_doneBool = false;

			while (_doneBool == false)
			{
				Console.WriteLine("---------------------------------------------------------------");
				Console.WriteLine("Pretraga izvodjaca:");
				Console.WriteLine("---------------------------------------------------------------");
				//ispisati opcije
				Console.WriteLine(Options.Izvodjac());

				string odgovor = Console.ReadLine().ToLower().Replace(" ","");

				if(Enum.TryParse(odgovor, out _izbor))
				{
					callSwitch();
				}

				else
				{
					Console.Clear();
					Console.WriteLine("Odaberite validnu opciju!");
				}
			}
		}

		private void callSwitch()
		{
			switch(_izbor)
			{
				case IzvodjacEnum.naziv:
					naziv();
					break;
				case IzvodjacEnum.svi:
					sviUnosi();
					break;
				case IzvodjacEnum.povratak:
					_doneBool = true;
					break;
				default:
					Console.WriteLine("Odaberite validnu opciju!");
					break;
			}
		}

		private void naziv()
		{
			Console.Clear();

			_izvodjac = new IzvodjacDTO();

			Console.WriteLine("Unesite naziv izvodjaca kojeg zelite da pretrazite i pritisnite Enter.\nZa povratak na prethodni meni unesite znak \'*\' i pritisnite Enter:");

			string odgovor = Console.ReadLine().ToUpper();

			if (odgovor == "*")
			{
				Console.Clear();
				return;
			}

			_izvodjac.Naziv = odgovor;
			executeSearch(_izvodjac);
			Console.Clear();
		}

		private void sviUnosi()
		{
			if (_allEngine.DoRetrieve(2))
			{
				ConvertAndShow.Izvodjac(_allEngine.GetViewModels());
			}
			Console.Clear();
		}

		private void executeSearch(IDTO input)
		{
			if (_engine.DoSearch(input) == true)
			{
				ConvertAndShow.Izvodjac(_engine.GetViewModels());
			}
			Console.Clear();
		}


	}
}

