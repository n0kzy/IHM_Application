using SAE2._01;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using System.Xml;
using System;
using System.IO;
using static System.Console;



namespace SAE2._01
{

    public interface IPersistance
    {
        IEnumerable<Personnage> LoadData();
        void SaveData(List<Personnage> personnages);
        void AddPersonnage(Personnage personnage);
        void addAllPerso();
    }
    public class Persistance :IPersistance
    {
        ///<summary>
        /// Cette variable sera utilisée pour sérialiser et désérialiser des objets dans le format de données spécifié par DataContract.
        ///</summary>
        private DataContractSerializer _serializer;
        private string PersFile { get; }
        private string PersoPath { get; }



        ///<summary>
        /// Propriété calculée qui retourne le chemin complet du fichier de persistance.
        /// Elle combine le chemin du répertoire de persistance (PersoPath) avec le nom du fichier de persistance (PersFile) <summary>
        /// </summary>
        private string FullPersoFile => Path.Combine(PersoPath, PersFile);
        public List<Personnage> personnages;
        ///<summary></summary>
        /// Initialise un nouvel objet Persistance avec le chemin du fichier de persistance et le nom du fichier de persistance fournis.
        /// Crée une instance de DataContractSerializer pour sérialiser et désérialiser des objets de type IEnumerable<Personnage>.
        /// </summary>
        public Persistance(string persoPath, string persFile)
        {
            _serializer = new DataContractSerializer(typeof(IEnumerable<Personnage>));
            PersoPath = persoPath;
            PersFile = persFile;
            personnages = LoadData().ToList(); // Initialisez la variable personnages
        }

        
        public IEnumerable<Personnage> LoadData()
        {
            Directory.SetCurrentDirectory(Path.Combine(PersoPath, "./"));
            var serializer = new DataContractSerializer(typeof(List<Personnage>));
            Personnage p;
            if (File.Exists("personnages.xml"))
            {
                using (FileStream stream2 = File.OpenRead("personnages.xml"))
                {
                    using (XmlDictionaryReader xmlDicoReader = XmlDictionaryReader.CreateBinaryReader(stream2, XmlDictionaryReaderQuotas.Max))
                    {
                        return serializer.ReadObject(stream2) as List<Personnage>;
                    }
                }
            }
            else
            {
                return new List<Personnage>(); // Retourner une liste vide si le fichier n'existe pas
            }
        }

        ///<summary></summary>
        ///permet d'ajouter un personnage à la liste Personnage
        ///</summary>
        public void AddPersonnage(Personnage personnage)
        {

            ///pour qu'on n'ajoute pas de personnage a valeur null dans la liste personnage
            if (personnage != null)
            {
                personnages.Add(personnage);
                SaveData(personnages);
            }
        }
        public void SaveData(List<Personnage> personnages)
        {
           
            Directory.SetCurrentDirectory(Path.Combine(PersoPath,"./"));

            if(File.Exists(PersFile))
            {
                File.Delete(PersFile);
            }
            var serializer = new DataContractSerializer(typeof(List<Personnage>));
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };

            using (TextWriter tw = File.CreateText(PersFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(writer, personnages);
                }
            }
        }

    

        ///<summary>
        ///permet d'ajouter les personnage en appelant la méthode AddPersonnage
        ///</summary>
        public void addAllPerso()
        {
            Dictionary<string, Competences> dicAatrox = new Dictionary<string, Competences>();
            dicAatrox.Add("comp1", new Competences(TypeCompetence.Passif, "Posture du massacreur", "Régulièrement, la prochaine attaque de base d'Aatrox inflige des dégâts physiques supplémentaires et le soigne, selon un pourcentage des PV max de la cible."));
            dicAatrox.Add("comp2", new Competences(TypeCompetence.Classique, "Épée des Darkin", "Aatrox abat son épée devant lui, infligeant des dégâts physiques. Il peut frapper jusqu'à 3 fois et chaque coup a une zone d'effet différente."));
            dicAatrox.Add("comp3", new Competences(TypeCompetence.Classique, "Chaînes infernales", "Aatrox frappe le sol, blessant le premier ennemi touché. Les champions et les grands monstres doivent vite quitter la zone d'effet sous peine d'être ramenés de force au point d'impact et de subir à nouveau les dégâts."));
            dicAatrox.Add("comp4", new Competences(TypeCompetence.Classique, "Ruée obscure", "Passivement, Aatrox se soigne quand il blesse des champions ennemis. À l'activation, il se rue dans une direction."));
            dicAatrox.Add("comp5", new Competences(TypeCompetence.Ultime, "Fossoyeur des mondes", "Aatrox libère sa forme démoniaque, effrayant les sbires ennemis proches et augmentant ses dégâts d'attaque, ses soins et sa vitesse de déplacement. La durée est prolongée s'il participe à l'élimination d'un champion ennemi."));
            Dictionary<string, Competences> dicAhri = new Dictionary<string, Competences>();
            dicAhri.Add("comp1", new Competences(TypeCompetence.Passif, "Vol essentiel", "Après avoir tué 9 sbires ou monstres, Ahri récupère des PV.\r\nAprès avoir participé à l'élimination d'un champion ennemi, Ahri récupère encore plus de PV."));
            dicAhri.Add("comp2", new Competences(TypeCompetence.Classique, "Orbe d'illusion", "Ahri lance son orbe et le ramène vers elle, infligeant des dégâts magiques à l'aller et des dégâts bruts au retour."));
            dicAhri.Add("comp3", new Competences(TypeCompetence.Classique, "Lucioles", "Ahri gagne un bref bonus en vitesse de déplacement et libère trois lucioles qui verrouillent et attaquent les ennemis proches"));
            dicAhri.Add("comp4", new Competences(TypeCompetence.Classique, "Charme", "Ahri envoie un baiser qui blesse et charme le premier ennemi qu'il touche, interrompant immédiatement ses compétences de déplacement et le faisant marcher docilement vers elle."));
            dicAhri.Add("comp5", new Competences(TypeCompetence.Ultime, "Assaut spirituel", "Ahri se rue vers l'avant et tire des traits spirituels, infligeant des dégâts aux ennemis proches. Assaut spirituel peut être lancé jusqu'à 3 fois avant d'entrer en phase de récupération et Ahri gagne des réactivations en participant à l'élimination de champions ennemis."));

            Dictionary<string, Competences> dicAkali = new Dictionary<string, Competences>();
            dicAkali.Add("comp1", new Competences(TypeCompetence.Passif, "Marque d'assassin", "Blesser un champion avec une compétence crée un cercle d'énergie autour de lui. Quitter ce cercle renforce la prochaine attaque d'Akali en augmentant sa portée et ses dégâts."));
            dicAkali.Add("comp2", new Competences(TypeCompetence.Classique, "Vague de kunais", "Akali lance cinq kunais, infligeant des dégâts selon ses dégâts d'attaque supplémentaires et sa puissance et ralentissant les ennemis."));
            dicAkali.Add("comp3", new Competences(TypeCompetence.Classique, "Linceul nébuleux", "Akali crée un nuage de fumée et augmente brièvement sa vitesse de déplacement. Dans ce nuage, Akali est invisible et impossible à cibler. Si elle attaque ou utilise des compétences, elle est temporairement révélée."));
            dicAkali.Add("comp4", new Competences(TypeCompetence.Classique, "Lancer acrobatique", "Fait un salto arrière et lance un shuriken vers l'avant, infligeant des dégâts magiques. Le premier ennemi ou nuage de fumée touché est marqué. Réactivez la compétence pour vous ruer sur la cible marquée et infliger des dégâts supplémentaires."));
            dicAkali.Add("comp5", new Competences(TypeCompetence.Ultime, "Maîtrise absolue", "Akali bondit dans une direction, blessant les ennemis qu'elle frappe. Réactivation : Akali se rue dans une direction, exécutant tous les ennemis qu'elle frappe."));

            Dictionary<string, Competences> dicAkshan = new Dictionary<string, Competences>();
            dicAkshan.Add("comp1", new Competences(TypeCompetence.Passif, "Fourberie", "Tous les trois coups venant de ses attaques ou de ses compétences, Akshan inflige des dégâts supplémentaires. Il gagne aussi un bouclier si la cible est un champion. Quand Akshan attaque, il effectue une attaque supplémentaire qui inflige moins de dégâts. S'il annule l'attaque supplémentaire, il gagne à la place de la vitesse de déplacement."));
            dicAkshan.Add("comp2", new Competences(TypeCompetence.Classique, "Vengerang", "Akshan lance un boomerang qui inflige des dégâts à l'aller et au retour. Sa portée augmente chaque fois qu'il touche un ennemi."));
            dicAkshan.Add("comp3", new Competences(TypeCompetence.Classique, "Cavalier seul", "Passivement, Akshan applique une marque Crapule sur les champions ennemis quand ils tuent des champions alliés. Si Akshan tue une Crapule, il ressuscite les alliés qu'elle a tués, gagne des PO supplémentaires et dissipe toutes les marques. À l'activation, Akshan se camoufle. Il gagne aussi de la vitesse de déplacement et de la régénération du mana quand il se dirige vers des Crapules. Akshan perd rapidement son camouflage quand il est hors des hautes herbes ou loin des éléments de terrain."));
            dicAkshan.Add("comp4", new Competences(TypeCompetence.Classique, "Envolée héroïque", "Akshan tire un grappin sur un élément de terrain et se balance autour. Pendant ce balancement, il tire à répétition sur l'ennemi le plus proche. Percuter un champion ou un élément de terrain le fait tomber de la corde, mais il peut aussi sauter de la corde prématurément."));
            dicAkshan.Add("comp5", new Competences(TypeCompetence.Ultime, "Bien mérité !", "Akshan se verrouille sur un champion ennemi et commence à stocker des balles. Quand il relâche la compétence, il tire toutes les balles stockées et inflige des dégâts selon les PV manquants du premier champion, sbire ou bâtiment touché."));

            Dictionary<string, Competences> dicAlistar = new Dictionary<string, Competences>();
            dicAlistar.Add("comp1", new Competences(TypeCompetence.Passif, "Cri triomphant", "Alistar charge son cri en étourdissant ou en déplaçant des champions ennemis ou quand des ennemis proches meurent. Quand le cri est pleinement chargé, Alistar se soigne et soigne tous les champions alliés proches."));
            dicAlistar.Add("comp2", new Competences(TypeCompetence.Classique, "Atomisation", "Alistar frappe le sol, infligeant des dégâts magiques aux ennemis proches et les projetant dans les airs."));
            dicAlistar.Add("comp3", new Competences(TypeCompetence.Classique, "Coup de tête", "Alistar charge une cible, lui inflige des dégâts et la fait tomber à la renverse."));
            dicAlistar.Add("comp4", new Competences(TypeCompetence.Classique, "Piétinement", "Alistar piétine les unités ennemies proches, ignorant les collisions avec les unités et gagnant un effet s'il blesse un champion ennemi. Au maximum d'effets cumulés, la prochaine attaque de base d'Alistar contre un champion ennemi infligera des dégâts magiques supplémentaires et étourdira la cible."));
            dicAlistar.Add("comp5", new Competences(TypeCompetence.Ultime, "Volonté de fer", "Alistar lâche un puissant rugissement, dissipant tous les effets de contrôle de foule qui l'affectent et réduisant les dégâts physiques et magiques subis pendant la durée d'effet."));

            Dictionary<string, Competences> dicAmumu = new Dictionary<string, Competences>();
            dicAmumu.Add("comp1", new Competences(TypeCompetence.Passif, "Toucher maudit", "Les attaques de base d'Amumu maudissent ses ennemis, leur faisant subir des dégâts bruts supplémentaires chaque fois qu'ils subissent des dégâts magiques."));
            dicAmumu.Add("comp2", new Competences(TypeCompetence.Classique, "Jet de bandelette", "Amumu jette une bandelette collante qui étourdit et blesse l'ennemi touché tandis qu'Amumu s'approche de lui."));
            dicAmumu.Add("comp3", new Competences(TypeCompetence.Classique, "Désespoir", "Saisis par l'angoisse, les ennemis proches perdent chaque seconde un pourcentage de leurs PV max et leurs Malédictions sont actualisées."));
            dicAmumu.Add("comp4", new Competences(TypeCompetence.Classique, "Colère", "Les dégâts physiques subis par Amumu sont réduits. Amumu peut libérer sa rage pour infliger des dégâts aux ennemis proches. Chaque fois qu'Amumu est touché, le délai de récupération de Colère est réduit."));
            dicAmumu.Add("comp5", new Competences(TypeCompetence.Ultime, "Malédiction d'Amumu", "Amumu emmêle les ennemis proches dans des bandelettes, appliquant sa Malédiction, leur infligeant des dégâts et les étourdissant."));

            Dictionary<string, Competences> dicAnivia = new Dictionary<string, Competences>();
            dicAnivia.Add("comp1", new Competences(TypeCompetence.Passif, "Renaissance", "Quand elle subit des dégâts mortels, Anivia se transforme en œuf et revient à la vie avec tous ses PV."));
            dicAnivia.Add("comp2", new Competences(TypeCompetence.Classique, "Lance de glace", "Anivia invoque une sphère de glace qui fonce vers ses adversaires, gelant et blessant tout le monde sur son passage. Quand la sphère explose, quiconque est à proximité est blessé et étourdi."));
            dicAnivia.Add("comp3", new Competences(TypeCompetence.Classique, "Cristallisation", "En utilisant l'humidité de l'air, Anivia invoque un mur de glace impénétrable pour bloquer le passage. Le mur ne dure qu'un court moment avant de fondre."));
            dicAnivia.Add("comp4", new Competences(TypeCompetence.Classique, "Gelure", "D'un mouvement d'ailes, Anivia lance une rafale de vent glacé vers sa cible, infligeant des dégâts. Si la cible a récemment été touchée par Lance de glace ou une Tempête glaciale à taille maximale, les dégâts sont doublés."));
            dicAnivia.Add("comp5", new Competences(TypeCompetence.Ultime, "Tempête glaciale", "Anivia invoque une pluie de glace et de grêle qui blesse ses ennemis et les ralentit."));

            Dictionary<string, Competences> dicAnnie = new Dictionary<string, Competences>();
            dicAnnie.Add("comp1", new Competences(TypeCompetence.Passif, "Pyromanie", "Après qu'Annie a utilisé 4 compétences, sa prochaine compétence offensive étourdit sa cible. Annie commence la partie et réapparaît avec Pyromanie disponible."));
            dicAnnie.Add("comp2", new Competences(TypeCompetence.Classique, "Désintégration", "Annie projette une boule d'énergie magique qui inflige des dégâts ; le coût en mana lui est rendu si l'attaque détruit la cible."));
            dicAnnie.Add("comp3", new Competences(TypeCompetence.Classique, "Incinération", "Annie projette un cône de flammes, infligeant des dégâts à tous les ennemis dans la zone"));
            dicAnnie.Add("comp4", new Competences(TypeCompetence.Classique, "Bouclier en fusion", "Octroie à Annie ou à un allié un bonus en vitesse de déplacement et un bouclier, lequel blesse les ennemis qui lui lancent des attaques ou des compétences."));
            dicAnnie.Add("comp5", new Competences(TypeCompetence.Ultime, "Invocation : Tibbers", "Annie insuffle la vie à son ours Tibbers et inflige des dégâts aux unités dans la zone d'effet. Tibbers peut attaquer et brûle les ennemis proches de lui."));

            Dictionary<string, Competences> dicKayle = new Dictionary<string, Competences>();
            dicKayle.Add("comp1", new Competences(TypeCompetence.Passif, "Ascension divine", "Les attaques de Kayle sont renforcées par les cieux au fur et à mesure qu'elle gagne des niveaux et dépense des points de compétence. Ses ailes s'enflamment tandis qu'elle gagne progressivement de la vitesse d'attaque, de la vitesse de déplacement, de la portée d'attaque et des vagues de feu sur ses attaques."));
            dicKayle.Add("comp2", new Competences(TypeCompetence.Classique, "Incandescence", "Kayle fait apparaître un portail pour tirer une épée céleste qui traverse les ennemis touchés, les ralentissant, les blessant et réduisant leurs résistances."));
            dicKayle.Add("comp3", new Competences(TypeCompetence.Classique, "Bénédiction céleste", "Kayle se soigne et soigne l'allié le plus proche, et tous les deux reçoivent un bonus en vitesse de déplacement."));
            dicKayle.Add("comp4", new Competences(TypeCompetence.Classique, "Lame de feu stellaire", "Passive : l'épée céleste de Kayle, Vertu, inflige des dégâts magiques supplémentaires aux ennemis qu'elle attaque. Active : la prochaine attaque de Kayle déchaîne le feu céleste sur sa cible, infligeant des dégâts supplémentaires en fonction des PV manquants de la cible."));
            dicKayle.Add("comp5", new Competences(TypeCompetence.Ultime, "Jugement divin", "Kayle rend un allié invulnérable et fait appel aux anciennes Manifestations de la Justice pour faire tomber une pluie d'épées purificatrices autour de sa cible."));

            Dictionary<string, Competences> dicRyze = new Dictionary<string, Competences>();
            dicRyze.Add("comp1", new Competences(TypeCompetence.Passif, "Maîtrise des arcanes", "Les sorts de Ryze infligent des dégâts supplémentaires en fonction de son mana supplémentaire, et son mana max est augmenté d'un pourcentage en fonction de sa puissance"));
            dicRyze.Add("comp2", new Competences(TypeCompetence.Classique, "Court-circuit", "Passivement, les autres sorts de base de Ryze réinitialisent le délai de récupération de Court-circuit et chargent une rune. Lorsque Ryze lance Court-circuit avec deux runes chargées, il gagne un bref bonus en vitesse de déplacement.\r\n\r\nÀ l'activation, Ryze tire une décharge de pure énergie en ligne droite, infligeant des dégâts au premier ennemi touché. Si la cible est marquée par Flux, Court-circuit inflige des dégâts supplémentaires et rebondit vers les ennemis proches marqués par Flux."));
            dicRyze.Add("comp3", new Competences(TypeCompetence.Classique, "Prison runique", "Ryze piège une cible dans une prison de runes, lui infligeant des dégâts et ralentissant ses déplacements. Si la cible est marquée par Flux, elle est immobilisée au lieu d'être ralentie."));
            dicRyze.Add("comp4", new Competences(TypeCompetence.Classique, "Flux envoûtant", "Ryze projette un orbe de pure énergie magique qui blesse une cible et marque les ennemis proches de sa cible. Les sorts de Ryze ont des effets supplémentaires sur les ennemis marqués."));
            dicRyze.Add("comp5", new Competences(TypeCompetence.Ultime, "Portail transdimensionnel", "Passivement, Court-circuit inflige des dégâts supplémentaires aux cibles marquées par Flux.\r\n\r\nÀ l'incantation, Ryze ouvre un portail menant à un endroit proche. Quelques secondes plus tard, tous les alliés près du portail sont transportés à l'endroit ciblé."));

            Dictionary<string, Competences> dicYi = new Dictionary<string, Competences>();
            dicYi.Add("comp1", new Competences(TypeCompetence.Passif, "Coup double", "Après plusieurs attaques consécutives, Maître Yi frappe deux fois."));
            dicYi.Add("comp2", new Competences(TypeCompetence.Classique, "Assaut éclair", "Maître Yi se téléporte sur le champ de bataille à la vitesse de l'éclair, infligeant des dégâts physiques à plusieurs unités sur son chemin tout en étant impossible à cibler. Assaut éclair peut infliger des coups critiques et inflige des dégâts physiques supplémentaires aux monstres. Les attaques de base réduisent le délai de récupération d'Assaut éclair."));
            dicYi.Add("comp3", new Competences(TypeCompetence.Classique, "Méditation", "Maître Yi médite, régénérant ses PV chaque seconde et subissant moins de dégâts un court moment. De plus, Maître Yi cumule des effets Coup double et met en pause la durée restante de Style Wuju et de Highlander pour chaque seconde de canalisation."));
            dicYi.Add("comp4", new Competences(TypeCompetence.Classique, "Style Wuju", "Permet aux attaques de base d'infliger des dégâts bruts supplémentaires."));
            dicYi.Add("comp5", new Competences(TypeCompetence.Ultime, "Highlander", "Maître Yi se déplace avec une agilité sans pareille, ce qui augmente ses vitesses de déplacement et d'attaque et le rend temporairement insensible aux effets qui ralentissent. Pendant la durée de l'effet, tuer un champion ou effectuer une assistance prolonge la durée de Highlander. Passivement, tuer un champion ou effectuer une assistance réduit le délai de récupération des autres compétences."));

            AddPersonnage(new Personnage(200, "Aatrox", "aatrox1.jpg", "top.png", "mid.png", "Autrefois, Aatrox et ses frères étaient honorés pour avoir défendu Shurima" +
                " contre le Néant. Mais ils finirent par devenir une menace plus grande encore pour Runeterra : la ruse et la sorcellerie furent employées pour les battre." +
                "Cependant, après des siècles d'emprisonnement, Aatrox fut le premier à retrouver sa liberté, en corrompant et transformant les mortels assez stupides pour tenter" +
                " de s'emparer de l'arme magique qui contenait son essence. Désormais en possession d'un corps qu'il a approximativement transformé pour rappeler son ancienne" +
                " forme, il arpente Runeterra en cherchant à assouvir sa vengeance apocalyptique.",dicAatrox));
            AddPersonnage(new Personnage(150, "Ahri", "ahri1.jpg", "mid.png", "top.png", "Connectée à la magie du royaume spirituel, Ahri est une mystérieuse" +
                " Vastaya aux traits de renard qui peut manipuler les émotions de sa proie et consumer son essence, afin de recevoir des fragments de sa mémoire." +
                " Ahri fut un temps un terrifiant prédateur, mais elle voyage désormais à la recherche des vestiges de ses ancêtres tout en essayant de remplacer" +
                " les souvenirs qu'elle a volés par sa propre expérience de l'existence.",dicAhri));
            AddPersonnage(new Personnage(160, "Akali", "akali1.jpg", "mid.png", "top.png", "Ayant abandonné l'Ordre Kinkou et le titre de Poing de l'ombre, " +
                "Akali combat aujourd'hui seule, prête à devenir l'arme mortelle dont son peuple a besoin. Bien qu'elle n'oublie rien de tout ce que son maître" +
                " Shen lui a enseigné, elle a juré de défendre Ionia contre ses ennemis, une élimination après l'autre. Akali tue sans faire de bruit, mais son " +
                "message est fort et clair : craignez l'assassin sans maître.",dicAkali));
            AddPersonnage(new Personnage(70, "Akshan", "akshan1.jpg", "bot.png", "top.png", "Se jouant du danger, Akshan combat le mal sans jamais se départir de son charisme" +
                " (il ne faut jamais sous-estimer l'importance de la cape) et de sa droiture. Il est passé maître dans l'art du combat furtif, ce qui lui permet d'échapper au" +
                " regard de ses ennemis et de réapparaître lorsqu'ils s'y attendent le moins. À l'aide de son sens aigu de la justice et d'une arme légendaire défiant la mort" +
                " elle-même, il redresse les torts des nombreux vauriens de Runeterra. Sa règle d'or : « ne sois pas crapuleux. »",dicAkshan));
            AddPersonnage(new Personnage(300, "Alistar", "alistar1.jpg", "support.png", "top.png", "Alistar est un guerrier redoutable cherchant à se venger de l'empire " +
                "noxien qui a détruit son clan. Bien qu'il ait été réduit en esclavage et forcé de vivre une vie de gladiateur, sa volonté de fer lui a permis de ne pas succomber" +
                " à la folie bestiale qui le menaçait. Maintenant qu'il a retrouvé la liberté, il combat au nom des faibles et des opprimés. Ses seules armes sont ses cornes," +
                " ses sabots et ses poings.",dicAlistar));
            AddPersonnage(new Personnage(50, "Amumu", "amumu1.jpg", "jungle.png", "top.png", "La légende veut qu'Amumu soit une âme solitaire et mélancolique de la Shurima " +
                "antique et qu'il parcoure le monde à la recherche d'un ami. Condamné par une malédiction à rester seul à jamais, il provoque la mort et la ruine à chaque " +
                "geste d'affection. Ceux qui prétendent l'avoir vu le décrivent comme un cadavre vivant, petit de taille, enveloppé dans d'effrayants bandages. Il a inspiré " +
                "bien des mythes, des chansons et des légendes, transmis de génération en génération pendant si longtemps qu'il est désormais impossible de démêler le vrai du faux."
                ,dicAmumu));
            AddPersonnage(new Personnage(350, "Anivia", "anivia1.jpg", "mid.png", "support.png", "Anivia est un esprit ailé bienveillant qui subit des cycles sans fin de vie," +
                " de mort et de renaissance pour protéger Freljord. Demi-déesse née de la glace la plus froide et des vents les plus coupants, elle utilise ses" +
                " pouvoirs élémentaires contre quiconque prétend troubler la paix de sa terre natale. Anivia guide et protège les tribus du Nord, qui la vénèrent comme " +
                "un symbole d'espoir et la promesse de grands changements. Elle combat de tout son être, sachant que son sacrifice fera vivre sa légende et qu'elle renaîtra" +
                " dans un lendemain nouveau.",dicAnivia));
            AddPersonnage(new Personnage(60, "Annie", "annie.jpg", "mid.png", "support.png", "Dangereuse, incroyablement précoce, Annie est une enfant mage dotée" +
                " d'extraordinaires pouvoirs de pyrokinésie. Même à l'ombre des montagnes du nord de Noxus, sa magie est un cas unique. Son affinité naturelle avec le" +
                " feu se manifesta dès sa prime enfance à travers des explosions émotionnelles imprévisibles, même si elle apprit rapidement à contrôler ces éclats." +
                "Parmi ses jeux favoris, elle aime invoquer son bien-aimé ours en peluche, Tibbers, sous la forme d'un protecteur enflammé." +
                " Perdue dans l'innocence perpétuelle de l'enfance, Annie sautille dans les forêts obscures, à la recherche de quelqu'un avec qui jouer.",dicAnnie));
            AddPersonnage(new Personnage(210, "Kayle", "kayle.jpg", "top.png", "mid.png", "Née d'une Manifestation targonienne au plus fort des Guerres runiques," +
            "Kayle honore l'héritage de sa mère en combattant pour la justice, portée par des ailes de feu divin. Elle et sa sœur jumelle Morgana ont longtemps été" +
            "les protectrices de Demacia. Mais Kayle fut déçue par les trop nombreuses faiblesses des mortels et elle abandonna le royaume. Pourtant, d'après les légendes," +
            "elle punit toujours l'iniquité avec ses lames de feu, et beaucoup attendent avec espoir son retour…",dicKayle));
            AddPersonnage(new Personnage(175, "Ryze", "ryze.jpg", "mid.png", "top.png", "Ryze est un archimage ancien et endurci avec un fardeau incroyablement " +
                "lourd à porter. Armé d'un immense pouvoir arcanique et d'une constitution illimitée, il chasse inlassablement les runes du monde, des fragments de" +
                " la magie brute qui a autrefois façonné le monde à partir du néant. Il doit récupérer ces artefacts avant qu'ils ne tombent entre de " +
                "mauvaises mains, car Ryze comprend les horreurs qu'ils pourraient déclencher sur Runeterra.",dicRyze));
            AddPersonnage(new Personnage(170, "Yi", "yi.jpg", "jungle.png", "top.png", "Maître Yi a renforcé son corps et affûté son esprit jusqu'à ce que réflexion " +
                "et action ne fassent plus qu'un. Bien qu'il ne fasse appel à la violence qu'en dernier recours, la grâce et la vitesse avec lesquelles il manie son " +
                "épée assurent une résolution rapide de tout conflit. En tant que l'un des derniers praticiens vivants de l'art martial ionien appelé Wuju, Yi a voué " +
                "sa vie à perpétuer l'héritage de son peuple, scrutant les nouveaux disciples potentiels à l'aide des Sept lentilles d'éveil pour identifier les plus " +
                "dignes de recevoir son enseignement.",dicYi));

            SaveData(personnages);
        }

    }


}