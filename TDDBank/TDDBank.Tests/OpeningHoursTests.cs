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
    }
}
