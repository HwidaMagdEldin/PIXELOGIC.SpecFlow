using System.Configuration;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

using Web.Automation.SpecFlow.Helpers;
using OpenQA.Selenium.Interactions;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using System;

namespace Web.Automation.SpecFlow.StepDefinitions
{
    [Binding]
    public sealed class WebSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private static string url = ConfigurationManager.AppSettings["URL"];
        private readonly ScenarioContext context;

        public WebSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"I am on Home page")]
        public void GivenIAmOnHomePage()
        {
            Driver.Visit(url);
        }
        [When(@"enter ""(.*)"" into ""(.*)""")]
        public void WhenEnterInto(string text, string textbox)
        {
            Driver.WebDriver.FindElement(By.XPath($"//LABEL[text()='{textbox}']/following-sibling::INPUT")).SendKeys(text);

        }

        [When(@"[Cc]lick on ""(.*)"" Button")]
        public void WhenClickOnButton(string button)
        {
            var jse = (IJavaScriptExecutor)Driver.WebDriver;

            var btn = Driver.WebDriver.FindElement(By.XPath($"//button[contains(text(),'{button}')]"));
            jse.ExecuteScript("arguments[0].scrollIntoView(true);", btn);
            btn.Click();
        }

        [Then(@"I Should see ""(.*)"" message")]
        public void ThenIShouldSeeMessage(string message)
        {
            var wait = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(5000));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath($"//p[contains(text(),'{message}')]")));
            var expectation = Driver.WebDriver.FindElement(By.XPath($"//p[contains(text(),'{message}')]")).Text;
            expectation.Should().Be(message);
        }


    }
}
