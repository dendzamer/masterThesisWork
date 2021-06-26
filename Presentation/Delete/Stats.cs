using System;
using Domain.DTOs;

namespace Presentation.Delete
{
	public class Stats
	{
		static public void AlbumStats(AlbumDTO input)
                {
                        Console.WriteLine("ID: {0} Naziv: {1}", input.Id, input.Naziv);
                        Console.WriteLine("Kataloski broj: {0}", input.KataloskiBroj);
                        Console.WriteLine("Godina izdanja: {0}", input.GodinaIzdanja);
                }

                static public void FonogramStats(FonogramDTO input)
                {
                        Console.WriteLine("ID: {0} Naziv: {1}", input.Id, input.Naziv);
                        Console.WriteLine("Kataloski broj: {0}", input.KataloskiBroj);
                        Console.WriteLine("Godina izdanja: {0}", input.GodinaIzdanja);
                }

                static public void IzvodjacStats(IzvodjacDTO input)
                {
                        Console.WriteLine("ID: {0} Naziv: {1}", input.Id, input.Naziv);
                }

	}
}
