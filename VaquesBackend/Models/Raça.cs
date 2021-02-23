namespace VaquesBackend.Models {

    public class Raça {
        public static string DESCONEGUDA = "Desconeguda";
        
        public string Nom { get; }
        public double LitresPerKg { get; }

        public Raça(string nom, double litresPerKg) {
            
            this.Nom = (nom == null || string.IsNullOrEmpty(nom)) ? DESCONEGUDA : nom;    	
            this.LitresPerKg = (litresPerKg < 0) ? 0 : litresPerKg; 
                
        }

    }
}