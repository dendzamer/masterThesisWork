using System;
using System.Collections.Generic;
using Domain.DTOs;
using Domain.Interfaces;
using Create.Enums;
using Presentation.Create.Interfaces;

namespace Presentation.Create
{
	public class CreateAlbum : ICreator
	{
		public AlbumDTO Album {get;}
		private bool _doneBool = false;
		private bool _finishedBool = true;
		private AlbumEnum _izbor;

		public CreateAlbum()
		{
			Album = new AlbumDTO();
		}

		public bool PopulateEntries()
		{
			_finishedBool = true;
			_doneBool = false;

			Console.Clear();
			do
			{
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Console.WriteLine("Kreiranje novog albuma:");
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Stats.AlbumStats(Album);
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Console.WriteLine(Options.Album());

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
				}
			}
			while (_doneBool == false);

			return _finishedBool;
		}

		private void callSwitch(AlbumEnum input)
		{
			switch(input)
			{
				case AlbumEnum.naziv:
					fillNaziv();
					break;
				case AlbumEnum.kataloskibroj:
					fillKataloskiBroj();
					break;
				case AlbumEnum.godinaizdanja:
					fillGodinaIzdanja();
					break;
				case AlbumEnum.zavrsi:
					_doneBool = true;
					break;
				case AlbumEnum.napusti:
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
			Stats.AlbumStats(Album);

			Console.WriteLine("-------------------------------------------------------------------------------------------");

			Console.WriteLine("(Za povratak na prethodni meni ukucajte znak * i pritisnite Enter)");
			Console.WriteLine("Ukucajte naziv albuma i pritisnite Enter:");

			string naziv = Console.ReadLine().ToUpper();

			if (naziv == "*")
			{
				Console.Clear();
				return;
			}
			else
			{
				Album.Naziv = naziv;
			}
			Console.Clear();
		}

		private void fillKataloskiBroj()
		{
			Console.Clear();
			Stats.AlbumStats(Album);
			Console.WriteLine("-------------------------------------------------------------------------------------------");
			Console.WriteLine("(Za povratak na prethodni meni ukucajte znak * i pritisnite Enter)");
			Console.WriteLine("Ukucajte kataloski broj albuma i pritisnite Enter:");

			string kataloskiBroj = Console.ReadLine().ToUpper();

			if (kataloskiBroj == "*")
			{
				Console.Clear();
				return;
			}
			else
			{
				Album.KataloskiBroj = kataloskiBroj;
			}
			Console.Clear();
		}

		private void fillGodinaIzdanja()
		{
			Console.Clear();
			Stats.AlbumStats(Album);
			Console.WriteLine("-------------------------------------------------------------------------------------------");
			Console.WriteLine("(Za povratak na prethodni meni ukucajte znak * i pritisnite Enter)");
			Console.WriteLine("Ukucajte godinu izdanja albuma i pritisnite Enter:");

			string godina = Console.ReadLine().ToUpper();

			if (godina == "*")
			{
				Console.Clear();
				return;
			}

			else
			{
				int godinaIzdanja = 0;
				if (int.TryParse(godina, out godinaIzdanja) == false)
				{
					Console.WriteLine("Neispravan unos! Pritisnite Enter za povratak.");
					Console.ReadLine();
				}
					Album.GodinaIzdanja = godinaIzdanja;
			}
			Console.Clear();
		}

		private bool CheckValidity()
		{
			if(Album.Naziv == null || Album.Naziv == "")
			{
				Console.Clear();
				Console.WriteLine("Popunite naziv albuma!");
				return false;
			}

			else if(Album.KataloskiBroj == null || Album.KataloskiBroj == "")
			{
				Console.Clear();
				Console.WriteLine("Popunite kataloski broj!");
				return false;
			}

			else if (Album.GodinaIzdanja == 0)
			{
				Console.Clear();
				Console.WriteLine("Popunite godinu izdanja albuma! Ne moze ostati nula!");
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
			return Album;
		}
	}
}
