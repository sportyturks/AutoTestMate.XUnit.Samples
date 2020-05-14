using AutoTestMate.NUnit.Infrastructure.Attributes;
using AutoTestMate.NUnit.Infrastructure.Core;
using AutoTestMate.NUnit.Samples.Web.Models;
using AutoTestMate.NUnit.Web.Core;
using Castle.MicroKernel.Registration;
using NUnit.Framework;

namespace AutoTestMate.NUnit.Samples.Web.Tests
{
    [TestFixture]
    public class SampleTests : WebTestBase
    {
        public IGoogleSearchPage GoogleSearchPage => TestManager.Container.Resolve<IGoogleSearchPage>();

        [SetUp]
        public override void OnTestInitialise()
        {
            base.OnTestInitialise();

            TestManager.Container.Register(Component.For<IGoogleSearchPage>().ImplementedBy<GoogleSearchPage>().OverridesExistingRegistration().LifestyleTransient());
        }

        [Test]
        [ExcelClosedTestData( @"./Data", "NurseryRhymesBook.xlsx",  "8", "TableThree")]
        public void EnsureCorrectFieldsAccessed()
        {
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("RowKey") == "8");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("FieldSeven") == "Climbed");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("FieldEight") == "Up");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("FieldNine") == "The");
            
            TestContext.WriteLine("Excel Attribute Passed with Flying Colors!");
        }

        [Test]
        [ExcelClosedTestData( @"./Data",  "NurseryRhymesBook.xlsx", "8",  "TableThree")]
        public void GoogleSearchTest()
        {
            var googleSearchPage = GoogleSearchPage;

            googleSearchPage
                .Open()
                .AddSearchText(ConfigurationReader.GetConfigurationValue("FieldSeven"))
                .ClickSearchForm()
                .ClickSearchButton();

            Assert.IsNotNull(ConfigurationReader);
        }
    }
}
