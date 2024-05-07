using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY_TUBES_KPL_KELOMPOK_05
{
    public class StringLibrary
    {
        public static DateTime KonversiStringKeDate(string tanggal)
        {
            DateTime hasilKonversi;
            if (DateTime.TryParseExact(tanggal, "yyyy MM dd", null, System.Globalization.DateTimeStyles.None, out hasilKonversi))
            {
                return hasilKonversi;
            }
            else
            {
                // Tanggal tidak dapat dikonversi, Anda dapat menangani kasus ini sesuai kebutuhan
                throw new ArgumentException("Format tanggal tidak valid");
            }
        }

        public static string KonversiDateKeString(DateTime tanggal)
        {
            return tanggal.ToString("yyyy MM dd");
        }


    }
}