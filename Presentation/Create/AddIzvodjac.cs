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
		private AddIzvodjacEnum _izbor;
		private ReadOneInstance _read;
		private Engine _engine;
		private CreateIzvodjac _create;

		public AddIzvodjac()
		{
			IdName = new Dictionary<int, string>();
			IzvodjaciId = new List<int>();
			_read = new ReadOneInstance();
			_engine = new Engine();
			_create = new CreateIzvodjac();
		}

		public void ChooseOptions()
		{

			_doneBool = false;

			Console.Clear();

			do
			{
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Console.WriteLine("Dodavanje izvodjaca u fonogram:");
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

		private void callSwitch(AddIzvodjacEnum input)
		{
			switch(input)
			{
				case AddIzvodjacEnum.dodaj:
					dodajIzvodjaca();
					break;
				case AddIzvodjacEnum.pretrazi:
					pretraziIzvodjaca();
					break;
				case AddIzvodjacEnum.kreiraj:
					kreirajIzvodjaca();
					break;
				case AddIzvodjacEnum.izbrisi:
					izbrisiIzvodjaca();
					break;
				case AddIzvodjacEnum.zavrsi:
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
			Console.WriteLine("Za povratak na prethodni meni ukucajte znak \'*\' i pritisnite Enter.");
			string unos = Console.ReadLine().ToLower().Replace(" ","");

			if (unos == "*")
			{
				Console.Clear();
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

		private void kreirajIzvodjaca()
		{
			if (_create.PopulateEntries() == true)
			{
				if(_engine.DoSave(_create.Izvodjac))
				{
					Show.ShowSaved(_engine.GetViewModel());
					ParseIzvodjac(_engine.GetViewModel());
				}
			}
			Console.Clear();
		}

		private void pretraziIzvodjaca()
		{

		}

		private void izbrisiIzvodjaca()
		{
			while (true)
			{
				Console.Clear();
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Stats.AddIzvodjacStats(IdName);
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Console.WriteLine("Unesite Id broj izvodjaca kog zelite da izbrisete sa liste i pritisnite Enter.\nZa povratak na prethodni meni ukucajte znak \'*\' i pritisnite Enter.");

				string unos = Console.ReadLine().ToLower().Replace(" ","");

				int myId = 0;
				if (unos == "*")
				{
					Console.Clear();
					return;
				}

				if (int.TryParse(unos, out myId))
				{
					if (IzvodjaciId.Any(p => p == myId))
					{
						IzvodjaciId.Remove(myId);
						IdName.Remove(myId);
					}
					else
					{
						Console.Clear();
						Console.WriteLine("Na listi nema izvodjaca sa tim Id brojem! Pritisnite Enter da pokusate ponovo!");
						Console.ReadLine();
					}
				}
				else
				{
					Console.Clear();
					Console.WriteLine("Neispravan unos! Pritisnite Enter da pokusate ponovo.");
					Console.ReadLine();
				}
			}
		}
	}
}
