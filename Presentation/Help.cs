using System;

namespace Presentation
{
	public class Help
	{
		public static void BasicHelp()
		{
			Console.Clear();

			string help = "Uputstvo za kreiranje novih unosa: "
				+ "\n\n1) Prvi korak je kreiranje novog albuma.\nDa biste dodali novi fonogram u bazu podataka neophodno je da prvo bude kreiran album u koji dodajete fonogram."
				+ "\nUkoliko je album vec kreiran onda ga mozete odabrati kasnije u toku kreiranje novog fonograma."
				+ "\n\n2) Drugi korak je kreiranje neophodnih izvodjaca.\nPotrebno je kreirati izvodjace koji se kasnije pridodaju fonogramu.\nUkoliko je izvodjac vec kreiran onda ga mozete odabrati kasnije u toku kreiranje novog fonograma i pridodati ga fonogramu."
				+ "\n\n3) Poslednji korak je kreiranje novog fonograma.\nNakon sto popunite sve unose u meniju za kreiranje novog fonograma odaberite opciju 6 \'zavrsi\' da potvrdite unos i sacuvate ga u bazu podataka.";

			Console.WriteLine(help);
			Console.WriteLine("\nPritisnite Enter za povratak na prethodni meni.");
			Console.ReadLine();
		}
	}
}
