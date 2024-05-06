namespace API_TUBES_KPL_KELOMPOK_05.Model
{
    public class Buku
    {
        public string kodeBuku { get; set; }
        public string Judul { get; set; }
        public string Sinopsis { get; set; }
        public string Penulis { get; set; }
        public int TahunTerbit { get; set; }
        public int stok { get; set; }
        public int jumlahBuku { get; set; }

        public Buku(string kodeBuku, string judul, string sinopsis, string penulis, int tahunTerbit ,int jumlahBuku)
        {
            this.kodeBuku = kodeBuku;
            this.Judul = judul;
            this.Sinopsis = sinopsis;
            this.Penulis = penulis;
            this.TahunTerbit = tahunTerbit;
            this.jumlahBuku = jumlahBuku;
        }

        public void displayBook()
        {
            Console.WriteLine("Kode buku: " + kodeBuku);
            Console.WriteLine("Judul Buku: " + Judul);
            Console.WriteLine("Judul Sinopsis: " + Sinopsis);
            Console.WriteLine("Judul Penulis: " + Penulis);
            Console.WriteLine("Tahun Terbit Buku: " + TahunTerbit);
            //Console.WriteLine("Stok Buku: " + (jumlahBuku - Peminjam.Count));
        }
    }
}
