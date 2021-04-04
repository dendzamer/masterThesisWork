using System;
using System.Collections.Generic;
using Create.Enums;
using System.Linq;
using Domain.DTOs;
using Domain.Interfaces;
using Presentation.Read;

namespace Presentation.Create
{
	public class AddIzvodjac
	{
		public Dictionary<int, string> IdName{get;}
		public List<int> IzvodjaciId {get;}
		private bool _doneBool = false;
		private AddEnum _izbor;
		private ReadOneInstance _read;

		public AddIzvodjac()
		{
			IdName = new Dictionary<int, string>();
			IzvodjaciId = new List<int>();
			_read = new ReadOneInstance();
		}

		public void ChooseOptions()
		{

			_doneBool = false;

			Console.Clear();

			do
			{
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Stats.AddIzvodjacStats(IdName);
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Console.WriteLine(Options.AddIzvodjac());

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
			while (_doneBool == false);
		}

		private void callSwitch(AddEnum input)
		{
			switch(input)
			{
				case AddEnum.dodaj:
					dodajIzvodjaca();
					break;
				case AddEnum.pretrazi:
					pretraziIzvodjaca();
					break;
				case AddEnum.izbrisi:
					izbrisiIzvodjaca();
					break;
				case AddEnum.zavrsi:
					_doneBool = true;
					break;
				default:
					Console.Clear();
					Console.WriteLine("Odaberite validnu opciju!");
					break;
			}
		}

		private void dodajIzvodjaca()
		{
			Console.Clear();
			Console.WriteLine("-------------------------------------------------------------------------------------------");
			Stats.AddIzvodjacStats(IdName);
			Console.WriteLine("-------------------------------------------------------------------------------------------");

			Console.WriteLine("Ukucajte ID broj izvodjaca:");
			Console.WriteLine("Za povratak na prethodni meni ukucajte znak \'*\'.");
			string unos = Console.ReadLine().ToLower().Replace(" ","");

			if (unos == "*")
			{
				return;
			}

			int myId = 0;

			if (int.TryParse(unos, out myId) == true)
			{
				retrieveIzvodjac(myId);
			}

			else
			{
				Console.Clear();
				Console.WriteLine("Neispravan unos!");
			}
		}

		private void retrieveIzvodjac(int input)
		{
			IDTO izvodjac = new IzvodjacDTO();
			izvodjac.Id = input;

			if(_read.DoSearch(izvodjac) == true)
			{
				ParseIzvodjac(_read.GetViewModel());
			}
		}

		private void ParseIzvodjac(IViewModel input)
		{
			if (IzvodjaciId.Any(p => p == input.Id))
			{
				Console.Clear();
				Console.WriteLine("Izvodjac je vec unet!");
			}

			else
			{
				IzvodjaciId.Add(input.Id);
				IdName.Add(input.Id, input.Naziv);
				Console.Clear();
			}
		}

		private void pretraziIzvodjaca()
		{

		}

		private void izbrisiIzvodjaca()
		{

		}
	}
}
