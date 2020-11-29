using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Converters;
using Domain.Models;
using Domain.Interfaces;
using Domain.ViewModels;

namespace Tests
{
	[TestClass]
	public class ConvertToViewModelTest
	{
		private Album _album;
		private Fonogram _fonogram;
		private Izvodjac _izvodjac;

		[TestInitialize]
		public void TestInitialize()
		{
			_fonogram = new Fonogram();
			_fonogram.Id = 123;
			_fonogram.Naziv = "Nova pesma";
			_fonogram.GodinaIzdanja = 1930;
			_fonogram.KataloskiBroj = 5555;

			_album = new Album();
			_album.Id = 321;
			_album.Naziv = "Novi album";
			_album.GodinaIzdanja = 1930;
			_album.KataloskiBroj = 5555;

			_izvodjac = new Izvodjac();
			_izvodjac.Id = 123;
			_izvodjac.Naziv = "Aca";
		}

		[TestMethod]
		public void IsGetAlbumViewModel_correct()
		{
			//Arrange
			//Act
			IViewModel viewmodel = ConvertToViewModel.GetAlbumViewModel(_album);
			IAlbumViewModel IviewModel= viewmodel as IAlbumViewModel;

			//Assert
			Assert.IsInstanceOfType(viewmodel,typeof(IViewModel));
			Assert.IsInstanceOfType(viewmodel,typeof(IAlbumViewModel));
			Assert.IsInstanceOfType(viewmodel,typeof(AlbumViewModel));
			Assert.AreEqual(IviewModel.Id,_album.Id);
			Assert.AreEqual(IviewModel.Naziv,_album.Naziv);
			Assert.AreEqual(IviewModel.Izvodjaci,"Jos nema unosa");
			Assert.AreEqual(IviewModel.Fonogrami,"Jos nema unosa");
			Assert.AreEqual(IviewModel.GodinaIzdanja, _album.GodinaIzdanja);
			Assert.AreEqual(IviewModel.KataloskiBroj, _album.KataloskiBroj);
		}

		[TestMethod]
		public void IsGetFonogramViewModel_correct()
		{
			//Arrange
			//Act
			IViewModel viewmodel = ConvertToViewModel.GetFonogramViewModel(_fonogram);
			IFonogramViewModel Iviewmodel = viewmodel as IFonogramViewModel;

			//Assert
			Assert.IsInstanceOfType(viewmodel,typeof(IViewModel));
			Assert.IsInstanceOfType(viewmodel,typeof(IFonogramViewModel));
			Assert.IsInstanceOfType(viewmodel,typeof(FonogramViewModel));
			Assert.AreEqual(Iviewmodel.Id,_fonogram.Id);
			Assert.AreEqual(Iviewmodel.Naziv,_fonogram.Naziv);
			Assert.AreEqual(Iviewmodel.KataloskiBroj,_fonogram.KataloskiBroj);
			Assert.AreEqual(Iviewmodel.GodinaIzdanja,_fonogram.GodinaIzdanja);
			Assert.AreEqual(Iviewmodel.Izvodjaci,"Jos nema unosa");
		}

		[TestMethod]
		public void IsGetIzvodjacViewModel_correct()
		{
			//Arrange
			//Act
			IViewModel viewmodel = ConvertToViewModel.GetIzvodjacViewModel(_izvodjac);
			IIzvodjacViewModel Iviewmodel = viewmodel as IIzvodjacViewModel;

			//Assert
			Assert.IsInstanceOfType(viewmodel,typeof(IViewModel));
			Assert.IsInstanceOfType(viewmodel,typeof(IIzvodjacViewModel));
			Assert.IsInstanceOfType(viewmodel,typeof(IzvodjacViewModel));
			Assert.AreEqual(Iviewmodel.Id,_izvodjac.Id);
			Assert.AreEqual(Iviewmodel.Naziv,_izvodjac.Naziv);
			Assert.AreEqual(Iviewmodel.Albumi,"Jos nema unosa");
			Assert.AreEqual(Iviewmodel.Fonogrami,"Jos nema unosa");
		}
	}
}
