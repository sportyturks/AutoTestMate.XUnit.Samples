using AutoTestMate.NUnit.Infrastructure.Core;
using AutoTestMate.NUnit.Web.Core;
using AutoTestMate.NUnit.Web.Extensions;
using OpenQA.Selenium;

namespace AutoTestMate.NUnit.Samples.Web.Models
{
    public partial class GoogleSearchPage : BasePage, IGoogleSearchPage
    {
        public GoogleSearchPage(IWebDriver driver, IConfigurationReader configurationReader, ILoggingUtility loggingUtility) : base(driver, configurationReader, loggingUtility)
        {
        }

        public GoogleSearchPage Open()
        {
            Driver.Navigate().GoToUrl(ConfigurationReader.GetConfigurationValue(NUnit.Web.Constants.Configuration.BaseUrlKey));
            return this;
        }

        public GoogleSearchPage AddSearchText(string text)
        {
            SearchTextBox.VisibleWait();
            SearchTextBox.Click();
            SearchTextBox.SendKeys(text);

            return this;
        }

        public GoogleSearchPage ClickSearchForm()
        {
            SearchForm.VisibleWait();
            SearchForm.Click();

            return this;
        }

        public GoogleSearchPage ClickSearchButton()
        {
            SearchButton.VisibleWait();
            SearchButton.Click();

            return this;
        }

    }
}
