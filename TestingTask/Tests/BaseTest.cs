using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestingTask.Tests
{
    public class BaseTest
    {
        protected const string baseUrl = "https://eu.syncplicity.com/";
        protected IWebDriver driver { get; set; }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Navigate().GoToUrl(baseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}