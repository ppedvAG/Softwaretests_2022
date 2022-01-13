using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.Autovermietung.Logic;
using ppedv.Autovermietung.Model;
using ppedv.Autovermietung.Model.Contracts;
using ppedv.Autovermietung.UI.WPF.ViewModel;

namespace ppedv.Autovermietung.UI.WPF.Tests
{
    [TestClass]
    public class AutoViewModelTests
    {
        private object mock;

        [TestMethod]
        public void OnStart_the_AutoList_should_be_loaded_pure()
        {
            var autoVm = new AutoViewModel();

            Assert.IsNotNull(autoVm.AutosList);
            Assert.IsTrue(autoVm.AutosList.Count > 0);
        }

        [TestMethod]
        public void OnStart_the_AutoList_should_be_loaded_core_mock()
        {

            var repoMock = new Mock<IRepository>();
            repoMock.Setup(x => x.GetAll<Auto>()).Returns(() =>
            {
                var a1 = new Auto() { PS = 200, Modell = "Grün" };
                var a2 = new Auto() { PS = 300, Modell = "Rot" };

                return new[] { a1, a2 };
            });

            var autoVm = new AutoViewModel(new Core(repoMock.Object));

            autoVm.AutosList.Should().NotBeEmpty();

        }
    }
}