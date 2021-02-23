using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using vacawasm.Model;

namespace vacawasm
{
    public class VaquesData : ComponentBase
    {

        public const string RestServer = "http://localhost:4567";
        protected string imatgeCamp = "camp";
        protected string imatgeCamio = "camio";
        protected string imatgeCiutat = "ciutat";

        protected List<Vaca> Camio = new List<Vaca>();
        protected List<Vaca> Camp = new List<Vaca>();
        protected List<Vaca> Ciutat = new List<Vaca>();

        protected int Viatges;
        protected double Litres;

        protected string Error = "";
    }
}
