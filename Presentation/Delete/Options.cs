using System;

namespace Presentation.Delete
{
	public class Options
	{
		public static string Album()
		{

			string opcije = "\nOdaberite jednu opciju: "
				+ "\n1) Da ucitate album koji zelite da izbrisete ukucajte broj 1 ili rec \'ucitaj\' i pritisnite Enter, "
				+ "\n2) Da potvrdite brisanje albuma ukucajte broj 2 ili rec \'izbrisi\' i pritisnite Enter, "
				+ "\n3) Da pretrazite albume ukucajte broj 3 ili rec \'pretrazi\' i pritisnite Enter,"
				+ "\n4) Za povratak na prethodni meni ukucajte broj 4 ili rec \'napusti\' i pritisnite Enter. \n";

			return opcije;
		}

		public static string Izvodjac()
		{
			string opcije = "\nOdaberite jednu opciju: "
				+ "\n1) Da ucitate izvodjaca kog zelite da izbrisete ukucajte broj 1 ili rec \'ucitaj\' i pritisnite Enter, "
				+ "\n2) Da potvrdite brisanje izvodjaca ukucajte broj 2 ili rec \'izbrisi\' i pritisnite Enter, "
                                + "\n3) Da pretrazite izvodjace ukucajte broj 3 ili rec \'pretrazi\' i pritisnite Enter,"
                                + "\n4) Za povratak na prethodni meni ukucajte broj 4 ili rec \'napusti\' i pritisnite Enter. \n";

			return opcije;
		}

		public static string Fonogram()
		{
			string opcije = "\nOdaberite jednu opciju: "
				+ "\n1) Da ucitate fonogram koji zelite da izbrisete ukucajte broj 1 ili rec \'ucitaj\' i pritisnite Enter, "
				+ "\n2) Da potvrdite brisanje fonograma ukucajte broj 2 ili rec \'izbrisi\' i pritisnite Enter, "
                                + "\n3) Da pretrazite fonograme ukucajte broj 3 ili rec \'pretrazi\' i pritisnite Enter,"
                                + "\n4) Za povratak na prethodni meni ukucajte broj 4 ili rec \'napusti\' i pritisnite Enter. \n";

			return opcije;
		}

                public static string Menu()
                {
                        string opcije = "\nOdaberite jednu opciju: "
                                + "\n1) Da izbrisete albume ukucajte broj 1 ili rec \'album\' i pritisnite Enter, "
                                + "\n2) Da izbrisete fonograme ukucajte broj 2 ili rec \'fonogram\' i pritisnite Enter, "
                                + "\n3) Da izbrisete izvodjace ukucajte broj 3 ili rec \'izvodjac\' i pritisnite Enter, "
                                + "\n4) Za povratak na prethodni meni ukucajte broj 4 ili rec \'povratak\' i pritisnite Enter.";
                        return opcije;
                }
	}
}
