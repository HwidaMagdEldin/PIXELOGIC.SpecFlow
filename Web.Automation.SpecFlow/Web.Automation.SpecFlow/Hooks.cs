using System.Configuration;
using TechTalk.SpecFlow;
using Web.Automation.SpecFlow.Helpers;

namespace Web.Automation.SpecFlow
{
    [Binding]
    public sealed class Hooks
    {
        protected static string browserName = ConfigurationManager.AppSettings["browser"];

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver.OpenBrowser(browserName);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
                ScreenShot.TakeScreenShot();            
            Driver.CloseBrowser();
        }
    }
}
