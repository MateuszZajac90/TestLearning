using Objectivity.Test.Automation.Common;
using PageObjects;
using System;
using TechTalk.SpecFlow;
using Test1AdrianM.PageObject;

namespace Test1AdrianM.Definition
{
	[Binding]
	class HerokuFileDownloadSteps
	{
		private readonly DriverContext driverContext;
		private readonly ScenarioContext scenarioContext;
		private HerokuFileDownloadPageObject page;
		private CommonPageObject commonPage;


		public HerokuFileDownloadSteps(ScenarioContext scenarioContext)
		{
			if (scenarioContext == null)
			{
				throw new ArgumentNullException(nameof(scenarioContext));
			}

			this.scenarioContext = scenarioContext;
			this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;

			if (this.page == null || this.commonPage == null)
			{
				this.page = new HerokuFileDownloadPageObject(this.driverContext);
				this.commonPage = new CommonPageObject(this.driverContext);

			}
		}

		[Given(@"Page to download file is opened")]
		public void GivenPageToDownloadFileIsOpened()
		{
			commonPage.NavigateToPage("download");
		}

		[When(@"I click on any file to download it")]
		public void WhenIClickOnFileToDownloadIt()
		{
			page.SaveFile("some-file.txt", "TESTxyz");
			//problem z pobraniem pliku
		}

		[Then(@"I checked that I download what I choose")]
		public void ThenICheckedThatIDownloadWhatIChoose()
		{
			page.SaveWebDriverScreenShot();
			//	Nie wiem jak zrobić assercję.
		}

	}
}
