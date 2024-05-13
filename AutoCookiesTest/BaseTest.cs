using AutoCookies.Pages;
using AutoCookies.Utilities;
using NUnit.Framework;

namespace AutoCookiesTest
{
    [Parallelizable(ParallelScope.All)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class BaseTest
    {
        public Driver Driver;
        
        public MainCookiePage Start(string? profile = "Default")
        {
            Driver = new(profile);
            return MainCookiePage.NavigateTo(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
