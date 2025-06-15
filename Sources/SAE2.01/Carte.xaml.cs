namespace SAE2._01;

public partial class cartes : ContentPage
{
	public cartes()
	{
		InitializeComponent();
	}

    private void Hyperlink_Carte_du_monde(object sender, EventArgs e)
    {
         Navigation.PushAsync(new Carte_du_monde());
    }

    private void Hyperlink_Carte_faille(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Carte_faille());
    }

    private void Hyperlink_Carte_abime(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Carte_abime());
    }
}