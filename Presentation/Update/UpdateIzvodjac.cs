using System;
using System.Collections.Generic;
using Domain.DTOs;
using Domain.Interfaces;
using Presentation.Update.Enums;
using Presentation.Read;

namespace Presentation.Update
{
	public class UpdateIzvodjac
	{
	
		private IzvodjacDTO _izvodjac;
		private bool _doneBool = false;
		private IzvodjacEnum _izbor;
		private LoadDTO _load;

		public UpdateIzvodjac()
		{
			_izvodjac = new IzvodjacDTO();
			_load = new LoadDTO();
		}

		public void ChooseOption()
		{
			_doneBool = false;

			Console.Clear();
			while(_doneBool == false)
			{
				Console.WriteLine("-------------------------------------------------------------------------------------------");
                                Console.WriteLine("Ispravka izvodjaca:");
                                Console.WriteLine("-------------------------------------------------------------------------------------------");
                                Stats.IzvodjacStats(_izvodjac);
                                Console.WriteLine("-------------------------------------------------------------------------------------------");

				Console.WriteLine(Options.Izvodjac());

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

		private void callSwitch(IzvodjacEnum input)
		{
			switch(input)
			{
				case IzvodjacEnum.ucitaj:
					loadIzvodjac();
					break;
				case IzvodjacEnum.naziv:
					naziv();
					break;
				case IzvodjacEnum.pretrazi:
					search();
					break;
				case IzvodjacEnum.sacuvaj:
					_doneBool = true;
					executeUpdate();
					break;
				case IzvodjacEnum.napusti:
					_doneBool = true;
					break;
				default:
					Console.Clear();
					Console.WriteLine("Odaberite validnu opciju!");
					break;
			}
		}

		private void loadIzvodjac()
		{
			_load.LoadIzvodjac(_izvodjac);
			Console.Clear();
		}

		private void naziv()
		{


		}

		private void search()
		{


		}

		private void executeUpdate()
		{


		}
	}
}
