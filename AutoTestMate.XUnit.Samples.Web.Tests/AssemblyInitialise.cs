using AutoTestMate.NUnit.Web.Core;
using NUnit.Framework;

namespace AutoTestMate.NUnit.Samples.Web.Tests
{
    [SetUpFixture]
    public class AssemblyInitialise
    {
        [OneTimeSetUp]
        public void Init()
        {
            WebTestManager.Instance().OnInitialiseAssemblyDependencies(TestContext.Parameters);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            WebTestManager.Instance().OnDisposeAssemblyDependencies();
        }
    }
}
