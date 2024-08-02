using OpenQA.Selenium;

namespace TestingTask.Pages
{
    public class UserManagementPage
    {
        private IWebDriver driver;

        public UserManagementPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SubMenues => driver.FindElement(By.ClassName("sub-menu"));
        public IWebElement userAccountsMenu => SubMenues.FindElement(By.LinkText("User Accounts"));
        public IWebElement addUserBtn => driver.FindElement(By.LinkText("Add a User"));
        public IWebElement emailField => driver.FindElement(By.Id("txtUserEmails"));
        public IWebElement userRoleDropdown => driver.FindElement(By.Id("roleselect"));
        public IWebElement nextBtn => driver.FindElement(By.Id("nextButtonUserEmails"));
        public IWebElement nextButtonMembership => driver.FindElement(By.Id("nextButtonGroupMembership"));
        public IWebElement checkDesktopOption => driver.FindElement(By.Id("chkDesktop"));
        public IWebElement nextButtonFolders => driver.FindElement(By.Id("nextButtonUserFolders"));
        public IWebElement conformationParagraph => driver.FindElement(By.XPath("//p[@class='createdUsers']"));
        public IWebElement userManagementAccounts => driver.FindElement(By.XPath("//a[contains(.,'Manage user accounts')]"));
        public IWebElement searchField => driver.FindElement(By.XPath("//input[@search='email']"));
        public IWebElement actualUserRole => driver.FindElement(By.ClassName("user-property"));
        public IWebElement selectRowsPerPage => driver.FindElement(By.XPath("//*[@id='MainContent_searchGridControl_itemsOnPage']/option[4]"));
        public IWebElement selectRowsPerPage500 => driver.FindElement(By.XPath("//*[@id='MainContent_searchGridControl_itemsOnPage']/option[5]"));

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
