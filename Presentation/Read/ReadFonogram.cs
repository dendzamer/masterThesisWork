using System;
using Domain.Interfaces;
using Domain.DTOs;
using Read.Enums;

namespace Presentation.Read
{
	public class ReadFonogram
	{
		private IFonogramDTO _fonogram;
		private bool _doneBool;
		private Engine _engine;
		private GetAllEngine _allEngine;
		private AlbumFonogramEnum _izbor;

		public ReadFonogram()
		{
			_engine = new Engine();
			_allEngine = new GetAllEngine();
		}

		public void ChooseOptions()
		{
			Console.Clear();
			_doneBool = false;

			while (_doneBool == false)
			{
				Console.WriteLine("---------------------------------------------------------------");
				Console.WriteLine("Pretraga fonograma:");
				Console.WriteLine("---------------------------------------------------------------");
				Console.WriteLine(Options.Fonogram());

				string odgovor = Console.ReadLine().ToLower().Replace(" ","");

				if (Enum.TryParse(odgovor, out _izbor))
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

			_fonogram = new FonogramDTO();

                        Console.WriteLine("Unesite naziv fonograma koji zelite da pretrazite i pritisnite Enter.\nZa povratak na prethodni meni unesite znak \'*\' i pritisnite Enter:");

			string odgovor = Console.ReadLine().ToUpper();

			if (odgovor == "*")
			{
				Console.Clear();
				return;
			}

			_fonogram.Naziv = odgovor;
			executeSearch(_fonogram);
			Console.Clear();
		}

		private void kataloskiBroj()
		{
			Console.Clear();

			_fonogram = new FonogramDTO();

                        Console.WriteLine("Unesite kataloski broj fonograma koji zelite da pretrazite i pritisnite Enter.\nZa povratak na prethodni meni unesite znak \'*\' i pritisnite Enter:");

			string odgovor = Console.ReadLine().ToUpper();

			if (odgovor == "*")
			{
				Console.Clear();
				return;
			}

			_fonogram.KataloskiBroj = odgovor;
			executeSearch(_fonogram);
			Console.Clear();
		}

		private void godinaIzdanja()
		{
			Console.Clear();

			_fonogram = new FonogramDTO();

                        Console.WriteLine("Unesite godinu izdanja fonograma koji zelite da pretrazite i pritisnite Enter.\nZa povratak na prethodni meni unesite znak \'*\' i pritisnite Enter:");

			string odgovor = Console.ReadLine().ToUpper();

			if (odgovor == "*")
			{
				Console.Clear();
				return;
			}

			int godina;

			if (int.TryParse(odgovor, out godina))
			{
				_fonogram.GodinaIzdanja = godina;
				executeSearch(_fonogram);
			}

			else
			{
				Console.Clear();
				Console.WriteLine("Neispravan unos!");
			}
		}

		private void sviUnosi()
		{
			if (_allEngine.DoRetrieve(1))
			{
				ConvertAndShow.Fonogram(_allEngine.GetViewModels());
			}
			Console.Clear();
		}

		private void executeSearch(IDTO input)
		{
			if (_engine.DoSave(input) == true)
			{
				ConvertAndShow.Fonogram(_engine.GetViewModels());
			}
			Console.Clear();
		}
	}
}
