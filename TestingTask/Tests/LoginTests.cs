using NUnit.Framework;
using OpenQA.Selenium;
using TestingTask.Pages;

namespace TestingTask.Tests
{
    public class LoginTests : BaseTest
    {
        LoginPage loginPage;

        [SetUp]
        public void Initialize()
        {
            this.loginPage = new LoginPage(driver);
        }

        [Test]
        public void WhenLoginWithValidCredentialsThenSuccess()
        {
            loginPage.LoginFieldEmail.SendKeys(loginPage.validEmail);
            loginPage.NextButton.Click();

            loginPage.LoginFieldPassword.SendKeys(loginPage.validPassword);
            loginPage.LoginButton.Click();

            var logedUserInfo = driver.FindElement(By.Id("loginView1_liUserTitle")).Text;
            Assert.That(logedUserInfo.Contains("Firstname Lastname"));
            Assert.That(driver.Url, Is.EqualTo("https://eu.syncplicity.com/Business/"));
            Assert.That(driver.Title, Is.EqualTo("Manage Policies"));
        }

        [Test]
        public void WhenLoginWithInvalidEmailThenValidationError()
        {
            loginPage.LoginFieldEmail.SendKeys("wrongEmail");

            loginPage.NextButton.Click();

            var emailValidationErrorText = loginPage.EmailFieldValidationError.Text;

            Assert.That(emailValidationErrorText, Is.EqualTo("Please enter a valid email address."));
            Assert.That(driver.Url, Is.EqualTo(baseUrl));
        }

        [Test]
        public void WhenLoginWithWrongPasswordThenError()
        {
            loginPage.LoginFieldEmail.SendKeys(loginPage.validEmail);
            loginPage.NextButton.Click();

            loginPage.LoginFieldPassword.SendKeys("proba");
            loginPage.LoginButton.Click();

            var errorText = loginPage.ErrorBanner.Text;
            Assert.That(errorText, Is.EqualTo("Invalid email or password. Please try again."));
            Assert.That(driver.Url, Is.EqualTo(baseUrl));
        }
    }
}