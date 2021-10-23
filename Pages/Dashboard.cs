using NUnitTestProject1.Utilities;
using OpenQA.Selenium;

using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;


namespace NUnitTestProject1.Pages
{
	class Dashboard
	{
		public Dashboard()
		{

			PageFactory.InitElements(Browser.Driver, this);
		}
		[FindsBy(How=How.XPath,Using = "//div[@id='state']/div")]
		public IWebElement StatusDiv { get; set; }

		private string common_status_option = "//div[@id='state']/././/div[text()='common']";
		public IWebElement StatusOption(string value)
		{
			return Base.ReplaceValueFromElement("common", value, common_status_option, Variables.ElementLocator.XPath);
		}
		public void ChooseValueFromDropdown(string value)
		{
			Base.ScrollToBottom();
			StatusDiv.ActionClick();
			IWebElement option = Base.ReplaceValueFromElement("common", value, common_status_option, Variables.ElementLocator.XPath);
			option.ActionClick();
		}



	}




}
