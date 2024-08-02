using NUnit.Framework;
using TestingTask.Pages;

namespace TestingTask.Tests
{
    public class UserManagementTests : BaseTest
    {
        LoginPage loginPage;
        UserManagementPage userManagementPage;

        [SetUp]
        public void Initialize()
        {
            loginPage = new LoginPage(driver);
            userManagementPage = new UserManagementPage(driver);
            loginPage.Login(loginPage.validEmail, loginPage.validPassword);
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
            userManagementPage.UserAccountsMenu.Click();
            userManagementPage.AddUserBtn.Click();

            string email = HelperMethods.RandomMailGenerator();
            userManagementPage.EmailField.SendKeys(email);
            userManagementPage.UserRoleDropdown.Click();
            userManagementPage.GetUserRoleSelection(userRole).Click();
            userManagementPage.NextBtn.Click();

            userManagementPage.NextButtonMembership.Click();

            userManagementPage.CheckDesktopOption.Click();
            userManagementPage.NextButtonFolders.Click();

            //assert that user is created with correct role in the User Table            
            userManagementPage.UserAccountsMenu.Click();
            Thread.Sleep(2000);
            userManagementPage.SelectRowsPerPage500.Click();
            userManagementPage.GetCreatedUserElement(email).Click();

            Assert.That(userManagementPage.ActualUserRole.Text, Is.EqualTo(userRole));
        }
    }
}