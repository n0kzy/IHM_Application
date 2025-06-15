using SAE2._01.Champions;
using System.Collections.ObjectModel;
using System.Xml.Linq;


namespace SAE2._01
{
    public partial class champions : ContentPage
    {
        private Manager manager;

        public champions()
        {
            InitializeComponent();
            manager = ((App)App.Current).Mgr;
            // R�cup�re l'instance du Manager � partir de l'application globale (App) et l'assigne � la variable manager.
            BindingContext = manager;
        }
         void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string previous = (e.PreviousSelection.FirstOrDefault() as Personnage)?.Name;
            // R�cup�re le nom du Personnage pr�c�demment s�lectionn� en utilisant la propri�t� Name.
            // La s�lection pr�c�dente est obtenue � partir de l'objet SelectionChangedEventArgs.

            string current = (e.CurrentSelection.FirstOrDefault() as Personnage)?.Name;
            // R�cup�re le nom du Personnage actuellement s�lectionn� en utilisant la propri�t� Name.
            // La s�lection actuelle est obtenue � partir de l'objet SelectionChangedEventArgs.

            Navigation.PushAsync(new Ryze());
             //Shell.Current.GoToAsync("PageDetaille");
        }
        private void OnSortPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = SortPicker.SelectedItem as string;

            if (selectedOption == "Nom")
            {
                manager.SortChampionsByName();
            }
            else if (selectedOption == "Poids")
            {
                manager.SortChampionsByScore();
            }
            // Ajoutez d'autres conditions de tri si n�cessaire
        }

        private void AjoutButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ModifierPersonnagePage());
        }


    }

}


