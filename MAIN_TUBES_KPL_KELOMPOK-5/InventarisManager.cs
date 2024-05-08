using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAIN_TUBES_KPL_KELOMPOK_5
{
    public class InventarisManager
    {
        public enum MenuOption
        {
            TambahBuku,
            HapusBuku,
            TampilBuku,
            Keluar
        }

        private Dictionary<MenuOption, Action> menuOptions;

        private List<Buku> daftarBuku = new List<Buku>(); // Menyimpan daftar buku

        public InventarisManager()
        {
            menuOptions = new Dictionary<MenuOption, Action>
        {
            { MenuOption.TambahBuku, TambahBuku },
            { MenuOption.HapusBuku, HapusBuku },
            { MenuOption.TampilBuku, TampilkanDaftarBuku },
            { MenuOption.Keluar, Keluar }
        };
        }

        public void ShowMenu()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("||  MENU INVENTARIS PERPUSTAKAAN  ||");
            Console.WriteLine("====================================");
            Console.WriteLine("||  1. Tambah Buku                ||");
            Console.WriteLine("||  2. Hapus Buku                 ||");
            Console.WriteLine("||  3. Tampilkan Daftar Buku      ||");
            Console.WriteLine("||  4. Keluar                     ||");
            Console.WriteLine("||  Pilih opsi (1-4):             ||");
            Console.WriteLine("====================================");
            Console.Write("Masukkan Pilihan Anda: ");

        }

        public void ProcessOption(MenuOption option)
        {
            switch (option)
            {
                case MenuOption.TambahBuku:
                    TambahBuku();
                    break;
                case MenuOption.HapusBuku:
                    HapusBuku();
                    break;
                case MenuOption.TampilBuku:
                    TampilkanDaftarBuku();
                    break;
                case MenuOption.Keluar:
                    Keluar();
                    break;
                default:
                    Console.WriteLine("Opsi tidak valid.");
                    break;
            }
        }


        public void TambahBuku()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("|         OPSI TAMBAH BUKU         |");
            Console.WriteLine("------------------------------------");
            // Input informasi buku dari pengguna
            Console.Write("|   Kode Buku         : ");
            string kodeBuku = Console.ReadLine();


            Console.Write("|   Judul Buku        : ");
            string judulBuku = Console.ReadLine();


            Console.Write("|   Sinopsis Buku     : ");
            string sinopsisBuku = Console.ReadLine();


            Console.Write("|   Penulis Buku      : ");
            string penulisBuku = Console.ReadLine();


            Console.Write("|   Tahun Terbit Buku : ");
            int tahunTerbit;
            while (!int.TryParse(Console.ReadLine(), out tahunTerbit))
            {
                Console.Write("|   Masukkan tahun terbit dalam format angka: ");
            }


            Console.Write("|   Jumlah Buku       : ");
            int jumlahBuku;
            while (!int.TryParse(Console.ReadLine(), out jumlahBuku))
            {
                Console.Write("|   Masukkan jumlah buku dalam format angka: ");
            }
            Console.WriteLine("------------------------------------");


            // Membuat objek buku baru
            Buku bukuBaru = new Buku(kodeBuku, judulBuku, sinopsisBuku, penulisBuku, tahunTerbit, jumlahBuku);

            // Menambahkan buku ke dalam daftar
            daftarBuku.Add(bukuBaru);

            Console.WriteLine("Buku berhasil ditambahkan.");
            Console.WriteLine("");
        }
        public void HapusBuku()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("|          OPSI HAPUS BUKU         |");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("|   Pilih opsi penghapusan:        |");
            Console.WriteLine("|   1. Berdasarkan Kode Buku       |");
            Console.WriteLine("|   2. Berdasarkan Judul           |");
            Console.WriteLine("|   3. Berdasarkan Penulis         |");
            Console.WriteLine("|   4. Berdasarkan Tahun Terbit    |");
            Console.WriteLine("------------------------------------");

            Console.Write("Masukkan Pilihan Anda: ");
            if (int.TryParse(Console.ReadLine(), out int option))
            {
                switch (option)
                {
                    case 1:
                        HapusBukuBerdasarkanKodeBuku();
                        break;
                    case 2:
                        HapusBukuBerdasarkanJudul();
                        break;
                    case 3:
                        HapusBukuBerdasarkanPenulis();
                        break;
                    case 4:
                        HapusBukuBerdasarkanTahunTerbit();
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Masukan tidak valid.");
            }

            Console.WriteLine("");

        }

        public void HapusBukuBerdasarkanKodeBuku()
        {
            Console.WriteLine("");
            Console.WriteLine("************************************");
            Console.Write("*   Masukkan judul buku: ");
            string kode = Console.ReadLine();
            Console.WriteLine("************************************");

            Buku bukuYangAkanDihapus = daftarBuku.Find(buku => buku.kodeBuku == kode);

            if (bukuYangAkanDihapus != null)
            {
                daftarBuku.Remove(bukuYangAkanDihapus);
                Console.WriteLine("Buku berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("Buku tidak ditemukan.");
            }

        }

        public void HapusBukuBerdasarkanJudul()
        {
            Console.WriteLine("");
            Console.WriteLine("************************************");
            Console.Write("*   Masukkan judul buku: ");
            string judulBuku = Console.ReadLine();
            Console.WriteLine("************************************");

            Buku bukuYangAkanDihapus = daftarBuku.Find(buku => buku.Judul == judulBuku);

            if (bukuYangAkanDihapus != null)
            {
                daftarBuku.Remove(bukuYangAkanDihapus);
                Console.WriteLine("Buku berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("Buku tidak ditemukan.");
            }

        }

        public void HapusBukuBerdasarkanPenulis()
        {
            Console.WriteLine("");
            Console.WriteLine("************************************");
            Console.Write("*   Masukkan nama penulis: ");
            string penulisBuku = Console.ReadLine();
            Console.WriteLine("************************************");

            List<Buku> bukuYangAkanDihapus = daftarBuku.FindAll(buku => buku.Penulis == penulisBuku);

            if (bukuYangAkanDihapus.Count > 0)
            {
                foreach (var buku in bukuYangAkanDihapus)
                {
                    daftarBuku.Remove(buku);
                }
                Console.WriteLine("Buku berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("Buku tidak ditemukan.");
            }

        }

        public void HapusBukuBerdasarkanTahunTerbit()
        {
            Console.WriteLine("");
            Console.WriteLine("************************************");
            Console.Write("*   Masukkan tahun terbit: ");
            if (int.TryParse(Console.ReadLine(), out int tahunTerbit))
            {
                Console.WriteLine("************************************");

                List<Buku> bukuYangAkanDihapus = daftarBuku.FindAll(buku => buku.TahunTerbit == tahunTerbit);

                if (bukuYangAkanDihapus.Count > 0)
                {
                    foreach (var buku in bukuYangAkanDihapus)
                    {
                        daftarBuku.Remove(buku);
                    }
                    Console.WriteLine("Buku berhasil dihapus.");
                }
                else
                {
                    Console.WriteLine("Buku tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("Masukan tidak valid.");
            }
        }


        public void TampilkanDaftarBuku()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("|         OPSI DAFTAR BUKU         |");
            Console.WriteLine("------------------------------------");
            foreach (var buku in daftarBuku)
            {
                Console.WriteLine($"|   Kode Buku    : {buku.kodeBuku}");
                Console.WriteLine($"|   Judul        : {buku.Judul}");
                Console.WriteLine($"|   Penulis      : {buku.Penulis}");
                Console.WriteLine($"|   Sinopsis     : {buku.Sinopsis}");
                Console.WriteLine($"|   Tahun Terbit : {buku.TahunTerbit}");
                Console.WriteLine($"|   Jumlah       : {buku.jumlahBuku}");
                Console.WriteLine("------------------------------------");
            }

            Console.WriteLine("");
        }

        public void Keluar()
        {
            Console.WriteLine("Keluar dari program.");
            Environment.Exit(0);
        }
    }

}
