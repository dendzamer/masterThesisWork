using System;
using Presentation;
using Domain.DTOs;
using Domain.Interfaces;
using Presentation.Delete.Enums;
using Presentation.Read;
using Presentation.Delete.Interfaces;

namespace Presentation.Delete
{
	public class DeleteAlbum : IDeleter
	{
		private AlbumDTO _album;
		private bool _doneBool = false;
		private DeleteEnum _izbor;
		private LoadDTO _load;
		private Engine _engine;
		private ReadAlbum _read;

		public DeleteAlbum()
		{
			_album = new AlbumDTO();
			_load = new LoadDTO();
			_engine = new Engine();
			_read = new ReadAlbum();
		}

		public void ChooseOption()
		{
			_doneBool = false;

			Console.Clear();
			while(_doneBool == false)
			{
                                Console.WriteLine("-------------------------------------------------------------------------------------------");
                                Console.WriteLine("Brisanje albuma:");
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

		public void callSwitch(DeleteEnum input)
		{
			switch(input)
			{
				case DeleteEnum.ucitaj:
					loadAlbum();
					break;
				case DeleteEnum.izbrisi:
					executeDelete();
					break;
				case DeleteEnum.pretrazi:
					search();
					break;
				case DeleteEnum.napusti:
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

		private void executeDelete()
		{

			Console.Clear();
			Console.WriteLine("-------------------------------------------------------------------------------------------");
			Stats.AlbumStats(_album);
			Console.WriteLine("-------------------------------------------------------------------------------------------");
			Console.WriteLine("Da li ste sigurni da zelite da izbrisete navedeni album? Album ce biti trajno obrisan! \nDa odustanete ukucajte \'ne\' i pritisnite enter. \nZa nastavak ukucajte bilo sta drugo i pritisnite enter.");

			string odgovor = Console.ReadLine().Trim().ToLower();

			if (odgovor == "ne")
			{
				Console.Clear();
				return;
			}

			if (_album.Id != 0)
			{
				if (_engine.DoDelete(_album))
				{
					Console.Clear();
					Console.WriteLine("Album JE IZBRISAN! Pritisnite enter za povratak na prethodni meni.");
					Console.ReadLine();
					Console.Clear();
					_album = new AlbumDTO();
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

		private void search()
		{
			_read.ChooseOption();
			Console.Clear();
		}
	}
}
