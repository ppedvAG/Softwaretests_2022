using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.Autovermietung.Model;
using ppedv.Autovermietung.Model.Contracts;
using System;

namespace ppedv.Autovermietung.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void GetFastedCar_no_cars_in_DB_should_return_null()
        {
            var mock = new Mock<IRepository>();
            var core = new Core(mock.Object);

            var result = core.GetFastedCar(DateTime.Now);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetFastedCar_2_cars_in_DB_should_return_the_one_with_more_PS_TestRepo()
        {
            var core = new Core(new TestRepo());

            var result = core.GetFastedCar(DateTime.Now);

            Assert.AreEqual("Rot", result.Modell);
        }

        [TestMethod]
        public void GetFastedCar_2_cars_in_DB_should_return_the_one_with_more_PS_moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Auto>()).Returns(() =>
            {
                var a1 = new Auto() { PS = 200, Modell = "Grün" };
                var a2 = new Auto() { PS = 300, Modell = "Rot" };

                return new[] { a1, a2 };
            });
            var core = new Core(mock.Object);

            var result = core.GetFastedCar(DateTime.Now);

            Assert.AreEqual("Rot", result.Modell);
        }

        [TestMethod]
        public void GetFastedCar_2_cars_in_DB_should_return_the_one_with_same_PS()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Auto>()).Returns(() =>
            {
                var a1 = new Auto() { PS = 200, Modell = "Grün" };
                var a2 = new Auto() { PS = 200, Modell = "Rot" };
                var a3 = new Auto() { PS = 200, Modell = "Blau" };

                return new[] { a1, a2, a3 };
            });
            var core = new Core(mock.Object);

            var result = core.GetFastedCar(DateTime.Now);

            Assert.AreEqual("Rot", result.Modell);

            mock.Verify(x => x.GetAll<Auto>(), Times.Once());
            //mock.Verify(x => x.SaveChanges(), Times.Exactly(2));
        }
    }
}