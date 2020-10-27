using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace CalculatorTestWithSelenium
{
    [TestClass]
    public class UnitTest1
    {
        const string URL = "http://localhost:3000/";
        IWebDriver driver = new ChromeDriver();

        [TestInitialize]
        public void TestSetUp()
        {
            driver.Navigate().GoToUrl(URL);
        }

        [TestMethod]
        public void TestMethod1()
        {
            IWebElement input1 = driver.FindElement(By.Id("x"));
            IWebElement input2 = driver.FindElement(By.Id("y"));

            input1.SendKeys("20");
            input2.SendKeys("10");

            IWebElement buttonElement = driver.FindElement(By.Id("equals"));
            buttonElement.Click();

            IWebElement resultElement = driver.FindElement(By.Id("result"));
            double result = Double.Parse(resultElement.Text);
            Assert.AreEqual(30, result);

            IWebElement selectElement = driver.FindElement(By.Id("operators"));
            var selectObject = new SelectElement(selectElement);
            selectObject.SelectByValue("-");

            buttonElement.Click();
            result = Double.Parse(resultElement.Text);
            Assert.AreEqual(10, result);


            selectObject.SelectByValue("*");
            buttonElement.Click();

            result = Double.Parse(resultElement.Text);
            Assert.AreEqual(200, result);

            selectObject.SelectByValue("/");

            buttonElement.Click();
            result = Double.Parse(resultElement.Text);
            Assert.AreEqual(2, result);

        }

        [TestCleanup]
        public void TestTearDown()
        {
            driver.Quit();
        }
    }
}
