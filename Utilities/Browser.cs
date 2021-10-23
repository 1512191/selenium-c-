using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1.Utilities
{
	class Browser
	{
		private static readonly IDictionary<string, IWebDriver> drivers = new Dictionary<string, IWebDriver>();
		private static IWebDriver driver;
		public static IWebDriver Driver
		{
			get
			{
				if (driver == null)
					throw new NullReferenceException("Driver was not initialized. You should first call method InitBrowser");
				return driver;
			}
			private set
			{
				driver = value;
			}
		}
		public static void initBrowser(string browser)
		{
			switch (browser)
			{
				case "Chrome":
					{
						if (driver == null)
						{
							var chromeoptions = new ChromeOptions();
							chromeoptions.AddArgument("start-maximized");
							chromeoptions.AddArgument("test-type");
							chromeoptions.AddArgument("--ignore-certificate-errors");
							chromeoptions.AddArgument("no-sandbox");
							chromeoptions.AddArgument("--disable-extensions");
							//Console.WriteLine(System.Environment.CurrentDirectory);// show current directory
							//chromeoptions.AddArgument("headless");
							driver = new ChromeDriver(@"../../../"+"Drivers/", chromeoptions);
							drivers.Add("Chrome", Driver);
						}
						break;
					}
				case "Firefox":
					{
						if(driver == null)
						{
							driver = new FirefoxDriver();
							drivers.Add("Firefox", Driver);
						}
						break;
					}
			}
		}
		public static void openWebsite(string url)
		{
			Driver.Url = url;
		}
		public static void closeAllBrowsers()
		{
			foreach (var key in drivers.Keys)
			{
				drivers[key].Close();
				drivers[key].Quit();
			}
		}
	}
}
