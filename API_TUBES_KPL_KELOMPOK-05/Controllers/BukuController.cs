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
            string jsonFilePath = "C:\\Users\\Rafif Purnomo\\OneDrive\\Documents\\Coding\\C#\\TUBES_KPL_KELOMPOK-05\\API_TUBES_KPL_KELOMPOK-05\\Data\\DataBuku.json";
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

        // GET BOOK BY JUDUL
        [HttpGet("{Judul}")]
        public ActionResult<Buku> GET(string Judul)
        {
            try
            {
                int id = -1;

                for (int i = 0; i < DataDisplayBook.Count; i++)
                {
                    if (Judul == DataDisplayBook[i].Judul)
                    {
                        id = i;
                    }
                }

                if (id != -1)
                {
                    return DataDisplayBook[id];
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
    }
}
