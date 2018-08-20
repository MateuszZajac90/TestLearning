using NUnit.Framework;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;
using Objectivity.Test.Automation.Tests.PageObjects;
using System;

namespace PageObjects
{
	public class CommonPageObject : ProjectPageBase
	{

		/// <summary>
		/// Locators for elements
		/// </summary>
		
		public CommonPageObject(DriverContext driverContext)
			: base(driverContext)
		{
		}
				
		public void NavigateToPage(string page)
		{
			switch (page.ToLower())
			{
				case "home":
					DriverContext.PerformanceMeasures.StartMeasure();
					Driver.NavigateTo(GetUrl());
					DriverContext.PerformanceMeasures.StopMeasure(TestContext.CurrentContext.Test.Name + "Homepage load time");
					break;
				case "checkboxes":
					Driver.NavigateTo(GetUrl("checkboxes"));
					break;
				case "dropdown":
					Driver.NavigateTo(GetUrl("dropdown"));
					break;
				case "password":
					Driver.NavigateTo(GetUrl("login"));
					break;
				case "download":
					Driver.NavigateTo(GetUrl("download"));
					break;
				case "upload":
					Driver.NavigateTo(GetUrl("upload"));
					break;
				case "iframe":
					Driver.NavigateTo(GetUrl("iframe"));
					break;
				default:
					Assert.IsTrue(false, "Page does not exist");
					break;
			}
		}


		private Uri GetUrl()
		{
			var url = BaseConfiguration.GetUrlValue;
			return new Uri(url);
		}

		private Uri GetUrl(string subpage)
		{
			return new Uri(GetUrl() + subpage);
		}


		public void GoBack()
		{
			Driver.Navigate().Back();
		}

		public void Refresh()
		{
			Driver.Navigate().Refresh();
		}

		public void SwitchToIframe()
		{
			Driver.SwitchTo().Frame(0);
		}

		public void GoBackFromIframe()
		{
			Driver.SwitchTo().DefaultContent();
		}
	}
}
