using OpenQA.Selenium;

namespace AutoCookies.Pages
{
    public class CookiesTitle : BaseElement
	{
		public CookiesTitle(IWebDriver driver) : base(driver, By.Id("cookies"))
		{
		}

		private BaseElement CookiesPerSecond => new(this, By.Id("cookiesPerSecond"));

		public int Count => int.Parse(Text.Split(' ')[0]);

		public int Cps => int.Parse(CookiesPerSecond.Text.Replace("per second: ", ""));
	}
}
