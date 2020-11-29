using System;
using Domain.Models;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
		Izvodjac izvodjac = new Izvodjac();
		izvodjac.Naziv = "Denis";

            Console.WriteLine(izvodjac.Show());
        }
    }
}
