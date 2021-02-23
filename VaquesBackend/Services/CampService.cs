using System.Collections.Generic;
using System.Linq;
using VaquesBackend.Db;
using VaquesBackend.Exceptions;
using VaquesBackend.Models;

namespace VaquesBackend.Services {


    public class CampService : ICampService
    {
        IVaquesRepository servei;

        List<IVaca> Camp;
        List<IVaca> Ciutat;
        Camio camio;

        public CampService()
        {
            this.servei = new MemoryVaquesRepository();
            Camp = servei.GetVaques(6).ToList();
            Ciutat = new List<IVaca>();
            camio = new Camio(1000);
        }

        public CampService(IVaquesRepository servei)
        {
            this.servei = servei;
        }

        public void init(int numVaques)
        {
            try
            {
                Camp = servei.GetVaques(numVaques).ToList();
                camio = new Camio(1000);
                Ciutat = new List<IVaca>();
            }
            catch (VaquesException)
            {

            }
        }

        public List<IVaca> getCasa()
        {
            return Camp;
        }

        public List<IVaca> getCiutat()
        {
            return Ciutat;
        }

        public List<IVaca> getCamio()
        {
            return camio.Vaques;
        }

        public double CamioACiutat()
        {
            double litres = camio.Litres;
            Ciutat.AddRange(camio.Vaques);
            camio.BuidaCamio();
            return litres;
        }

        public bool PosaVacaAlCamio(string nom)
        {
            IVaca vaca = Camp
                    .FirstOrDefault(v => v.Nom.ToLower() == nom.ToLower());
            if (vaca == null)
            {
                throw new VaquesException($"Vaca {nom} no trobada");
            }
            var entra = camio.EntraVaca(vaca);
            if (entra)
            {
                Camp.Remove(vaca);
            }
            return entra;
        }

        public bool PosaVacaAlCamp(string nom)
        {
            IVaca vaca = camio.Vaques
                    .FirstOrDefault(v => v.Nom.ToLower() == nom.ToLower());
            if (vaca == null) return false;
            camio.SurtVaca(vaca);
            Camp.Add(vaca);
            return true;
        }

    }
}