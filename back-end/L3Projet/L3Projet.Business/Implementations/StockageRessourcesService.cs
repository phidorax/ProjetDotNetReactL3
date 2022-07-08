using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;

namespace L3Projet.Business.Implementations
{
    public class StockageRessourcesService : IStockageRessourcesService
    {
        private readonly GameContext _gameContext;

        public StockageRessourcesService(GameContext context)
        {
            this._gameContext = context;
        }
        public IEnumerable<StockageRessources> GetAllStockageRessources()
        {
            return _gameContext.StockageRessources.OrderBy(x => x.ID_Stockage_Ressource);
        }

        public bool UpdateRessources(StockageRessources stockageRessources)
        {
            DateTime now = DateTime.Now;
            TimeSpan diffTime = now - stockageRessources.LastUpdate;
            var addedStock = stockageRessources.Ressource.Production_Naturelle_Ressource * diffTime.TotalSeconds;
            if (stockageRessources.Resource_Stock + addedStock <= stockageRessources.Max_Stock)
            {
                stockageRessources.Resource_Stock += (ulong)addedStock;
            }
            else
            {
                stockageRessources.Resource_Stock = stockageRessources.Max_Stock;
            }
            stockageRessources.LastUpdate = now;
            _gameContext.StockageRessources.Update(stockageRessources);
            return _gameContext.SaveChanges() == 1;

        }
    }
}
