using OpenQA.Selenium;

namespace AutoCookies.Pages
{
	public class OptionsMenu : BaseElement
	{
		public OptionsMenu(IWebDriver driver) : base(driver, By.Id("menu"))
		{
		}
	}
}
