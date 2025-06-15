using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace SAE2._01
{
    public class Manager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Personnage> sortedPersonnages;
        private Personnage selectedCharacter;
        public IPersistance Persistance;

        private List<Personnage> loadedPersonnages; // Variable locale pour mettre en cache les personnages

                public Manager(IPersistance persistance)
        {
            this.Persistance = persistance;
            loadedPersonnages = Persistance.LoadData()?.ToList() ?? new List<Personnage>();

            if (loadedPersonnages.Count == 0)
            {
                Persistance.addAllPerso();
                loadedPersonnages = Persistance.LoadData()?.ToList() ?? new List<Personnage>();
            }

            var observableCollection = new ObservableCollection<Personnage>(loadedPersonnages);
            RonlyPerso = new ReadOnlyObservableCollection<Personnage>(observableCollection);
        }

        public void SortChampionsByName()
        {
            RonlyPerso = new ReadOnlyObservableCollection<Personnage>(
                new ObservableCollection<Personnage>(RonlyPerso.OrderBy(p => p.Name))
            );
        }


        public void SortChampionsByScore()
        {
            RonlyPerso = new ReadOnlyObservableCollection<Personnage>(
                new ObservableCollection<Personnage>(RonlyPerso.OrderByDescending(p => p?.Poids ?? 0))
            );
        }
        public void RemoveCharacter(Personnage character)
        {
            if (RonlyPerso.Contains(character))
            {
                var tempList = new List<Personnage>(RonlyPerso);
                tempList.Remove(character);
                RonlyPerso = new ReadOnlyObservableCollection<Personnage>(new ObservableCollection<Personnage>(tempList));
                Persistance.SaveData(RonlyPerso.ToList());
            }
        }

        public void AddCharacter(Personnage character)
        {
            var tempList = new List<Personnage>(RonlyPerso);
            tempList.Add(character);
            RonlyPerso = new ReadOnlyObservableCollection<Personnage>(new ObservableCollection<Personnage>(tempList));
            Persistance.SaveData(RonlyPerso.ToList());
        }

        public void UpdateCharacter(Personnage updatedCharacter)
        {
            var tempList = new List<Personnage>(RonlyPerso);
            var existingCharacter = tempList.FirstOrDefault(p => p.Name == updatedCharacter.Name);
            if (existingCharacter != null)
            {
                int index = tempList.IndexOf(existingCharacter);
                tempList[index] = updatedCharacter;
                RonlyPerso = new ReadOnlyObservableCollection<Personnage>(new ObservableCollection<Personnage>(tempList));
                Persistance.SaveData(RonlyPerso.ToList());
            }
        }

        public Personnage SelectedCharacter
        {
            get => selectedCharacter;
            set
            {
                if (selectedCharacter == value)
                    return;
                selectedCharacter = value;
                OnPropertyChanged(nameof(SelectedCharacter));
            }
        }
        private ReadOnlyObservableCollection<Personnage> _ronlyPerso;
        public ReadOnlyObservableCollection<Personnage> RonlyPerso
        {
            get { return _ronlyPerso; }
            set
            {
                if (_ronlyPerso != value)
                {
                    _ronlyPerso = value;
                    OnPropertyChanged(nameof(RonlyPerso));
                }
            }
        }


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadPersonnages()
        {
            if (RonlyPerso != null)
                return;

            loadedPersonnages = Persistance.LoadData().ToList();

            if (loadedPersonnages.Count == 0)
            {
                Persistance.addAllPerso();
                loadedPersonnages = Persistance.LoadData().ToList();
            }

            var observableCollection = new ObservableCollection<Personnage>(loadedPersonnages);
            RonlyPerso = new ReadOnlyObservableCollection<Personnage>(observableCollection);
        }
    }
}