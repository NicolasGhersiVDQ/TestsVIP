using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VIP
{
    [TestFixture]
    [Parallelizable]
    public class VIP_Web
    {
        private IWebDriver webDriver;

        [SetUp]
        public void Init()
        {
            webDriver = new ChromeDriver();
        }

        [Test]
        public void Test_Acces_Notifications()
        {
            webDriver.Url = "https://zonerh/client/VQELogin.aspx  ";
            IWebElement idUsager = webDriver.FindElement(By.Id("inputUserName"));
            idUsager.SendKeys("cbur");
            IWebElement mdp = webDriver.FindElement(By.Id("inputPassword"));
            mdp.SendKeys("cbur6410");
            IWebElement btnLogin = webDriver.FindElement(By.Id("btnLogin"));
            btnLogin.Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(2000);
            IWebElement lnkMessages = webDriver.FindElement(By.XPath("//*[@id='aa']/div/div/div/div/div/div/div/div/div[2]/a"));
            lnkMessages.Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            webDriver.SwitchTo().Window(webDriver.WindowHandles.Last());
            IWebElement lnkNotifications = webDriver.FindElement(By.XPath("//*[@id='aa']/div[2]/div/div[2]/div/div/div[2]/div/div/div/div/div/div/div/div/div/div[2]/div/span"));
            lnkNotifications.Click();
            IWebElement btnRetour = webDriver.FindElement(By.XPath("//*[@id='aa']/div[2]/div/div[2]/div/div/div[2]/div/div/div/div/div/div/div/div/div/div/div[2]/a"));
        }

        [TearDown]
        public void Dispose()
        {
            webDriver.Quit();
        }
    }
}