using System.Collections.Generic;
using VaquesBackend.Models;

namespace VaquesBackend.Services
{
    public interface ICampService
    {
        double CamioACiutat();
        List<Vaca> getCamio();
        List<Vaca> getCasa();
        List<Vaca> getCiutat();
        void init(int numVaques);
        bool PosaVacaAlCamio(string nom);
        bool PosaVacaAlCamp(string nom);
    }
}