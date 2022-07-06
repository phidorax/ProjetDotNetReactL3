using L3Projet.Common.Models;

namespace L3Projet.DataAccess.Interfaces;

public interface IBatimentDataAccess
{
    Task<IEnumerable<Batiment>> GetAllBatiments();
    Task<Batiment?> GetById(int id);
    //Task AddUser(User? user);
}