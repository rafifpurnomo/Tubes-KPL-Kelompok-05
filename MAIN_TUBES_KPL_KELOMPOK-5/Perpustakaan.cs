using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAIN_TUBES_KPL_KELOMPOK_5
{
    internal class Perpustakaan
    {
        private List<Buku> buku;
        private List<Peminjaman> DaftarPeminjaman;
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


        }



    }
}
