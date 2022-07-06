using System.Security.Cryptography.X509Certificates;
using L3Projet.Common.Models;
using L3Projet.DataAccess.Interfaces;

namespace L3Projet.DataAccess.Implementations;

public class BatimentDataAccess : IBatimentDataAccess
{
    private readonly List<Batiment> batimentDb = new();

    public BatimentDataAccess()
    {
        batimentDb.Add(new Batiment
        {
            Nom_Batiment = "un",
            Niveau_Batiment = 1,
            Score_Total_Batiment = 10,
        });
    }
    public async Task<IEnumerable<Batiment>> GetAllBatiments()
    {
        return batimentDb;
    }

    public async Task<Batiment?> GetById(int id)
    {
        return batimentDb?.FirstOrDefault(x => x.ID_Batiment == id);
    }
}