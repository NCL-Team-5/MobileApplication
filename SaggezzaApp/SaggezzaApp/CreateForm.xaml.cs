using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Storage;
using Plugin.CloudFirestore;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaggezzaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateForm : ContentPage
    {

        public DateTime DateValue { get; set; }

        public String ReceiptPic { get; set; }

        public string DescriptionValue { get; set; }

        public string CategoryValue { get; set; }

        public string ClientNameValue { get; set; }

        public string ProjectNameValue { get; set; }

        public string PaymentMethodValue { get; set; }

        public bool BillableToClientValue { get; set; }

        //        public string UserID { get; set; }

        public decimal AmountValue { get; set; }

        public string CurrencyValue { get; set; }


        public CreateForm()
        {
            InitializeComponent();
        }

        async void Submit_Clicked(System.Object sender, System.EventArgs e)
        {
            if (ClientName.SelectedIndex == 2)
            {
                ClientNameValue = ExternalClientName.Text;
            }
            else
            {
                ClientNameValue = ClientName.Items[ClientName.SelectedIndex];
            }

            DateValue = Date.Date;
            DescriptionValue = Description.Text;
            CategoryValue = Category.Items[Category.SelectedIndex];
            ProjectNameValue = ProjectName.Text;
            BillableToClientValue = BillableToClient.IsChecked;
            PaymentMethodValue = PaymentMethod.Items[PaymentMethod.SelectedIndex];
            CurrencyValue = Currency.Items[Currency.SelectedIndex];
            AmountValue = Convert.ToDecimal(Amount.Text);
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
            };
            CrossCloudFirestore.Current
                                .Instance
                                .GetCollection("reports")
                                .AddDocument(report, (error) =>
                                {
                                    if (error != null)
                                    {
                                        System.Diagnostics.Debug.WriteLine(error);
                                    }
                                });
        }

        async void UploadPicture_Clicked(System.Object sender, System.EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Unavailable", "Your device has not enabled the required permissions", "OK");
                return;
            }
            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Full
            };
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);
            if (selectedImageFile == null)
            {
                await DisplayAlert("Error", "Please try again", "OK");
                return;
            }
            uploadPicture.Text = "Picture Uploaded";
            ReceiptPic = await StoreImage(selectedImageFile.GetStream());
        }

        public async Task<string> StoreImage(Stream imageStream)
        {
            var uploadImage = await new FirebaseStorage("saggezza-b37e6.appspot.com")
            .Child("receipts")
            .Child("image.jpg")
            .PutAsync(imageStream);
            string imgurl = uploadImage;
            return imgurl;
        }

        void ClientName_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (ClientName.SelectedIndex == 2)
            {
                ExternalClientName.IsVisible = true;
                ClientNameLabel.IsVisible = true;
            }
            else
            {
                ExternalClientName.IsVisible = false;
                ClientNameLabel.IsVisible = false;
            }
        }

    }
}