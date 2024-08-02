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


        public IWebElement loginFieldEmail => driver.FindElement(By.Id(LocatorsLoginPage.emailFieldId));


        public IWebElement nextButton => driver.FindElement(By.Id(LocatorsLoginPage.nextButtonId));


        public IWebElement loginFieldPassword => driver.FindElement(By.Id(LocatorsLoginPage.passwordFieldId));


        public IWebElement loginButton => driver.FindElement(By.Id(LocatorsLoginPage.loginButtonId));

        public IWebElement emailFieldValidationError => driver.FindElement(By.Id(LocatorsLoginPage.emailFieldValidationErrorId));

        public IWebElement errorBanner => driver.FindElement(By.Id(LocatorsLoginPage.errorBannerId)).FindElement(By.XPath(".//li"));


        public void login()
        {
            loginFieldEmail.SendKeys(validEmail);
            nextButton.Click();
            loginFieldPassword.SendKeys(validPassword);
            loginButton.Click();
        }
    }
}
