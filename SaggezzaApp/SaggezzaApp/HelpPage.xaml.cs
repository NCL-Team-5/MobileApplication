using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaggezzaApp {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpPage : ContentPage {
        public UserData user;

        public HelpPage(UserData _user) {
            InitializeComponent();
            user = _user;
        }

        private async void Home(object sender, EventArgs e) {
            var page = new HomePage(user);
            await Navigation.PushAsync(page);
        }
    }
}