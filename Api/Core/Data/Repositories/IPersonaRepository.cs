using Api.Core.Entity;

namespace Api.Core.Data.Repositories
{
    public interface IPersonaRepository
    {
        Task<List<Persona>> GetAllAsync();
        Task<Persona?> GetByIdAsync(int id);
        Task<int> AddAsync(Persona persona);
        Task<int> UpdateAsync(Persona persona);
        Task<int> DeleteAsync(Persona persona);
    }
}
