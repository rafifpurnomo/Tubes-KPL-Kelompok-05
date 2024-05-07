using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MAIN_TUBES_KPL_KELOMPOK_5
{
    public class ConfigManager
    {
        public const string filePath = @"covidconfig.json";

        public int BatasWaktuPeminjaman { get; set; }

        public double TarifDendaPerHari { get; set; }

        public int JumlahMaksimumPerpanjangan { get; set; }

        public int BatasWaktuMaksimumPerpanjangan { get; set; }

        public string MataUang { get; set; }
        public ConfigManager()
        {
            try
            {
                MuatKonfigurasi();
            }

            catch (Exception)
            {
                SetDefaultKonfigurasi();
            }
        }

        public void MuatKonfigurasi()
        {
            string jsonData = File.ReadAllText(filePath);
            var config = JsonSerializer.Deserialize<ConfigManager>(jsonData);
            if (config != null)
            {
                BatasWaktuPeminjaman = config.BatasWaktuPeminjaman;
                TarifDendaPerHari = config.TarifDendaPerHari;
                JumlahMaksimumPerpanjangan = config.JumlahMaksimumPerpanjangan;
                BatasWaktuMaksimumPerpanjangan = config.BatasWaktuMaksimumPerpanjangan;
            }
        }

        public void SetDefaultKonfigurasi()
        {
            // Default Configuration
            BatasWaktuPeminjaman = 7;
            TarifDendaPerHari = 1000;
            JumlahMaksimumPerpanjangan = 2;
            BatasWaktuMaksimumPerpanjangan = 14;
            MataUang = "Rp";
        }
    }
}
