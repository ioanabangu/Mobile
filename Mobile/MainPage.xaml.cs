using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
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
        } // creating an animated gradient background that goes forward and turns back from where it ends doing this infinity times
        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogIn());
        } //Navigateing to the LogIn page
        private async void SignUp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        } //Navigating to the SignUp page
    }
}
// the code reference https://github.com/devcrux/Xamarin.Forms-Brushes-Animated-Gradient-Background

