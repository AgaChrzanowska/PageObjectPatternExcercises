using System;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObjectPatternExcercises.Pages;
using PageObjectPatternExcercises.Tests.Login;

namespace PageObjectPatternExcercises.Tests.OnlineStatementsTests
{
    [TestClass]
    public class OnlineStatementsTests
    {
        private IWebDriver _driver;
        private OnlineStatementsPageObject _onlineStatementsPageObject;
        private WebDriverWait _waiter;

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            LoginPageObject login = new LoginPageObject(_driver);
            login.Driver.Navigate().GoToUrl(OnlineStatementsHelper.Url);
            _onlineStatementsPageObject = (OnlineStatementsPageObject)login.Login(LoginHelper.UsernameValue, LoginHelper.PasswordValue, ExpectedPageObject.OnlineStatementsPageObject);
        }


        [TestMethod]
        public void Check_Number_Headers_And_Tables()
        {
            Assert.AreEqual(_onlineStatementsPageObject.Headers.Count, 1);
            //Can takes value from method or from properties.
            //Assert.AreEqual(_onlineStatementsPageObject.GetNumberHeaders(), 1); 
            Assert.AreEqual(_onlineStatementsPageObject.Tables.Count, 1);
        }

        [TestMethod]
        public void Check_Headers_Names()
        {
            Assert.AreEqual("Statements & Documents", _onlineStatementsPageObject.GetHeaderNameByIndex(0));
            Assert.AreEqual("Account - Savings", _onlineStatementsPageObject.GetHeaderNameByIndex(1));
        }
        [TestMethod]
        public void Check_Text_First_And_Second_Table()
        {
            Assert.AreEqual("Account", _onlineStatementsPageObject.FirstTableText.Text);
            Assert.AreEqual("Recent Statements", _onlineStatementsPageObject.SecondTableText.Text);
        }

        [TestMethod]
        public void Check_Amount_Years()
        {
            //Assert.AreEqual(4, _onlineStatementsPageObject.YearsList.Count());
            int rowsCount = _onlineStatementsPageObject.ClickYearAndGetRowsFromTable(1);
            Assert.AreEqual(3, rowsCount);

        }
        

        [TestCleanup]
        public void Close()
        {
            _driver.Dispose();
        }

    }
}
