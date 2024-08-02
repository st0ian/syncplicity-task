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
        public IWebElement userAccountsMenu => SubMenues.FindElement(By.LinkText(LocatorsUserManagementPage.userAccountsMenuLocator));
        public IWebElement addUserBtn => driver.FindElement(By.LinkText(LocatorsUserManagementPage.addUserBtnLocator));
        public IWebElement emailField => driver.FindElement(By.Id(LocatorsUserManagementPage.emailFieldLocator));
        public IWebElement userRoleDropdown => driver.FindElement(By.Id(LocatorsUserManagementPage.userRoleDropdownLocator));
        public IWebElement nextBtn => driver.FindElement(By.Id(LocatorsUserManagementPage.nextBtnLocator));
        public IWebElement nextButtonMembership => driver.FindElement(By.Id(LocatorsUserManagementPage.nextButtonMembershipLocator));
        public IWebElement checkDesktopOption => driver.FindElement(By.Id(LocatorsUserManagementPage.checkDesktopOptionLocator));
        public IWebElement nextButtonFolders => driver.FindElement(By.Id(LocatorsUserManagementPage.nextButtonFoldersLocator));
        public IWebElement actualUserRole => driver.FindElement(By.ClassName(LocatorsUserManagementPage.actualUserRoleLocator));
        public IWebElement selectRowsPerPage500 => driver.FindElement(By.XPath(LocatorsUserManagementPage.selectRowsPerPage500Locator));

        public IWebElement getUserRoleSelection(string userRole)
        {
            IWebElement userRoleSelection = driver.FindElement(By.XPath($"//ul[@class='dropdown-menu roles-selector']/li[contains(text(), '{userRole}')]"));
            return userRoleSelection;
        }

        public IWebElement getCreatedUserElement(string email)
        {
            IWebElement createdUser = driver.FindElement(By.XPath($"//a[text()='{email}']"));
            return createdUser;
        }
    }
}
