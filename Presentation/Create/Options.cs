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
				+ "\n5) Da napustite program ukucajte broj 5 ili rec \'napusti\' i pritisnite Enter. \n";

			return opcije;
		}
	}
}
