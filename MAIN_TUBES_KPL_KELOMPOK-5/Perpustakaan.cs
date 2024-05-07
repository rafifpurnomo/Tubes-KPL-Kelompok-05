
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIBRARY_TUBES_KPL_KELOMPOK_05;

namespace MAIN_TUBES_KPL_KELOMPOK_5
{
    internal class Perpustakaan
    {
        private List<Buku> buku = new List<Buku>
        {
            new Buku("BK001", "Dasar Pemrograman JS", "Javascript", "Rafif" ,2024, 10),
            new Buku("BK002", "Dasar Pemrograman GO", "Golang", "Belva" ,2010, 10),
            new Buku("BK003", "Dasar Pemrograman C#", "C#", "Zidan" ,2022, 10),
            new Buku("BK004", "Dasar Pemrograman WEB", "WEB", "Rizki" ,2009, 10),
            new Buku("BK005", "Dasar Pemrograman C++", "C++", "Daffa" ,2021, 10),
            new Buku("BK006", "Dasar Pemrograman Python", "Python", "Ghiyats" ,2018, 10),
            new Buku("BK007", "Dasar Networking", "Networking", "Dana" ,2018, 10),
        };

        private Buku[] bukuArray;

        private List<Peminjaman> DaftarPeminjaman;
        
        ConfigManager configManager = new ConfigManager();
        
        public Perpustakaan()
        {
            DaftarPeminjaman = new List<Peminjaman>();
        }
        public void toArray()
        {
            bukuArray = buku.ToArray();
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
        public void cariByJudul(string judul)
        {

            for (int i = 0; i < bukuArray.Length; i++)
            {
                if (judul == bukuArray[i].Judul)
                {
                    Console.WriteLine("Kode buku: " + bukuArray[i].kodeBuku);
                    Console.WriteLine("Judul Buku" + bukuArray[i].Judul);
                    Console.WriteLine("Sinopsis: " + bukuArray[i].Sinopsis);
                    Console.WriteLine("Penulis: " + bukuArray[i].Penulis);
                    Console.WriteLine("Tahun Terbit: " + bukuArray[i].TahunTerbit);
                }
            }
        }

        public int returnIndex(string judul)
        {
            int index = -1;

            for (int i = 0; i < bukuArray.Length; i++)
            {
                if (judul == bukuArray[i].Judul)
                {
                    return index = i;
                    break;
                }
            }

            return index;
        }

        public void PerpanjangPeminjaman(List<Peminjaman> daftarPeminjam)
        {
            Console.Write("Masukan id peminjaman buku: ");
            string ID_peminjaman = Console.ReadLine();

            foreach (Peminjaman peminjaman in daftarPeminjam)
            {
                if (peminjaman.ID_Peminjaman == ID_peminjaman)
                {
                    DateTime pengembalianBaru = StringLibrary.KonversiStringKeDate(peminjaman.TanggalPengembalian).AddDays(configManager.BatasWaktuMaksimumPerpanjangan);
                    peminjaman.TanggalPengembalian = StringLibrary.KonversiDateKeString(pengembalianBaru);
                    Console.WriteLine("Waktu peminjaman buku Anda sudah dipepanjang selama " + configManager.JumlahMaksimumPerpanjangan + "hari");
                    break;
                }
            }

            Console.WriteLine("Peminjaman dengan ID " + ID_peminjaman + "tidak ditemukan");
        }
    }
}
