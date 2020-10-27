using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace CalculatorSeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const string url = "http://localhost:3000/";
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            //driver.Manage().Window.Minimize();

            IWebElement input1 = driver.FindElement(By.Id("x"));
            IWebElement input2 = driver.FindElement(By.Id("y"));
            IWebElement selectElement = driver.FindElement(By.Id("operators"));
            var selectObject = new SelectElement(selectElement);

            input1.Clear();
            input1.SendKeys("10");
            input2.Clear();
            input2.SendKeys("10");

            IWebElement button = driver.FindElement(By.Id("equals"));
            button.Click();

            selectObject.SelectByValue("-");
            button.Click();
            Thread.Sleep(2000);

            selectObject.SelectByValue("/");
            button.Click();
            Thread.Sleep(2000);

            selectObject.SelectByValue("*");
            button.Click();
            Thread.Sleep(2000);

            driver.Quit();
        }
    }
}
