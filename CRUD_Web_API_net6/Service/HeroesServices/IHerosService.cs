using Microsoft.AspNetCore.Mvc;

namespace CRUD_Web_API_net6.Service.HeroesServices
{
    public interface IHerosService
    {
        Task<List<Heroes>> GetAllHeroes();
        Task<Heroes?> GetDetailHeroes(int id);
        Task<List<Heroes>> AddHeroes(Heroes request);
        Task<Heroes?> UpdateHeroes(int id, Heroes request);
        Task<List<Heroes>?> DeleteHeroes(int id);
    }
}
