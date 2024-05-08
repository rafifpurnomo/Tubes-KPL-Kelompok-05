namespace API_TUBES_KPL_KELOMPOK_05.Model
{
    public class Akun
    {
        public string namaUser { get; set; }

        public string No_Anggota { get; set; }

        public string Role { get; set; }

        public string no_Telpon { get; set; }

        public MemberStatus status { get; set; }

        public Akun(string namaUser, string No_Anggota, string role, string no_Telpon)
        {
            this.namaUser = namaUser;
            this.No_Anggota = No_Anggota;
            this.Role = role;
            this.no_Telpon = no_Telpon;
            status = MemberStatus.Unverified;
        }
    }

    public enum MemberStatus
    {
        Unverified,
        Active,
        Inactive,
        Frozen
    }
}
