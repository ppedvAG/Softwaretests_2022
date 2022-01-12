using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Autovermietung.Model;
using System;

namespace ppedv.Autovermietung.Data.EFCore.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void Can_create_database()
        {
            var con = new EfContext();
            con.Database.EnsureDeleted();

            bool result = con.Database.EnsureCreated();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Can_insert_auto()
        {
            var auto = new Auto()
            {
                Hersteller = $"Baudi_{Guid.NewGuid()}",
                Modell = "B99",
                PS = 17,
                Baujahr = new DateTime(2022, 1, 11)
            };

            using (var con = new EfContext())
            {
                con.Add(auto);
                Assert.AreEqual(1, con.SaveChanges());
            }

            using (var con = new EfContext())
            {
                var loaded = con.Find<Auto>(auto.Id);
                Assert.IsNotNull(loaded);
                Assert.AreEqual(auto.Hersteller, loaded.Hersteller);
            }
        }
    }
}