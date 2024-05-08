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
            string jsonFilePath = "D:\\Coding\\C#\\TubesKPL\\Tubes-KPL-Kelompok-05\\API_TUBES_KPL_KELOMPOK-05\\Data\\DataAkun.json";
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
        [HttpGet("No/{No_Anggota}")]
        public Akun GETAnggota(string No_Anggota)
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

        // GET DATA BY Role
        [HttpGet("Role/{Role}")]
        public ActionResult<List<Akun>> GetRole(string Role)
        {
            try
            {
                List<Akun> roles = new List<Akun>();
                for (int i = 0; i < DataAkun.Count; i++)
                {
                    if (Role == DataAkun[i].Role)
                    {
                        roles.Add(DataAkun[i]);
                    }
                }
                if (roles.Count > 0)
                {
                    return roles;
                }
                else
                {
                    return NotFound("Judul tidak ada");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Terjadi kesalahan: " + e.Message);
            }
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
                string jsonFilePath = "D:\\Coding\\C#\\TubesKPL\\Tubes-KPL-Kelompok-05\\API_TUBES_KPL_KELOMPOK-05\\Data\\DataAkun.json";
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
                    string jsonFilePath = "D:\\Coding\\C#\\TubesKPL\\Tubes-KPL-Kelompok-05\\API_TUBES_KPL_KELOMPOK-05\\Data\\DataAkun.json";
                    string jsonContent = JsonConvert.SerializeObject(DataAkun);
                    System.IO.File.WriteAllText(jsonFilePath, jsonContent);
                    break;
                }
            }
        }
    }
}

