using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace BarcodeScanner
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Scan_Clicked(object sender, EventArgs e)
        {
            
            MobileBarcodeScanningOptions options = new MobileBarcodeScanningOptions();
            options.PossibleFormats = new List<ZXing.BarcodeFormat>() {
                ZXing.BarcodeFormat.PDF_417
            };

            var scanPage = new ZXingScannerPage(options);
            Navigation.PushAsync(scanPage);
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();

                    // Outputting Drivers License Info to App
                    DriversLicenseFields.Fields dlFields = new DriversLicenseFields.Fields();
                    BarcodeParser.ParseResults(result.Text, ref dlFields);
                    last_name.Text = dlFields.last_name;
                    if (dlFields.first_middle != null)
                    {
                        first_middle.Text = dlFields.first_middle;
                        first_middle.IsVisible = true;
                        first_name.IsVisible = false;
                        middle_name.IsVisible = false;
                        full_name.IsVisible = false;
                        last_name.IsVisible = true;
                    }
                    else if (dlFields.first_name != null && dlFields.last_name != null)
                    {
                        first_name.Text = dlFields.first_name;
                        middle_name.Text = dlFields.middle_name;
                        first_name.IsVisible = true;
                        middle_name.IsVisible = true;
                        first_middle.IsVisible = false;
                        full_name.IsVisible = false;
                        last_name.IsVisible = true;
                    }
                    else
                    {
                        full_name.Text = dlFields.full_name;
                        full_name.IsVisible = true;
                        first_name.IsVisible = false;
                        middle_name.IsVisible = false;
                        first_middle.IsVisible = false;
                        last_name.IsVisible = false;
                    }

                    address.Text = dlFields.address;
                    city.Text = dlFields.city;
                    state.Text = dlFields.state;
                    zip.Text = dlFields.zip;
                    license.Text = dlFields.license;
                });
                
            };

            
        }
    }
}
