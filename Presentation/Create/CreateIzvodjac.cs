using System;
using System.Collections.Generic;
using Domain.DTOs;
using Domain.Interfaces;
using Create.Enums;
using Presentation.Create.Interfaces;

namespace Presentation.Create
{
	public class CreateIzvodjac : ICreator
	{
		public IzvodjacDTO Izvodjac {get;}
		private bool _doneBool = false;
		private bool _finishedBool = true;
		private IzvodjacEnum _izbor;
		
		public CreateIzvodjac()
		{
			Izvodjac = new IzvodjacDTO();
		}

		public bool PopulateEntries()
		{
			_finishedBool = true;
			_doneBool = false;

			Console.Clear();
			do
			{
				Stats.IzvodjacStats(Izvodjac);
				Console.WriteLine("-------------------------------------------------------------------------------------------");

				Console.WriteLine(Options.Izvodjac());

				string myOption = Console.ReadLine().ToLower().Replace(" ", "");

				if (Enum.TryParse(myOption, out _izbor))
				{
					callSwitch(_izbor);

					if (_finishedBool == true && _doneBool == true)
					{
						_doneBool = CheckValidity();
					}
				}

				else
				{
					Console.Clear();
					Console.WriteLine("Odaberite validnu opciju!");
					_doneBool = false;
				}
			}
			while (_doneBool == false);

			return _finishedBool;
		}

		private void callSwitch(IzvodjacEnum input)
		{
			switch(input)
			{
				case IzvodjacEnum.naziv:
					fillNaziv();
					break;
				case IzvodjacEnum.zavrsi:
					_doneBool = true;
					break;
				case IzvodjacEnum.napusti:
					_finishedBool = false;
					_doneBool = true;
					break;
				default:
					Console.Clear();
					Console.WriteLine("Odaberite validnu opciju!");
					break;
			}
		}

		private void fillNaziv()
		{
			Console.Clear();
			Stats.IzvodjacStats(Izvodjac);
			Console.WriteLine("-------------------------------------------------------------------------------------------");
			Console.WriteLine("(Za povratak na prethodni meni ukucajte znak * i pritisnite Enter)");
			Console.WriteLine("Ukucajte naziv album i pritisnite Enter:");

			string naziv = Console.ReadLine();

			if (naziv == "*")
			{
				return;
			}
			else
			{
				Izvodjac.Naziv = naziv;
			}
			Console.Clear();
		}

		private bool CheckValidity()
		{
			if (Izvodjac.Naziv == null || Izvodjac.Naziv == "")
			{
				Console.Clear();
				Console.WriteLine("Popunite naziv izvodjaca!");
				return false;
			}
			else
			{
				Console.Clear();
				return true;
			}
		}

		public IDTO GetDto()
		{
			return Izvodjac;
		}
	}
}
