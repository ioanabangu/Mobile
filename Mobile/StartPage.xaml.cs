using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Mobile.Tables;

namespace Mobile
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }
        private async void LogOut(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetNotesAsync();
        }//creats the list of the notes
        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
        //clickinf on a note sends you to the NoteEntryPage
    }
}
//References: https://docs.microsoft.com/en-us/xamarin/get-started/quickstarts/multi-page?pivots=windows
