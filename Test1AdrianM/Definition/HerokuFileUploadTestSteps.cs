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
	class HerokuFileUploadTestSteps
	{
		private readonly DriverContext driverContext;
		private readonly ScenarioContext scenarioContext;
		private HerokuFileUploadPageObject page;
		private CommonPageObject commonPage;


		public HerokuFileUploadTestSteps(ScenarioContext scenarioContext)
		{
			if (scenarioContext == null)
			{
				throw new ArgumentNullException(nameof(scenarioContext));
			}

			this.scenarioContext = scenarioContext;
			this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;

			if (this.page == null || this.commonPage == null)
			{
				this.page = new HerokuFileUploadPageObject(this.driverContext);
				this.commonPage = new CommonPageObject(this.driverContext);

			}
		}


		[Given(@"Page to upload file is opened")]
		public void GivenPageToUploadFileIsOpened()
		{
			commonPage.NavigateToPage("upload");
		}


		[When(@"I Upload file on page with name: '(.*)'")]
		public void WhenIUploadFileOnPageWithName(string newName)
		{
			ScenarioContext.Current["nameOfFile"] = newName;
			page.UploadFile(newName);
		}

		//[When(@"I Upload file on page with name: '(.)'")]
		//public void WhenIUploadFileOnPage()
		//{
		//	page.UploadFile("NewUploadFileMza");
		//}


		[Then(@"I checked that I upload file")]
		public void ThenICheckedThatIUploadFile()
		{
			var y = (string)ScenarioContext.Current["nameOfFile"];
			Assert.AreEqual("File Uploaded!", page.CheckHeaderUploadFile());
			Assert.AreEqual(y, page.CheckFileUploaded());
		}

	}
}
