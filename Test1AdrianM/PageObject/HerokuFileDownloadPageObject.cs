﻿namespace Test1AdrianM.PageObject
{
	using System;
	using System.Globalization;
	using System.IO;
	using NLog;
	using Objectivity.Test.Automation.Common;
	using Objectivity.Test.Automation.Common.Extensions;
	using Objectivity.Test.Automation.Common.Helpers;
	using Objectivity.Test.Automation.Common.Types;
	using Objectivity.Test.Automation.Tests.PageObjects;

	public class HerokuFileDownloadPageObject : ProjectPageBase
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Locators for elements
		/// </summary>
		private readonly ElementLocator downloadPageHeader = new ElementLocator(Locator.XPath, "//h3[.='File Downloader']"),
										fileLink = new ElementLocator(Locator.CssSelector, "a[href='download/{0}']");

		public HerokuFileDownloadPageObject(DriverContext driverContext)
			: base(driverContext)
		{
			Logger.Info("Waiting for File Download page to open");
			this.Driver.IsElementPresent(this.downloadPageHeader, BaseConfiguration.ShortTimeout);
		}

		public HerokuFileDownloadPageObject SaveFile(string fileName, string newName)
		{
			if (BaseConfiguration.TestBrowser == BrowserType.Firefox
				|| BaseConfiguration.TestBrowser == BrowserType.Chrome
				|| BaseConfiguration.TestBrowser == BrowserType.RemoteWebDriver)
			{
				this.Driver.GetElement(this.fileLink.Format(fileName), "Click on file").Click();
				FilesHelper.WaitForFileOfGivenName(fileName, this.DriverContext.DownloadFolder, false);
				FilesHelper.RenameFile(fileName, newName, this.DriverContext.DownloadFolder, FileType.Csv);
			}
			else
			{
				Logger.Info(CultureInfo.CurrentCulture, "Downloading files in browser {0} is not supported", BaseConfiguration.TestBrowser);
			}

			return this;
		}

		public HerokuFileDownloadPageObject SaveFile(string newName)
		{
			if (BaseConfiguration.TestBrowser == BrowserType.Firefox
				 || BaseConfiguration.TestBrowser == BrowserType.Chrome
				 || BaseConfiguration.TestBrowser == BrowserType.RemoteWebDriver)
			{
				var filesNumber = FilesHelper.CountFiles(this.DriverContext.DownloadFolder, FileType.Txt);
				this.Driver.GetElement(this.fileLink.Format("some-file.txt")).Click();
				FilesHelper.WaitForFileOfGivenType(FileType.Txt, filesNumber, this.DriverContext.DownloadFolder);
				FileInfo file = FilesHelper.GetLastFile(this.DriverContext.DownloadFolder, FileType.Txt);
				FilesHelper.RenameFile(file.Name, newName, this.DriverContext.DownloadFolder, FileType.Txt);
			}
			else
			{
				Logger.Info(CultureInfo.CurrentCulture, "Downloading files in browser {0} is not supported", BaseConfiguration.TestBrowser);
			}

			return this;
		}

		public HerokuFileDownloadPageObject SaveAnyFile()
		{
			if (BaseConfiguration.TestBrowser == BrowserType.Firefox
				|| BaseConfiguration.TestBrowser == BrowserType.Chrome
				|| BaseConfiguration.TestBrowser == BrowserType.RemoteWebDriver)
			{
				var filesNumber = FilesHelper.CountFiles(this.DriverContext.DownloadFolder);
				this.Driver.GetElement(this.fileLink.Format("ObjectivityTestAutomationCSHarpFramework.txt")).Click();
				FilesHelper.WaitForFile(filesNumber, this.DriverContext.DownloadFolder);
				FileInfo file = FilesHelper.GetLastFile(this.DriverContext.DownloadFolder);
				FilesHelper.RenameFile(BaseConfiguration.ShortTimeout, file.Name, "name_of_file_branch.txt", this.DriverContext.DownloadFolder);
			}
			else
			{
				Logger.Info(CultureInfo.CurrentCulture, "Downloading files in browser {0} is not supported", BaseConfiguration.TestBrowser);
			}

			return this;
		}

		public string CheckIfScreenShotIsSaved(int screenShotNumber)
		{
			Logger.Info(CultureInfo.CurrentCulture, "Number of files {0}", screenShotNumber);
			FilesHelper.WaitForFileOfGivenType(FileType.Png, 10, screenShotNumber, this.DriverContext.ScreenShotFolder, true);
			var nameOfFile = FilesHelper.GetLastFile(this.DriverContext.ScreenShotFolder, FileType.Png);

			return nameOfFile.FullName;
		}

		public string SaveWebDriverScreenShot()
		{
			return this.DriverContext.SaveScreenshot(new ErrorDetail(this.DriverContext.TakeScreenshot(), DateTime.Now, null), this.DriverContext.ScreenShotFolder, this.DriverContext.TestTitle);
		}
	}
}