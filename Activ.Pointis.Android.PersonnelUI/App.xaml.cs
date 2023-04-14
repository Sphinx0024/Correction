namespace Activ.Pointis.Android.PersonnelUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
