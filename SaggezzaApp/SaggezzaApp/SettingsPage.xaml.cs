using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaggezzaApp {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage {
        public SettingsPage() {
            InitializeComponent();
        }

        void HelpClicked(object sender, EventArgs e) {

        }

        void LogoutClicked(object sender, EventArgs e) {

        }
    }
}