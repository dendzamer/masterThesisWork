using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;
using Domain.DTOs;
using Domain.Interfaces;
using Domain.Models;

namespace Tests
{
	[TestClass]
	public class RepSaverTest
	{
		RepSaver _saver = new RepSaver();

		[TestMethod]
		public void IsIzvodjacMethod_correct()
		{
			//Arrange
			IDTO idto = new IzvodjacDTO();
			idto.Naziv = "Aca";

			//Act
			_saver.Izvodjac(idto);

			//Assert
			Assert.IsInstanceOfType(_saver.GetViewable(),typeof(IViewable));
			Assert.IsInstanceOfType(_saver.GetViewable(),typeof(IIzvodjacViewable));
			Assert.IsInstanceOfType(_saver.GetViewable(),typeof(Izvodjac));

		}

		[TestMethod]
		public void IsFonogramMethod_correct()
		{
			//Arrange
			IFonogramDTO idto = new FonogramDTO();
			idto.Naziv = "Pesma 1";
			idto.KataloskiBroj = "12345";
			idto.GodinaIzdanja = 1987;
			idto.AlbumId = 12;

			//Act
			_saver.Fonogram(idto);

			//Assert
			Assert.IsInstanceOfType(_saver.GetViewable(),typeof(IViewable));
			Assert.IsInstanceOfType(_saver.GetViewable(),typeof(IFonogramViewable));
			Assert.IsInstanceOfType(_saver.GetViewable(),typeof(Fonogram));
		}

		[TestMethod]
		public void IsAlbumMethod_correct()
		{
			//arrange
			IAlbumDTO idto = new AlbumDTO();
			idto.Naziv = "Prvi album";
			idto.KataloskiBroj = "1234";
			idto.GodinaIzdanja = 1987;

			//act
			_saver.Album(idto);

			//assert
			Assert.IsInstanceOfType(_saver.GetViewable(),typeof(IViewable));
			Assert.IsInstanceOfType(_saver.GetViewable(),typeof(IAlbumViewable));
			Assert.IsInstanceOfType(_saver.GetViewable(),typeof(Album));
		}
	}
}
