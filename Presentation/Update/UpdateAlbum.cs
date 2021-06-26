using System;
using Domain.DTOs;
using Presentation;
using Domain.Interfaces;
using Presentation.Update.Enums;
using Presentation.Read;
using Presentation.Update.Interfaces;

namespace Presentation.Update
{
	public class UpdateAlbum : IUpdater
	{
		private AlbumDTO _album;
		private bool _doneBool = false;
		private FonogramAlbumEnum _izbor;
		private LoadDTO _load;
		private Engine _engine;
		private ReadAlbum _read;

		public UpdateAlbum()
		{
			_album = new AlbumDTO();
			_load = new LoadDTO();
			_engine = new Engine();
			_read =  new ReadAlbum();
		}

		public void ChooseOption()
		{
			_doneBool = false;

			Console.Clear();
			while(_doneBool == false)
			{
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Console.WriteLine("Ispravka albuma:");
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Stats.AlbumStats(_album);
				Console.WriteLine("-------------------------------------------------------------------------------------------");

				Console.WriteLine(Options.Album());

				string myOption = Console.ReadLine().ToLower().Replace(" ","");

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

		public void callSwitch(FonogramAlbumEnum input)
		{
			switch(input)
			{
				case FonogramAlbumEnum.ucitaj:
					loadAlbum();
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

		private void loadAlbum()
		{
			_load.LoadAlbum(_album);
			Console.Clear();
		}

		private void naziv()
		{
			if (isAlbumUcitan() == false)
			{
				return;
			}

			Console.Clear();
                        Stats.AlbumStats(_album);
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                        Console.WriteLine("Unesite novi naziv albuma i pritisnite Enter. Za povratak na prethodni meni ukucajte znak \'*\' i pritisnite enter.");
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
				_album.Naziv = naziv;
				Console.Clear();
			}
		}

		private void kataloskiBroj()
		{
			if (isAlbumUcitan() == false)
			{
				return;
			}

                        Console.Clear();
                        Stats.AlbumStats(_album);
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                        Console.WriteLine("Unesite novi kataloski broj albuma i pritisnite Enter. Za povratak na prethodni meni ukucajte znak \'*\' i pritisnite enter.");
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
				_album.KataloskiBroj = katBroj;
				Console.Clear();
			}
		}

		private void godinaIzdanja()
		{
			if ( isAlbumUcitan() == false)
			{
				return;
			}

                        Console.Clear();
                        Stats.AlbumStats(_album);
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                        Console.WriteLine("Unesite novu godinu izdanja albuma i pritisnite Enter. Za povratak na prethodni meni ukucajte znak \'*\' i pritisnite enter.");
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
				_album.GodinaIzdanja = godinaIzdanja;
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

		private bool isAlbumUcitan()
		{
			if (_album.Id == 0)
			{
                                Console.Clear();
                                Console.WriteLine("Album nije ucitan! Pritisnite Enter za povratak na prethodni meni.");
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
			if (_album.Id != 0)
			{
				if (_engine.DoSave(_album))
				{
					Show.ShowSaved(_engine.GetViewModel());
					Console.Clear();
				}
			}

			else
			{
				Console.Clear();
                                Console.WriteLine("Album nije ucitan! Pritisnite Enter za povratak na prethodni meni.");
                                Console.ReadLine();
                                Console.Clear();
			}
		}


	}
}
