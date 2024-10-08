﻿using System;
using System.IO;
using Xamarin.Forms;
using Mobile.Data;

namespace Mobile
{
    public partial class App : Application
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Mobile.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] { "Brush_Experimental" });
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}