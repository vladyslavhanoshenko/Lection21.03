using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Threading;
using OpenQA;

namespace Lection21._03
{
    [TestFixture]
    public class TestClass
    {
        IWebDriver driver;
        string Task1 = "https://www.toolsqa.com/";
        string Task2 = "http://toolsqa.com/automation-practice-switch-windows/";
        string Task3 = "https://www.w3schools.com/hTml/html_iframe.asp";
        string alertText;



        [TearDown]
        public void Quit()
        {
            driver.Quit();
        }

        [Test]
        public void TestMethod()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Actions action = new Actions(driver);
            driver.Navigate().GoToUrl(Task1);

            WebDriverWait explicitWaits = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement demoSitesButton = explicitWaits.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='tp-bgimg defaultimg ']")));
            //Thread.Sleep(1000);
            IWebElement demosites = driver.FindElement(By.XPath("(//span[contains(@class, 'menu-text')][contains(text(), 'DEMO SITES')][1])"));
            IWebElement switchToPage = driver.FindElement(By.XPath("//li[@class='menu-item menu-item-type-post_type menu-item-object-page menu-item-22593']/a"));


            action.MoveToElement(demosites).Perform();

            switchToPage.Click();


            IWebElement button = driver.FindElement(By.XPath("//div[@class='content']//button[contains(text(),'New Browser Tab')]"));
            button.Click();

            var handles = driver.WindowHandles;
            driver.SwitchTo().Window(handles.Last());

            Assert.AreEqual("QA Automation Tools Tutorial", driver.Title);
            Quit();

            
        }

        [Test]
        public void TestMethod1()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Task2);
            
            IWebElement allertButton = driver.FindElement(By.XPath("//button[@id='timingAlert'][contains(text(),'Timing Alert')]"));
            allertButton.Click();
            bool isAlertPresent = false;
            IAlert alert;
            
            while (!isAlertPresent)
            {
                try
                {
                    alert = driver.SwitchTo().Alert();
                    alertText = driver.SwitchTo().Alert().Text;
                    isAlertPresent = true;
                }
                catch (NoAlertPresentException ex)
                {
                    continue;
                }
            }   
            Assert.AreEqual("Knowledge increases by sharing but not by saving. Please share this website with your friends and in your organization.", alertText);
        }

        [Test]
        public void TestMethod2()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl(Task3);
            IWebElement frame = driver.FindElement(By.XPath("//iframe[@src='default.asp']"));
            driver.SwitchTo().Frame(frame);
            IWebElement nextButton = driver.FindElement(By.XPath("//a[@class='w3-right w3-btn'][contains(text(), 'Next')]"));
            nextButton.Click();

            string titleOfPage = driver.Title;
            IWebElement test1 = driver.FindElement(By.XPath("//h1[contains(text(),'HTML')]/span[contains(text(),'Introduction')]"));

            string titleInIFrame = "HTML"+test1.Text;
            


            Assert.Multiple(() =>
            {
                Assert.AreEqual("HTML Iframes", titleOfPage);
                Assert.AreEqual("HTML Introduction", titleInIFrame);
            });


            
            Thread.Sleep(10000);



        }
        [Test]
        public void InstaCheck()
        {
            string url = "https://www.instagram.com/";
            var options = new ChromeOptions();
            options.AddArgument("--user-agent=Mozilla/5.0 (Linux; Android 7.0; SM-J327T1 Build/NRD90M; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/69.0.3497.100 Mobile Safari/537.36");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Navigate().GoToUrl(url);

            IWebElement regButton = driver.FindElement(By.XPath("//button[@class='_0mzm- sqdOP yWX7d        '][contains(text(), 'Sign up with email or phone number')]"));

            
            regButton.Click();

            IWebElement sw = driver.FindElement(By.XPath("//span[@class='_8r0M_ '][contains(text(), 'Email')]"));

            sw.Click();

            IWebElement input = driver.FindElement(By.XPath("//input[@class='j_2Hd  _4eaDf  _8KKY4  _0mzm- _0mzm- RO68f ']"));
            input.SendKeys("cu22nalila123d@mail.ru");

            IWebElement but = driver.FindElement(By.XPath("//button[@class='_0mzm- sqdOP  L3NKy     cB_4K  ']"));
            but.Click();

            IWebElement IN2 = driver.FindElement(By.XPath("//input[@class='j_2Hd  _4eaDf  _8KKY4  _0mzm- _0mzm- RO68f '][@name='fullName']"));
            IN2.SendKeys("teraf12311a22");

            IWebElement pass = driver.FindElement(By.XPath("//input[@class='j_2Hd  _4eaDf  _8KKY4  _0mzm- _0mzm- RO68f '][@name='password']"));
            pass.SendKeys("test1FFF");

            IWebElement bt33 = driver.FindElement(By.XPath("//button[@class='_0mzm- sqdOP  L3NKy     cB_4K  '][contains(text(),'Next')]"));
            bt33.Click();

            IWebElement btfinal33 = driver.FindElement(By.XPath("//button[@class='_0mzm- sqdOP  L3NKy     cB_4K  '][contains(text(), 'Next')]"));
            btfinal33.Click();
            

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            

            Thread.Sleep(10000000);


        }

          
        }
    }

