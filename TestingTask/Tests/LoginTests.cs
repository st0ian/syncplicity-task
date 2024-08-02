using NUnit.Framework;
using OpenQA.Selenium;
using TestingTask.Source.Pages;

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
            loginPage.loginFieldEmail.SendKeys(loginPage.validEmail);
            loginPage.nextButton.Click();
            loginPage.loginFieldPassword.SendKeys(loginPage.validPassword);
            loginPage.loginButton.Click();

            var logedUserInfo = driver.FindElement(By.Id("loginView1_liUserTitle")).Text;
            Assert.That(logedUserInfo.Contains("Firstname Lastname"));
            Assert.That(driver.Url, Is.EqualTo("https://eu.syncplicity.com/Business/"));
            Assert.That(driver.Title, Is.EqualTo("Manage Policies"));
        }

        [Test]
        public void WhenLoginWithInvalidEmailThenValidationError()
        {
            loginPage.loginFieldEmail.SendKeys("wrongEmail");

            loginPage.nextButton.Click();

            var emailValidationErrorText = loginPage.emailFieldValidationError.Text;

            Assert.That(emailValidationErrorText, Is.EqualTo("Please enter a valid email address."));
            Assert.That(driver.Url, Is.EqualTo(baseUrl));
        }

        [Test]
        public void WhenLoginWithWrongPasswordThenError()
        {
            loginPage.loginFieldEmail.SendKeys(loginPage.validEmail);
            loginPage.nextButton.Click();
            loginPage.loginFieldPassword.SendKeys("proba");
            loginPage.loginButton.Click();

            var errorText = loginPage.errorBanner.Text;
            Assert.That(errorText, Is.EqualTo("Invalid email or password. Please try again."));
            Assert.That(driver.Url, Is.EqualTo(baseUrl));
        }
    }
}