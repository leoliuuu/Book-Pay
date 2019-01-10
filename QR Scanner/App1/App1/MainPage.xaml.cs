using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        ZXingScannerPage scanPage;

        public MainPage()
        {
            InitializeComponent();
            buttonScanContinuously.Clicked += ButtonScanContinuously_Clicked;
            
        }

        private async void ButtonScanContinuously_Clicked(object sender, EventArgs e)
        {
            scanPage = new ZXingScannerPage(new ZXing.Mobile.MobileBarcodeScanningOptions { DelayBetweenContinuousScans = 3000 });
            scanPage.OnScanResult += (result) =>
                Device.BeginInvokeOnMainThread(() =>
                    DisplayAlert("Scanned Barcode", result.Text, "OK"));

            await Navigation.PushModalAsync(scanPage);
        
        }
    }
}
