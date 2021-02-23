using System.Collections.Generic;
using VaquesBackend.Models;

namespace VaquesBackend.Db {
    public class MemoryVaquesRepository : IVaquesRepository {

        public static List<Raça> races = new List<Raça>() {
                new Raça("Holstein-Friesian", 0.3),
                new Raça("Jersey", 0.1),
                new Raça("Simental", 0.05),
                new Raça("Ayshire", 0.12),
                new Raça("Guernsey", 0.09)
        };

        public static List<Vaca> vaques = new List<Vaca>() {
                new Vaca("Toñi", 360.3, races[0]),
                new Vaca("Pepa", 250.25, races[1]),
                new Vaca("Flor", 400.5, races[2]),
                new Vaca("Maria", 180.7, races[0]),
                new Vaca("Blanca", 99.8, races[3]),
                new Vaca("Conxi", 201.7, races[0]),
                new Vaca("Guenya", 173.0, races[4]),
                new Vaca("Marta", 280.2, races[2]),
                new Vaca("Manoli", 250.5, races[1]),
                new Vaca("Piguellada", 200.1, races[0]),
                new Vaca("Tigressa", 267, races[1]),            
        };

        public IEnumerable<Vaca> GetVaques(int quantes) 
        {
            List<Vaca> vacalist = new List<Vaca>();
            for(int i=0; i<quantes; i++) {
                if (i>vaques.Count) break;
                vacalist.Add(vaques[i]);
            }
            return vacalist;
        }
    }
}
