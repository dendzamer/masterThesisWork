using System;

namespace Presentation.Update
{
	public class Options
	{
		public static string Album()
		{

			string opcije = "\nOdaberite jednu opciju: "
				+ "\n1) Da ucitate album ukucajte broj 1 ili rec \'ucitaj\' i pritisnite Enter, "
				+ "\n2) Da ispravite \'Naziv\' ukucajte broj 2 ili rec \'naziv\' i pritisnite Enter, "
				+ "\n3) Da ispravite \'Kataloski broj\' ukucajte broj 3 ili rec \'kataloskibroj\' i pritisnite Enter, "
				+ "\n4) Da ispravite \'Godina izdanja\' ukucajte broj 4 ili rec \'godinaizdanja\' i pritisnite Enter, "
				+ "\n5) Da pretrazite albume ukucajte broj 5 ili rec \'pretrazi\' i pritisnite Enter, "
				+ "\n6) Da sacuvate promene ukucajte broj 6 ili rec \'sacuvaj\' i pritisnite Enter, "
				+ "\n7) Da se vratite na prethodni meni ukucajte broj 7 ili rec \'napusti\' i pritisnite Enter. \n";

			return opcije;
		}

		public static string Izvodjac()
		{
			string opcije = "\nOdaberite jednu opciju: "
				+ "\n1) Da ucitate izvodjaca ukucajte broj 1 ili rec \'ucitaj\' i pritisnite Enter, "
				+ "\n2) Da ispravite \'Naziv\' ukucajte broj 2 ili rec \'naziv\' i pritisnite Enter, "
				+ "\n3) Da pretrazite izvodjace ukucajte broj 3 ili rec \'pretrazi\' i pritisnite Enter, "
				+ "\n4) Da sacuvate promene ukucajte broj 4 ili rec \'sacuvaj\' i pritisnite Enter, "
				+ "\n5) Da se vratite na prethodni meni ukucajte broj 5 ili rec \'napusti\' i pritisnite Enter. \n";

			return opcije;
		}

		public static string Fonogram()
		{
			string opcije = "\nOdaberite jednu opciju: "
				+ "\n1) Da ucitate fonogram ukucajte broj 1 ili rec \'ucitaj\' i pritisnite Enter, "
				+ "\n2) Da ispravite \'Naziv\' ukucajte broj 2 ili rec \'naziv\' i pritisnite Enter, "
				+ "\n3) Da ispravite \'Kataloski broj\' ukucajte broj 3 ili rec \'kataloskibroj\' i pritisnite Enter, "
				+ "\n4) Da ispravite \'Godina izdanja\' ukucajte broj 4 ili rec \'godinaizdanja\' i pritisnite Enter, "
				+ "\n5) Da pretrazite fonograme ukucajte broj 5 ili rec \'pretrazi\' i pritisnite Enter, "
				+ "\n6) Da sacuvate promene ukucajte broj 6 ili rec \'sacuvaj\' i pritisnite Enter, "
				+ "\n7) Da se vratite na prethodni meni ukucajte broj 7 ili rec \'napusti\' i pritisnite Enter. \n";

			return opcije;
		}

                public static string Menu()
                {
                        string opcije = "\nOdaberite jednu opciju: "
                                + "\n1) Da ispravite albume ukucajte broj 1 ili rec \'album\' i pritisnite Enter, "
                                + "\n2) Da ispravite fonograme ukucajte broj 2 ili rec \'fonogram\' i pritisnite Enter, "
                                + "\n3) Da ispravite izvodjace ukucajte broj 3 ili rec \'izvodjac\' i pritisnite Enter, "
                                + "\n4) Za povratak na prethodni meni ukucajte broj 4 ili rec \'povratak\' i pritisnite Enter.";
                        return opcije;
                }
	}
}
