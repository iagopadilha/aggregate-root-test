using ProjectPP.Dtos;
using ProjectPP.Models;

namespace ProjectPP.Services.Interfaces;

public interface IAdressService
{
    Task<BuscarAdressDto> GetAdressById(int id);
}
