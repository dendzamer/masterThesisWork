using System;
using System.Collections.Generic;
using DataInjector;
using Domain.DTOs;
using Domain.Interfaces;
using Domain.ViewModels;
using Presentation.Create;
using Presentation.Read;
using Presentation.Update;
using Presentation.Delete;
using Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Presentation
{
    class Program
    {
	    static void Main(string[] args)
	    {
		    MainMenu menu = new MainMenu();
		    menu.ChooseOption();
	    }
    }
}
