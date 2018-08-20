using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objectivity.Test.Automation.Common;
using PageObjects;
using System;
using TechTalk.SpecFlow;
using Test1AdrianM.PageObject;

namespace Test1AdrianM.Definition
{
		[Binding]
	class HerokuPasswordTestSteps 
	{
		private readonly DriverContext driverContext;
		private readonly ScenarioContext scenarioContext;
		private HerokuPasswordPageObject page;
		private CommonPageObject commonPage;


		public HerokuPasswordTestSteps(ScenarioContext scenarioContext)
		{
			if (scenarioContext == null)
			{
				throw new ArgumentNullException(nameof(scenarioContext));
			}

			this.scenarioContext = scenarioContext;
			this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;

			if (this.page == null || this.commonPage == null)
			{
				this.page = new HerokuPasswordPageObject(this.driverContext);
				this.commonPage = new CommonPageObject(this.driverContext);

			}
		}


		[Given(@"Password page is opened")]
		public void GivenPasswordPageIsOpened()
		{
			commonPage.NavigateToPage("password");
		}

		[When(@"I enter login '(.*)'")]
		public void WhenIEnterLogin(string login)
		{
			page.EnterUserName(login);
		}

		[When(@"I enter super secret password: '(.*)'")]
		public void WhenIEnterSuperSecretPassword(string password)
		{
			page.EnterPassword(password);
		}

		[When(@"I click on log on button")]
		public void WhenIClickOnLogOnButton()
		{
			page.LogOn();
		}


		[Then(@"I checked that I am log in to app")]
		public void ThenICheckedThatIAmLogInToApp()
		{
			var x = page.GetMessage;
			Assert.AreEqual("You logged into a secure area!", page.GetMessage);

		}


	}
}
