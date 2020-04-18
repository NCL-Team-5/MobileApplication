using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaggezzaApp {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage {
        public ProfilePage() {
            InitializeComponent();
        }

        private async void Settings(object sender, EventArgs e) {
            var page = new SettingsPage();
            await Navigation.PushAsync(page);
        }

        private async void PastReceipts(object sender, EventArgs e) {
            var page = new PastReceipts();
            await Navigation.PushAsync(page);
        }

        private async void CreateForm(object sender, EventArgs e) {
            var page = new CreateForm();
            await Navigation.PushAsync(page);
        }

        private async void Attatchments(object sender, EventArgs e) {
            var page = new Attatchments();
            await Navigation.PushAsync(page);
        }

        private async void Home(object sender, EventArgs e) {
            var page = new HomePage();
            await Navigation.PushAsync(page);
        }

    }
}