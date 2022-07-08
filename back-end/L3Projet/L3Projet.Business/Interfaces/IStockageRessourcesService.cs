using L3Projet.Common.Models;

namespace L3Projet.Business.Interfaces
{
    public interface IStockageRessourcesService
    {
        IEnumerable<StockageRessources> GetAllStockageRessources();

        bool UpdateRessources(StockageRessources stockaheRessources);

    }
}
