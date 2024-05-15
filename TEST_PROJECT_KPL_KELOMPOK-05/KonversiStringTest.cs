using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIBRARY_TUBES_KPL_KELOMPOK_05;

namespace TEST_PROJECT_KPL_KELOMPOK_05
{
    [TestClass]
    public class KonversiStringTest
    {
        // Pengujian Method Konversi String Ke Date Time
        [TestMethod]
        public void TestKonversiTanggalValid()
        {
            DateTime expectedDate = new DateTime(2023, 5, 1);
            DateTime actualDate = StringLibrary.KonversiStringKeDate("2023 05 01");
            Assert.AreEqual(expectedDate, actualDate, "Tanggal harus dikonversi dengan benar.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Format tanggal tidak valid")]
        public void TestKonversiTanggalInvalid()
        {
            StringLibrary.KonversiStringKeDate("2023-05-01");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Format tanggal tidak valid")]
        public void TestKonversiTanggalKosong()
        {
            StringLibrary.KonversiStringKeDate("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Format tanggal tidak valid")]
        public void TestKonversiTanggalNull()
        {
            StringLibrary.KonversiStringKeDate(null);
        }

        // Pengujian Method Konversi Date Time ke String
        [TestMethod]
        public void TestKonversiTanggalValid2()
        {
            DateTime expectedDate = new DateTime(2023, 5, 1);
            DateTime actualDate = StringLibrary.KonversiStringKeDate("2023 05 01");
            Assert.AreEqual(expectedDate, actualDate, "Tanggal harus dikonversi dengan benar.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Format tanggal tidak valid")]
        public void TestKonversiTanggalInvalid2()
        {
            StringLibrary.KonversiStringKeDate("2023-05-01");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Format tanggal tidak valid")]
        public void TestKonversiTanggalKosong2()
        {
            StringLibrary.KonversiStringKeDate("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Format tanggal tidak valid")]
        public void TestKonversiTanggalNull2()
        {
            StringLibrary.KonversiStringKeDate(null);
        }

        [TestMethod]
        public void TestKonversiDateKeStringValid()
        {
            DateTime date = new DateTime(2023, 5, 1);
            string expectedString = "2023 05 01";
            string actualString = StringLibrary.KonversiDateKeString(date);
            Assert.AreEqual(expectedString, actualString, "String harus dikonversi dengan format yang benar.");
        }

    }
}
