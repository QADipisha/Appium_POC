using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Html5;
using Location = OpenQA.Selenium.Appium.Location;
using OpenQA.Selenium.Appium.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
       
        private static AndroidDriver<AppiumWebElement> _driver;
        private static AppiumLocalService _appiumLocalService;
        
        [ClassInitialize]
        public void OpenAppium()
        {
            _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            _appiumLocalService.Start();
            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel XL API 31");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.App, @"D:\Dipisha\Projects\2023\Geico - Telematices\Extra\APK\android-debug.apk");

            _driver = new AndroidDriver<AppiumWebElement>(_appiumLocalService, driverOptions);
            _driver.CloseApp();

            // AndroidDriver<AndroidElement> androiddriver = new AndroidDriver<AndroidElement>(driverOptions);
            // _driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), driverOptions);
            //  _driver.FindElementByXPath("//android.view.View[@content-desc=\"Account\"]/android.widget.TextView").Click();
            Location loc = new Location();
           // Location location = new Location(77.59974003, 12.91024781, 909);
            // _driver.Location.Latitude = 94.23;
            loc.Latitude = 94.23;
            // _driver.Location.Latitude = 121.21;
            loc.Altitude = 121.21;
            // _driver.Location.Longitude = 11.56;
            loc.Longitude = 11.56;
            // Location location = new Location();
           // _driver.g (loc);
           // driver.setGeoLocation({ latitude: "121.21", longitude: "11.56"});
        }
        [TestInitialize]
        public void TestInitialize()
        {
            _driver?.LaunchApp();
        }
        [TestCleanup]
        public void TestCleanup()
        {
            _driver?.CloseApp();
        }
        [ClassCleanup]
        public static void ClassCleanup()
        {
            _appiumLocalService.Dispose();
        }
    }
}