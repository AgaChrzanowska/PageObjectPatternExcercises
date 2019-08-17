using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObjectPatternExcercises.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectPatternExcercises.Pages
{
    public class LoginPageObject: BasePageObject
    {
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.Id, Using = "user_login")]
        public IWebElement LoginField { get; set; }

        [FindsBy(How = How.Id, Using = "user_password")]
        public IWebElement PasswordField { get; set; }

        [FindsBy(How = How.Id, Using = "user_remember_me")]
        public IWebElement CheckBox { get; set; }

        [FindsBy(How = How.Name, Using = "submit")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.wrapper > div.container > div > div > div > a")]
        public IWebElement ForgotPasswordLink { get; set; }

        [FindsBy(How = How.ClassName, Using = "alert-error")]
        public IWebElement ErrorBox { get; set; }

        public LoginPageObject(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public BasePageObject Login(string username, string password, ExpectedPageObject expectedPageObject)
        {
            LoginField.SendKeys(username);
            PasswordField.SendKeys(password);
            CheckBox.Click();

            SubmitButton.Click();

            if (expectedPageObject == ExpectedPageObject.AccountSummaryPageObject)
            {
                return new AccountSummaryPageObject(Driver);
            }
            if (expectedPageObject == ExpectedPageObject.OnlineStatementsPageObject)
            {
                return new OnlineStatementsPageObject(Driver);
            }

            throw new ArgumentException("expectedPageObject");
        }
    }
}