using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIBRARY_TUBES_KPL_KELOMPOK_05;

namespace MAIN_TUBES_KPL_KELOMPOK_5
{
    internal class Perpustakaan
    {
        private List<Buku> buku;
        private List<Peminjaman> DaftarPeminjaman;
        ConfigManager configManager = new ConfigManager();
        public Perpustakaan()
        {
            buku = new List<Buku>();
            DaftarPeminjaman = new List<Peminjaman>();

        }

        // Implementasikan Method 
        public void PeminjamanBuku(List<Buku> rakBuku, Akun pengguna)
        {
            Console.Write("Masukkan judul buku yang ingin dipinjam : ");
            string judulYangDipinjam = Console.ReadLine();


            int idx_buku = -1;

            for (int i = 0; i < rakBuku.Count; i++)
            {
                if (rakBuku[i].Judul == judulYangDipinjam)
                {
                    idx_buku = i;
                    break;


                }
            }

            if (idx_buku == -1)
            {
                Console.WriteLine("Buku tidak ada");
            }

            else if (rakBuku[idx_buku].stok == 0) // cek ketersediaan buku
            {
                Console.WriteLine("Stok BUku Kosong");
            }

            else
            {
                DateTime sekarang = DateTime.Now;
                string peminjaman = StringLibrary.KonversiDateKeString(sekarang);
                string pengembalian = StringLibrary.KonversiDateKeString(sekarang.AddDays(configManager.BatasWaktuPeminjaman));

                Peminjaman peminjamanBaru = new Peminjaman(Peminjaman.ID_count.ToString(), rakBuku[idx_buku].Judul, pengguna, peminjaman, pengembalian, false);
                DaftarPeminjaman.Add(peminjamanBaru);
                Console.WriteLine("Berhasil melakukan peminjaman");
                rakBuku[idx_buku].stok--;
            }
        }
        public void tesst()
        {
            Console.WriteLine("sdsds");
        }
    }
}