using SAE2._01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class CustomDictionary : Dictionary<string, Competences>
    {
        /// Implémentation de la méthode Equals du protocole d'égalité
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            CustomDictionary other = (CustomDictionary)obj;

            if (Count != other.Count)
                return false;

            foreach (var pair in this)
            {
                if (!other.ContainsKey(pair.Key) || !other[pair.Key].Equals(pair.Value))
                    return false;
            }

            return true;
        }

        /// Implémentation de la méthode GetHashCode pour la cohérence avec Equals
        public override int GetHashCode()
        {
            int hashCode = 0;

            foreach (var pair in this)
            {
                hashCode ^= pair.Key.GetHashCode() ^ pair.Value.GetHashCode();
            }

            return hashCode;
        }
    }
}
