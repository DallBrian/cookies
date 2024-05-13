using AutoCookies;

try
{
	App.Instance.Play();
}
catch (Exception ex)
{
	Console.WriteLine(ex.ToString());
}
finally
{
	App.Instance.Save();
	App.Instance.Dispose();
}