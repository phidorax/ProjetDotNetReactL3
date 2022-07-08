using L3Projet.Common.Models;

namespace L3Projet.Business.Interfaces
{
    public interface IMondesService
    {
        IEnumerable<Monde> GetAllMondes();
        Boolean AddMonde(Monde newWorld);

    }
}
