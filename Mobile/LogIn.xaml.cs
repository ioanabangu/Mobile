using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Mobile.Tables;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        public LogIn()
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
        }
        //creating the animation for the background
        private async void Start(object sender, EventArgs e)
        {

            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<Person>().Where(u => u.UserName.Equals(EnterEmail.Text) && u.Password.Equals(EnterPassword.Text)).FirstOrDefault();
            //checking in the database if the name and the password are in there 
            if (myquery != null)
            {
                App.Current.MainPage = new NavigationPage(new StartPage());
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Error", "Failed user name and password", "Yes", "cancel");
                    if (result)
                        await Navigation.PushAsync(new LogIn());
                    else
                    {
                        await Navigation.PushAsync(new LogIn());
                    }
                });
                //if they got the email and the password correct they will be send to that start page othewise they will get a message that the autentification failed 
            }
        }
        private async void SignUp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }
        private async void Forgot(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Forgot());
        }
    }
}
// References: https://www.youtube.com/watch?v=TuN8Y9sUCmw