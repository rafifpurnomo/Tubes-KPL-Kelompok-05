using System;
using System.Collections.Generic;

namespace MAIN_TUBES_KPL_KELOMPOK_5
{
    public class Perpustakaan
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

        public void toArray()
        {
            bukuArray = buku.ToArray(); 
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
        

    }
}
