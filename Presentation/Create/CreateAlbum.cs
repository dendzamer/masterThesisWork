using System;
using System.Collections.Generic;
using Domain.DTOs;
using Create.Enums;

namespace Presentation.Create
{
	public class CreateAlbum
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
			while (_doneBool == false)
			{
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				//Ispisati sve opcije
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
			Console.WriteLine("(Za povratak na prethodni meni ukucajte znak * i pritisnite Enter)");
			Console.WriteLine("Ukucajte naziv albuma i pritisnite Enter:");

			string naziv = Console.ReadLine();

			if (naziv == "*")
			{
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
			Console.WriteLine("(Za povratak na prethodni meni ukucajte znak * i pritisnite Enter)");
			Console.WriteLine("Ukucajte kataloski broj albuma i pritisnite Enter:");

			string kataloskiBroj = Console.ReadLine();

			if (kataloskiBroj == "*")
			{
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
			Console.WriteLine("(Za povratak na prethodni meni ukucajte znak * i pritisnite Enter)");
			Console.WriteLine("Ukucajte godinu izdanja albuma i pritisnite Enter:");

			string godina = Console.ReadLine();

			if (godina == "*")
			{
				return;
			}

			else
			{
				int godinaIzdanja = 0;
				int.TryParse(godina, out godinaIzdanja);
				Album.GodinaIzdanja = godinaIzdanja;
			}
			Console.Clear();
		}

		private bool CheckValidity()
		{
			if(Album.Naziv == null)
			{
				Console.Clear();
				Console.WriteLine("Popunite naziv albuma!");
				return false;
			}

			else if(Album.KataloskiBroj == null)
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
	}
}
