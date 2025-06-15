using System;


namespace SAE2._01
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifierPersonnagePage : ContentPage
    {
        public ModifierPersonnagePage()
        {
            InitializeComponent();
        }

        private void EnregistrerButton_Clicked(object sender, EventArgs e)
        {
            // Récupérer les nouvelles valeurs des entrées de texte
            int nouveauPoids = 0;
            int.TryParse(PoidsEntry.Text, out nouveauPoids);
            string role1 = Role1Entry.Text;
            string role2 = Role2Entry.Text;
            string histoire = histoireEntry.Text;
            string Image = ImageEntry.Text;
            TypeCompetence type1;
            string Nom1 = Comp1Nom.Text;
            string description1 = Description1.Text;
            TypeCompetence.TryParse(TypeComp1.Text, out type1);
            TypeCompetence type2;
            string Nom2 = Comp2Nom.Text;
            string description2 = Description2.Text;
            TypeCompetence.TryParse(TypeComp2.Text, out type2);
            TypeCompetence type3;
            string Nom3 = Comp3Nom.Text;
            string description3 = Description3.Text;
            TypeCompetence.TryParse(TypeComp3.Text, out type3);
            TypeCompetence type4;
            string Nom4 = Comp4Nom.Text;
            string description4 = Description4.Text;
            TypeCompetence.TryParse(TypeComp4.Text, out type4);
            TypeCompetence type5;
            string Nom5 = Comp5Nom.Text;
            string description5 = Description5.Text;
            TypeCompetence.TryParse(TypeComp5.Text, out type5);

            Personnage selectedPersonnage = ((App)Application.Current).Mgr.SelectedCharacter;
            selectedPersonnage.Poids = nouveauPoids != 0 ? nouveauPoids : selectedPersonnage.Poids;
            selectedPersonnage.Role1 = role1 ?? selectedPersonnage.Role1;
            selectedPersonnage.Role2 = role2 ?? selectedPersonnage.Role2;
            selectedPersonnage.Histoire = histoire ?? selectedPersonnage.Histoire;
            selectedPersonnage.ImageUrl = Image ?? selectedPersonnage.ImageUrl;
            selectedPersonnage.dic["comp1"].Nom = Nom1 ?? selectedPersonnage.dic["comp1"].Nom;
            selectedPersonnage.dic["comp1"].Description = description1 ?? selectedPersonnage.dic["comp1"].Description;
            selectedPersonnage.dic["comp1"].Type = type1 != null ? type1 : selectedPersonnage.dic["comp1"].Type;
            selectedPersonnage.dic["comp2"].Nom = Nom2 ?? selectedPersonnage.dic["comp2"].Nom;
            selectedPersonnage.dic["comp2"].Description = description2 ?? selectedPersonnage.dic["comp2"].Description;
            selectedPersonnage.dic["comp2"].Type = type2 != null ? type2 : selectedPersonnage.dic["comp2"].Type;
            selectedPersonnage.dic["comp3"].Nom = Nom3 ?? selectedPersonnage.dic["comp3"].Nom;
            selectedPersonnage.dic["comp3"].Description = description3 ?? selectedPersonnage.dic["comp3"].Description;
            selectedPersonnage.dic["comp3"].Type = type3 != null ? type3 : selectedPersonnage.dic["comp3"].Type;
            selectedPersonnage.dic["comp4"].Nom = Nom4 ?? selectedPersonnage.dic["comp4"].Nom;
            selectedPersonnage.dic["comp4"].Description = description4 ?? selectedPersonnage.dic["comp4"].Description;
            selectedPersonnage.dic["comp4"].Type = type4 != null ? type4 : selectedPersonnage.dic["comp4"].Type;
            selectedPersonnage.dic["comp5"].Nom = Nom5 ?? selectedPersonnage.dic["comp5"].Nom;
            selectedPersonnage.dic["comp5"].Description = description5 ?? selectedPersonnage.dic["comp5"].Description;
            selectedPersonnage.dic["comp5"].Type = type5 != null ? type5 : selectedPersonnage.dic["comp5"].Type;

            if(selectedPersonnage.dic == null)
            {

            }
            // Mettez à jour les autres attributs du personnage
            ((App)Application.Current).Mgr.UpdateCharacter(selectedPersonnage);
            // Naviguer vers la page précédente (par exemple, PageDetaille)
            Navigation.PopAsync();
        }

        private void AjouterButton_Clicked(object sender, EventArgs e)
        {
            // Récupérer les nouvelles valeurs des entrées de texte
            string Name = NameEntry.Text;
            int nouveauPoids = 0;
            int.TryParse(PoidsEntry.Text, out nouveauPoids);
            string role1 = Role1Entry.Text;
            string role2 = Role2Entry.Text;
            string histoire = histoireEntry.Text;
            string Image = ImageEntry.Text;
            TypeCompetence type1;
            string Nom1 = Comp1Nom.Text;
            string description1 = Description1.Text;
            TypeCompetence.TryParse(TypeComp1.Text, out type1);
            TypeCompetence type2;
            string Nom2 = Comp2Nom.Text;
            string description2 = Description2.Text;
            TypeCompetence.TryParse(TypeComp2.Text, out type2);
            TypeCompetence type3;
            string Nom3 = Comp3Nom.Text;
            string description3 = Description3.Text;
            TypeCompetence.TryParse(TypeComp3.Text, out type3);
            TypeCompetence type4;
            string Nom4 = Comp4Nom.Text;
            string description4 = Description4.Text;
            TypeCompetence.TryParse(TypeComp4.Text, out type4);
            TypeCompetence type5;
            string Nom5 = Comp5Nom.Text;
            string description5 = Description5.Text;
            TypeCompetence.TryParse(TypeComp5.Text, out type5);
            // Récupérez les autres valeurs modifiées des autres entrées de texte
            Dictionary<string, Competences> dic = new Dictionary<string, Competences>();
            dic.Add("comp1", new Competences(type1, Nom1, description1));
            dic.Add("comp2", new Competences(type2, Nom2, description2));
            dic.Add("comp3", new Competences(type3, Nom3, description3));
            dic.Add("comp4", new Competences(type4, Nom4, description4));
            dic.Add("comp5", new Competences(type5, Nom5, description5));
            // Récupérez les autres valeurs modifiées des autres entrées de texte

            // Mettre à jour les attributs du personnage

               Personnage selectedPersonnage = new Personnage(nouveauPoids, Name, Image, role1, role2, histoire, dic);


            // Mettez à jour les autres attributs du personnage
            ((App)Application.Current).Mgr.AddCharacter(selectedPersonnage);

            // Naviguer vers la page précédente (par exemple, PageDetaille)
            Navigation.PopAsync();
        }
    }
}