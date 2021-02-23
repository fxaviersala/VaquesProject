namespace vacawasm.Model
{
    public class Vaca
    {
        public Vaca()
        {

        }

        public string Nom { get; set; }
        public double Pes { get; set; }

        public Raça Raça { get; set; }

        public double GetDiners()
        {
            return Pes * Raça.LitresPerKg;
        }
    }

    public class Raça
    {
        public string Nom { get; set; }
        public double LitresPerKg { get; set; }
    }
}

