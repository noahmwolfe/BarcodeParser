using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeScanner
{
    static class BarcodeParser
    {
        public static void ParseResults(string results, ref DriversLicenseFields.Fields dlFields)
        {
            string[] separator = { "DAQ", "DAA", "DCS", "DAC", "DAD", "DCT", "DBB", "DAG", "DAI", "DAJ", "DAK" };
            char[] separator_chars = { '\n', '\r' };
            string [] outputs = results.Split(separator_chars);

            string[] split_result;

            foreach (string output in outputs)
            {
                if(!String.IsNullOrWhiteSpace(output) && output.Length >= 3)
                {
                    
                    if (output.Contains("DAA"))
                    {
                        split_result = output.Split(separator, StringSplitOptions.None);
                        dlFields.full_name = split_result[1];
                    }
                    else if (output.Contains("DCS"))
                    {
                        split_result = output.Split(separator, StringSplitOptions.None);
                        dlFields.last_name = split_result[1];
                    }
                    else if (output.Contains("DAC"))
                    {
                        split_result = output.Split(separator, StringSplitOptions.None);
                        dlFields.first_name = split_result[1];
                    }
                    else if (output.Contains("DAD"))
                    {
                        split_result = output.Split(separator, StringSplitOptions.None);
                        dlFields.middle_name = split_result[1];
                    }
                    else if (output.Contains("DCT"))
                    {
                        split_result = output.Split(separator, StringSplitOptions.None);
                        dlFields.first_middle = split_result[1];
                    }
                    else if (output.Contains("DBB"))
                    {
                        split_result = output.Split(separator, StringSplitOptions.None);
                        dlFields.birthday = split_result[1];
                    }
                    else if (output.Contains("DAG"))
                    {
                        split_result = output.Split(separator, StringSplitOptions.None);
                        dlFields.address = split_result[1];
                    }
                    else if (output.Contains("DAI"))
                    {
                        split_result = output.Split(separator, StringSplitOptions.None);
                        dlFields.city = split_result[1];
                    }
                    else if (output.Contains("DAJ"))
                    {
                        split_result = output.Split(separator, StringSplitOptions.None);
                        dlFields.state = split_result[1];
                    }
                    else if (output.Contains("DAK"))
                    {
                        split_result = output.Split(separator, StringSplitOptions.None);
                        dlFields.zip = split_result[1];
                    }
                    else if (output.Contains("DAQ"))
                    {
                        split_result = output.Split(separator, StringSplitOptions.None);
                        dlFields.license = split_result[1];
                    }
                    else if (output.Contains("DBC"))
                    {
                        split_result = output.Split(separator, StringSplitOptions.None);
                        dlFields.gender = split_result[1];
                    }
                    else if (output.Contains("DAU"))
                    {
                        split_result = output.Split(separator, StringSplitOptions.None);
                        dlFields.height = split_result[1];
                    }
                    else if (output.Contains("DAW"))
                    {
                        split_result = output.Split(separator, StringSplitOptions.None);
                        dlFields.weight = split_result[1];
                    }

                }
                    
            }

        }

    }
}
