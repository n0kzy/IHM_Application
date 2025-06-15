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
            // Récupère l'instance du Manager à partir de l'application globale (App) et l'assigne à la variable manager.
            BindingContext = manager;
        }
         void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string previous = (e.PreviousSelection.FirstOrDefault() as Personnage)?.Name;
            // Récupère le nom du Personnage précédemment sélectionné en utilisant la propriété Name.
            // La sélection précédente est obtenue à partir de l'objet SelectionChangedEventArgs.

            string current = (e.CurrentSelection.FirstOrDefault() as Personnage)?.Name;
            // Récupère le nom du Personnage actuellement sélectionné en utilisant la propriété Name.
            // La sélection actuelle est obtenue à partir de l'objet SelectionChangedEventArgs.

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
            // Ajoutez d'autres conditions de tri si nécessaire
        }

        private void AjoutButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ModifierPersonnagePage());
        }


    }

}


