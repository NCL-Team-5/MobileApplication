using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Storage;
using Plugin.CloudFirestore;
using Plugin.LocalNotifications;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaggezzaApp {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateForm : ContentPage {

        public UserData user;

        public DateTime DateValue;

        public String ReceiptPic;

        public string DescriptionValue;

        public string CategoryValue;

        public string ClientNameValue;

        public string ProjectNameValue;

        public string PaymentMethodValue;

        public bool BillableToClientValue;

        public string UserID;

        public decimal AmountValue;

        public string CurrencyValue;

        public bool SaggezzaName;

        public bool SoftCopy;

        // Random string function for image name
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public CreateForm(UserData _user) {
            InitializeComponent();
            user = _user;
        }

        // Executed when submit button is pressed
        async void Submit_Clicked(System.Object sender, System.EventArgs e)
        {
            // If client is not Saggezza then client name = user inputted name
            if (SaggezzaName == false)
            {
                ClientNameValue = ExternalClientName.Text;
            } else
            {
                ClientNameValue = ClientName.Items[ClientName.SelectedIndex];
            }

            if (SoftCopy == false)
            {
                if (ReceiptPicker.SelectedIndex == 1)
                {
                    ReceiptPic = "Hard Copy";
                } else
                {
                    ReceiptPic = "None";
                }
            }

            // Get all values from form
            DateValue = Date.Date;
            DescriptionValue = Description.Text;
            CategoryValue = Category.Items[Category.SelectedIndex];
            ProjectNameValue = ProjectName.Text;
            BillableToClientValue = BillableToClient.IsChecked;
            PaymentMethodValue = PaymentMethod.Items[PaymentMethod.SelectedIndex];
            CurrencyValue = Currency.Items[Currency.SelectedIndex];
            AmountValue = Convert.ToDecimal(Amount.Text);

            // Create new expense report object from form value
            var report = new ExpenseReport
            {
                ClaimDate = DateValue,
                ReceiptPic = ReceiptPic,
                Description = DescriptionValue,
                ClientName = ClientNameValue,
                Category = CategoryValue,
                PaymentMethod = PaymentMethodValue,
                BillableToClient = BillableToClientValue,
                Amount = AmountValue,
                Currency = CurrencyValue,
                Status = "Pending",
                UserID = user.Id,
            };

            // Add new document to Firestore
            CrossCloudFirestore.Current
                                .Instance
                                .GetCollection("reports")
                                .AddDocument(report, async (error) =>
                                {
                                    if (error != null)
                                    {
                                        // Display alert if document not successfully added to Firestore
                                        System.Diagnostics.Debug.WriteLine(error);
                                        await DisplayAlert("Error", "Expense report not submitted, please try again", "OK");
                                    } else
                                    {
                                        // Local Notification if document successfully added to Firestore, go to Home Page
                                        // CrossLocalNotifications.Current.Show("Expense Report Submitted Successfully", "You will be notified when its status changed");
                                        await DisplayAlert("Success", "Expense report submitted successfully", "OK");
                                        var page = new HomePage(user);
                                        await Navigation.PushAsync(page);
                                    };
                                });
        }

        // Let user select Picture from camera roll
        async void UploadPicture_Clicked(System.Object sender, System.EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if(!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Unavailable", "Your device has not enabled the required permissions", "OK");
                return;
            }
            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Full
            };
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);
            if(selectedImageFile == null)
            {
                await DisplayAlert("Error", "Please try again", "OK");
                return;
            }
            uploadPicture.Text = "Picture Uploaded";
            ReceiptPic = await StoreImage(selectedImageFile.GetStream());
            }

            // Upload picture to Firebase storage, get image URL
            public async Task<string> StoreImage(Stream imageStream)
            {
                    var uploadImage = await new FirebaseStorage("saggezza-b37e6.appspot.com")
                    .Child("receipts")
                    .Child(RandomString(6) + ".jpg")
                    .PutAsync(imageStream);
                string imgurl = uploadImage;
                return imgurl;
            }

        // Show/Hide client name entry field depending on whether user selects Saggezza or Client
        void ClientName_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if(ClientName.SelectedIndex == 2)
            {
                SaggezzaName = false;
                ExternalClientName.IsVisible = true;
                ClientNameLabel.IsVisible = true;
            } else
            {
                ExternalClientName.IsVisible = false;
                ClientNameLabel.IsVisible = false;
                SaggezzaName = true;
            }
        }

        // If user selects soft copy reciept then show button to upload photo
        void ReceiptPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (ReceiptPicker.SelectedIndex == 0)
            {
                SoftCopy = true;
                uploadPicture.IsVisible = true;
            } else
            {
                SoftCopy = false;
                uploadPicture.IsVisible = false;
            };
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