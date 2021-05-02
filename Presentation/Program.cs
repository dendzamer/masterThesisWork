using System;
using System.Collections.Generic;
using DataInjector;
using Domain.DTOs;
using Domain.Interfaces;
using Domain.ViewModels;
using Presentation.Create;
using Presentation.Read;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
		ReadFonogram read = new ReadFonogram();
		read.ChooseOptions();
		//ReadAlbum read = new ReadAlbum();
		//read.ChooseOptions();
		//CreateMenu createMenu = new CreateMenu();
		//createMenu.ChooseOption();
		/*AddIzvodjac addIz = new AddIzvodjac();
		addIz.ChooseOptions();
		*/
		/*CreateFonogram create = new CreateFonogram();
		create.PopulateEntries();

		FonogramDTO fonogram = create.Fonogram;


		Console.WriteLine($"\nNaziv: {fonogram.Naziv}\nKataloskiBroj: {fonogram.KataloskiBroj}\nGodina Izdanja: {fonogram.GodinaIzdanja}");
		Console.ReadLine();
	*/	
		

		/*CreateIzvodjac create = new CreateIzvodjac();
		create.PopulateEntries();

		IzvodjacDTO izvodjac = create.Izvodjac;
		Console.WriteLine($"\nNaziv: {izvodjac.Naziv}\n");
		Console.ReadLine();
		*/

		/*CreateAlbum create = new CreateAlbum();
		create.PopulateEntries();

		AlbumDTO album = create.Album;


		Console.WriteLine($"\nNaziv: {album.Naziv}\nKataloskiBroj: {album.KataloskiBroj}\nGodina Izdanja: {album.GodinaIzdanja}");
		Console.ReadLine();
		*/
		
		

		//!!!!!!!!!!!!!!!!!!!! Napraviti Albumi u IzvodjacViewModelu!! i sve sto treba propratno za to!!!
		
		//CreateAlbum();
		//CreateIzvodjac("Neki John");
		//CreateFonogram("Bas super pesma");
		//ReadAlbum();
		//ReadIzvodjac();
		//ReadFonogram();

		//UpdateFonogram("Four");
		//UpdateIzvodjac("Charles Darwin");
		//UpdateAlbum();

		//SearchAlbum();
		//SearchFonogram();
		//SearchIzvodjac();

		//GetAlbumi();
		//GetFonogrami();
		//GetIzvodjaci();

		//DeleteAlbum();
		//DeleteFonogram();
		//DeleteIzvodjac();
        }

	static public void DeleteIzvodjac()
	{
		InjectSRU inject = new InjectSRU();
		IDTO izvodjac = new IzvodjacDTO();

		izvodjac.Id = 8;
		
		IIzvodjacViewModel izvodjacView = inject.DeleteData(izvodjac) as IzvodjacViewModel;
		string result = $"izbrisan je sledeci izvodjac: \n{izvodjacView.Id}\n{izvodjacView.Naziv}\n{izvodjacView.Fonogrami}";
		Console.WriteLine(result);
	}

	static public void DeleteFonogram()
	{
		InjectSRU inject = new InjectSRU();
		IFonogramDTO fonogram = new FonogramDTO();
		
		fonogram.Id = 13;
	
		IFonogramViewModel fonogramView = inject.DeleteData(fonogram) as FonogramViewModel;
		string result = $"izbrisan je sledeci fonogram: \n{fonogramView.Id}\n{fonogramView.Naziv}\n{fonogramView.KataloskiBroj}\n{fonogramView.GodinaIzdanja}\n{fonogramView.Izvodjaci}\n";

		Console.WriteLine(result);


	}
	static public void DeleteAlbum()
	{
		InjectSRU inject = new InjectSRU();
		List<IViewModel> listFromInject = inject.GetAll(2);

		IAlbumDTO album = new AlbumDTO();
		album.Id = 2;

		IAlbumViewModel albumView = inject.DeleteData(album) as AlbumViewModel;

		string result = $"Izbrisan je sledeci album: \n{albumView.Id}\n{albumView.Naziv}\n{albumView.Izvodjaci}\n{albumView.GodinaIzdanja}\n{albumView.KataloskiBroj}\n{albumView.Fonogrami}";
		Console.WriteLine(result);
	}

	static public void GetIzvodjaci()
	{
		InjectSRU inject = new InjectSRU();
		List<IViewModel> listFromInject = inject.GetAll(2);

		string result = "";

		List<IIzvodjacViewModel> izvodjacView = new List<IIzvodjacViewModel>();
		foreach (var element in listFromInject)
		{
			izvodjacView.Add(element as IIzvodjacViewModel);

		}

		foreach (var element in izvodjacView)
		{
			result += $"\n{element.Id}\n{element.Naziv}\n{element.Fonogrami}";
		}

		Console.WriteLine(result);
	}
	static public void GetFonogrami()
	{
		InjectSRU inject = new InjectSRU();
		List<IViewModel> listFromInject = inject.GetAll(1);

		string result = "";

		List<IFonogramViewModel> fonogramView = new List<IFonogramViewModel>();
		foreach (var element in listFromInject)
		{

			fonogramView.Add(element as IFonogramViewModel);
		}

		foreach (var element in fonogramView)
		{

			result += $"\n{element.Id}\n{element.Naziv}\n{element.KataloskiBroj}\n{element.GodinaIzdanja}\n{element.Izvodjaci}\n";
		}

		Console.WriteLine(result);
		
	}
	static public void GetAlbumi()
	{
		InjectSRU inject = new InjectSRU();
		List<IViewModel> listFromInject = inject.GetAll(0);

		string result = "";

		List<IAlbumViewModel> albumView = new List<IAlbumViewModel>();
		foreach (var element in listFromInject)
		{
			albumView.Add(element as IAlbumViewModel);
		}

		foreach (var element in albumView)
		{

			result += $"\n{element.Id}\n{element.Naziv}\n{element.Izvodjaci}\n{element.GodinaIzdanja}\n{element.KataloskiBroj}\n{element.Fonogrami}";

		}

		Console.WriteLine(result);
	}

	static public void SearchIzvodjac()
	{
		InjectSRU inject = new InjectSRU();
		IDTO izvodjac = new IzvodjacDTO();

		izvodjac.Naziv = "izvodjac";

		string result = "";

		List<IViewModel> listFromInject = inject.SearchData(izvodjac);
		List<IIzvodjacViewModel> izvodjacView = new List<IIzvodjacViewModel>();
		foreach (var element in listFromInject)
		{
			izvodjacView.Add(element as IIzvodjacViewModel);

		}

		foreach (var element in izvodjacView)
		{
			result += $"\n{element.Id}\n{element.Naziv}\n{element.Fonogrami}";
		}

		Console.WriteLine(result);


	}
	static public void SearchFonogram()
	{
		InjectSRU inject = new InjectSRU();
		IFonogramDTO fonogram = new FonogramDTO();

		fonogram.KataloskiBroj = "088";

		string result = "";

		List<IViewModel> listFromInject = inject.SearchData(fonogram);
		List<IFonogramViewModel> fonogramView = new List<IFonogramViewModel>();
		foreach (var element in listFromInject)
		{

			fonogramView.Add(element as IFonogramViewModel);
		}

		foreach (var element in fonogramView)
		{

			result += $"\n{element.Id}\n{element.Naziv}\n{element.KataloskiBroj}\n{element.GodinaIzdanja}\n{element.Izvodjaci}\n";
		}

		Console.WriteLine(result);

		
	}
	static public void SearchAlbum()
	{
		InjectSRU inject = new InjectSRU();

		IAlbumDTO album = new AlbumDTO();

		album.GodinaIzdanja = 2019;

		string result = "";

		List<IViewModel> listFromInject = inject.SearchData(album);
		List<IAlbumViewModel> albumView = new List<IAlbumViewModel>();
		foreach (var element in listFromInject)
		{
			albumView.Add(element as IAlbumViewModel);
		}

		foreach (var element in albumView)
		{

			result += $"\n{element.Id}\n{element.Naziv}\n{element.Izvodjaci}\n{element.GodinaIzdanja}\n{element.KataloskiBroj}\n{element.Fonogrami}";

		}

		Console.WriteLine(result);

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
		fonogram.AlbumId = 2;
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
		album.Id = 2;

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
		fonogram.Id = 3;

		IFonogramViewModel fonogramView = inject.ReadData(fonogram) as FonogramViewModel;

		string result = $"\n{fonogramView.Id}\n{fonogramView.Naziv}\n{fonogramView.KataloskiBroj}\n{fonogramView.GodinaIzdanja}\n{fonogramView.Izvodjaci}\n{fonogramView.AlbumNaziv}";

		Console.WriteLine(result);
	}

    }
}
