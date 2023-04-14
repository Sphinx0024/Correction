namespace Activ.Pointis.Android.PersonnelUI;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void ConnexionClick(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new MainPage());
    }

}