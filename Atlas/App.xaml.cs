﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Atlas.Model_Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Atlas
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
      
        protected override void OnStartup(StartupEventArgs e)
        {

            DatabaseFacade facade = new DatabaseFacade(new DataContext());
            facade.EnsureCreated();

        }

  
    }
}
