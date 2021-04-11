using System;

namespace Presentation.Create
{
	public class Options
	{
		public static string Album()
		{
			string opcije = "\nOdaberite jednu opciju: "
				+ "\n1) Da popunite \'Naziv\' ukucajte broj 1 ili rec \'naziv\' i pritisnite Enter, "
				+ "\n2) Da popunite \'Kataloski broj\' ukucajte broj 2 ili rec \'kataloskibroj\' i pritisnite Enter, "
				+ "\n3) Da popunite \'Godina izdanja\' ukucajte broj 3 ili rec \'godinaizdanja\' i pritisnite Enter, "
				+ "\n4) Da zavrsite i potvrdite sve unose ukucajte broj 4 ili rec \'zavrsi\' i pritisnite Enter, "
				+ "\n5) Da se vratite na prethodni meni ukucajte broj 5 ili rec \'napusti\' i pritisnite Enter. \n";

			return opcije;
		}

		public static string Izvodjac()
		{
			string opcije = "\nOdaberite jednu opciju: "
				+ "\n1) Da popunite \'Naziv\' ukucajte broj 1 ili rec \'naziv\' i pritisnite Enter, "
				+ "\n2) Da zavrsite i potvrdite sve unose ukucajte broj 2 ili rec \'zavrsi\' i pritisnite Enter, "
				+ "\n3) Da se vratite na prethodni meni ukucajte broj 3 ili rec \'napusti\' i pritisnite Enter. \n";

			return opcije;
		}

		public static string Fonogram()
		{
			string opcije = "\nOdaberite jednu opciju: "
				+ "\n1) Da popunite \'Naziv\' ukucajte broj 1 ili rec \'naziv\' i pritisnite Enter, "
				+ "\n2) Da popunite \'Kataloski broj\' ukucajte broj 2 ili rec \'kataloskibroj\' i pritisnite Enter, "
				+ "\n3) Da popunite \'Godina izdanja\' ukucajte broj 3 ili rec \'godinaizdanja\' i pritisnite Enter, "
				+ "\n4) Da popunite \'Izvodjace\' ukucajte broj 4 ili rec \'izvodjaci\' i pritisnite Enter, "
				+ "\n5) Da popunite \'Album\' ukucajte broj 5 ili rec \'album\' i pritisnite Enter, "
				+ "\n6) Da zavrsite i potvrdite sve unose ukucajte broj 6 ili rec \'zavrsi\' i pritisnite Enter, "
				+ "\n7) Da se vratite na prethodni meni ukucajte broj 7 ili rec \'napusti\' i pritisnite Enter. \n";

			return opcije;
		}

		public static string AddIzvodjac()
		{
			string opcije = "\nOdaberite jednu opciju: "
				+ "\n1) Da dodate izvodjaca ukucajte broj 1 ili rec \'dodaj\' i pritisnite Enter, "
				+ "\n2) Da pretrazite izvodjace kucajte broj 2 ili rec \'pretrazi\' i pritisnite Enter, "
				+ "\n3) Da kreirate novog izvodjaca ukucajte broj 3 ili rec \'kreiraj\' i pritisnite Enter, "
				+ "\n4) Da izbrisete izvodjace ukucajte broj 4 ili rec \'izbrisi\' i pritisnite Enter, "
				+ "\n5) Da zavrsite i potvrdite sve unose ukucajte broj 5 ili rec \'zavrsi\' i pritisnite Enter, ";

			return opcije;
		}
	}
}
