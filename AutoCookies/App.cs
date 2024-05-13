using AutoCookies.Pages;
using AutoCookies.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutoCookies
{
    public class App : IDisposable
	{
		private static App? _app;
		public static App Instance => _app ??= new();

		private App()
		{
			driver = new();
		}
		
		private Driver? driver;
		
		List<Task> GameActions = new();

		public void Play()
		{
			if (driver is null) throw new("Driver cannot be null to Play");
			var page = MainCookiePage.NavigateTo(driver);
			if (page.ChangeLanguageModal.IsDisplayed())
				page.ChangeLanguageModal.EnglishElement.Click();

			GameActions.Add(DoActionContinuously(ClickCookie(page)));
			GameActions.Add(DoActionContinuously(ClickShimmers(page)));
			GameActions.Add(DoActionContinuously(BuyProducts(page)));
			GameActions.Add(DoActionContinuously(BuyUpgrades(page)));

			Task.WaitAll(GameActions.ToArray());
		}
		
		public void Save()
		{
			if (driver is null) throw new("Driver cannot be null to Save");
			new Actions(driver).SendKeys(Keys.LeftControl + "S").Build().Perform();
		}

		public Action ClickCookie(MainCookiePage page)
		{
			return () => page.BigCookie.Click();
		}

		public Action ClickShimmers(MainCookiePage page)
		{
			return () => page.Shimmer.ClickIgnoreException();
		}

		public Action BuyProducts(MainCookiePage page)
		{
			return () => page.Store.Products.LastOrDefault(p => p.CanBuy)?.Click();
		}

		public Action BuyUpgrades(MainCookiePage page)
		{
			return () => page.Store.Upgrades.LastOrDefault(u => u.CanBuy)?.Click();
		}

		public Task DoActionContinuously(Action action)
		{
			var task = new Task(() =>
			{
				//Stop task if it fails three times in a row
				var errorCount = 0;
				while (errorCount < 3)
				{
					try
					{
						action.Invoke();
						errorCount = 0;
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.ToString());
						errorCount++;
					}
				}
			});
			task.Start();
			return task;
		}

		public void Dispose()
		{
			driver?.Quit();
			driver?.Dispose();
		}
	}
}
