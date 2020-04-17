﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//TODO: Populate Notifications + Pending Receipts Table

namespace SaggezzaApp {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage {

        public UserData user;

        public HomePage(UserData _user) {
            InitializeComponent();
            user = _user;
            UpdateData();
        }

        public void UpdateData()
        {
            WelcomeText.Text = "Welcome " + user.GivenName;
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

        private async void Profile(object sender, EventArgs e) {
            var page = new ProfilePage(user);
            await Navigation.PushAsync(page);
        }

    }
}