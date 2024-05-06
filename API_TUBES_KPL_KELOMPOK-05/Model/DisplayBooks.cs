namespace API_TUBES_KPL_KELOMPOK_05.Model
{
    public class DisplayBooks
    {
        public string kodeBuku { get; set; }
        public string Judul { get; set; }
        public string Sinopsis { get; set; }
        public string Penulis { get; set; }
        public int TahunTerbit { get; set; }
        public bool statusPeminjaman { get; set; }

        public DisplayBooks(string kodeBuku, string judul, string sinopsis, string penulis, int tahunTerbit, bool statusPeminjaman)
        {
            this.kodeBuku = kodeBuku;
            this.Judul = judul;
            this.Sinopsis = sinopsis;
            this.Penulis = penulis;
            this.TahunTerbit = tahunTerbit;
            this.statusPeminjaman = statusPeminjaman;
            this.statusPeminjaman = statusPeminjaman;
        }
    }
}
