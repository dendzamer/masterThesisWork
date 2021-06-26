using System;
using System.Collections.Generic;
using Presentation;
using Domain.DTOs;
using Domain.Interfaces;
using Presentation.Update.Enums;
using Presentation.Read;
using Presentation.Update.Interfaces;

namespace Presentation.Update
{
	public class UpdateFonogram : IUpdater
	{
		private FonogramDTO _fonogram;
		private bool _doneBool = false;
		private FonogramAlbumEnum _izbor;
		private LoadDTO _load;
		private Engine _engine;
		private	ReadFonogram _read;

		public UpdateFonogram()
		{
			_fonogram = new FonogramDTO();
			_load = new LoadDTO();
			_engine = new Engine();
			_read = new ReadFonogram();
		}

		public void ChooseOption()
		{
			_doneBool = false;

			Console.Clear();
			while(_doneBool == false)
			{
				Console.WriteLine("-------------------------------------------------------------------------------------------");
                                Console.WriteLine("Ispravka fonograma:");
                                Console.WriteLine("-------------------------------------------------------------------------------------------");
                                Stats.FonogramStats(_fonogram);
                                Console.WriteLine("-------------------------------------------------------------------------------------------");

				Console.WriteLine(Options.Fonogram());

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
		}

		private void callSwitch(FonogramAlbumEnum input)
		{
			switch(input)
			{
				case FonogramAlbumEnum.ucitaj:
					loadFonogram();
					break;
				case FonogramAlbumEnum.naziv:
					naziv();
					break;
				case FonogramAlbumEnum.kataloskibroj:
					kataloskiBroj();
					break;
				case FonogramAlbumEnum.godinaizdanja:
					godinaIzdanja();
					break;
				case FonogramAlbumEnum.pretrazi:
					search();
					break;
				case FonogramAlbumEnum.sacuvaj:
					executeUpdate();
					break;
				case FonogramAlbumEnum.napusti:
					_doneBool = true;
					break;
				default:
					Console.Clear();
					Console.WriteLine("Odaberite validnu opciju!");
					break;
			}
		}

		private void loadFonogram()
		{
			_load.LoadFonogram(_fonogram);
			Console.Clear();
		}

		private void naziv()
		{
			if (isFonogramUcitan() == false)
			{
				return;
			}

			Console.Clear();
			Stats.FonogramStats(_fonogram);
			Console.WriteLine("-------------------------------------------------------------------------------------------");
			Console.WriteLine("Unesite novi naziv fonograma i pritisnite Enter. Za povratak na prethodni meni ukucajte znak \'*\' i pritisnite enter.");
			Console.WriteLine("-------------------------------------------------------------------------------------------");

			string naziv = Console.ReadLine().ToUpper();

			if (naziv == "*")
			{
				Console.Clear();
				return;
			}

			else if (naziv == "" || naziv == null)
			{
				Console.Clear();
				Console.WriteLine("Neispravan unos! Pritisnite Enter za povratak na prethodni meni!");
				Console.ReadLine();
				Console.Clear();
			}

			else
			{
				_fonogram.Naziv = naziv;
				Console.Clear();
			}
		}

		private void kataloskiBroj()
		{

			if (isFonogramUcitan() == false)
			{
				return;
			}

			Console.Clear();
			Stats.FonogramStats(_fonogram);
			Console.WriteLine("-------------------------------------------------------------------------------------------");
			Console.WriteLine("Unesite novi kataloski broj fonograma i pritisnite Enter. Za povratak na prethodni meni ukucajte znak \'*\' i pritisnite enter.");
			Console.WriteLine("-------------------------------------------------------------------------------------------");

			string katBroj = Console.ReadLine().ToUpper();

			if (katBroj == "*")
			{
				Console.Clear();
				return;
			}

			else if (katBroj == "" || katBroj == null)
			{
				Console.Clear();
				Console.WriteLine("Neispravan unos! Pritisnite Enter za povratak na prethodni meni!");
				Console.ReadLine();
				Console.Clear();
			}

			else
			{
				_fonogram.KataloskiBroj = katBroj;
				Console.Clear();
			}
		}

		private void godinaIzdanja()
		{

			if (isFonogramUcitan() == false)
			{
				return;
			}

                        Console.Clear();
                        Stats.FonogramStats(_fonogram);
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                        Console.WriteLine("Unesite novu godinu izdanja fonograma i pritisnite Enter. Za povratak na prethodni meni ukucajte znak \'*\' i pritisnite enter.");
                        Console.WriteLine("-------------------------------------------------------------------------------------------");

                        string unos = Console.ReadLine().ToUpper();
			int godinaIzdanja = 0;


                        if (unos == "*")
                        {
                                Console.Clear();
                                return;
                        }

			else if (int.TryParse(unos, out godinaIzdanja) && godinaIzdanja > 0)
			{
				_fonogram.GodinaIzdanja  = godinaIzdanja;
                                Console.Clear();
			}

			else
			{
				Console.Clear();
				Console.WriteLine("Neispravan unos! Pritisnite Enter za povratak na prethodni meni!");
				Console.ReadLine();
				Console.Clear(); 
			}
		}

		private bool isFonogramUcitan()
		{

                        if (_fonogram.Id == 0)
                        {
                                Console.Clear();
                                Console.WriteLine("Fonogram nije ucitan! Pritisnite Enter za povratak na prethodni meni.");
                                Console.ReadLine();
                                Console.Clear();
                                return false;
                        }

			else
			{
				return true;
			}
		}

		private void search()
		{
			_read.ChooseOption();
			Console.Clear();
		}

		private void executeUpdate()
		{
			if (_fonogram.Id != 0)
			{
				if (_engine.DoSave(_fonogram))
				{
					Show.ShowSaved(_engine.GetViewModel());
					Console.Clear();
				}
			}

			else
			{
                                Console.Clear();
                                Console.WriteLine("Fonogram nije ucitan! Pritisnite Enter za povratak na prethodni meni.");
                                Console.ReadLine();
                                Console.Clear();
			}
		}
	}
}
