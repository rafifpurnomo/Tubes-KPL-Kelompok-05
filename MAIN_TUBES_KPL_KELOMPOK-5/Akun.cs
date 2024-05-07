using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAIN_TUBES_KPL_KELOMPOK_5
{
    internal class Akun
    {
        public string namaUser { get; set; }

        public string No_Anggota { get; set; }

        public string Role { get; set; }

        public string no_Telpon { get; set; }

        public Akun(string namaUser, string No_Anggota, string role, string no_Telpon)
        {
            this.namaUser = namaUser;
            this.No_Anggota = No_Anggota;
            this.Role = role;
            this.no_Telpon = no_Telpon;
        }
    }
}
