namespace Objectivity.Test.Automation.Tests.PageObjects.PageObjects.TheInternet
{
	using Common;
	using Common.Extensions;
	using Common.Types;
	using Common.WebElements;
	using OpenQA.Selenium;
	using OpenQA.Selenium.Support.UI;

	public class HerokuDropdownPageObject : ProjectPageBase
	{
		private readonly ElementLocator dropDownLocator = new ElementLocator(
			Locator.Id, "dropdown");

		public HerokuDropdownPageObject(DriverContext driverContext)
			: base(driverContext)
		{
		}

		public string SelectedText
		{
			get
			{
				var element = this.Driver.GetElement(this.dropDownLocator);
				var select = new SelectElement(element);
				return select.SelectedOption.Text;
			}
		}

		public bool IsOptionWithTextPresent(string optionText)
		{
			var isPresent = false;
			var element = this.Driver.GetElement(this.dropDownLocator);
			var select = new SelectElement(element);
			foreach (var option in select.Options)
			{
				if (optionText.Equals(option.Text))
				{
					isPresent = true;
				}
			}

			return isPresent;
		}

		public void SelectByIndexWithCustomTimeout(int index, int timeout)
		{
			Select select = this.Driver.GetElement<Select>(this.dropDownLocator, timeout);
			select.SelectByIndex(index, timeout);
		}

		public void SelectByIndex(int index)
		{
			Select select = this.Driver.GetElement<Select>(this.dropDownLocator, 300);
			select.SelectByIndex(index, 300);
		}

		public void SelectByValue(string value)
		{
			Select select = this.Driver.GetElement<Select>(this.dropDownLocator, 300);
			select.SelectByValue(value);
		}

		public void SelectByValueWithCustomTimeout(string value, int timeout)
		{
			Select select = this.Driver.GetElement<Select>(this.dropDownLocator, 300);
			select.SelectByValue(value, timeout);
		}

		public void SelectByText(string text)
		{
			Select select = this.Driver.GetElement<Select>(this.dropDownLocator);

			if (select.IsSelectOptionAvailable(text) == false)
			{
				throw new NoSuchElementException("Option with text " + text + " is not present");
			}

			select.SelectByText(text);
		}
	}
}