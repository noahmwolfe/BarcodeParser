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
                    try
                    {
                        BarcodeParser.ParseResults(result.Text, ref dlFields);
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Invalid Barcode", "The barcode could not be read! Please be sure you are scanning a valid Drivers License", "Ok");
                    }
                    
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

                    string month;
                    string day;
                    string year;
                    if ((dlFields.birthday[0] == '1' && dlFields.birthday[1] == '9') || (dlFields.birthday[0] == '2' && dlFields.birthday[1] == '0'))
                    {
                        year = dlFields.birthday.Substring(0, 4);
                        month = dlFields.birthday.Substring(4, 2);
                        day = dlFields.birthday.Substring(6, 2);
                    }
                    else
                    {
                        month = dlFields.birthday.Substring(0, 2);
                        day = dlFields.birthday.Substring(2, 2);
                        year = dlFields.birthday.Substring(4, 4);
                    }

                    birthday.Text = month + "/" + day + "/" + year;
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
