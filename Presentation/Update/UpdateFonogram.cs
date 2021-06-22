using System;
using System.Collections.Generic;
using Domain.DTOs;
using Domain.Interfaces;
using Presentation.Update.Enums;
using Presentation.Read;

namespace Presentation.Update
{
	public class UpdateFonogram
	{
		private FonogramDTO _fonogram;
		private bool _doneBool = false;
		private FonogramEnum _izbor;
		private LoadDTO _load;
		private Engine _engine;
		ReadFonogram _read;

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

		private void callSwitch(FonogramEnum input)
		{
			switch(input)
			{
				case FonogramEnum.ucitaj:
					loadFonogram();
					break;
				case FonogramEnum.naziv:
					naziv();
					break;
				case FonogramEnum.kataloskibroj:
					kataloskiBroj();
					break;
				case FonogramEnum.godinaizdanja:
					godinaIzdanja();
					break;
				case FonogramEnum.pretrazi:
					search();
					break;
				case FonogramEnum.sacuvaj:
					executeUpdate();
					break;
				case FonogramEnum.napusti:
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
			if (_fonogram.Id == 0)
			{
				Console.Clear();
				Console.WriteLine("Fonogram nije ucitan! Pritisnite Enter za povratak na prethodni meni.");
				Console.ReadLine();
				Console.Clear();
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

			if (_fonogram.Id == 0)
			{
				Console.Clear();
				Console.WriteLine("Fonogram nije ucitan! Pritisnite Enter za povratak na prethodni meni.");
				Console.ReadLine();
				Console.Clear();
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

                        if (_fonogram.Id == 0)
                        {
                                Console.Clear();
                                Console.WriteLine("Fonogram nije ucitan! Pritisnite Enter za povratak na prethodni meni.");
                                Console.ReadLine();
                                Console.Clear();
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
