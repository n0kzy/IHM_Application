namespace SAE2._01;

public partial class CustomHeader : ContentView
{
    public CustomHeader()
    {
        InitializeComponent();
    }
     void Hyperlink_profil(object sender, EventArgs e)
    {
         Navigation.PushAsync(new profil());
    }
}