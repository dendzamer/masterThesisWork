using System;

namespace Presentation.Read
{
	public class Options
	{
		public static string Album()
		{
			string opcije = "\nOdaberite jednu opciju: "
				+ "\n1) Da pretrazite albume prema kategoriji \'Naziv\' ukucajte broj 1 ili rec \'naziv\' i pritisnite Enter, "
				+ "\n2) Da pretrazite albume prema kategoriji \'Kataloski broj\' ukucajte broj 2 ili rec \'kataloskibroj\' i pritisnite Enter, "
				+ "\n3) Da pretrazite albume prema kategoriji \'Godina izdanja\' ukucajte broj 3 ili rec \'godinaizdanja\' i pritisnite Enter, "
				+ "\n4) Da ucitate sve unose iz baze podataka u ukucajte broj 4 ili rec \'svi\' i pritisnite Enter, "
				+ "\n5) Za povratak na prethodni meni ukucajte broj 5 ili rec \'povratak\' i pritisnite Enter.";

			return opcije;
		}

		public static string Fonogram()
                {
                        string opcije = "\nOdaberite jednu opciju: "
                                + "\n1) Da pretrazite fonograme prema kategoriji \'Naziv\' ukucajte broj 1 ili rec \'naziv\' i pritisnite Enter, "
                                + "\n2) Da pretrazite fonograme prema kategoriji \'Kataloski broj\' ukucajte broj 2 ili rec \'kataloskibroj\' i pritisnite Enter, "
                                + "\n3) Da pretrazite fonograme prema kategoriji \'Godina izdanja\' ukucajte broj 3 ili rec \'godinaizdanja\' i pritisnite Enter, "
                                + "\n4) Da ucitate sve unose iz baze podataka u ukucajte broj 4 ili rec \'svi\' i pritisnite Enter, "
                                + "\n5) Za povratak na prethodni meni ukucajte broj 5 ili rec \'povratak\' i pritisnite Enter.";

                        return opcije;
                }

		public static string Izvodjac()
		{
			string opcije = "\nOdaberite jednu opciju: "
				+ "\n1) Da pretrazite izvodjace prema kategoriji \'Naziv\' ukucajte broj 1 ili rec \'naziv\' i pritisnite Enter, "
				+ "\n2) Da ucitate sve unose iz baze podataka u ukucajte broj 2 ili rec \'svi\' i pritisnite Enter, "
				+ "\n3) Za povratak na prethodni meni ukucajte broj 3 ili rec \'povratak\' i pritisnite Enter.";

			return opcije;
		}

		public static string Menu()
		{
			string opcije = "\nOdaberite jednu opciju: "
				+ "\n1) Da pretrazujete albume ukucajte broj 1 ili rec \'album\' i pritisnite Enter, "
				+ "\n2) Da pretrazujete fonograme ukucajte broj 2 ili rec \'fonogram\' i pritisnite Enter, "
				+ "\n3) Da pretrazujete izvodjace ukucajte broj 3 ili rec \'izvodjac\' i pritisnite Enter, "
				+ "\n4) Za povratak na prethodni meni ukucajte broj 4 ili rec \'povratak\' i pritisnite Enter.";
			return opcije;
		}

	}
}
