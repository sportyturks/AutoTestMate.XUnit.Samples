using System.Linq;
using OpenQA.Selenium;

namespace AutoTestMate.NUnit.Samples.Web.Models
{
    public partial class GoogleSearchPage
    {
	    public IWebElement SearchTextBox => Driver.FindElement(By.XPath("//div//input[@title='Search']"));

	    public IWebElement ResultSearchButton => Driver.FindElement(By.XPath("//button[@aria-label='Google Search']"));

	    public IWebElement SearchButton => Driver.FindElements(By.XPath("//div//input[@value='Google Search']")).Last();

        public IWebElement SearchFirstItemResult => Driver.FindElement(By.XPath("//div//ul/li[1]"));

        public IWebElement SearchForm => Driver.FindElement(By.Id("searchform"));
    }
}
