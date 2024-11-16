using Api.Core.Data.Repositories;
using Api.Core.Dtos;
using Api.Core.Entity;
using Mapster;

namespace Api.Core.Bussines
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _repository;

        public PersonaService(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseDto<List<PersonaDto>>> GetAllAsync()
        {
            try
            {
                var result = await _repository.GetAllAsync();

                var resultDto = result.Adapt<List<PersonaDto>>();

                return new()
                {
                    Code = 200,
                    Message = "Consulta correcta",
                    Data = resultDto
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Code = 500,
                    Message = $"Error: {ex.Message}",
                    Data = []
                };
            }
        }

        public async Task<ResponseDto<PersonaDto?>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repository.GetByIdAsync(id);

                var resultDto = result.Adapt<PersonaDto>();

                return new()
                {
                    Code = 200,
                    Message = "Consulta correcta",
                    Data = resultDto
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Code = 500,
                    Message = $"Error: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<int>> AddAsync(PersonaDto personaDto)
        {
            try
            {
                var persona = personaDto.Adapt<Persona>();

                var result = await _repository.AddAsync(persona);

                return new()
                {
                    Code = 200,
                    Message = "Agregado con exito",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Code = 500,
                    Message = $"Error: {ex.Message}",
                    Data = 0
                };
            }
        }
        public async Task<ResponseDto<int>> UpdateAsync(PersonaDto personaDto)
        {
            try
            {
                var persona = personaDto.Adapt<Persona>();

                var result = await _repository.UpdateAsync(persona);

                return new()
                {
                    Code = 200,
                    Message = "Actualizado con exito",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Code = 500,
                    Message = $"Error: {ex.Message}",
                    Data = 0
                };
            }
        }

        public async Task<ResponseDto<bool>> DeleteAsync(int id)
        {
            try
            {
                var persona = await _repository.GetByIdAsync(id);
                if (persona == null)
                {
                    return new()
                    {
                        Code = 200,
                        Message = "La persona no fue encotrada",
                        Data = true
                    };
                }

                int result = await _repository.DeleteAsync(persona);

                if (result > 0)
                {
                    return new()
                    {
                        Code = 200,
                        Message = "Persona eliminada correctamente",
                        Data = true
                    };
                }

                return new()
                {
                    Code = 200,
                    Message = "La persona no pude ser eliminada",
                    Data = true
                };

            }
            catch (Exception ex) 
            {
                return new()
                {
                    Code = 500,
                    Message = $"Error: {ex.Message}",
                    Data = true
                };
            }
        } 
    }
}
