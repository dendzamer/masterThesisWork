using System;
using Persistence;

namespace DataInjector
{
	public static class RepCreator
	{

		public static RepSaver GetRepSaver()
		{
			RepSaver repSaver = new RepSaver();

			return repSaver;
		}

		public static RepRetriever GetRepRetriever()
		{
			RepRetriever repRetriever = new RepRetriever();

			return repRetriever;
		}

		public static RepUpdater GetRepUpdater()
		{
			RepUpdater repUpdater = new RepUpdater();

			return repUpdater;
		}


	}
}
