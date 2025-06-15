using SAE2._01.Champions;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace SAE2._01.Champions
{
    public partial class Ryze : ContentPage
    {



        public Ryze()
        {
            InitializeComponent();
            BindingContext = ((App)App.Current).Mgr;

    }

        private async void Hyperlink_Equipement(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Ryze_equipement());
        }
        private void ModifierButton_Clicked(object sender, EventArgs e)
        {
            // Logique pour la modification du personnage
            Personnage updatedPersonnage = ((App)App.Current).Mgr.SelectedCharacter;

            Navigation.PushAsync(new ModifierPersonnagePage());
            ((App)App.Current).Mgr.UpdateCharacter(updatedPersonnage);
        }

        private void Suppresion_Clicked(object sender, EventArgs e)
        {
            Personnage personnageSupprimer = ((App)Application.Current).Mgr.SelectedCharacter;

            ((App)Application.Current).Mgr.RemoveCharacter(personnageSupprimer);
             Navigation.PopAsync();

        }


    }

}