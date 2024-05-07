using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAIN_TUBES_KPL_KELOMPOK_5
{
    internal class Peminjaman
    {
        public static int ID_count = 1;

        public string ID_Peminjaman { get; set; }
        public Akun Peminjam { get; set; }
        public string JudulBuku { get; set; }
        public string TanggalPinjam { get; set; }
        public string TanggalPengembalian { get; set; }
        public bool statusPengembalian { get; set; }

        public Peminjaman(string ID_Peminjaman, string JudulBuku, Akun Peminjam, string TanggalPinjam, string TanggalPengembalian, bool statusPengembalian)
        {
            this.ID_Peminjaman = ID_Peminjaman;
            this.JudulBuku = JudulBuku;
            this.Peminjam = Peminjam;
            this.TanggalPinjam = TanggalPinjam;
            this.TanggalPengembalian = TanggalPengembalian;
            this.statusPengembalian = statusPengembalian;
        }
    }
}
