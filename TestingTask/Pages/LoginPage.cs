using OpenQA.Selenium;
using TestingTask.Constants;

namespace TestingTask.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        public string validEmail = "syncplicity-technical-interview@dispostable.com";
        public string validPassword = "s7ncplicit@Y";

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        public IWebElement LoginFieldEmail => driver.FindElement(By.Id(LocatorsLoginPage.emailFieldLocator));
        public IWebElement NextButton => driver.FindElement(By.Id(LocatorsLoginPage.nextButtonLocator));
        public IWebElement LoginFieldPassword => driver.FindElement(By.Id(LocatorsLoginPage.passwordFieldLocator));
        public IWebElement LoginButton => driver.FindElement(By.Id(LocatorsLoginPage.loginButtonLocator));
        public IWebElement EmailFieldValidationError => driver.FindElement(By.Id(LocatorsLoginPage.emailFieldValidationErrorLocator));
        public IWebElement ErrorBanner => driver.FindElement(By.Id(LocatorsLoginPage.errorBannerLocator)).FindElement(By.XPath(".//li"));


        public void Login(string email, string password)
        {
            LoginFieldEmail.SendKeys(email);
            NextButton.Click();
            LoginFieldPassword.SendKeys(password);
            LoginButton.Click();
        }
    }
}
