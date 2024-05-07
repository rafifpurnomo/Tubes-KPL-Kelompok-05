using System;
using System.Collections.Generic;

public class InventarisManager
{
    public enum MenuOption
    {
        TambahBuku,
        EditBuku,
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
            { MenuOption.EditBuku, EditBuku },
            { MenuOption.HapusBuku, HapusBuku },
            { MenuOption.Keluar, Keluar }
        };
    }

    public void ShowMenu()
    {
        Console.WriteLine("Menu Inventaris Perpustakaan:");
        Console.WriteLine("1. Tambah Buku");
        Console.WriteLine("2. Edit Buku");
        Console.WriteLine("3. Hapus Buku");
        Console.WriteLine("4. Tampilkan Daftar Buku");
        Console.WriteLine("5. Keluar");
        Console.WriteLine("Pilih opsi (1-5):");
    }

    public void ProcessOption(MenuOption option)
    {
        switch (option)
        {
            case MenuOption.TambahBuku:
                TambahBuku();
                break;
            case MenuOption.EditBuku:
                EditBuku();
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

    private void TampilkanDaftarBuku()
    {
        Console.WriteLine("Daftar Buku:");
        foreach (var buku in daftarBuku)
        {
            Console.WriteLine($"Judul: {buku.Judul}, Penulis: {buku.Penulis}, Tahun Terbit: {buku.TahunTerbit}, Jumlah: {buku.jumlahBuku}");
        }
    }


    private void TambahBuku()
    {
        Console.WriteLine("Menambahkan buku...");

        // Input informasi buku dari pengguna
        Console.WriteLine("Masukkan kode buku:");
        string kodeBuku = Console.ReadLine();

        Console.WriteLine("Masukkan judul buku:");
        string judulBuku = Console.ReadLine();

        Console.WriteLine("Masukkan sinopsis buku:");
        string sinopsisBuku = Console.ReadLine();

        Console.WriteLine("Masukkan penulis buku:");
        string penulisBuku = Console.ReadLine();

        Console.WriteLine("Masukkan tahun terbit buku:");
        int tahunTerbit;
        while (!int.TryParse(Console.ReadLine(), out tahunTerbit))
        {
            Console.WriteLine("Masukkan tahun terbit dalam format angka.");
        }

        Console.WriteLine("Masukkan jumlah buku:");
        int jumlahBuku;
        while (!int.TryParse(Console.ReadLine(), out jumlahBuku))
        {
            Console.WriteLine("Masukkan jumlah buku dalam format angka.");
        }

        // Membuat objek buku baru
        Buku bukuBaru = new Buku(kodeBuku, judulBuku, sinopsisBuku, penulisBuku, tahunTerbit, jumlahBuku);

        // Menambahkan buku ke dalam daftar
        daftarBuku.Add(bukuBaru);

        Console.WriteLine("Buku berhasil ditambahkan.");
    }

    private void EditBuku()
    {
        Console.WriteLine("Mengedit buku...");

        // Input judul buku yang akan diedit
        Console.WriteLine("Masukkan judul buku yang akan diedit:");
        string judulBuku = Console.ReadLine();

        // Mencari buku berdasarkan judul
        Buku bukuYangAkanDiEdit = daftarBuku.Find(buku => buku.Judul == judulBuku);

        // Jika buku ditemukan
        if (bukuYangAkanDiEdit != null)
        {
            // Input informasi baru dari pengguna
            Console.WriteLine("Masukkan kode buku:");
            bukuYangAkanDiEdit.kodeBuku = Console.ReadLine();

            Console.WriteLine("Masukkan judul buku:");
            bukuYangAkanDiEdit.Judul = Console.ReadLine();

            Console.WriteLine("Masukkan sinopsis buku:");
            bukuYangAkanDiEdit.Sinopsis = Console.ReadLine();

            Console.WriteLine("Masukkan penulis buku:");
            bukuYangAkanDiEdit.Penulis = Console.ReadLine();

            Console.WriteLine("Masukkan tahun terbit buku:");
            int tahunTerbit;
            while (!int.TryParse(Console.ReadLine(), out tahunTerbit))
            {
                Console.WriteLine("Masukkan tahun terbit dalam format angka.");
            }
            bukuYangAkanDiEdit.TahunTerbit = tahunTerbit;

            Console.WriteLine("Masukkan jumlah buku:");
            int jumlahBuku;
            while (!int.TryParse(Console.ReadLine(), out jumlahBuku))
            {
                Console.WriteLine("Masukkan jumlah buku dalam format angka.");
            }
            bukuYangAkanDiEdit.jumlahBuku = jumlahBuku;

            Console.WriteLine("Buku berhasil diubah.");
        }
        else
        {
            Console.WriteLine("Buku tidak ditemukan.");
        }
    }

    private void HapusBuku()
    {
        Console.WriteLine("Menghapus buku...");

        // Input judul buku yang akan dihapus
        Console.WriteLine("Masukkan judul buku yang akan dihapus:");
        string judulBuku = Console.ReadLine();

        // Mencari buku berdasarkan judul
        Buku bukuYangAkanDihapus = daftarBuku.Find(buku => buku.Judul == judulBuku);

        // Jika buku ditemukan
        if (bukuYangAkanDihapus != null)
        {
            // Menghapus buku dari daftar
            daftarBuku.Remove(bukuYangAkanDihapus);
            Console.WriteLine("Buku berhasil dihapus.");
        }
        else
        {
            Console.WriteLine("Buku tidak ditemukan.");
        }
    }

    private void Keluar()
    {
        Console.WriteLine("Keluar dari program.");
        Environment.Exit(0);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        InventarisManager inventarisManager = new InventarisManager();

        while (true)
        {
            inventarisManager.ShowMenu();

            if (int.TryParse(Console.ReadLine(), out int option))
            {
                if (Enum.IsDefined(typeof(InventarisManager.MenuOption), option - 1))
                {
                    inventarisManager.ProcessOption((InventarisManager.MenuOption)(option - 1));
                }
                else
                {
                    Console.WriteLine("Pilihan tidak valid.");
                }
            }
            else
            {
                Console.WriteLine("Masukan tidak valid.");
            }
        }
    }
}

public class Buku
{
    public string kodeBuku { get; set; }
    public string Judul { get; set; }
    public string Sinopsis { get; set; }
    public string Penulis { get; set; }
    public int TahunTerbit { get; set; }
    public int jumlahBuku { get; set; }

    public Buku(string kodeBuku, string judul, string sinopsis, string penulis, int tahunTerbit, int jumlahBuku)
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
        Console.WriteLine("Sinopsis: " + Sinopsis);
        Console.WriteLine("Penulis: " + Penulis);
        Console.WriteLine("Tahun Terbit: " + TahunTerbit);
        Console.WriteLine("Jumlah Buku: " + jumlahBuku);
    }
}
