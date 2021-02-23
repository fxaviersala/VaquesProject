using System.Collections.Generic;
using VaquesBackend.Models;

namespace VaquesBackend.Services
{
    public interface ICampService
    {
        double CamioACiutat();
        List<IVaca> getCamio();
        List<IVaca> getCasa();
        List<IVaca> getCiutat();
        void init(int numVaques);
        bool PosaVacaAlCamio(string nom);
        bool PosaVacaAlCamp(string nom);
    }
}