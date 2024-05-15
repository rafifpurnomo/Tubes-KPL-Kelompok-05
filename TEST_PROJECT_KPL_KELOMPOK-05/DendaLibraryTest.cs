using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIBRARY_TUBES_KPL_KELOMPOK_05;

namespace TEST_PROJECT_KPL_KELOMPOK_05
{
    [TestClass]
    public class DendaLibraryTest
    {
        [TestMethod]
        public void TestPengembalianTepatWaktu()
        {
            double denda = Denda.PerhitunganDenda("2023 05 01", "2023 05 01", 1000.0);
            Assert.AreEqual(0.0, denda, "Denda harus 0 jika pengembalian tepat waktu.");
        }

        [TestMethod]
        public void TestPengembalianTerlambat1Hari()
        {
            double denda = Denda.PerhitunganDenda("2023 05 01", "2023 05 02", 1000.0);
            Assert.AreEqual(1000.0, denda, "Denda harus 1000 jika terlambat 1 hari dengan denda 1000 per hari.");
        }

        [TestMethod]
        public void TestPengembalianTerlambat5Hari()
        {
            double denda = Denda.PerhitunganDenda("2023 05 01", "2023 05 06", 500.0);
            Assert.AreEqual(2500.0, denda, "Denda harus 2500 jika terlambat 5 hari dengan denda 500 per hari.");
        }

        [TestMethod]
        public void TestPengembalianLebihAwal()
        {
            double denda = Denda.PerhitunganDenda("2023 05 10", "2023 05 05", 1000.0);
            Assert.AreEqual(0.0, denda, "Denda harus 0 jika pengembalian lebih awal dari tanggal telat.");
        }

        [TestMethod]
        public void TestPengembalianTepatWaktuDenganDendaNol()
        {
            double denda = Denda.PerhitunganDenda("2023 05 01", "2023 05 01", 0.0);
            Assert.AreEqual(0.0, denda, "Denda harus 0 jika pengembalian tepat waktu dengan denda 0 per hari.");
        }
    }
}
