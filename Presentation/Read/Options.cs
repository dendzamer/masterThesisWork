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
	}
}
