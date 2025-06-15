namespace SAE2._01;

public partial class MainPage : ContentPage
{

    public DataTemplate LocalDataTemplate { get; set; }
    public MainPage()
	{
        InitializeComponent();

        LocalDataTemplate = (DataTemplate)Resources["LocalDataTemplate"];

    }

	private void Hyperlink_Champ(object sender, EventArgs e)
	{
        Navigation.PushAsync(new champions());
    }

    private  void Hyperlink_Carte(object sender, EventArgs e)
    {
       Navigation.PushAsync(new cartes());
    }

    private void Hyperlink_Mode_de_jeu(object sender, EventArgs e)
    {
       Navigation.PushAsync(new mode_de_jeu());
    }
}

