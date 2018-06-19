using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeScanner
{
    public class DriversLicenseFields
    {
        public struct Fields
        {
            public string full_name;
            public string last_name;
            public string first_name;
            public string middle_name;
            public string first_middle;
            public string address;
            public string city;
            public string state;
            public string zip;
            public string license;
            public string birthday;
        };
    }
}
