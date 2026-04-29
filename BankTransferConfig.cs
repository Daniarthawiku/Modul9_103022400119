using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace modul9_10302240119
{
    public class BankTransferConfig
    {
        public string lang { get; set; }
        public string transfer { get; set; }
        public string methods { get; set; }
        public string confirmation { get; set; }
        private const string filePath = "bank_transfer_config.json";
        public BankTransferConfig() { }

        public static BankTransferConfig Load()
        {
            if (!File.Exists(filePath))
            {
                try
                {
                    string jsonString = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<BankTransferConfig>(jsonString);
                }
                catch
                {
                    return createDefault();
                }
            }
            else
            {
                return createDefault();
            }
        }

        public static BankTransferConfig createDefault()
        {
            //BankTransferConfig defaultConfig = new BankTransferConfig
            //{
            //    lang = "en",
            //    defaultConfig.transfer = {
            //        threshold = 25000000,
            //        low_fee = 6500,
            //        high_fee = 15000
            //    },
            //    defaultConfig.methods = {
            //        "Online Transfer",
            //        "Mobile Banking",
            //        "ATM"
            //    },
            //    methods = "1. Online Transfer\n2. Mobile Banking\n3. ATM",
            //    confirmation = "Your transfer is being processed."
            //};
            BankTransferConfig defaultConfig = new BankTransferConfig
            {
                lang = "en",
                transfer = "Threshold: 25000000, Low Fee: 6500, High Fee: 15000",
                methods = "1. RTO (REAL-TIME)\n2. SKN (SKNBI)\n3. RTGS (RTGS)\n4. BI FAST (BI FAST)",
                confirmation = "Yes"
            };
            string jsonString = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
            return defaultConfig;
        }

        public void Save()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(this, options);
            File.WriteAllText(filePath, jsonString);

        }
    }
}