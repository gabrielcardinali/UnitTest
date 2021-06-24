using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class OpenTrivia
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            var option = new ChromeOptions()
            {
                BinaryLocation = @"/opt/google/chrome/google-chrome"
            };

            driver = new ChromeDriver(option);
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

        //Funcionalidade: Busca no Banco de Quest�es
        //Cen�rio: Busca por quest�o inexistente
        //Dado que navego para a p�gina de busca do banco de quest�es
        //E digito 'Science: Computers' no campo de busca
        //Quando clico no bot�o de buscar
        //Ent�o visualizo uma mensagem de erro com o texto 'No questions found.'

        [TestMethod]
        public void NoQuestionsFoundTest()
        {
            string validationMessage = "No questions found.";

            driver.Navigate().GoToUrl("https://opentdb.com/");
            driver.FindElement(By.LinkText("BROWSE")).Click();
            driver.FindElement(By.XPath("//body[@id='page-top']/div[2]")).Click();
            driver.FindElement(By.Id("query")).Click();
            driver.FindElement(By.Id("query")).Clear();
            driver.FindElement(By.Id("query")).SendKeys("Science: Computers");
            driver.FindElement(By.XPath("//body[@id='page-top']/div/form/div/button")).Click();

            IWebElement returnMessage = driver.FindElement(By.XPath("//div[@class='alert alert-danger']"));
         
            Assert.AreEqual(validationMessage, returnMessage.Text);

        }


        //Segunda parte

        //Funcionalidade: Busca no Banco de Quest�es
        //Cen�rio: Busca por quest�o inexistente
        //Dado que navego para a p�gina de busca do banco de quest�es
        //E digito 'Science: Computers' no campo de busca e seleciono Category
        //Quando clico no bot�o de buscar
        //Ent�o visualizo a listagem de quest�es com 25 itens e o controle de pagina��o.'

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

            Assert.IsNotNull(driver.FindElement(By.XPath("//*[@id='page-top']/div[2]/table/tbody/tr[25]")));
        }

        //Terceira parte

        //Funcionalidade: login de usu�rio
        //Cen�rio: Valida um usu�rio logado
        //Dado que um usu�rio possua uma conta no sistema
        //E tente acessar a p�gina de login ap�s a inser��o de suas credenciais
        //Quando ele aciona a op��o de realizar login
        //Ent�o ele deve ser redirecionado para a p�gina inicial logado


        // [TestMethod]
        // public void LoginTest()
        // {
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
        // }

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