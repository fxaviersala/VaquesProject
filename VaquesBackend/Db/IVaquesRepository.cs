using System.Collections.Generic;
using VaquesBackend.Models;

namespace VaquesBackend.Db {
    public interface IVaquesRepository {
        IEnumerable<IVaca> GetVaques(int numVaques);
    }
}