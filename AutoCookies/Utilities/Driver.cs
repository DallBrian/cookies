using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoCookies.Utilities
{
    public class Driver : IWebDriver
    {
        private readonly IWebDriver driver;

        public Driver(string? profile)
        {
            var options = new ChromeOptions();
            options.ImplicitWaitTimeout = TimeSpan.Zero;
            if (profile is not null)
            {
                options.AddArguments(@"user-data-dir=C:/Repos/SQE Workshop/Cookies/AutoCookies/Data/ChromeProfiles/",
                    $"profile-directory={profile}");
            }

            driver = new ChromeDriver(options);
        }

        public Driver() : this(Properties.Profile)
        {
        }

        #region Implementation of ISearchContext

        public IWebElement FindElement(By by)
        {
            return driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return driver.FindElements(by);
        }

        #endregion

        #region Implementation of IWebDriver

        public void Close()
        {
            driver.Close();
        }

        public void Quit()
        {
            driver.Quit();
        }

        public IOptions Manage()
        {
            return driver.Manage();
        }

        public INavigation Navigate()
        {
            return driver.Navigate();
        }

        public ITargetLocator SwitchTo()
        {
            return driver.SwitchTo();
        }

        public string Url
        {
            get => driver.Url;
            set => driver.Url = value;
        }

        public string Title => driver.Title;

        public string PageSource => driver.PageSource;

        public string CurrentWindowHandle => driver.CurrentWindowHandle;

        public ReadOnlyCollection<string> WindowHandles => driver.WindowHandles;

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            driver.Dispose();
        }

        #endregion
    }
}
