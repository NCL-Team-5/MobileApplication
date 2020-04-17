using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.FirebaseAuth;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using Xamarin.Forms.Internals;

//TODO: Comments, login errors

namespace SaggezzaApp
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public UserData user;

        public MainPage()
        {
            InitializeComponent();
            _googleClientManager = CrossGoogleClient.Current;
        }

        private readonly IGoogleClientManager _googleClientManager;
        public event PropertyChangedEventHandler PropertyChanged;

        public void SignInBtn(object sender, EventArgs e)
        {
            UserLoginAsync();
        }

        public async void UserLoginAsync()
        {

            CrossGoogleClient.Current.OnLogin += OnLoginCompleted;
                try
                {
                    await CrossGoogleClient.Current.LoginAsync();
                }
                catch (GoogleClientSignInNetworkErrorException e)
                {
                    await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
                }
                catch (GoogleClientSignInCanceledErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientSignInInvalidAccountErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientSignInInternalErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientNotInitializedErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientBaseException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }

            //GoogleResponse<GoogleUser> googleResponse = await CrossGoogleClient.Current.LoginAsync();

            //var user = new UserData
            //{
            //    Id = googleResponse.Data.Id,
            //    Name = googleResponse.Data.Name,
            //    GivenName = googleResponse.Data.GivenName,
            //    FamilyName = googleResponse.Data.FamilyName,
            //    Email = googleResponse.Data.Email,
            //};
            //await DisplayAlert(user.Id, "b", "c");
            //UserDataViewModel abc = new UserDataViewModel(user);
            //await DisplayAlert(abc.Id, "b", "c");
            //var page = new HomePage();
            //await Navigation.PushAsync(page);
            //await DisplayAlert("a", "b", "c");
        }

        private async void OnLoginCompleted(object sender, GoogleClientResultEventArgs<GoogleUser> loginEventArgs)
        {

            GoogleUser googleUser = loginEventArgs.Data;
            var user = new UserData
            {
                Id = googleUser.Id,
                Name = googleUser.Name,
                GivenName = googleUser.GivenName,
                FamilyName = googleUser.FamilyName,
                Email = googleUser.Email,
            };
            var page = new HomePage(user);
            await Navigation.PushAsync(page);
            CrossGoogleClient.Current.OnLogin -= OnLoginCompleted;

        }

    }
}
