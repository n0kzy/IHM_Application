using Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.DataContracts;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SAE2._01
{

    [DataContract(Name = "personnage")]
    public class Personnage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;



        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        [DataMember]
        public string Name
        {
            get => name;
            set
            {
                if (name == value)
                    return;
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        [DataMember]
        private string name;

        [DataMember]
        public int Poids
        {
            get => poids;
            set
            {
                if (poids == value)
                    return;
                poids = value;
                OnPropertyChanged(nameof(Poids));
            }
        }
        [DataMember]
        private int poids;

        [DataMember]
        public string ImageUrl
        {
            get => imageurl;
            set
            {
                if (imageurl == value)
                    return;
                imageurl = value;
                OnPropertyChanged(nameof(ImageUrl));
            }
        }
        [DataMember]
        private string imageurl;

        public string Role1
        {
            get => role1;
            set
            {
                if (role1 == value)
                    return;
                role1 = value;
                OnPropertyChanged(nameof(Role1));
            }
        }
        [DataMember(EmitDefaultValue = false)]
        private string role1;

        [DataMember]
        public string Role2
        {
            get => role2;
            set
            {
                if (role2 == value)
                    return;
                role2 = value;
                OnPropertyChanged(nameof(Role2));
            }
        }
        [DataMember(EmitDefaultValue = false)]
        private string role2;



        [DataMember]
        public string Histoire
        {
            get => histoire;
            set
            {
                if (histoire == value)
                    return;
                histoire = value;
                OnPropertyChanged(nameof(Histoire));
            }
        }
        [DataMember(EmitDefaultValue = false)]
        private string histoire;

        [DataMember]
        public Dictionary<string, Competences> dic { get; set; } = new CustomDictionary();

        public Personnage(int poids, string name, string imgurl, string role1, string role2, string histoire, Dictionary<string, Competences> dic)
        {

            this.name = name ?? throw new ArgumentNullException(nameof(name), "Le champ 'name' ne peut pas être null.");
            this.Poids = poids;
            this.imageurl = imgurl ?? throw new ArgumentNullException(nameof(imgurl), "Le champ 'imgurl' ne peut pas être null.");
            this.histoire = histoire ?? string.Empty;
            this.role1 = role1 ?? string.Empty;
            this.role2 = role2 ?? string.Empty;
            this.dic = dic;
        }

    }
}