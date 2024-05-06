using API_TUBES_KPL_KELOMPOK_05.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_TUBES_KPL_KELOMPOK_05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisplayBooksController : Controller
    {
        private static List<DisplayBooks> DataDisplayBook = new List<DisplayBooks>();

        public DisplayBooksController()
        {
            string jsonFilePath = "C:\\Users\\Rafif Purnomo\\OneDrive\\Documents\\Coding\\C#\\TUBES_KPL_KELOMPOK_05\\API_TUBES_KPL\\API_TUBES_KPL\\Data\\DataDisplayBooks.json";
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            DataDisplayBook = JsonConvert.DeserializeObject<List<DisplayBooks>>(jsonData);
        }

        // GET DATA ALL API
        [HttpGet]
        public IEnumerable<DisplayBooks> GET()
        {
            return DataDisplayBook;
        }

        // GET BOOK BY JUDUL
        [HttpGet("{Judul}")]

        public DisplayBooks GET(String Judul)
        {
            int id = -1;

            for (int i = 0; i < DataDisplayBook.Count; i++)
            {
                if (Judul == DataDisplayBook[i].Judul)
                {
                    id = i;
                }
            }
            return DataDisplayBook[id];
        }

        // POST DATA BOOK 
        [HttpPost]
        public void POST([FromBody] DisplayBooks newBook)
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
                string jsonFilePath = "C:\\Users\\Rafif Purnomo\\OneDrive\\Documents\\Coding\\C#\\TUBES_KPL_KELOMPOK_05\\API_TUBES_KPL\\API_TUBES_KPL\\Data\\DataDisplayBooks.json";
                string jsonContent = JsonConvert.SerializeObject(DataDisplayBook);
                System.IO.File.WriteAllText(jsonFilePath, jsonContent);
            }
        }

        // DELETE BUKU BY JUDUL
        [HttpDelete("{Judul}")]

        public void DELETE(String Judul)
        {
            int id = -1;

            for (int i = 0; i < DataDisplayBook.Count; i++)
            {
                if (Judul == DataDisplayBook[i].Judul)
                {
                    DataDisplayBook.RemoveAt(i);
                    string jsonFilePath = "C:\\Users\\Rafif Purnomo\\OneDrive\\Documents\\Coding\\C#\\TUBES_KPL_KELOMPOK_05\\API_TUBES_KPL\\API_TUBES_KPL\\Data\\DataDisplayBooks.json";
                    string jsonContent = JsonConvert.SerializeObject(DataDisplayBook);
                    System.IO.File.WriteAllText(jsonFilePath, jsonContent);
                    break;
                }
            }
        }
    }
}
