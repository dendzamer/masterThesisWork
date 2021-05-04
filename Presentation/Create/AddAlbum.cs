using System;
using Domain.Interfaces;
using Domain.DTOs;
using Domain.ViewModels;
using Presentation.Read;
using Create.Enums;

namespace Presentation.Create
{
	public class AddAlbum
	{
		public IAlbumViewModel Album {get; private set;}
		private bool _doneBool = false;
		private AddAlbumEnum _izbor;
		private ReadOneInstance _read;
		private CreateAlbum _create;
		private Engine _engine;

		public AddAlbum()
		{
			Album = new AlbumViewModel();
			_read = new ReadOneInstance();
			_create = new CreateAlbum();
			_engine = new Engine();
		}

		public void ChooseOptions()
		{

			_doneBool = false;

			Console.Clear();

			do
			{
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Console.WriteLine("Dodavanje albuma u fonogram:");
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Stats.AddAlbumStats(Album);
				Console.WriteLine("-------------------------------------------------------------------------------------------");
				Console.WriteLine(Options.AddAlbum());

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
			while (_doneBool == false);
		}

		private void callSwitch(AddAlbumEnum input)
		{
			switch(input)
			{
				case AddAlbumEnum.dodaj:
					dodajAlbum();
					break;
				case AddAlbumEnum.pretrazi:
					pretraziAlbume();
					break;
				case AddAlbumEnum.kreiraj:
					kreirajAlbum();
					break;
				case AddAlbumEnum.zavrsi:
					_doneBool = true;
					break;
				default:
					Console.Clear();
					Console.WriteLine("Odaberite validnu opciju!");
					break;
			}
		}

		private void dodajAlbum()
		{
			Console.Clear();
			Console.WriteLine("-------------------------------------------------------------------------------------------");
			Stats.AddAlbumStats(Album);
			Console.WriteLine("-------------------------------------------------------------------------------------------");

			Console.WriteLine("Ukucajte ID broj albuma i pritisnite Enter:");
			Console.WriteLine("Za povratak na prethodni meni ukucajte znak \'*\' i pritisnite Enter.");
			string unos = Console.ReadLine().ToLower().Replace(" ","");
			
			if (unos == "*")
			{
				Console.Clear();
				return;
			}

			int myId = 0;

			if (int.TryParse(unos, out myId) == true)
			{
				retrieveAlbum(myId);
			}

			else
			{
				Console.Clear();
				Console.WriteLine("Neispravan unos!");
			}
		}

		private void retrieveAlbum(int input)
		{
			IAlbumDTO album = new AlbumDTO();
			album.Id = input;

			if(_read.DoSearch(album) == true)
			{
				Album = _read.GetViewModel() as IAlbumViewModel;
			}
			Console.Clear();
		}

		private void pretraziAlbume()
		{
			ReadAlbum read = new ReadAlbum();
			read.ChooseOption();
			Console.Clear();
		}

		private void kreirajAlbum()
		{
			if (_create.PopulateEntries() == true)
			{
				if (_engine.DoSave(_create.Album))
				{
					Show.ShowSaved(_engine.GetViewModel());
					Album = _engine.GetViewModel() as IAlbumViewModel;
				}
			}
			Console.Clear();
		}
	}
}
