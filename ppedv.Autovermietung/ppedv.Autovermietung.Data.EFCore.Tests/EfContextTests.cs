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
            //InitDb();
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
            //CleanDb();
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

        [TestMethod]
        public void Delete_Vermietung_should_not_delete_Auto()
        {
            var auto = new Auto();
            var vm = new Vermietung();
            auto.Vermietungen.Add(vm);
            using (var con = new EfContext())
            {
                con.Add(auto);
                con.SaveChanges().Should().Be(2);
            }

            using (var con = new EfContext())
            {
                var vmLoaded = con.Find<Vermietung>(vm.Id);
                con.Remove<Vermietung>(vmLoaded);
                con.SaveChanges().Should().Be(1);
            }

            using (var con = new EfContext())
            {
                var autoLoaded = con.Find<Auto>(auto.Id);
                autoLoaded.Should().NotBeNull();
                var vmLoaded = con.Find<Vermietung>(vm.Id);
                vmLoaded.Should().BeNull();

            }
        }

        [TestMethod]
        public void Delete_Auto_should_delete_all_Vermietungen()
        {
            var auto = new Auto();
            var vm1 = new Vermietung();
            var vm2 = new Vermietung();
            auto.Vermietungen.Add(vm1);
            auto.Vermietungen.Add(vm2);
            using (var con = new EfContext())
            {
                con.Add(auto);
                con.SaveChanges().Should().Be(3);
            }

            using (var con = new EfContext())
            {
                var autoLoaded = con.Find<Auto>(auto.Id);
                con.Remove<Auto>(autoLoaded);
                con.SaveChanges().Should().Be(1);
            }

            using (var con = new EfContext())
            {
                con.Find<Auto>(auto.Id).Should().BeNull();
                con.Find<Vermietung>(vm1.Id).Should().BeNull();
                con.Find<Vermietung>(vm2.Id).Should().BeNull();
            }
        }

    }
}