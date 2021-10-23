using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnitTestProject1.Utilities;
using NUnitTestProject1.Variables;

namespace NUnitTestProject1.Pages
{
	public static class Base
	{
		//Enter Text
		public static void EnterText(this IWebElement webElement, string value)
		{
			webElement.SendKeys(value);
		}
		//Get Text
		public static String GetText(this IWebElement webElement)
		{
			string text = webElement.Text;
			return text;
		}
		//Get value from execute javascript
		public static T GetTextFromJS<T>(String element,String type)
		{
			IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)Browser.Driver;
			string js = null;
			if (type == "value")
			{
				js = $"return windown.document.evaluate({element},document,null,XpathResult.FIRST_ORDERED_NODE_TYPE,null).singleNodeValue.value";

			}
			else if (type == "text")
			{
				js = $"return windown.document.evaluate({element},document,null,XpathResult.FIRST_ORDERED_NODE_TYPE,null).singleNodeValue.innerText";

			}
			else if (type == "check")
			{
				js = $"return windown.document.evaluate({element},document,null,XpathResult.FIRST_ORDERED_NODE_TYPE,null).singleNodeValue.checked";
			}
			return (T) javaScriptExecutor.ExecuteScript(js);
		}
		//Click a button, checkbox
		public static void ActionClick(this IWebElement webElement)
		{
			webElement.Click();
		}
		//Select a drop down control, select tag is required to use this function 
		public static void SelectDropdown(this IWebElement webElement, string value)
		{
			new SelectElement(webElement).SelectByText(value);
		}
		//Use action to scroll to element
		public static void ScrollToElement(this IWebElement webElement)
		{
			Actions actions = new Actions(Browser.Driver);
			actions.MoveToElement(webElement);
			actions.Perform();
		}
		//scroll to bottom of page
		public static void ScrollToBottom()
		{
			IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)Browser.Driver;
			javaScriptExecutor.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");
		}
		//scroll to top of page
		public static void ScrollToTop()
		{
			IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)Browser.Driver;
			javaScriptExecutor.ExecuteScript("window.scrollBy(0,0)");
		}
		//scroll to element by scroll of javascript
		public static void ScrollToElementByJS(this IWebElement element)
		{
			IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)Browser.Driver;
			javaScriptExecutor.ExecuteScript("argument[0].scrollIntoView();",element);
		}
		//return element after replacing 
		public static IWebElement ReplaceValueFromElement(string search, string replace, string element, ElementLocator element_type)
		{
			IWebElement webElement = null;
			string element_new = element.Replace(search, replace);
			if (element_type == ElementLocator.Id)
			{
				webElement = Browser.Driver.FindElement(By.Id(element_new));

			}
			else if (element_type == ElementLocator.Name)
			{
				webElement = Browser.Driver.FindElement(By.Name(element_new));
			}
			else if (element_type == ElementLocator.ClassName)
			{
				webElement = Browser.Driver.FindElement(By.ClassName(element_new));
			}
			else if (element_type == ElementLocator.LinkText)
			{
				webElement = Browser.Driver.FindElement(By.LinkText(element_new));

			}
			else if (element_type == ElementLocator.XPath)
			{
				webElement = Browser.Driver.FindElement(By.XPath(element_new));

			}
			else if (element_type == ElementLocator.CssSelector)
			{
				webElement = Browser.Driver.FindElement(By.CssSelector(element_new));

			}
			return webElement;
		}
	}
}
