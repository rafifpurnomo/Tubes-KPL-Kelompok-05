using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIBRARY_TUBES_KPL_KELOMPOK_05;

namespace MAIN_TUBES_KPL_KELOMPOK_5
{
    public class FineManager
    {
        public double TotalDenda { get; set; }
        public bool StatusPelunasan { get; set; }
        public string namaAkun { get; set; }

        public ConfigManager ConfigManager { get; set; }

        public FineManager(string DeadlinePengembalian, string TanggalPenggembalian)
        {
            TotalDenda = Denda.PerhitunganDenda(DeadlinePengembalian, TanggalPenggembalian, ConfigManager.TarifDendaPerHari);
            StatusPelunasan = false;
        }

        public void PembayaranDenda()
        {
            Console.WriteLine("Anda memiliki denda sebesar : "+ ConfigManager.MataUang +". " + TotalDenda);
            Console.Write("Ketik 'SETUJU' untuk mengkonfrmasi pembayaran : ");
            string input = Console.ReadLine();
            input = input.ToLower();

            if ( input == "setuju")
            {
                Console.WriteLine("Pembayaran Berhasil");
                StatusPelunasan=true;
            }
            else
            {
                Console.WriteLine("Pembayaran Gagal");
            }
        }


    }
}
