using OpenQA.Selenium;
using TestingTask.Constants;

namespace TestingTask.Pages
{
    public class UserManagementPage
    {
        private IWebDriver driver;

        public UserManagementPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SubMenues => driver.FindElement(By.ClassName(LocatorsUserManagementPage.subMenuesLocator));
        public IWebElement UserAccountsMenu => SubMenues.FindElement(By.LinkText(LocatorsUserManagementPage.userAccountsMenuLocator));
        public IWebElement AddUserBtn => driver.FindElement(By.LinkText(LocatorsUserManagementPage.addUserBtnLocator));
        public IWebElement EmailField => driver.FindElement(By.Id(LocatorsUserManagementPage.emailFieldLocator));
        public IWebElement UserRoleDropdown => driver.FindElement(By.Id(LocatorsUserManagementPage.userRoleDropdownLocator));
        public IWebElement NextBtn => driver.FindElement(By.Id(LocatorsUserManagementPage.nextBtnLocator));
        public IWebElement NextButtonMembership => driver.FindElement(By.Id(LocatorsUserManagementPage.nextButtonMembershipLocator));
        public IWebElement CheckDesktopOption => driver.FindElement(By.Id(LocatorsUserManagementPage.checkDesktopOptionLocator));
        public IWebElement NextButtonFolders => driver.FindElement(By.Id(LocatorsUserManagementPage.nextButtonFoldersLocator));
        public IWebElement ActualUserRole => driver.FindElement(By.ClassName(LocatorsUserManagementPage.actualUserRoleLocator));
        public IWebElement SelectRowsPerPage500 => driver.FindElement(By.XPath(LocatorsUserManagementPage.selectRowsPerPage500Locator));

        public IWebElement GetUserRoleSelection(string userRole)
        {
            IWebElement userRoleSelection = driver.FindElement(By.XPath($"//ul[@class='dropdown-menu roles-selector']/li[contains(text(), '{userRole}')]"));
            return userRoleSelection;
        }

        public IWebElement GetCreatedUserElement(string email)
        {
            IWebElement createdUser = driver.FindElement(By.XPath($"//a[text()='{email}']"));
            return createdUser;
        }
    }
}
