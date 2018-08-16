using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Tests.PageObjects.PageObjects.TheInternet;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pwc.Platform.UITests.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace Test1AdrianM.Definition
{
	[Binding]
	class HerokuSimpleTest
	{
		private readonly DriverContext driverContext;
		private readonly ScenarioContext scenarioContext;
		private HerokuCheckboxesPageObject page;
		private HerokuDropdownPageObject page2;
		private CommonPageObject commonPage;


		public HerokuSimpleTest(ScenarioContext scenarioContext)
		{
			if (scenarioContext == null)
			{
				throw new ArgumentNullException(nameof(scenarioContext));
			}

			this.scenarioContext = scenarioContext;
			this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;

			if (this.page == null || this.commonPage == null || this.page2 == null)
			{
				this.page = new HerokuCheckboxesPageObject(this.driverContext);
				this.commonPage = new CommonPageObject(this.driverContext);
				this.page2 = new HerokuDropdownPageObject(this.driverContext);

			}
		}


		[Given(@"Checkboxes HerokuApp page is opened")]
		public void GivenCheckboxesHerokuAppPageIsOpened()
		{                                                               // czy to tak powinno być wywołane?
			commonPage.NavigateToPage("checkboxes");

		}

		[When(@"I sign checkbox")]
		public void WhenISignCheckbox()
		{
			page.TickCheckboxOne();
		}

		[Then(@"I can see marked checkbox")]
		public void ThenICanSeeMarkedCheckbox()
		{
			Assert.AreEqual(true, page.IsCheckmarkOneTicked);
		}

		[When(@"I unsign checkbox")]
		public void WhenIUnsignCheckbox()
		{
			page.UnTickCheckboxOne();
		}

		[When(@"I unsign second checkbox")]
		public void WhenIUnsignSecondCheckbox()
		{
			page.UnTickCheckboxTwo();
		}

		[Then(@"I can see unmarked checkbox")]
		public void ThenICanSeeUnmarkedCheckbox()
		{
			Assert.AreEqual(false, page.IsCheckmarkOneTicked);
		}

		[Then(@"I can see unmarked checkboxes")]
		public void ThenICanSeeUnmarkedCheckbox2()
		{
			Assert.AreEqual(false, page.IsCheckmarkOneTicked);
			Assert.AreEqual(false, page.IsCheckmarkTwoTicked);

		}

		[Given(@"Dropdown HerokuApp page is opened")]
		public void GivenDropdownHerokuAppPageIsOpened()
		{
			commonPage.NavigateToPage("dropdown");
		}

		[When(@"I choose option number '(.*)' on dropdown")]
		public void WhenIChooseSecondOptionOnDropdown(int option)
		{
			var x = option;
			page2.SelectByIndex(x);
			ScenarioContext.Current["DropdownOption"] = x;

		}

		[Then(@"I can see choosen dropdown value")]
		public void ThenICanSeeChoosenDropdownValue()
		{
			Assert.IsTrue(page2.IsOptionWithTextPresent("Option 2"));
		}


	}
}
