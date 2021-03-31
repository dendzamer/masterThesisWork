using System;
using System.Collections.Generic;
using Domain.DTOs;
using Create.Enums;

namespace Presentation.Create
{
	public class CreateFonogram
	{
		public FonogramDTO Fonogram {get;}
		private bool _doneBool = false;
		private bool _finishedBool = true;
		private FonogramEnum _izbor;

		public CreateFonogram()
		{
			Fonogram = new FonogramDTO();
		}

		public bool PopulateEntries()
		{
			_finishedBool = true;

			Console.Clear();
			do
			{
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Console.WriteLine(Options.Fonogram());

				string myOption = Console.ReadLine().ToLower().Replace(" ","");

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

		private void callSwitch(FonogramEnum input)
		{
			switch(input)
			{
				case FonogramEnum.naziv:
					fillNaziv();
					break;
				case FonogramEnum.kataloskibroj:
					fillKataloskiBroj();
					break;
				case FonogramEnum.godinaizdanja:
					fillGodinaIzdanja();
					break;
				case FonogramEnum.izvodjaci:
					fillIzvodjaci();
					break;
				case FonogramEnum.zavrsi:
					_doneBool = true;
					break;
				case FonogramEnum.napusti:
					_finishedBool = false;
					_doneBool = true;
					break;
				default:
					Console.Clear();
					Console.WriteLine("Odaberite validnu opciju!");
					break;
			}
		}

		public void fillNaziv()
		{
			Console.Clear();
			Console.WriteLine("(Za povratak na prethodni meni ukucajte znak * i pritisnite Enter)");
			Console.WriteLine("Ukucajte naziv fonograma i pritisnite Enter:");

			string naziv = Console.ReadLine();

			if (naziv == "*")
			{
				return;
			}
			else
			{
				Fonogram.Naziv = naziv;
			}
			Console.Clear();
		}
		
		public void fillKataloskiBroj()
		{
			Console.Clear();
			Console.WriteLine("(Za povratak na prethodni meni ukucajte znak * i pritisnite Enter)");
			Console.WriteLine("Ukucajte kataloski broj fonograma i pritisnite Enter:");

			string kataloskiBroj = Console.ReadLine();

			if (kataloskiBroj == "*")
			{
				return;
			}
			else
			{
				Fonogram.KataloskiBroj = kataloskiBroj;
			}
			Console.Clear();
		}

		public void fillGodinaIzdanja()
		{
			Console.Clear();
			Console.WriteLine("(Za povratak na prethodni meni ukucajte znak * i pritisnite Enter)");
			Console.WriteLine("Ukucajte godinu izdanja fonograma i pritisnite Enter:");

			string godina = Console.ReadLine();

			if (godina == "")
			{
				return;
			}

			else
			{
				int godinaIzdanja = 0;
				int.TryParse(godina, out godinaIzdanja);
				Fonogram.GodinaIzdanja = godinaIzdanja;
			}
			Console.Clear();
		}

		public void fillIzvodjaci()
		{


		}

		private bool CheckValidity()
		{
			if (Fonogram.Naziv == null || Fonogram.Naziv == "")
			{
				Console.Clear();
				Console.WriteLine("Popunite naziv fonograma!");
				return false;
			}

			else if (Fonogram.KataloskiBroj == null || Fonogram.KataloskiBroj == "")
			{
				Console.Clear();
				Console.WriteLine("Popunite kataloski broj!");
				return false;
			}

			else if (Fonogram.GodinaIzdanja == 0)
			{
				Console.Clear();
				Console.WriteLine("Popunite godinu izdanja albuma! Ne moze ostati nula!");
				return false;
			}

			/*
			else if (Fonogram.Izvodjaci.Any() == false)
			{
				Console.Clear();
				Console.WriteLine("Unesite barem jednog izvodjaca!");
				return false;
			}
			*/

			else
			{
				Console.Clear();
				return true;
			}
		}


	}
}
