using MAIN_TUBES_KPL_KELOMPOK_5;
using System.Security.Cryptography;

internal class Program
{
    private static void Main(string[] args)
    {
        // TEST SEARCH BY JUDUL
        Perpustakaan cariBuku = new Perpustakaan();
        cariBuku.toArray();
        string judulBuku = "Dasar Pemrograman JS";
        cariBuku.cariByJudul(judulBuku);
        int indexBuku = cariBuku.returnIndex("Dasar Pemrograman JS");
        Console.WriteLine("\nJudul buku: " + judulBuku + "ada pada index: " + indexBuku);


    }
}