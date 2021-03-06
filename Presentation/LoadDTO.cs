using System;
using Presentation.Read;
using Domain.DTOs;
using Domain.ViewModels;
using Domain.Interfaces;

namespace Presentation
{
	public class LoadDTO
	{
		private ReadOneInstance _read;

		public LoadDTO()
		{
			_read = new ReadOneInstance();
		}

		public void LoadIzvodjac(IzvodjacDTO input)
		{
			Console.Clear();
			Console.WriteLine("Unesite Id izvodjaca kog zelite da ucitate iz baze podataka i pritisnite Enter!\nZa povratak na prethodni meni ukucajte znak \'*\' i pritisnite Enter.");

			string izbor = Console.ReadLine();
			int id = 0;

			if (izbor == "*")
			{
				Console.Clear();
				return;
			}

			if (int.TryParse(izbor, out id))
			{
				input.Id = id;

				if(_read.DoSearch(input))
				{
					parseIzvodjac(_read.GetViewModel(), input);
				}

				else
				{
					input.Id = 0;
				}
			}

			else 
			{
				input.Id = 0;
				Console.Clear();
				Console.WriteLine("Neispravan unos! Pritisnite Enter za nastavak...");
				Console.ReadLine();
				return;
			}
		}

		public void LoadFonogram(FonogramDTO input)
		{
			Console.Clear();
			Console.WriteLine("Unesite Id fonograma koji zelite da ucitate iz baze podataka i pritisnite Enter!\nZa povratak na prethodni meni ukucajte znak \'*\' i pritisnite Enter.");

			string izbor = Console.ReadLine();
			int id = 0;

			if (izbor == "*")
			{
				Console.Clear();
				return;
			}

			if (int.TryParse(izbor, out id))
			{
				input.Id = id;

				if (_read.DoSearch(input))
				{
					parseFonogram(_read.GetViewModel(), input);
				}

				else
				{
					input.Id = 0;
				}
			}

			else
			{
				input.Id = 0;
				Console.Clear();
				Console.WriteLine("Neispravan unos! Pritisnite Enter za nastavak...");
				Console.ReadLine();
				return;
			}
		}

		public void LoadAlbum(AlbumDTO input)
		{
                        Console.Clear();
                        Console.WriteLine("Unesite Id albuma kog zelite da ucitate iz baze podataka i pritisnite Enter!\nZa povratak na prethodni meni ukucajte znak \'*\' i pritisnite Enter.");

                        string izbor = Console.ReadLine();
                        int id = 0;

                        if (izbor == "*")
                        {
                                Console.Clear();
                                return;
                        }

			if (int.TryParse(izbor, out id))
			{
				input.Id = id;

				if (_read.DoSearch(input))
				{
					parseAlbum(_read.GetViewModel(), input);
				}

				else
				{
					input.Id = 0;
				}
			}

			else
			{
				input.Id = 0;
				Console.Clear();
				Console.WriteLine("Neispravan unos! Pritisnite Enter za nastavak...");
				Console.ReadLine();
				return;
			}

		}

		private void parseIzvodjac(IViewModel viewModel, IzvodjacDTO output)
		{
			IIzvodjacViewModel input = viewModel as IIzvodjacViewModel;

			output.Id = input.Id;
			output.Naziv = input.Naziv;
		}

		private void parseFonogram(IViewModel viewModel, FonogramDTO output)
		{
			IFonogramViewModel input = viewModel as IFonogramViewModel;

			output.Id = input.Id;
			output.Naziv = input.Naziv;
			output.KataloskiBroj = input.KataloskiBroj;
			output.GodinaIzdanja = input.GodinaIzdanja;
		}

		private void parseAlbum(IViewModel viewModel, AlbumDTO output)
		{
			IAlbumViewModel input = viewModel as IAlbumViewModel;

			output.Id = input.Id;
			output.Naziv = input.Naziv;
			output.KataloskiBroj = input.KataloskiBroj;
			output.GodinaIzdanja = input.GodinaIzdanja;
		}
	}
}
