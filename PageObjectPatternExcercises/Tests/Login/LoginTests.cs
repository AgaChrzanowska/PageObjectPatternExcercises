using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectPatternExcercises.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectPatternExcercises.Tests.Login
{
    [TestClass]
    public class LoginTests
    {
        public IWebDriver _driver;
        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]
        public void EnterToApp_LoginToApp_CheckCorrectnessFunctionality()
        {
            LoginPageObject login = new LoginPageObject(_driver);
            login.Driver.Navigate().GoToUrl(LoginHelper.Url);
            Assert.AreEqual(login.Driver.Url, LoginHelper.Url);
            login.Login(LoginHelper.UsernameValue, LoginHelper.PasswordValue, ExpectedPageObject.AccountSummaryPageObject);
            Assert.AreEqual(login.Driver.Url, LoginHelper.LoggedInUrl);
        }

        [TestMethod]
        public void EnterToApp_LoginToApp_CheckValidation()
        {
            LoginPageObject login = new LoginPageObject(_driver);
            login.Driver.Navigate().GoToUrl(LoginHelper.Url);
            login.Login(LoginHelper.WrongUsernameValue, LoginHelper.WrongPasswordValue, ExpectedPageObject.AccountSummaryPageObject);
            string errorText = login.ErrorBox.Text;
            Assert.IsTrue(login.ErrorBox.Displayed);
            Assert.AreEqual(LoginHelper.WrongLoginMessage, errorText);

        }

        [TestCleanup]
        public void Close()
        {
            _driver.Dispose();
        }
    }
}
