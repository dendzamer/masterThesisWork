using System;
using System.Collections.Generic;
using Persistence.Models;

namespace Persistence.Interfaces
{
	public interface IDbIzvodjac : IDb
	{
		int IzvodjacId {get; set;}

		List<Fonogram> Fonogrami {get; set;}
	}
}
