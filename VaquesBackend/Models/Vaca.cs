using System;

namespace VaquesBackend.Models {
    public class Vaca {
        public string Nom { get; }
        public double Pes { get; }
        public Raça Raça { get; }

        public Vaca(string nom, double pes, Raça raça) {
            Nom = nom;
            Pes = pes;
            Raça = raça;
        }

        public double Litres()  {
                return Pes * Raça.LitresPerKg;
        }


        public override string ToString() {
            return "Vaca{" +
                    "nom='" + Nom + '\'' +
                    ", pes=" + Pes +
                    ", raça=" + Raça.Nom +
                    '}';
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else {
                Vaca other = (Vaca) obj;
                return (Nom == other.Nom);
            }
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode() * 1714;
        }
    }
}