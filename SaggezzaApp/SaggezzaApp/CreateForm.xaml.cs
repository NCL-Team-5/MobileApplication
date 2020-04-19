using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaggezzaApp {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateForm : ContentPage {
        public CreateForm() {
            InitializeComponent();
        }

        private async void Home(object sender, EventArgs e) {
            var page = new HomePage();
            await Navigation.PushAsync(page);
        }

        private async void PastReceipts(object sender, EventArgs e) {
            var page = new PastReceipts();
            await Navigation.PushAsync(page);
        }

        

        private async void Attatchments(object sender, EventArgs e) {
            var page = new Attatchments();
            await Navigation.PushAsync(page);
        }

        private async void Profile(object sender, EventArgs e) {
            var page = new ProfilePage();
            await Navigation.PushAsync(page);
        }
    }
}