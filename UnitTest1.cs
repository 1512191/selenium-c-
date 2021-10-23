using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using NUnitTestProject1.Pages;
using NUnitTestProject1.Utilities;
using NUnitTestProject1.Variables;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Tests
{
	public class Tests
	{

		[SetUp]
		public void Setup()
		{
			Browser.initBrowser("Chrome");
			ReadExcel.readJsonFile();
			
			Browser.openWebsite(ReadExcel.config.Url);
			
			

		}
		[Test]
		public void verifyPage()
		{
			Dashboard dashboard = new Dashboard();
			dashboard.ChooseValueFromDropdown("NCR");
			Thread.Sleep(1000);
		}
		[TearDown]
		public void Close()
		{
			Browser.closeAllBrowsers();
		}
		//[Test]
		//public void DataDrivenTestingDynamicData(string first_name, string last_name, string end_date)
		//{
		//	IWebDriver driver = new ChromeDriver("Drivers/chromedriver");
		//	driver.Manage().Window.Maximize();
		//	string url = "http://automationpractice.com/index.php";
		//	driver.Url = url;
		//	//driver.Navigate().GoToUrl(url);
		//	//driver.FindElement(By.Id("FirstName")).SendKeys(first_name);
		//	// input[id ^= "email"] // match doan dau
		//	// a[href$="/edit/"] // match doan cuoi
		//	// a[href*="/dashboard/"] // match bat ky
		//	// a[href^="/user/"][href$="/edit/"] ---> ket hop

		//	driver.Quit();
		//}
		//[TestCase]
		//public void Test1()
		//{
		//	Assert.Pass();
		//}
		//[TestCleanUp]
	}
}