﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using ArmaLauncher.ViewModel;

namespace ArmaLauncher
{
    /// <summary>
    ///     Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : Page, INotifyPropertyChanged
    {
        public MainViewModel ViewModel { get; set; }

        public Notes()
        {
            InitializeComponent();
            InitializeObjects();
            DataContext = this;
            var pageType = this.GetType().FullName;
            ViewModel = new MainViewModel(pageType);
            Globals.Current.ViewModel = ViewModel;
            Globals.Current.PageNotes = this;
        }

        private void InitializeObjects()
        {
            //reset grid
            this.MainDataGrid.AutoGenerateColumns = true;
            this.MainDataGrid.AutoGenerateColumns = false;
            this.MainDataGrid.Items.Refresh();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var eventToFire = PropertyChanged;
            if (eventToFire == null)
                return;

            eventToFire(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Notes_OnLoaded(object sender, RoutedEventArgs e)
        {
            InitializeObjects();
        }
    }
}