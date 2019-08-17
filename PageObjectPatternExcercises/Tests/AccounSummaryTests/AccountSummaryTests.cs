using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectPatternExcercises.Pages;
using PageObjectPatternExcercises.Tests.Login;

namespace PageObjectPatternExcercises.Tests.AccounSummaryTests
{
    [TestClass]
    public class AccountSummaryTests
    {
        private IWebDriver _driver;
        private AccountSummaryPageObject _accountSummaryPageObject;


        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();


            LoginPageObject login = new LoginPageObject(_driver);
            login.Driver.Navigate().GoToUrl(AccountSummaryHelper.Url);
            _accountSummaryPageObject = (AccountSummaryPageObject)login.Login(LoginHelper.UsernameValue, LoginHelper.PasswordValue, ExpectedPageObject.AccountSummaryPageObject);
           
        }

        [TestMethod]
        public void Check_Table_Name()
        {
            // Two alternate ways to check elements.
            Assert.AreEqual(_accountSummaryPageObject.TabAccountSummary.Text, "Account Summary");
            Assert.AreEqual(_accountSummaryPageObject.GetTabAccountSummaryText(), "Account Summary");
        }
       
        [TestMethod]
        public void Get_Tables_Count()
        {
            Assert.AreEqual(_accountSummaryPageObject.TableHeaders.Count, 4);
            Assert.AreEqual(_accountSummaryPageObject.GetTableHeadersCount(), 4);
        }
        [TestMethod]
        public void Check_If_Table_Count_Equals_Headers_Count()
        {
            int tablesCount = _accountSummaryPageObject.GetAccountsTablesCount();
            int headreCount = _accountSummaryPageObject.GetTableHeadersCount();
            //Assert.AreEqual(_accountSummaryPageObject.GetAccountsTablesCount(), _accountSummaryPageObject.GetTableHeadersCount());
            Assert.AreEqual(tablesCount, headreCount);
        }

        [TestMethod]
        public void Check_Numbers_Rows_In_First_Table()
        {
            Assert.AreEqual(3, _accountSummaryPageObject.GetFirstTableRowsCount());
            Assert.AreEqual(2, _accountSummaryPageObject.GetExpectedTableRows(1));
        }
        [TestMethod]
        public void Check_First_Text()
        {
            //WaitHelper.WaitUntilElementsDisplayed(_driver, _accountSummaryPageObject.AccountsTables);

            Assert.AreEqual("Savings", _accountSummaryPageObject.GetTextAtFirstColumnAndFirstRowInFirstTable());
            Assert.AreEqual("Credit Card", _accountSummaryPageObject.GetTableCellText(2, 2, 0));
        }

        [TestCleanup]
        public void Close()
        {
            _driver.Dispose();
        }
    }
}
