using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class BookManyHealthcareAppointments
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            var option = new ChromeOptions()
            {
                BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe"
            };

            //option.AddArgument("--headdless");
            driver = new ChromeDriver(option);
            //driver = new ChromeDriver();
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }

        //Primeira parte

        //Funcionalidade: Busca no Banco de Questões
        //Cenário: Busca por questão inexistente
        //Dado que navego para a página de busca do banco de questões
        //E digito 'Science: Computers' no campo de busca
        //Quando clico no botão de buscar
        //Então visualizo uma mensagem de erro com o texto 'No questions found.'

        [TestMethod]
        public void NoQuestionsFoundTest()
        {
            driver.Navigate().GoToUrl("https://opentdb.com/");
            driver.FindElement(By.LinkText("BROWSE")).Click();
            driver.FindElement(By.XPath("//body[@id='page-top']/div[2]")).Click();
            driver.FindElement(By.Id("query")).Click();
            driver.FindElement(By.Id("query")).Clear();
            driver.FindElement(By.Id("query")).SendKeys("Science: Computers");
            driver.FindElement(By.XPath("//body[@id='page-top']/div/form/div/button")).Click();

            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot screenshot = camera.GetScreenshot();
            string cas = DateTime.Now.ToString("dd_MM_yy_HH_mm_ss");

            screenshot.SaveAsFile("C:/Users/bieel/Desktop/Gabriel/TestProject1/TestProject1/bin/Debug/net5.0/ScreenShotsNotFoundTest/" + cas + ".png");
        }


        //Segunda parte

        //Funcionalidade: Busca no Banco de Questões
        //Cenário: Busca por questão inexistente
        //Dado que navego para a página de busca do banco de questões
        //E digito 'Science: Computers' no campo de busca e seleciono Category
        //Quando clico no botão de buscar
        //Então visualizo a listagem de questões com 25 itens e o controle de paginação.'

        [TestMethod]
        public void CategoryTest()
        {
            driver.FindElement(By.LinkText("BROWSE")).Click();
            driver.FindElement(By.XPath("//body[@id='page-top']/div[2]")).Click();
            driver.FindElement(By.Id("query")).Click();
            driver.FindElement(By.Id("query")).Clear();
            driver.FindElement(By.Id("query")).SendKeys("Science: Computers");
            driver.FindElement(By.XPath("//body[@id='page-top']/div/form/div/button")).Click();
            driver.FindElement(By.Id("type")).Click();
            new SelectElement(driver.FindElement(By.Id("type"))).SelectByText("Category");
            driver.FindElement(By.Id("type")).Click();
            driver.FindElement(By.XPath("//body[@id='page-top']/div/form/div/button")).Click();
            driver.FindElement(By.LinkText("2")).Click();
            driver.FindElement(By.LinkText("3")).Click();
            driver.FindElement(By.LinkText("4")).Click();
            driver.FindElement(By.LinkText("5")).Click();
            driver.FindElement(By.LinkText("6")).Click();
            driver.FindElement(By.LinkText("7")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("gabrielcardinali");
            driver.FindElement(By.Id("page-top")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("123456");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot screenshot = camera.GetScreenshot();
            string cas = DateTime.Now.ToString("dd_MM_yy_HH_mm_ss");

            screenshot.SaveAsFile("C:/Users/bieel/Desktop/Gabriel/TestProject1/TestProject1/bin/Debug/net5.0/ScreenShotsCategoryTest/" + cas + ".png");
        }

        //Terceira parte

        //Funcionalidade: login de usuário
        //Cenário: Valida um usuário logado
        //Dado que um usuário possua uma conta no sistema
        //E tente acessar a página de login após a inserção de suas credenciais
        //Quando ele aciona a opção de realizar login
        //Então ele deve ser redirecionado para a página inicial logado


        //[TestMethod]
        //public void LoginTest()
        //{
        //    driver.FindElement(By.LinkText("BROWSE")).Click();
        //    driver.FindElement(By.Id("B")).Clear();
        //    driver.FindElement(By.LinkText("Login")).Click();
        //    driver.FindElement(By.Id("username")).Clear();
        //    driver.FindElement(By.Id("username")).SendKeys("");
        //    driver.FindElement(By.Id("password")).Click();
        //    driver.FindElement(By.Id("password")).Clear();
        //    driver.FindElement(By.Id("password")).SendKeys("");
        //    driver.FindElement(By.XPath("//button[@type='submit']")).Click();

        //    ITakesScreenshot camera = driver as ITakesScreenshot;
        //    Screenshot screenshot = camera.GetScreenshot();
        //    string cas = DateTime.Now.ToString("dd_MM_yy_HH_mm_ss");

        //    screenshot.SaveAsFile("C:/Users/bieel/Desktop/Gabriel/TestProject1/TestProject1/bin/Debug/net5.0/ScreenShotsLoginTest/" + cas + ".png");
        //}

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}