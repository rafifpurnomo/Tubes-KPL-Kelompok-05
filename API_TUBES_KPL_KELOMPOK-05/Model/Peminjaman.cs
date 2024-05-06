namespace API_TUBES_KPL_KELOMPOK_05.Model
{
    public class Peminjaman : DisplayBooks
    {
        public Peminjaman(string kodeBuku, string judul, string sinopsis, string penulis, int tahunTerbit, bool statusPeminjaman)
            : base(kodeBuku, judul, sinopsis, penulis, tahunTerbit, statusPeminjaman)
        {

        }
    }
}
