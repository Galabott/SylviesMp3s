﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SylviesMp3s
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// Author : $username$
    /// Creation Date : $time$
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow win = new MainWindow();

            win.Show();
        }
    }
}
