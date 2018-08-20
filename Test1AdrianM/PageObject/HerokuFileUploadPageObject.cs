using System;
using System.Globalization;
using System.IO;
using NLog;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Helpers;
using Objectivity.Test.Automation.Common.Types;
using Objectivity.Test.Automation.Tests.PageObjects;

namespace Test1AdrianM.PageObject
{
	class HerokuFileUploadPageObject : ProjectPageBase
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Locators for elements
		/// </summary>
		private readonly ElementLocator uploadPageHeader = new ElementLocator(Locator.XPath, "//h3[.='File Uploader']"),
										fileUpload = new ElementLocator(Locator.Id, "file-upload"),
										fileSumbit = new ElementLocator(Locator.Id, "file-submit"),
										fileUploadedPageHeader = new ElementLocator(Locator.XPath, "//h3[.='File Uploaded!']"),
										namefileUploaded = new ElementLocator(Locator.XPath, "//*[@id='uploaded-files']");

		public HerokuFileUploadPageObject(DriverContext driverContext)
			: base(driverContext)
		{
			Logger.Info("Waiting for File Upload page to open");
			this.Driver.IsElementPresent(this.uploadPageHeader, BaseConfiguration.ShortTimeout);
		}

		public HerokuFileUploadPageObject UploadFile(string newName)
		{
			if (BaseConfiguration.TestBrowser == BrowserType.Firefox
				|| BaseConfiguration.TestBrowser == BrowserType.Chrome
				|| BaseConfiguration.TestBrowser == BrowserType.RemoteWebDriver)
			{
				newName = FilesHelper.CopyFile(BaseConfiguration.ShortTimeout, "mateuszZ3.txt", newName, this.DriverContext.DownloadFolder);
				this.Driver.GetElement(this.fileUpload).SendKeys(this.DriverContext.DownloadFolder + "\\" + newName);
				this.Driver.GetElement(this.fileSumbit).Click();
				this.Driver.IsElementPresent(this.fileUploadedPageHeader, BaseConfiguration.ShortTimeout);
			}
			else
			{
				Logger.Info(CultureInfo.CurrentCulture, "Uploading files in browser {0} is not supported", BaseConfiguration.TestBrowser);
			}


			return this;
		}

		public string CheckHeaderUploadFile()
			{
			return this.Driver.GetElement(fileUploadedPageHeader).Text;
			}

		public string CheckFileUploaded()
		{
			return this.Driver.GetElement(namefileUploaded).Text;
		}


	}
}
