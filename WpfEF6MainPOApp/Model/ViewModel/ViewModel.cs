﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfEF6MainPOApp.Model.ViewModel
{
    /// <summary>
    /// Klasa abstrakcyjna udostępniająca możliwość powiadamiania składowych o zmianach w viewmodelu
    /// </summary>
    public abstract class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Właściwość event informująca elementy zbidowane z własnosią o zmienie parametru bindowania.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        
        /// <summary>
        /// Powiadamia elementy zbidowane z własnosią o zmienie parametru bindowania.
        /// </summary>
        /// <param name="propertyName">
        /// Własność, która ulagła zmianie
        /// </param>
        protected void NotifyPropertyChange([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                System.Diagnostics.Debug.WriteLine("@MY@@@@    NotifyPropertyChange @My@");
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
