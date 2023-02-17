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

using OpenQA.Selenium.Appium.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Location = OpenQA.Selenium.Appium.Location;

namespace TestProject1
{ 
    public class Tests
    {
        private static AppiumDriver<AppiumWebElement> _driver;
        private static AppiumLocalService _appiumLocalService;

        [Test]
        public void OpenAppium()
        {
            _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            _appiumLocalService.Start();
            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel XL API 31");
            // driverOptions.AddAdditionalCapability(MobileCapabilityType.App, @"D:\Dipisha\Projects\2023\Geico - Telematices\Extra\APK\android-debug.apk");
            driverOptions.AddAdditionalCapability("appPackage", "com.google.android.apps.maps");

            driverOptions.AddAdditionalCapability("appActivity", "com.google.android.maps.MapsActivity");
            _driver = new AndroidDriver<AppiumWebElement>(_appiumLocalService, driverOptions);
             Location location = new Location();
            _driver.Location.Altitude = 77.59974003;
            _driver.Location.Latitude = 12.91024781;
            _driver.Location.Longitude = 909;



        }
        [TearDown]
        public void close_Browser()
        {
            _driver.CloseApp();
        }
    }
}