using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeScanner
{
    static class BarcodeParser
    {
        public static void ParseResults(string results, ref DriversLicenseFields.Fields dlFields)
        {
            string[] separator = { "DAQ" };
            string [] outputs = results.Split('\n');
            if (outputs[1].Contains("DAQ"))
            {
                string[] license_num = outputs[1].Split(separator, StringSplitOptions.None);
                dlFields.license = license_num[1];
            }

            foreach (string output in outputs)
            {
                if(!String.IsNullOrWhiteSpace(output) && output.Length >= 3)
                {
                    string abbr = output.Substring(0, 3);
                    
                    switch (abbr)
                    {
                        case "DAA":
                            dlFields.full_name = output.Substring(3, output.Length - 3);
                            break;

                        case "DCS":
                            dlFields.last_name = output.Substring(3, output.Length - 3);
                                break;

                        case "DAC":
                            dlFields.first_name = output.Substring(3, output.Length - 3);
                            break;

                        case "DAD":
                            dlFields.middle_name = output.Substring(3, output.Length - 3);
                            break;

                        case "DCT":
                            dlFields.first_middle = output.Substring(3, output.Length - 3);
                            break;

                        case "DBB":
                            dlFields.birthday = output.Substring(3, output.Length - 3);
                            break;

                        case "DAG":
                            dlFields.address = output.Substring(3, output.Length - 3);
                            break;

                        case "DAI":
                            dlFields.city = output.Substring(3, output.Length - 3);
                            break;

                        case "DAJ":
                            dlFields.state = output.Substring(3, output.Length - 3);
                            break;

                        case "DAK":
                            dlFields.zip = output.Substring(3, output.Length - 3);
                            break;

                        case "DAQ":
                            dlFields.license = output.Substring(3, output.Length - 3);
                            break;

                        default:
                            break;
                    }
                    
                }
                    
            }

        }

    }
}
