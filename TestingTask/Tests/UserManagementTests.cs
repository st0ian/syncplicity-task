using NUnit.Framework;
using OpenQA.Selenium;
using TestingTask.Pages;

namespace TestingTask.Tests
{
    public class UserManagementTests : BaseTest
    {
        LoginPage loginPage;
        UserManagementPage userManagementPage;

        public string randomMailGenerator()
        {
            var randomName = new Random().Next();
            string email = randomName + "@abv.bg";
            return email;
        }

        [SetUp]
        public void Initialize()
        {
            loginPage = new LoginPage(driver);
            userManagementPage = new UserManagementPage(driver);
            loginPage.login();
        }

        //there is redundant whitespace before eDiscovery Administrator role in <li text
        [Test]
        [TestCase("User")]
        [TestCase("Support Administrator")]
        [TestCase("eDiscovery Administrator")]
        [TestCase("Global Administrator")]
        [TestCase("API User")]
        public void CreateUser(string userRole)
        {
            userManagementPage.userAccountsMenu.Click();
            userManagementPage.addUserBtn.Click();

            string email = randomMailGenerator();
            userManagementPage.emailField.SendKeys(email);
            userManagementPage.userRoleDropdown.Click();
            userManagementPage.getUserRoleSelection(userRole).Click();
            userManagementPage.nextBtn.Click();

            userManagementPage.nextButtonMembership.Click();

            userManagementPage.checkDesktopOption.Click();
            userManagementPage.nextButtonFolders.Click();

            //assert that user is created with correct role in the User Table            
            userManagementPage.userAccountsMenu.Click();
            Thread.Sleep(2000);
            userManagementPage.selectRowsPerPage500.Click();
            userManagementPage.getCreatedUserElement(email).Click();

            Assert.That(userManagementPage.actualUserRole.Text, Is.EqualTo(userRole));
        }
    }
}