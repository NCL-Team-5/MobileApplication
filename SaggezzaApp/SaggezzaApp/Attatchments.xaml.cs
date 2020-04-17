using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaggezzaApp {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Attatchments : ContentPage {
        public UserData user;

        public Attatchments(UserData _user) {
            InitializeComponent();
            user = _user;
        }
    }
}