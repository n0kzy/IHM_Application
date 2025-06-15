using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace SAE2._01
{
    [DataContract]
    public class Competences : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private TypeCompetence _type;
        private string _nom;
        private string _description;

        [DataMember]
        public TypeCompetence Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }

        [DataMember]
        public string Nom
        {
            get => _nom;
            set
            {
                if (_nom != value)
                {
                    _nom = value;
                    OnPropertyChanged(nameof(Nom));
                }
            }
        }

        [DataMember]
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    public Competences(TypeCompetence type , string Nom , string description)
    {
            this.Nom = Nom;
            this.Description = description;
            this.Type = type;

    }
}
}


