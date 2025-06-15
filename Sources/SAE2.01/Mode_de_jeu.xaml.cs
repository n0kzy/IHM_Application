namespace SAE2._01;

public partial class mode_de_jeu : ContentPage
{
	public mode_de_jeu()
	{
		InitializeComponent();
	}

    private  void Hyperlink_Couramment_jouables(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Couramment());
    }


}