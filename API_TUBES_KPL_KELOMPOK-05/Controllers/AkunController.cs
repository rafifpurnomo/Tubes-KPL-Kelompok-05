using API_TUBES_KPL_KELOMPOK_05.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_TUBES_KPL_KELOMPOK_05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AkunController : Controller
    {
        private static List<Akun> DataAkun = new List<Akun>();

        public AkunController()
        {
            string jsonFilePath = "C:\\Users\\Rafif Purnomo\\OneDrive\\Documents\\Coding\\C#\\TUBES_KPL_KELOMPOK_05\\API_TUBES_KPL\\API_TUBES_KPL\\Data\\DataAkun.json";
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            DataAkun = JsonConvert.DeserializeObject<List<Akun>>(jsonData);
        }

        // GET DATA ALL API
        [HttpGet]
        public IEnumerable<Akun> GET()
        {
            return DataAkun;
        }

        // GET DATA BY No_Anggota 
        [HttpGet("{No_Anggota}")]
        public Akun GET(string No_Anggota)
        {
            int id = -1;

            for (int i = 0; i < DataAkun.Count; i++)
            {
                if (No_Anggota == DataAkun[i].No_Anggota)
                {
                    id = i;
                }
            }
            return DataAkun[id];
        }

        // POST DATA BY No_Anggota
        [HttpPost]
        public void POST([FromBody] Akun newAkun)
        {
            int id = -1;
            Boolean sama = false;

            for (int i = 0; i < DataAkun.Count; i++)
            {
                if (newAkun.No_Anggota == DataAkun[i].No_Anggota)
                {
                    sama = true;
                }
            }

            if (!sama)
            {
                DataAkun.Add(newAkun);
                string jsonFilePath = "C:\\Users\\Rafif Purnomo\\OneDrive\\Documents\\Coding\\C#\\TUBES_KPL_KELOMPOK_05\\API_TUBES_KPL\\API_TUBES_KPL\\Data\\DataAkun.json";
                string jsonContent = JsonConvert.SerializeObject(DataAkun);
                System.IO.File.WriteAllText(jsonFilePath, jsonContent);
            }
        }

        // DELETE DATA BY No_Anggota
        [HttpDelete("{No_Anggota}")]
        public void DELETE(String No_Anggota)
        {
            int id = -1;

            for (int i = 0; i < DataAkun.Count; i++)
            {
                if (No_Anggota == DataAkun[i].No_Anggota)
                {
                    DataAkun.RemoveAt(i);
                    string jsonFilePath = "C:\\Users\\Rafif Purnomo\\OneDrive\\Documents\\Coding\\C#\\TUBES_KPL_KELOMPOK_05\\API_TUBES_KPL\\API_TUBES_KPL\\Data\\DataAkun.json";
                    string jsonContent = JsonConvert.SerializeObject(DataAkun);
                    System.IO.File.WriteAllText(jsonFilePath, jsonContent);
                    break;
                }
            }
        }
    }
}

