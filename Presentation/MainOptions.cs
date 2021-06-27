using System;

namespace Presentation
{
	public class MainOptions
	{
		public static string Options()
		{
			string opcije = "\nOdaberite jednu opciju: "
				+ "\n1) Da kreirate novi unos ukucajte broj 1 ili rec \'kreiraj\' i pritisnite Enter, "
				+ "\n2) Da pretrazite unose ukucajte broj 2 ili rec \'pretrazi\' i pritisnite Enter, "
				+ "\n3) Da ispravite neki od unosa ukucajte broj 3 ili rec \'ispravi\' i pritisnite Enter, "
				+ "\n4) Da izbrisete neki od unosa ukucajte broj 4 ili rec \'izbrisi\' i pritisnite Enter, "
				+ "\n5) Da procitate uputstvo za upotrebu ukucajte broj 5 ili rec \'pomoc\' i pritisnite Enter, "
				+ "\n6) Da napustite program ukucajte broj 6 ili rec \'napusti\' i pritisnite Enter.";

			return opcije;
		}
	}
}
