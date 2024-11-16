using Api.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Api.Core.Data.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Persona>> GetAllAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona?> GetByIdAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task<int> AddAsync(Persona persona)
        {
            await _context.Personas.AddAsync(persona);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Persona persona)
        {
            _context.Personas.Update(persona);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Persona persona)
        {
            _context.Personas.Remove(persona);
            return await _context.SaveChangesAsync();
        }
    }

}
