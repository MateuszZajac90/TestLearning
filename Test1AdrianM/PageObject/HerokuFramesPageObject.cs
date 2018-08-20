namespace Test1AdrianM.PageObject
{

	using System.Globalization;
	using Objectivity.Test.Automation.Common.Extensions;
	using Objectivity.Test.Automation.Common.Types;
	using NLog;
	using Objectivity.Test.Automation.Common;
	using Objectivity.Test.Automation.Common.Helpers;
	using Objectivity.Test.Automation.Tests.PageObjects;

	public class HerokuFramesPageObject : ProjectPageBase
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		private readonly ElementLocator
			menu = new ElementLocator(Locator.Id, "mceu_14-body"),
			iframe = new ElementLocator(Locator.Id, "mce_0_ifr"),
			elelemtInIFrame = new ElementLocator(Locator.Id, "tinymce");

		public HerokuFramesPageObject(DriverContext driverContext)
			: base(driverContext)
		{
		}

		public string TakeScreenShotsOfTextInIFrame(string folder, string name)
		{
			Logger.Info(CultureInfo.CurrentCulture, "Take Screen Shots");
			var iFrame = this.Driver.GetElement(this.iframe);
			int x = iFrame.Location.X;
			int y = iFrame.Location.Y;
			this.Driver.SwitchTo().Frame(0);
			var el = this.Driver.GetElement(this.elelemtInIFrame);
			return TakeScreenShot.TakeScreenShotOfElement(x, y, el, folder, name);
		}

		public string TakeScreenShotsOfMenu(string folder, string name)
		{
			Logger.Info(CultureInfo.CurrentCulture, "Take Screen Shots");
			var el = this.Driver.GetElement(this.menu);
			return TakeScreenShot.TakeScreenShotOfElement(el, folder, name);
		}
	}
}
