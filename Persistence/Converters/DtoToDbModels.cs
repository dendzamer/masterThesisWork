using System;
using Persistence.Models;
using Domain.Interfaces;

namespace Persistence.Converters
{
	public class DtoToDbModels
	{
		public static Album ConvertToAlbum(IAlbumDTO input)
		{
			Album album = new Album();
			album.Naziv = input.Naziv;
			album.GodinaIzdanja = input.GodinaIzdanja;
			album.KataloskiBroj = input.KataloskiBroj;

			return album;
		}
	}
}
