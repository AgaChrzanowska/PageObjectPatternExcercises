using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PageObjectPatternExcercises.Pages
{
    public class AccountSummaryPageObject : BasePageObject
    {
        private WebDriverWait _wait;
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.Id, Using = "account_summary_tab")]
        public IWebElement TabAccountSummary { get; set; }
        
        [FindsBy(How = How.TagName, Using = "h2")]
        public IList<IWebElement> TableHeaders { get; set; }

        [FindsBy(How = How.TagName,Using ="table")]
        public IList<IWebElement> AccountsTables { get; set; }

   
        public AccountSummaryPageObject(IWebDriver _driver)
        {
            this.Driver = _driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(_driver, this);
        }
        public string GetTabAccountSummaryText()
        {
            return TabAccountSummary.Text;
        }
        public int GetTableHeadersCount()
        {
            return TableHeaders.Count;
        }
        public int GetAccountsTablesCount()
        {
            return AccountsTables.Count;
        }

        public int GetFirstTableRowsCount()
        {
            IWebElement tableCashAccount = AccountsTables.ElementAt(0); //wyciąmay pierwszą tabelę
            IList<IWebElement> rows = tableCashAccount.FindElements(By.TagName("tr")); //z peirwszej tabeli wyciągmy wiersze
            return rows.Count;

            //zwracamy count wierszy
        }
        public int GetExpectedTableRows(int tableIndex)
        {
            IWebElement expectedTable = AccountsTables.ElementAt(tableIndex);
            IList<IWebElement> rows = expectedTable.FindElements(By.TagName("tr"));
            return rows.Count;
        }
        public string GetTextAtFirstColumnAndFirstRowInFirstTable()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("table")));

            IWebElement tableCashAccount = AccountsTables.ElementAt(0); 
            IList<IWebElement> rows = tableCashAccount.FindElements(By.TagName("tr"));
            IWebElement firstRow = rows.ElementAt(1); // wyciągamy pierwszy wiersz
            IList<IWebElement> columns = firstRow.FindElements(By.TagName("td"));  //wyciągamy pierwszą kolumnę
            IWebElement firstColumn = columns.ElementAt(0);
            return firstColumn.Text;
        }

        /// <summary>
        /// Returns a text in any cell in table based by table index, row index and column index
        /// </summary>
        /// <param name="tableIndex">just a number</param>
        /// <param name="rowIndex">just a number but >= 1</param>
        /// <param name="columnIndex">just a number</param>
        /// <returns>Text in cell</returns>        
        public string GetTableCellText(int tableIndex, int rowIndex, int columnIndex)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("table")));

            IWebElement expectedTable = AccountsTables.ElementAt(tableIndex);
            IList<IWebElement> rows = expectedTable.FindElements(By.TagName("tr"));
            IWebElement expectedRow = rows.ElementAt(rowIndex);
            IList<IWebElement> columns = expectedRow.FindElements(By.TagName("td"));
            IWebElement expectedColumn = columns.ElementAt(columnIndex);
            return expectedColumn.Text;

        }
    }
}