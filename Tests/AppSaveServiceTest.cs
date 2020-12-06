using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.ViewModels;
using Domain.Facade;
using Domain.Interfaces;
using Domain.DTOs;
using Persistence;


namespace Tests
{
	[TestClass]
	public class AppSaveServiceTest
	{
		private IRepository _repository = new RepSaver();
		private AppSaveService _service;

		[TestInitialize]
		public void TestInitialize()
		{
			_service = new AppSaveService(_repository);

		}

		[TestMethod]
		public void IsSaveAlbum_correct()
		{
			//arrange
			IAlbumDTO album = new AlbumDTO();
			album.Naziv = "Prvi Album";
			album.KataloskiBroj = "12345";
			album.GodinaIzdanja = 1987;

			var mojAlbum = (AlbumViewModel)_service.SaveAlbum(album);

			//act
			//assert
			Assert.IsInstanceOfType(_service.SaveAlbum(album),typeof(IViewModel));
			Assert.IsInstanceOfType(_service.SaveAlbum(album),typeof(AlbumViewModel));
			Assert.IsNotNull(mojAlbum.Izvodjaci);
			Assert.IsNotNull(mojAlbum.Fonogrami);
		}

		[TestMethod]
		public void IsSaveFonogram_correct()
		{
			//arrange
			IFonogramDTO fonogram = new FonogramDTO();
			fonogram.Naziv = "Pesma";
			fonogram.KataloskiBroj = "1234";
			fonogram.GodinaIzdanja = 1987;
			fonogram.AlbumId = 1;

			var mojFonogram = (FonogramViewModel)_service.SaveFonogram(fonogram);

			//assert
			Assert.IsInstanceOfType(_service.SaveFonogram(fonogram), typeof(IViewModel));
			Assert.IsInstanceOfType(_service.SaveFonogram(fonogram), typeof(FonogramViewModel));
			Assert.IsNotNull(mojFonogram.Izvodjaci);
		}

		[TestMethod]
		public void IsSaveIzvodjac_correct()
		{
			//arrange
			IDTO izvodjac = new IzvodjacDTO();
			izvodjac.Naziv = "Aca";

			var mojIzvodjac = (IzvodjacViewModel)_service.SaveIzvodjac(izvodjac);

			//assert
			Assert.IsInstanceOfType(_service.SaveIzvodjac(izvodjac), typeof(IViewModel));
			Assert.IsInstanceOfType(_service.SaveIzvodjac(izvodjac), typeof(IzvodjacViewModel));
			Assert.IsNotNull(mojIzvodjac.Fonogrami);
			Assert.IsNotNull(mojIzvodjac.Albumi);

		}
	}
}
