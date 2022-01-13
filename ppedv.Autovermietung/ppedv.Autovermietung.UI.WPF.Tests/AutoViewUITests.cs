using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace ppedv.Autovermietung.UI.WPF.Tests
{
    [TestClass]
    public class AutoViewUITests
    {

        private const string WpfAppId = @"C:\Users\Fred\source\repos\ppedvAG\Softwaretests_2022\ppedv.Autovermietung\ppedv.Autovermietung.UI.WPF\bin\Debug\net6.0-windows\ppedv.Autovermietung.UI.WPF.exe";
        protected const string URL = "http://127.0.0.1:4723";

        [TestMethod]
        public void OnStart_in_Hersteller_Textbox_should_be_any_text()
        {
            //Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");

            var ops = new AppiumOptions();
            ops.AddAdditionalCapability("app", WpfAppId);
            WindowsDriver<WindowsElement> session = new WindowsDriver<WindowsElement>(new Uri(URL), ops);

            var tb = session.FindElementByAccessibilityId("herstellerTb");
            tb.Text.Should().NotBeEmpty();

            session.Dispose();
        }
    }
}
