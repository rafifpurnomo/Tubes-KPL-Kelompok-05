using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY_TUBES_KPL_KELOMPOK_05
{
    public class Denda
    {
        public static double PerhitunganDenda(string tglPengembalian, string tglTelat, double dendaPerHari)
        {

            DateTime tanggalPengembalian = DateTime.ParseExact(tglPengembalian, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime tanggalTelat = DateTime.ParseExact(tglTelat, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);

            TimeSpan selisihTanggal = tanggalTelat.Subtract(tanggalPengembalian);
            int jumlahHariKeterlambatan = (int)selisihTanggal.TotalDays;

            return jumlahHariKeterlambatan * dendaPerHari;
        }
    }
}
