using System.Collections.Generic;

namespace VaquesBackend.Models {

    public class Camio {
        private readonly double MaxPes;

        public double PesActual { get; private set;}
        public double Litres { get; private set;}
        public List<IVaca> Vaques { get; }

        public Camio(double maxPes) {
            MaxPes = maxPes;
            PesActual = 0;
            Litres = 0;
            Vaques = new List<IVaca>();
        }

        public bool EntraVaca(IVaca vaca) {
            if (PesActual + vaca.Pes <= MaxPes) {
                PesActual += vaca.Pes;
                Litres += vaca.Litres();
                Vaques.Add(vaca);
                return true;
            }
            return false;
        }

        public void BuidaCamio() {
            PesActual = 0;
            Litres = 0;
            Vaques.Clear();
        }

        public void SurtVaca(IVaca vaca) {
            PesActual -= vaca.Pes;
            Litres -= vaca.Litres();
            Vaques.Remove(vaca);
        }
    }
}