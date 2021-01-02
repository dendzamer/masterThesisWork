using System;
using Domain.Interfaces;

namespace Domain.DTOs
{
	public class IzvodjacDTO : IDTO
	{
		public int Id {get; set;}
		public string Naziv {get; set;}
	}
}
