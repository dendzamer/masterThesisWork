using System;
using DataInjector;
using Domain.DTOs;
using Domain.Interfaces;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
		/*
            Console.WriteLine("Hello World!");

	    AlbumDTO album = new AlbumDTO();
	    album.Naziv = "Bljak pesma";
	    album.KataloskiBroj = "5598057";
	    album.GodinaIzdanja = 2019;

	    DataSaver saver = new DataSaver(album);
	    IAlbumViewModel viewModel = saver.GetViewModel() as IAlbumViewModel;

	    Console.WriteLine("{0} {1} {2} {3} {4} {5}", viewModel.Id, viewModel.Naziv, viewModel.Izvodjaci, viewModel.GodinaIzdanja, viewModel.KataloskiBroj, viewModel.Fonogrami);

	    Console.WriteLine("uspeh!");
	    */
	    

	    
		/*
	    IzvodjacDTO izvodjac = new IzvodjacDTO();
	    izvodjac.Naziv = "Drugi izvodjac";

	    DataSaver noviSaver = new DataSaver(izvodjac);
	    IIzvodjacViewModel izvodjacView = noviSaver.GetViewModel() as IIzvodjacViewModel;

	    Console.WriteLine("{0} {1}", izvodjacView.Id, izvodjacView.Naziv);
	    */

	    FonogramDTO fonogram = new FonogramDTO();
	    fonogram.Naziv = "uh peesma";
	    fonogram.KataloskiBroj = "5598057";
	    fonogram.GodinaIzdanja = 2019;
	    fonogram.AlbumId = 1;
	    fonogram.IzvodjacId.Add(1);
	    fonogram.IzvodjacId.Add(2);

	    DataSaver saver = new DataSaver(fonogram);
	    IFonogramViewModel viewModel = saver.GetViewModel() as IFonogramViewModel;

	    Console.WriteLine("{0} {1} {2} {3} {4}", viewModel.Id, viewModel.Naziv, viewModel.Izvodjaci, viewModel.GodinaIzdanja, viewModel.KataloskiBroj);



	    
        }
    }
}
