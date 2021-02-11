using System;
using DataInjector;
using Domain.DTOs;
using Domain.Interfaces;
using Domain.ViewModels;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
		//!!!!!!!!!!!!!!!!!!!! Napraviti Albumi u IzvodjacViewModelu!! i sve sto treba propratno za to!!!
		
		//CreateAlbum();
		//CreateIzvodjac("Neki John");
		//CreateFonogram("Nova pesma");
		//ReadAlbum();
		//ReadIzvodjac();
		//ReadFonogram();

		//UpdateFonogram("Four");
		//UpdateIzvodjac("Charles Darwin");
		UpdateAlbum();
		

        }


	static public void UpdateAlbum()
	{
		InjectSRU inject = new InjectSRU();

		IAlbumDTO album = new AlbumDTO();
		album.Id = 2;
		album.Naziv = "Full House";
		album.KataloskiBroj = "088";
		album.GodinaIzdanja = 2019;

		IAlbumViewModel albumView = inject.UpdateData(album) as AlbumViewModel;

		string result = $"\n{albumView.Id}\n{albumView.Naziv}\n{albumView.Izvodjaci}\n{albumView.GodinaIzdanja}\n{albumView.KataloskiBroj}\n{albumView.Fonogrami}";
		Console.WriteLine(result);
	}	
	
	static public void UpdateIzvodjac(string naziv)
	{
		InjectSRU inject = new InjectSRU();
		IDTO izvodjac = new IzvodjacDTO();

		izvodjac.Id = 8;
		izvodjac.Naziv = naziv;
		
		IIzvodjacViewModel izvodjacView = inject.UpdateData(izvodjac) as IzvodjacViewModel;
		string result = $"\n{izvodjacView.Id}\n{izvodjacView.Naziv}\n{izvodjacView.Fonogrami}";
		Console.WriteLine(result);

	}

	static public void UpdateFonogram(string naziv)
	{
		InjectSRU inject = new InjectSRU();
		IFonogramDTO fonogram = new FonogramDTO();
		
		fonogram.Id = 12;
		fonogram.Naziv = naziv;
		fonogram.KataloskiBroj = "777";
		fonogram.AlbumId = 2;
		fonogram.GodinaIzdanja = 2009;
		fonogram.IzvodjacId.Add(8);
		fonogram.IzvodjacId.Add(9);
		fonogram.IzvodjacId.Add(10);
		fonogram.IzvodjacId.Add(11);

		IFonogramViewModel fonogramView = inject.UpdateData(fonogram) as FonogramViewModel;
		string result = $"\n{fonogramView.Id}\n{fonogramView.Naziv}\n{fonogramView.KataloskiBroj}\n{fonogramView.GodinaIzdanja}\n{fonogramView.Izvodjaci}\n";

		Console.WriteLine(result);
	}

	static public void CreateFonogram(string naziv)
	{
		InjectSRU inject = new InjectSRU();
		IFonogramDTO fonogram = new FonogramDTO();
		
		fonogram.Naziv = naziv;
		fonogram.KataloskiBroj = "0888072301290";
		fonogram.AlbumId = 1;
		fonogram.GodinaIzdanja = 2007;
		fonogram.IzvodjacId.Add(8);
		fonogram.IzvodjacId.Add(9);
		fonogram.IzvodjacId.Add(10);
		fonogram.IzvodjacId.Add(11);

		IFonogramViewModel fonogramView = inject.SaveData(fonogram) as FonogramViewModel;
		string result = $"\n{fonogramView.Id}\n{fonogramView.Naziv}\n{fonogramView.KataloskiBroj}\n{fonogramView.GodinaIzdanja}\n{fonogramView.Izvodjaci}\n";

		Console.WriteLine(result);
	}

	static public void CreateIzvodjac(string ime)
	{
		InjectSRU inject = new InjectSRU();

		IDTO izvodjac = new IzvodjacDTO();
		izvodjac.Naziv = ime;

		IIzvodjacViewModel izvodjacView = inject.SaveData(izvodjac) as IzvodjacViewModel;
		string result = $"\n{izvodjacView.Id}\n{izvodjacView.Naziv}\n{izvodjacView.Fonogrami}";
		Console.WriteLine(result);
	}

	


	static public void CreateAlbum()
	{
		InjectSRU inject = new InjectSRU();

		IAlbumDTO album = new AlbumDTO();
		album.Naziv = "Full House - Wes Montgomery";
		album.KataloskiBroj = "0888072301290";
		album.GodinaIzdanja = 2007;

		IAlbumViewModel albumView = inject.SaveData(album) as AlbumViewModel;

		string result = $"\n{albumView.Id}\n{albumView.Naziv}\n{albumView.Izvodjaci}\n{albumView.GodinaIzdanja}\n{albumView.KataloskiBroj}\n{albumView.Fonogrami}";
		Console.WriteLine(result);
	}

	static public void ReadAlbum()
	{
		InjectSRU inject = new InjectSRU();

		IAlbumDTO album = new AlbumDTO();
		album.Id = 1;

		IAlbumViewModel albumView = inject.ReadData(album) as AlbumViewModel;

		string result = $"\n{albumView.Id}\n{albumView.Naziv}\n{albumView.Izvodjaci}\n{albumView.GodinaIzdanja}\n{albumView.KataloskiBroj}\n{albumView.Fonogrami}";
		Console.WriteLine(result);
	}

	static public void ReadIzvodjac()
	{
		InjectSRU inject = new InjectSRU();
		IDTO izvodjac = new IzvodjacDTO();
		izvodjac.Id = 9;

		IIzvodjacViewModel izvodjacView = inject.ReadData(izvodjac) as IzvodjacViewModel;

		string result = $"\n{izvodjacView.Id}\n{izvodjacView.Naziv}\n{izvodjacView.Fonogrami}\n{izvodjacView.Albumi}";
		Console.WriteLine(result);
	}

	static public void ReadFonogram()
	{
		InjectSRU inject = new InjectSRU();
		IFonogramDTO fonogram = new FonogramDTO();
		fonogram.Id = 12;

		IFonogramViewModel fonogramView = inject.ReadData(fonogram) as FonogramViewModel;

		string result = $"\n{fonogramView.Id}\n{fonogramView.Naziv}\n{fonogramView.KataloskiBroj}\n{fonogramView.GodinaIzdanja}\n{fonogramView.Izvodjaci}\n";

		Console.WriteLine(result);
	}

    }
}
