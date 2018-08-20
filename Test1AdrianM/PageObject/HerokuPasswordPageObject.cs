using System;
using System.Globalization;
using NLog;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;
using Objectivity.Test.Automation.Tests.PageObjects;
using OpenQA.Selenium;

namespace Test1AdrianM.PageObject
{
	public class HerokuPasswordPageObject : ProjectPageBase
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Locators for elements
		/// </summary>
		private readonly ElementLocator pageHeader = new ElementLocator(Locator.XPath, "//h3[.='Login Page']"),
										userNameForm = new ElementLocator(Locator.CssSelector, "Input[id=username]"),
										passwordForm = new ElementLocator(Locator.CssSelector, "Input[id=password]"),
										loginButton = new ElementLocator(Locator.XPath, "//form[@id='login']/button"),
										message = new ElementLocator(Locator.XPath, "//a[@class='close']/..");

		public HerokuPasswordPageObject(DriverContext driverContext)
			: base(driverContext)
		{
			Logger.Info("Waiting for page to open");
			this.Driver.IsElementPresent(this.pageHeader, BaseConfiguration.ShortTimeout);
		}

		public string GetMessage
		{
			get
			{
				Logger.Info("Try to get message");
				var text = this.Driver.GetElement(this.message, BaseConfiguration.MediumTimeout, 0.1, e => e.Displayed & e.Enabled, "Tying to get welcome message every 0.1 s").Text;
				var index = text.IndexOf("!", StringComparison.Ordinal);
				text = text.Remove(index + 1);
				Logger.Info(CultureInfo.CurrentCulture, "Message '{0}'", text);
				return text;
			}
		}

		public void EnterPassword(string password)
		{
			Logger.Info(CultureInfo.CurrentCulture, "Password '{0}'", password);
			this.Driver.GetElement(this.passwordForm).SendKeys(password);
			this.Driver.WaitForAjax();
		}

		public void EnterUserName(string userName)
		{
			Logger.Info(CultureInfo.CurrentCulture, "User name '{0}'", userName);
			this.Driver.GetElement(this.userNameForm).SendKeys(userName);
		}

		public void LogOn()
		{
			Logger.Info(CultureInfo.CurrentCulture, "Click on Login Button");

			this.Driver.GetElement(this.loginButton).JavaScriptClick();
		}
	}
}