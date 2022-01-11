using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBank.Tests
{
    [TestClass]
    public class OpeningHoursTests
    {
        [TestMethod]
        [DataRow(2022, 1, 10, 10, 30, true)]//mo
        [DataRow(2022, 1, 10, 10, 29, false)]//mo
        [DataRow(2022, 1, 10, 10, 0, false)] //mo
        [DataRow(2022, 1, 10, 18, 59, true)] //mo
        [DataRow(2022, 1, 10, 19, 00, false)] //mo
        [DataRow(2022, 1, 15, 13, 0, true)] //sa
        [DataRow(2022, 1, 15, 16, 0, false)] //sa
        [DataRow(2022, 1, 16, 20, 0, false)] //so
        public void OpeningHours_IsOpen(int y, int M, int d, int h, int m, bool result)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();

            Assert.AreEqual(result, oh.IsOpen(dt));
        }


        [TestMethod]
        public void IsWeekend()
        {
            var oh = new OpeningHours();

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022,1,10);
                Assert.IsFalse(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022,1,11);
                Assert.IsFalse(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022,1,12);
                Assert.IsFalse(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022,1,13);
                Assert.IsFalse(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022,1,14);
                Assert.IsFalse(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022,1,15);
                Assert.IsTrue(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022,1,16);
                Assert.IsTrue(oh.IsWeekend());
            }

        }

        [TestMethod]
        public void Can_GetData()
        {
            var oh = new OpeningHours();
            using (ShimsContext.Create())
            {
                System.IO.Fakes.ShimFile.ReadAllTextString = x => "TEXT mit Buchstaben";
                Assert.IsTrue(oh.GetData());
            }
        }
    }
}
