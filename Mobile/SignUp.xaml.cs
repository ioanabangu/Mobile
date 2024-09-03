using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Tables;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using SQLite;

namespace Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
            Task.Run(AnimateBackground);
        }
        private async void AnimateBackground()
        {
            Action<double> forward = input => bdGradient.AnchorY = input;
            Action<double> backward = input => bdGradient.AnchorY = input;

            while (true)
            {
                bdGradient.Animate(name: "forward", callback: forward, start: 0, end: 1, length: 5000, easing: Easing.SinIn);
                await Task.Delay(5000);
                bdGradient.Animate(name: "backward", callback: backward, start: 1, end: 0, length: 5000, easing: Easing.SinIn);
                await Task.Delay(5000);
            }
        }//creating the animation in the background
        private async void Start (object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<Person>();
            var item = new Person()
            {
                UserName = EntryUserName.Text,
                Email = EntryEmail.Text,
                Password = EntryPassword.Text,
            };
            //sending the information to the database
            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Congratulation", "User Registration Sicessfull", "Yes", "Cancel");

                if (result)
                    await Navigation.PushAsync(new LogIn());
            });
        } //A message will pop up on the screen whenever someone will create a new account and send them to the LogIn page to connect 
        private async void LogIn(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogIn());
        }
        //Navigating to the LogIn Page
    }
}
//reference: https://www.youtube.com/watch?reload=9&v=8JQSd9sF3XI&feature=youtu.be&fbclid=IwAR0s53-ecNpHYbgZxlIB9y7c9iueFAw9B98GkZrLmUox6gXSBKPGEyR6QR4