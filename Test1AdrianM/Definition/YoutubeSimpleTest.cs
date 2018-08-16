using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objectivity.Test.Automation.Common;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Test1AdrianM.Models;
using Test1AdrianM.PageObject;

namespace Test1AdrianM.Definition
{
	[Binding]
	class YoutubeSimpleTest
	{//NIE WIEM PO CO TO >>>>>
		private readonly DriverContext driverContext;
		private readonly ScenarioContext scenarioContext;
		private YoutubePageObject page;

		public YoutubeSimpleTest(ScenarioContext scenarioContext)
		{
			if (scenarioContext == null)
			{
				throw new ArgumentNullException(nameof(scenarioContext));
			}

			this.scenarioContext = scenarioContext;
			this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;

			if (this.page == null)
			{
				this.page = new YoutubePageObject(this.driverContext);
			}
		}
		[Given(@"Youtube page is opened")]
		public void GivenYoutubePageIsOpened()
		{
			page.NavigateToPage();
		}
		[When(@"I put in search '(.*)' name")]
		public void WhenIPutInSearchName(string companyName)
		{
			page.InputSearch(companyName);
		}

		[When(@"I insert in search name on Youtube")]
		public void WhenIPutInSearchName2(Table table)
		{
			var value = table.CreateInstance<SearchField>();
			page.InputSearch(value.SearchThing);
		}

		[When(@"I insert in search name")]
		public void WhenIInsertInSearchName3(Table table)
		{
			var value = table.CreateSet<SearchField>();

			foreach (var data in value)
			{
				page.InputSearch(data.SearchThing);

			}
		}

		[When(@"I insert in search name (.*)")]
		public void WhenIInsertInSearchName4(string channels)
		{

			page.InputSearch2(channels);
			
		}

		[When(@"I click on search button")]
		public void WhenIClickOnSearchButton()
		{
			page.UseSearchButton();
		}

		[When(@"I choose Objectivity channel")]
		public void WhenIChooseObjectivityChannel()
		{
			page.ChooseObjChannel();
		}

		[When(@"I subscribe channel")]
		public void WhenISubscribeChannel()
		{
			page.SubscribeChannel();
		}

		[Then(@"I can see question If I want to subsrcibe it")]
		public void ThenICanSeeQuestionIfIWantToSubsrcibeIt()
		{
			Assert.AreEqual("Want to subscribe to this channel?", page.ReturnQuestion());
		}
		
		[When(@"I found first movie on Youtube")]
		public void WhenIFoundFirstMovieOnYoutube()
		{
			var x = page.FindFirstMovie();
			ScenarioContext.Current["FirstMovie"] = x;
		}

		[When(@"I put in search Movie")]
		public void WhenIPutInSearch()
		{
			var firstMovie = (string)ScenarioContext.Current["FirstMovie"];
			page.InsertFoundMovie(firstMovie);
		}

		[Then(@"I verify that this movie was opened")]
		public void ThenIVerifyThatThisMovieWasOpened()
		{
			var firstMovie = (string)ScenarioContext.Current["FirstMovie"];
			Assert.AreEqual(firstMovie, page.CheckTitleOfOpenMovie());
		}

		///rzutowanie / konwersje  C# parse



	}
}