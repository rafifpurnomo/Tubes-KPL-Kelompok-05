using API_TUBES_KPL_KELOMPOK_05.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_TUBES_KPL_KELOMPOK_05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BukuController : Controller
    {
        private static List<Buku> DataDisplayBook = new List<Buku>();

        public BukuController()
        {
            string jsonFilePath = "C:\\TubesKPL\\Tubes-KPL-Kelompok-05\\API_TUBES_KPL_KELOMPOK-05\\Data\\DataBuku.json";
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            DataDisplayBook = JsonConvert.DeserializeObject<List<Buku>>(jsonData);
        }

        public static List<Buku> getDataDisplayBook()
        {
            return DataDisplayBook;
        }

        // GET DATA ALL API
        [HttpGet]
        public IEnumerable<Buku> GET()
        {
            return DataDisplayBook;
        }

        // GET BOOKS BY JUDUL
        [HttpGet("Judul/{Judul}")]
        public ActionResult<List<Buku>> GETJUDUL(string Judul)
        {
            try
            {
                List<Buku> bukus = new List<Buku>();

                for (int i = 0; i < DataDisplayBook.Count; i++)
                {
                    if (Judul == DataDisplayBook[i].Judul)
                    {
                        bukus.Add(DataDisplayBook[i]);
                    }
                }

                if (bukus.Count > 0)
                {
                    return bukus;
                }
                else
                {
                    return NotFound("Judul tidak ada"); // Mengembalikan respons 404 Not Found dengan pesan
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Terjadi kesalahan: " + ex.Message); // Mengembalikan respons 500 Internal Server Error dengan pesan
            }
        }

        // GET BOOKS BY PENULIS
        [HttpGet("penulis/{Penulis}")]
        public ActionResult<List<Buku>> GETPENULIS(string Penulis)
        {
            try
            {
                List<Buku> penulis = new List<Buku>();

                for (int i = 0; i < DataDisplayBook.Count; i++)
                {
                    if (Penulis == DataDisplayBook[i].Penulis)
                    {
                        penulis.Add(DataDisplayBook[i]);
                    }
                }

                if (penulis.Count > 0)
                {
                    return penulis;
                }
                else
                {
                    return NotFound("Judul tidak ada"); // Mengembalikan respons 404 Not Found dengan pesan
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Terjadi kesalahan: " + ex.Message); // Mengembalikan respons 500 Internal Server Error dengan pesan
            }
        }

        // GET BOOKS BY TAHUN TERBIT
        [HttpGet("tahunTerbit/{TahunTerbit}")]
        public ActionResult<List<Buku>> GETTAHUNTERBIT(int TahunTerbit)
        {
            try
            {
                List<Buku> tahunTerbit = new List<Buku>();

                for (int i = 0; i < DataDisplayBook.Count; i++)
                {
                    if (TahunTerbit == DataDisplayBook[i].TahunTerbit)
                    {
                        tahunTerbit.Add(DataDisplayBook[i]);
                    }
                }

                if (tahunTerbit.Count > 0)
                {
                    return tahunTerbit;
                }
                else
                {
                    return NotFound("Judul tidak ada"); // Mengembalikan respons 404 Not Found dengan pesan
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Terjadi kesalahan: " + ex.Message); // Mengembalikan respons 500 Internal Server Error dengan pesan
            }
        }

        // POST DATA BOOK 
        [HttpPost]
        public void POST([FromBody] Buku newBook)
        {
            int id = -1;
            Boolean sama = false;

            // CHECK KODE  BUKU
            for (int i = 0; i < DataDisplayBook.Count; i++)
            {
                if (newBook.kodeBuku == DataDisplayBook[i].kodeBuku)
                {
                    sama = true;
                }
            }

            if (!sama)
            {
                DataDisplayBook.Add(newBook);
                string jsonFilePath = "C:\\TubesKPL\\Tubes-KPL-Kelompok-05\\API_TUBES_KPL_KELOMPOK-05\\Data\\DataBuku.json";
                string jsonContent = JsonConvert.SerializeObject(DataDisplayBook);
                System.IO.File.WriteAllText(jsonFilePath, jsonContent);
            }
        }

        // DELETE BUKU BY JUDUL
        [HttpDelete("judul/{Judul}")]

        public void DELETEBYJUDUL(String Judul)
        {
            int id = -1;

            for (int i = 0; i < DataDisplayBook.Count; i++)
            {
                if (Judul == DataDisplayBook[i].Judul)
                {
                    DataDisplayBook.RemoveAt(i);
                    string jsonFilePath = "C:\\TubesKPL\\Tubes-KPL-Kelompok-05\\API_TUBES_KPL_KELOMPOK-05\\Data\\DataBuku.json";
                    string jsonContent = JsonConvert.SerializeObject(DataDisplayBook);
                    System.IO.File.WriteAllText(jsonFilePath, jsonContent);
                    break;
                }
            }
        }

        // DELETE BUKU BY KODEBUKU
        [HttpDelete("kode/{kodeBuku}")]

        public void DELETEBYKODEBUKU(String kodeBuku)
        {
            int id = -1;

            for (int i = 0; i < DataDisplayBook.Count; i++)
            {
                if (kodeBuku == DataDisplayBook[i].kodeBuku)
                {
                    DataDisplayBook.RemoveAt(i);
                    string jsonFilePath = "C:\\TubesKPL\\Tubes-KPL-Kelompok-05\\API_TUBES_KPL_KELOMPOK-05\\Data\\DataBuku.json";
                    string jsonContent = JsonConvert.SerializeObject(DataDisplayBook);
                    System.IO.File.WriteAllText(jsonFilePath, jsonContent);
                    break;
                }
            }
        }

        // DELETE BUKU BY PENULIS
        [HttpDelete("penulis/{Penulis}")]

        public void DELETEBYPENULIS(String Penulis)
        {
            int id = -1;

            for (int i = 0; i < DataDisplayBook.Count; i++)
            {
                if (Penulis == DataDisplayBook[i].Penulis)
                {
                    DataDisplayBook.RemoveAt(i);
                    string jsonFilePath = "C:\\TubesKPL\\Tubes-KPL-Kelompok-05\\API_TUBES_KPL_KELOMPOK-05\\Data\\DataBuku.json";
                    string jsonContent = JsonConvert.SerializeObject(DataDisplayBook);
                    System.IO.File.WriteAllText(jsonFilePath, jsonContent);
                    break;
                }
            }
        }

        // DELETE BUKU BY PENULIS
        [HttpDelete("tahun/{TahunTerbit}")]

        public void DELETEBYTAHUN(int TahunTerbit)
        {
            int id = -1;

            for (int i = 0; i < DataDisplayBook.Count; i++)
            {
                if (TahunTerbit == DataDisplayBook[i].TahunTerbit)
                {
                    DataDisplayBook.RemoveAt(i);
                    string jsonFilePath = "C:\\TubesKPL\\Tubes-KPL-Kelompok-05\\API_TUBES_KPL_KELOMPOK-05\\Data\\DataBuku.json";
                    string jsonContent = JsonConvert.SerializeObject(DataDisplayBook);
                    System.IO.File.WriteAllText(jsonFilePath, jsonContent);
                    break;
                }
            }
        }
    }
}
