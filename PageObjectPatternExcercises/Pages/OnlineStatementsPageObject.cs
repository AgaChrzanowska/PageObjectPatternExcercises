using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectPatternExcercises.Pages
{
    public class OnlineStatementsPageObject : BasePageObject
    {
        public IWebDriver Driver { get; set; }
        private WebDriverWait _wait;

        [FindsBy(How = How.ClassName, Using = "board-header")]
        public IList<IWebElement> Headers { get; set; }

        [FindsBy(How = How.ClassName, Using = "board-content")]
        public IList<IWebElement> Tables { get; set; }

        [FindsBy(How = How.Id, Using = "os_accountId")]
        public IWebElement FirstHeaderDropdown { get; set; }

        [FindsBy(How = How.ClassName, Using = "control-label")]
        public IWebElement FirstTableText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "ul.nav.nav-pills>li")]
        public IList<IWebElement> YearsList { get; set; }

        [FindsBy(How = How.ClassName, Using = "pull-left")]
        public IWebElement SecondTableText { get; set; }

        [FindsBy(How = How.Id, Using = "os_2012")]
        public IList<IWebElement> RowsFromSecondTable { get; set; }

        [FindsBy(How = How.ClassName, Using = "table-bordered")]
        public IList<IWebElement> YearTables { get; set; }

        public OnlineStatementsPageObject(IWebDriver _driver)
        {
            this.Driver = _driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(_driver, this);
        }

        /// <summary>
        /// Takes specified header name by index:
        /// </summary>
        /// <param name="headerIndex"></param>
        /// <returns></returns>
        public string GetHeaderNameByIndex(int headerIndex)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("board-header")));

            string header = Headers.ElementAt(headerIndex).Text;
            return header;
        }
        public int ClickYearAndGetRowsFromTable(int index)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("ul.nav.nav-pills>li")));
            IWebElement yearTab = YearsList.ElementAt(index);
            yearTab.Click();
            IWebElement yearTable = YearTables.ElementAt(index);
            IList<IWebElement> yearTableRows = yearTable.FindElements(By.CssSelector("tr"));
            return yearTableRows.Count;
        }
    }
}
