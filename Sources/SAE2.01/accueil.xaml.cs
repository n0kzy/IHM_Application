namespace SAE2._01;

public partial class Accueil : ContentPage
{
	public Accueil()
	{
		InitializeComponent();
	}
    private void Hyperlink_MainPage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }

    private  void Hyperlink_CreationCompte(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CreationCompte());
    }

    private void Hyperlink_ConnexionPage(object sender, EventArgs e)
    {
         Navigation.PushAsync(new Connexion());
    }
}