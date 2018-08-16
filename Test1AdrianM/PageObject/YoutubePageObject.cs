using Objectivity.Test.Automation.Tests.PageObjects;
using System;
using Objectivity.Test.Automation.Common.Types;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;

namespace Test1AdrianM.PageObject
{
	public class YoutubePageObject : ProjectPageBase
	{
		public YoutubePageObject(DriverContext driverContext)
		: base(driverContext)
		{
		}
		private Uri GetUrl()
		{
			var url = BaseConfiguration.GetUrlValue;
			return new Uri(url);
		}

		private readonly ElementLocator
			SearchFieldLocator = new ElementLocator(Locator.CssSelector, "#search"),
			SearchButtonLocator = new ElementLocator(Locator.CssSelector, "#search-icon-legacy > yt-icon"),
			YoutubeChannel = new ElementLocator(Locator.CssSelector, "#channel-title > span"),
			SubscribeButtonLocator = new ElementLocator(Locator.XPath, "(//yt-formatted-string[text()='Subscribe'])[1]"),
			SubscribeQuestionLocator = new ElementLocator(Locator.XPath, "//yt-formatted-string[text()='Want to subscribe to this channel?']"),
			FirsMovieLocator = new ElementLocator(Locator.CssSelector, "#video-title"),
			OpenMovieTitleLocator = new ElementLocator(Locator.CssSelector, "#video-title");
			//asdasdasdasd
		public void NavigateToPage()
		{
					Driver.NavigateTo(GetUrl());
					Driver.Manage().Window.Maximize();
		}
		public void InputSearch(string companyName)
		{
			Driver.GetElement(SearchFieldLocator).SendKeys(companyName);
		}
		public void InputSearch2(string channels)
		{
			Driver.GetElement(SearchFieldLocator).SendKeys(channels);
		}
		public void UseSearchButton()
		{
			Driver.GetElement(SearchButtonLocator).Click();
		}

		public void ChooseObjChannel()
		{
			Driver.GetElement(YoutubeChannel).Click();
		}

		public void SubscribeChannel()
		{
			Driver.GetElement(SubscribeButtonLocator).Click();
		}

		public string ReturnQuestion()
		{
			string question = Driver.GetElement(SubscribeQuestionLocator).Text;
			return question;
		}

		public string FindFirstMovie()
		{
			string firstMovie = Driver.GetElement(FirsMovieLocator).Text;
			return firstMovie;
		}
		public void InsertFoundMovie(string movie)
		{
			Driver.GetElement(SearchFieldLocator).SendKeys(movie);
		}
		public string CheckTitleOfOpenMovie()
		{
			string movieTitle = Driver.GetElement(OpenMovieTitleLocator).Text;
			return movieTitle;
		}
	}
}
