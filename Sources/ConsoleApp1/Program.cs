// See https://aka.ms/new-console-template for more information
using System.Net.NetworkInformation;
using System.Diagnostics;
using System;
using SAE2._01;



User a = new User("Pat", "Bru", 123, "pat@uca");
Competences c = new Competences(TypeCompetence.Passif, "gros cou", "fait mal");
Dictionary<string, Competences> dic = new Dictionary<string, Competences>();
dic.Add("comp1",new Competences(TypeCompetence.Classique, "nom", "description"));
Personnage p = new Personnage(60,"annie","annie.jpg","role1","role2", "histoire",dic);
Objet o = new Objet(1, 1, 1, 11, 1, 1, 1, 1, "aa");





Dictionary<string, Competences> dicAatrox = new Dictionary<string, Competences>()
{
    {"comp1", new Competences(TypeCompetence.Passif, "Posture du massacreur", "Attaque de base inflige des dégâts et se soigne")},
    {"comp2", new Competences(TypeCompetence.Classique, "Épée des Darkin", "Attaque avec une épée jusqu'à 3 fois")},
    {"comp3", new Competences(TypeCompetence.Classique, "Chaînes infernales", "Frappe le sol, ramène les ennemis et leur inflige des dégâts")},
    {"comp4", new Competences(TypeCompetence.Classique, "Ruée obscure", "Se soigne en blessant des champions ennemis")},
    {"comp5", new Competences(TypeCompetence.Ultime, "Fossoyeur des mondes", "Augmente les dégâts, les soins et la vitesse de déplacement")}
};

Dictionary<string, Competences> dicAhri = new Dictionary<string, Competences>()
{
    {"comp1", new Competences(TypeCompetence.Passif, "Vol essentiel", "Récupère des PV après avoir tué des sbires ou des champions")},
    {"comp2", new Competences(TypeCompetence.Classique, "Orbe d'illusion", "Lance un orbe qui inflige des dégâts magiques")},
    {"comp3", new Competences(TypeCompetence.Classique, "Lucioles", "Gagne en vitesse de déplacement et libère des lucioles qui attaquent les ennemis")},
    {"comp4", new Competences(TypeCompetence.Classique, "Charme", "Envoie un baiser qui blesse et charme le premier ennemi touché")},
    {"comp5", new Competences(TypeCompetence.Ultime, "Assaut spirituel", "Rush en avant et inflige des dégâts aux ennemis proches")}
};

Dictionary<string, Competences> dicLux = new Dictionary<string, Competences>()
{
    {"comp1", new Competences(TypeCompetence.Passif, "Illumination", "Dégâts supplémentaires après avoir touché un ennemi avec une compétence")},
    {"comp2", new Competences(TypeCompetence.Classique, "Liandry", "Lance une sphère de lumière qui explose et brûle les ennemis")},
    {"comp3", new Competences(TypeCompetence.Classique, "Barrière prismatique", "Crée un bouclier qui bloque les dégâts et ralentit les ennemis")},
    {"comp4", new Competences(TypeCompetence.Classique, "Entrave de lumière", "Lance un filet qui immobilise les ennemis touchés")},
    {"comp5", new Competences(TypeCompetence.Ultime, "Éclat final", "Invoque un rayon de lumière qui inflige d'importants dégâts")}
};

List<Personnage> testList = new List<Personnage>()
{
    new Personnage(200, "Aatrox", "aatrox1.jpg", "top.png", "mid.png", "Description Aatrox", dicAatrox),
    new Personnage(150, "Ahri", "ahri1.jpg", "mid.png", "top.png", "Description Ahri", dicAhri),
    new Personnage(180, "Lux", "lux1.jpg", "mid.png", "support.png", "Description Lux", dicLux),
    // Ajoutez d'autres personnages
};


var query = from perso in testList
            where perso.Name.StartsWith("a") && perso.Poids is >= 100
            select perso;

foreach (var perso in query)
{
    Debug.WriteLine(perso.Name);
    Debug.WriteLine(perso.Poids);
    Debug.WriteLine(perso.ImageUrl);
    Debug.WriteLine("\n");
}


List <Competences> TestComp = new List<Competences>();
TestComp.Add(new Competences(TypeCompetence.Passif, "peureux", "s'enfuie très rapidement"));
TestComp.Add(new Competences(TypeCompetence.Ultime, "gros cou", "fait mal"));
TestComp.Add(new Competences(TypeCompetence.Classique, "gifle", "mets une gifle puis s'enfuit"));

 var query2 = from comp in TestComp
              where comp.Type == TypeCompetence.Passif
              select comp;
foreach (var comp in query2)
{
    Debug.WriteLine(comp.Nom);
    Debug.WriteLine(comp.Description);
    Debug.WriteLine(comp.Type);
    Debug.WriteLine("\n");
}

List<User> Testusers = new List<User>();
Testusers.Add(new User("Pat", "Bru", 123, "pat@uca"));
Testusers.Add(new User("Bat", "Bru", 235, "bat@uca"));
Testusers.Add(new User("Mat", "Bru", 345, "mat@uca"));
Testusers.Add(new User("Rat", "Bru", 145, "rat@uca"));

 var query3 = from user in Testusers
              where user.Mot_de_passe.CompareTo(123) == 0
              select user;
foreach (var user in query3)
{
    Debug.WriteLine(user.Nom);
    Debug.WriteLine(user.Prenom);
    Debug.WriteLine(user.Mot_de_passe);
    Debug.WriteLine(user.Email);
    Debug.WriteLine("\n");


}
List<Objet> Testobj = new List<Objet>();
Testobj.Add(new Objet(1, 1, 1, 11, 1, 1, 1, 1, "aa"));
Testobj.Add(new Objet(2, 2, 2, 22, 2, 2, 2, 2, "ab"));
Testobj.Add(new Objet(3, 3, 3, 33, 3, 3, 3, 3, "ac"));
Testobj.Add(new Objet(4, 4, 4, 44, 4, 4, 4, 4, "ad"));

var query4 = from obj in Testobj
             where obj.Passif != "aa" && obj.Puissance < 3
             select obj;
foreach (var obj in query4)
{
    Debug.WriteLine(obj.Puissance);
    Debug.WriteLine(obj.Passif);
    Debug.WriteLine(obj.Armure_magique);
    Debug.WriteLine(obj.Vitesse_attaque);
    Debug.WriteLine("\n");


}



Debug.WriteLine($"Prénom: {a.Prenom}, Nom: {a.Nom}, Mot de passe: {a.Mot_de_passe}, Email: {a.Email}");

Debug.WriteLine($"Poids: {p.Poids}, Nom: {p.Name}, Image URL: {p.ImageUrl}");

Debug.WriteLine($"Nom: {c.Nom}, Description: {c.Description}, Type: {c.Type}");
Debug.WriteLine($"Armure: {o.Armure}, Armure magique: {o.Armure_magique}, Puissance: {o.Puissance}");
Debug.WriteLine($"Pourcentage coup critique: {o.Pourcentage_coup_critique}, Pénétration armure: {o.Penetration_armure}");
Debug.WriteLine($"Dégât: {o.Dégât}, Pénétration magique: {o.Penetration_magique}");
