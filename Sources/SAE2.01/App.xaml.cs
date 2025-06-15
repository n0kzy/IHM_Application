using System.Xml.Serialization;
using System.IO;
namespace SAE2._01;
using System.Runtime.Serialization;
using System.Xml;
public partial class App : Application
{

    public Manager Mgr { get; set; } = new Manager(new Persistance(FileSystem.Current.AppDataDirectory,"personnages.xml"));
    public App()
	{
		InitializeComponent();

        // Définition de MainPage avec une nouvelle instance de AppShell
        MainPage = new AppShell();

        // Enregistrement de la route "Champions" associée à la classe champions dans le routage
        Routing.RegisterRoute("Champions", typeof(champions));


    }

}
