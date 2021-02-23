using System.Collections.Generic;
using VaquesBackend.Models;

namespace VaquesBackend.Db {
    public interface IVaquesRepository {
        IEnumerable<Vaca> GetVaques(int numVaques);
    }
}