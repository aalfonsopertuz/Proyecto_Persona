using Api.Core.Dtos;
using Api.Core.Entity;

namespace Api.Core.Bussines
{
    public interface IPersonaService
    {
        Task<ResponseDto<List<PersonaDto>>> GetAllAsync();
        Task<ResponseDto<PersonaDto?>> GetByIdAsync(int id);
        Task<ResponseDto<int>> AddAsync(PersonaDto personaDto);
        Task<ResponseDto<int>> UpdateAsync(PersonaDto personaDto);
        Task<ResponseDto<bool>> DeleteAsync(int id);
    }
}
