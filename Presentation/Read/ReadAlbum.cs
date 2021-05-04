using System;
using Domain.Interfaces;
using Domain.DTOs;
using Read.Enums;
using Read.Interfaces;

namespace Presentation.Read
{
	public class ReadAlbum : IReader
	{
		private IAlbumDTO _album;
		private bool _doneBool;
		private Engine _engine;
		private GetAllEngine _allEngine;
		private AlbumFonogramEnum _izbor;

		public ReadAlbum()
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
				Console.WriteLine("Pretraga albuma:");
				Console.WriteLine("---------------------------------------------------------------");
				//ispisati opcije
				Console.WriteLine(Options.Album());

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
				case AlbumFonogramEnum.naziv:
					naziv();
					break;
				case AlbumFonogramEnum.kataloskibroj:
					kataloskiBroj();
					break;
				case AlbumFonogramEnum.godinaizdanja:
					godinaIzdanja();
					break;
				case AlbumFonogramEnum.svi:
					sviUnosi();
					break;
				case AlbumFonogramEnum.povratak:
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

			_album = new AlbumDTO();

			Console.WriteLine("Unesite naziv albuma koji zelite da pretrazite i pritisnite Enter.\nZa povratak na prethodni meni unesite znak \'*\' i pritisnite Enter:");

			string odgovor = Console.ReadLine().ToUpper();

			if (odgovor == "*")
			{
				Console.Clear();
				return;
			}

			_album.Naziv = odgovor;
			executeSearch(_album);
			Console.Clear();
		}

		private void kataloskiBroj()
		{
			Console.Clear();

			_album = new AlbumDTO();

			Console.WriteLine("Unesite kataloski broj albuma koji zelite da pretrazite i pritisnite Enter.\nZa povratak na prethodni meni unesite znak \'*\' i pritisnite Enter:");

			string odgovor = Console.ReadLine().ToUpper();

			if (odgovor == "*")
			{
				Console.Clear();
				return;
			}

			_album.KataloskiBroj = odgovor;
			executeSearch(_album);
			Console.Clear();
		}

		private void godinaIzdanja()
		{
			Console.Clear();

			_album = new AlbumDTO();

			Console.WriteLine("Unesite godinu izdanja albuma koji zelite da pretrazite i pritisnite Enter.\nZa povratak na prethodni meni unesite znak \'*\' i pritisnite Enter:");
			string odgovor = Console.ReadLine().ToUpper();

			if (odgovor == "*")
			{
				Console.Clear();
				return;
			}

			int godina;

			if (int.TryParse(odgovor, out godina))
			{
				_album.GodinaIzdanja = godina;
				executeSearch(_album);
			}

			else
			{
				Console.Clear();
				Console.WriteLine("Neispravan unos!");
			}
		}

		private void sviUnosi()
		{
			//OVDE STOJI INT 0 KAO INPUT PARAMETAR ZA POVLACENJE SVIH ALBUM UNOSA ZATO STO SAM TAKO PREDEFINISAO U GETALL KLASI U DATAINJECTOR-U. OVO BIH MOGAO DA RAZMISLIM I DA PROMENIM I DTO.
			if (_allEngine.DoRetrieve(0))
			{
				ConvertAndShow.Album(_allEngine.GetViewModels());
			}
			Console.Clear();
		}


		private void executeSearch(IDTO input)
		{
		 
			if (_engine.DoSearch(input) == true)
			{
				ConvertAndShow.Album(_engine.GetViewModels());
			}
			Console.Clear();
		}
	}
}
