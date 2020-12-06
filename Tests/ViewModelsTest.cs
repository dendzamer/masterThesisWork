using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.ViewModels;
using Domain.Interfaces;
using Domain.Models;

namespace Test
{
	[TestClass]
	public class ViewModelsTest
	{
		private Fonogram _fonogram;
		private Album _album;
		private Izvodjac _izvodjac;

		[TestInitialize]
		public void TestInitialize()
		{
			_fonogram = new Fonogram();
			_fonogram.Id = 123;
			_fonogram.Naziv = "Nova pesma";
			_fonogram.GodinaIzdanja = 1930;
			_fonogram.KataloskiBroj = "55555";

			_album = new Album();
			_album.Id = 321;
			_album.Naziv = "Novi Album";
			_album.GodinaIzdanja = 1930;
			_album.KataloskiBroj = "555555";

			_izvodjac = new Izvodjac();
			_izvodjac.Id = 123;
			_izvodjac.Naziv = "Aca";
		}

		[TestMethod]
		public void IsAlbumViewModel_correct()
		{
			//Arrange
			IAlbumViewModel albumView = new AlbumViewModel();

			//Act
			albumView.SetData(_album);

			//Assert
			Assert.IsInstanceOfType(albumView,typeof(IViewModel));
			Assert.IsInstanceOfType(albumView,typeof(IAlbumViewModel));
			Assert.IsInstanceOfType(albumView,typeof(AlbumViewModel));
			Assert.IsInstanceOfType(albumView.Id,typeof(int));
			Assert.IsInstanceOfType(albumView.Naziv,typeof(string));
			Assert.IsInstanceOfType(albumView.Izvodjaci,typeof(string));
			Assert.IsInstanceOfType(albumView.GodinaIzdanja,typeof(int));
			Assert.IsInstanceOfType(albumView.KataloskiBroj,typeof(string));
			Assert.IsInstanceOfType(albumView.Fonogrami,typeof(string));
			Assert.AreEqual(albumView.Id, _album.Id);
			Assert.AreEqual(albumView.Naziv, _album.Naziv);
			Assert.AreEqual(albumView.GodinaIzdanja, _album.GodinaIzdanja);
			Assert.AreEqual(albumView.KataloskiBroj, _album.KataloskiBroj);
			Assert.AreEqual(albumView.Izvodjaci, "Jos nema unosa");
			Assert.AreEqual(albumView.Fonogrami, "Jos nema unosa");
		}

		[TestMethod]
		public void IsFonogramViewModel_correct()
		{
			//Arrange
			IFonogramViewModel fonogramView = new FonogramViewModel();

			//Act
			fonogramView.SetData(_fonogram);

			//Assert
			Assert.IsInstanceOfType(fonogramView,typeof(IViewModel));
			Assert.IsInstanceOfType(fonogramView,typeof(IFonogramViewModel));
			Assert.IsInstanceOfType(fonogramView,typeof(FonogramViewModel));
			Assert.IsInstanceOfType(fonogramView.Id,typeof(int));
			Assert.IsInstanceOfType(fonogramView.Naziv,typeof(string));
			Assert.IsInstanceOfType(fonogramView.Izvodjaci,typeof(string));
			Assert.IsInstanceOfType(fonogramView.GodinaIzdanja,typeof(int));
			Assert.IsInstanceOfType(fonogramView.KataloskiBroj,typeof(string));
			Assert.AreEqual(fonogramView.Id,_fonogram.Id);
			Assert.AreEqual(fonogramView.Naziv,_fonogram.Naziv);
			Assert.AreEqual(fonogramView.GodinaIzdanja,_fonogram.GodinaIzdanja);
			Assert.AreEqual(fonogramView.KataloskiBroj,_fonogram.KataloskiBroj);
			Assert.AreEqual(fonogramView.Izvodjaci,"Jos nema unosa");
		}

		[TestMethod]
		public void IsIzvodjacViewModel_correct()
		{
			//Arrange
			IIzvodjacViewModel izvodjacView = new IzvodjacViewModel();

			//Act
			izvodjacView.SetData(_izvodjac);

			//Assert
			Assert.IsInstanceOfType(izvodjacView,typeof(IViewModel));
			Assert.IsInstanceOfType(izvodjacView,typeof(IIzvodjacViewModel));
			Assert.IsInstanceOfType(izvodjacView,typeof(IzvodjacViewModel));
			Assert.IsInstanceOfType(izvodjacView.Id,typeof(int));
			Assert.IsInstanceOfType(izvodjacView.Naziv,typeof(string));
			Assert.IsInstanceOfType(izvodjacView.Albumi,typeof(string));
			Assert.IsInstanceOfType(izvodjacView.Fonogrami,typeof(string));
			Assert.AreEqual(izvodjacView.Id,_izvodjac.Id);
			Assert.AreEqual(izvodjacView.Naziv,_izvodjac.Naziv);
			Assert.AreEqual(izvodjacView.Albumi,"Jos nema unosa");
			Assert.AreEqual(izvodjacView.Fonogrami,"Jos nema unosa");
		}

	}
}

