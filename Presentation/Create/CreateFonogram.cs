using System;
using System.Collections.Generic;
using Domain.DTOs;
using Domain.Interfaces;
using Create.Enums;
using System.Linq;
using Presentation.Create.Interfaces;

namespace Presentation.Create
{
	public class CreateFonogram : ICreator
	{
		public FonogramDTO Fonogram {get;}
		private bool _doneBool = false;
		private bool _finishedBool = true;
		private FonogramEnum _izbor;
		private AddIzvodjac _addIzvodjac;
		private AddAlbum _addAlbum;
		private string albumNaziv;


		private Dictionary<int, string> _fullIzvodjaci;

		public CreateFonogram()
		{
			Fonogram = new FonogramDTO();
			_fullIzvodjaci = new Dictionary<int, string>();
			_addIzvodjac = new AddIzvodjac();
			_addAlbum = new AddAlbum();
			albumNaziv = "";
		}

		public bool PopulateEntries()
		{
			_finishedBool = true;
			_doneBool = false;

			Console.Clear();
			do
			{
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Console.WriteLine("Kreiranje novog fonograma:");
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Stats.FonogramStats(Fonogram, _fullIzvodjaci, albumNaziv);
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
				case FonogramEnum.album:
					fillAlbum();
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

			string naziv = Console.ReadLine().ToUpper();

			if (naziv == "*")
			{
				Console.Clear();
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

			string kataloskiBroj = Console.ReadLine().ToUpper();

			if (kataloskiBroj == "*")
			{
				Console.Clear();
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

			string godina = Console.ReadLine().ToUpper();

			if (godina == "*")
			{
				Console.Clear();
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
			_addIzvodjac.ChooseOptions();
			Fonogram.IzvodjacId = _addIzvodjac.IzvodjaciId;
			_fullIzvodjaci = _addIzvodjac.IdName;
			Console.Clear();
		}

		public void fillAlbum()
		{
			_addAlbum.ChooseOptions();
			Fonogram.AlbumId = _addAlbum.Album.Id;
			albumNaziv = _addAlbum.Album.Naziv; 
			Console.Clear();
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

			
			else if (Fonogram.IzvodjacId.Any() == false)
			{
				Console.Clear();
				Console.WriteLine("Unesite barem jednog izvodjaca!");
				return false;
			}

			else if (Fonogram.AlbumId == 0)
			{
				Console.Clear();
				Console.WriteLine("Unesite Id broj albuma u koji dodajete fonogram!");
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
			return Fonogram;
		}
	}
}
