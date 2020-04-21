using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//TODO: Comments

namespace SaggezzaApp {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage {

        public UserData user;

        public ProfilePage(UserData _user)
        {
            InitializeComponent();
            user = _user;
            UpdateData();
        }

        public void UpdateData()
        {
            NameLabel.Text = user.Name;
            IDLabel.Text = user.Id;
        }

        private async void Settings(object sender, EventArgs e) {
            var page = new SettingsPage();
            await Navigation.PushAsync(page);
        }

        private async void PastReceipts(object sender, EventArgs e) {
            var page = new PastReceipts(user);
            await Navigation.PushAsync(page);
        }

        private async void CreateForm(object sender, EventArgs e) {
            var page = new CreateForm(user);
            await Navigation.PushAsync(page);
        }

        private async void Attatchments(object sender, EventArgs e) {
            var page = new Attatchments(user);
            await Navigation.PushAsync(page);
        }

        private async void Home(object sender, EventArgs e) {
            var page = new HomePage(user);
            await Navigation.PushAsync(page);
        }

    }
}