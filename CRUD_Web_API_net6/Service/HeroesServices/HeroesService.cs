using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Web_API_net6.Service.HeroesServices
{
    public class HeroesService : IHerosService
    {
        private readonly DataContext _context;
        public HeroesService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<List<Heroes>> GetAllHeroes()
        {
            return await _context.Heroes.ToListAsync();
        }

        public async Task<Heroes?> GetDetailHeroes(int id)
        {
            var data = await _context.Heroes.FindAsync(id);

            if (data == null)
            {
                return null;
            }

            return data;
        }

        public async Task<List<Heroes>> AddHeroes(Heroes request)
        {
            _context.Heroes.Add(request);
            await _context.SaveChangesAsync();

            return await _context.Heroes.ToListAsync();
        }

        public async Task<Heroes?> UpdateHeroes(int id, Heroes request)
        {
            var data = await _context.Heroes.FindAsync(id);

            if (data == null)
            {
                return null;
            }

            data.Nickname = request.Nickname;
            data.FirstName = request.FirstName;
            data.LastName = request.LastName;
            data.address = request.address;

            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<List<Heroes>?> DeleteHeroes(int id)
        {
            var data = await _context.Heroes.FindAsync(id);

            if (data == null)
            {
                return null;
            }

            _context.Remove(data);
            await _context.SaveChangesAsync();

            return await _context.Heroes.ToListAsync();
        }
    }
}
