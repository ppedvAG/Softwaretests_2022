using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Autovermietung.Model;
using System;
using FluentAssertions;
using AutoFixture;

namespace ppedv.Autovermietung.Data.EFCore.Tests
{
    [TestClass]
    public partial class EfContextTests
    {
        [TestMethod]
        public void Can_create_database()
        {
            var con = new EfContext();
            con.Database.EnsureDeleted();

            bool result = con.Database.EnsureCreated();

            //Assert.IsTrue(result);
            result.Should().BeTrue();
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
                //Assert.AreEqual(1, con.SaveChanges());
                con.SaveChanges().Should().Be(1);
            }

            using (var con = new EfContext())
            {
                var loaded = con.Find<Auto>(auto.Id);
                //Assert.IsNotNull(loaded);
                loaded.Should().NotBeNull();
                //Assert.AreEqual(auto.Hersteller, loaded.Hersteller);
                //loaded?.Hersteller.Should().Be(auto.Hersteller);

                loaded.Should().BeEquivalentTo(auto);
            }
        }

        [TestMethod]
        public void Can_insert_auto_via_autoFix()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter("Id"));
            var auto = fix.Build<Auto>().Create();

            using (var con = new EfContext())
            {
                con.Add(auto);
                con.SaveChanges().Should().Be(4);
            }

            using (var con = new EfContext())
            {
                var loaded = con.Find<Auto>(auto.Id);
                loaded.Should().BeEquivalentTo(auto, x => x.IgnoringCyclicReferences());
            }
        }
        

    }
}