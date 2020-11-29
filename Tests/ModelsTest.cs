using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Models;
using System.Linq;

namespace Tests
{
	[TestClass]
	public class ModelsTest
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
			_fonogram.KataloskiBroj = 55555;

			_album = new Album();
			_album.Id = 321;
			_album.Naziv = "Novi album";
			_album.GodinaIzdanja = 1930;
			_album.KataloskiBroj = 55555;
			
			_izvodjac = new Izvodjac();
			_izvodjac.Id = 123;
			_izvodjac.Naziv = "Aca";
		}

		[TestMethod]
		public void IsFonogram_correct()
		{
			//Arrange
			Fonogram fonogram = _fonogram;

			//Act
			fonogram.Izvodjaci.Add(_izvodjac);

			//Assert
			Assert.IsInstanceOfType(fonogram.Id, typeof(int));
			Assert.IsInstanceOfType(fonogram.Naziv, typeof(string));
			Assert.IsInstanceOfType(fonogram.GodinaIzdanja, typeof(int));
			Assert.IsInstanceOfType(fonogram.KataloskiBroj, typeof(int));
			Assert.IsNotNull(fonogram.Id);
			Assert.IsNotNull(fonogram.Naziv);
			Assert.IsNotNull(fonogram.Izvodjaci);
			Assert.IsNotNull(fonogram.GodinaIzdanja);
			Assert.IsNotNull(fonogram.KataloskiBroj);
			Assert.IsTrue(fonogram.Izvodjaci.Any());
			foreach(var izvodjac in fonogram.Izvodjaci)
			{
				Assert.IsNotNull(izvodjac.Albumi);
				Assert.IsNotNull(izvodjac.Fonogrami);
			}
		}

		[TestMethod]
		public void IsAlbum_correct()
		{
			//Arrange
			Album album = _album;

			//Act
			album.Fonogrami.Add(_fonogram);
			foreach(Fonogram fonogram in album.Fonogrami)
			{
				foreach (Izvodjac izvodjac in fonogram.Izvodjaci)
				{
					album.Izvodjaci.Add(izvodjac);
				}
			}

			//Assert
			Assert.IsInstanceOfType(album.Id, typeof(int));
			Assert.IsInstanceOfType(album.Naziv, typeof(string));
			Assert.IsInstanceOfType(album.GodinaIzdanja, typeof(int));
			Assert.IsInstanceOfType(album.KataloskiBroj, typeof(int));
			Assert.IsNotNull(album.Fonogrami);
			Assert.IsNotNull(album.Izvodjaci);
			foreach(Izvodjac izvodjac in album.Izvodjaci)
			{
				Assert.IsNotNull(izvodjac.Albumi);
				Assert.IsNotNull(izvodjac.Fonogrami);
			}
			foreach (Fonogram fonogram in album.Fonogrami)
			{
				Assert.IsNotNull(fonogram.Izvodjaci);
			}
		}

		[TestMethod]
		public void IsIzvodjac_correct()
		{
			//Arrange
			Izvodjac izvodjac = _izvodjac; 

			//Act
			izvodjac.Fonogrami.Add(_fonogram);
			izvodjac.Albumi.Add(_album);

			//Assert
			Assert.IsInstanceOfType(izvodjac.Id,typeof(int));
			Assert.IsInstanceOfType(izvodjac.Naziv,typeof(string));
			Assert.IsNotNull(izvodjac.Albumi);
			Assert.IsNotNull(izvodjac.Fonogrami);
			foreach (Fonogram fonogram in izvodjac.Fonogrami)
			{
				Assert.IsNotNull(fonogram.Izvodjaci);
			}

			foreach (Album album in izvodjac.Albumi)
			{
				Assert.IsNotNull(album.Fonogrami);
				Assert.IsNotNull(album.Izvodjaci);
			}
		}




	}
}
