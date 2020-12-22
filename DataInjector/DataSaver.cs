using System;
using Domain.DTOs;
using Domain.Facade;
using Domain.Interfaces;
using Persistence;

namespace DataInjector
{
    public class DataSaver
    {
	    private IViewModel _resultViewModel;
	    private IRepository _repository;
	    private AppSaveService _localSaveService;

	    public DataSaver(IDTO inputDTO)
	    {
		    _repository = new RepSaver();
		    _localSaveService = new AppSaveService(_repository);
		    evaluateInput(inputDTO);
	    }

	    private void evaluateInput(IDTO dtoToSave)
	    {
		    if (dtoToSave is IAlbumDTO)
		    {
			    _resultViewModel = _localSaveService.SaveAlbum(dtoToSave);
		    }

		    else if (dtoToSave is IFonogramDTO)
		    {
			    _resultViewModel = _localSaveService.SaveFonogram(dtoToSave);
		    }

		    else
		    {
			    _resultViewModel = _localSaveService.SaveIzvodjac(dtoToSave);
		    }
	    }

	    public IViewModel GetViewModel()
	    {
		    return _resultViewModel;
	    }
    }
}
