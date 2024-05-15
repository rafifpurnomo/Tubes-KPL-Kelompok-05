using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY_TUBES_KPL_KELOMPOK_05
{
    public class Denda
    {
        public static double PerhitunganDenda(string tglTelat, string tglPengembalian, double dendaPerHari)
        {

            DateTime tanggalPengembalian = DateTime.ParseExact(tglPengembalian, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime tanggalTelat = DateTime.ParseExact(tglTelat, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);

            TimeSpan selisihTanggal = tanggalPengembalian - tanggalTelat;
            int jumlahHariKeterlambatan = (int)selisihTanggal.TotalDays;

            if (jumlahHariKeterlambatan < 0)
            {
                jumlahHariKeterlambatan = 0;
            }

            return jumlahHariKeterlambatan * dendaPerHari;
        }
    }
}
