using System;
using Domain.Interfaces;

namespace Presentation.Create.Interfaces
{
	public interface ICreator
	{
		bool PopulateEntries();
		IDTO GetDto();
	}
}
