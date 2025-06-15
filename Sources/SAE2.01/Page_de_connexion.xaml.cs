namespace SAE2._01;

public partial class Connexion : ContentPage
{
	public Connexion()
	{
		InitializeComponent();
	}
    private  void Hyperlink_MainPage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}