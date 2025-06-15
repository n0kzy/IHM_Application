namespace SAE2._01;

public partial class CreationCompte : ContentPage
{

    private void Hyperlink_MainPage(object sender, EventArgs e)
    {
         Navigation.PushAsync(new MainPage());
    }
    public CreationCompte()
	{
		InitializeComponent();
	}
}