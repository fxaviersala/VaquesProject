namespace VaquesBackend.Models
{
    public interface IVaca
    {
        string Nom { get; }
        double Pes { get; }
        IRaça Raça { get; }
        double Litres();
    }
}