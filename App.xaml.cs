using Microsoft.EntityFrameworkCore.Infrastructure;
using MusicStreaming.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MusicStreaming
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Event handler that is called when the application is starting up.
        /// </summary>
        /// <param name="e">The <see cref="StartupEventArgs"/> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            DatabaseFacade facade = new DatabaseFacade(new MusicStreamingDataContext());
            facade.EnsureCreated();
        }

    }
}
