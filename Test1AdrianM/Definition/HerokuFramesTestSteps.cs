using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objectivity.Test.Automation.Common;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Test1AdrianM.PageObject;

namespace Test1AdrianM.Definition
{
		[Binding]
	class HerokuFramesTestSteps
	{
		private readonly DriverContext driverContext;
		private readonly ScenarioContext scenarioContext;
		private HerokuFramesPageObject page;
		private CommonPageObject commonPage;


		public HerokuFramesTestSteps(ScenarioContext scenarioContext)
		{
			if (scenarioContext == null)
			{
				throw new ArgumentNullException(nameof(scenarioContext));
			}

			this.scenarioContext = scenarioContext;
			this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;

			if (this.page == null || this.commonPage == null)
			{
				this.page = new HerokuFramesPageObject(this.driverContext);
				this.commonPage = new CommonPageObject(this.driverContext);

			}
		}


		[Given(@"Move to iFrame page")]
		public void GivenMoveToIFramePage()
		{
			commonPage.NavigateToPage("iframe");
		}

		[When(@"Clear TextField")]
		public void WhenClearTextField()
		{
			page.ClearTextField();
		}

		[When(@"Put in TextField '(.*)'")]
		public void WhenPutInTextField(string exampleText)
		{
			page.WriteText(exampleText);
			ScenarioContext.Current["temporaryText"] = exampleText;
		}

		[Then(@"Verify that text is presented")]
		public void ThenVerifyThatTextIsPresented()
		{
			var x = ScenarioContext.Current["temporaryText"];
			Assert.AreEqual(x,page.VerifyWriteText());
		}



	}
}
