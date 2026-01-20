using Microsoft.EntityFrameworkCore;
using ProjectPP.Data;
using ProjectPP.Dtos;
using ProjectPP.Models;
using ProjectPP.Services.Interfaces;
using System.Text;

namespace ProjectPP.Services.Implementation;

public class AdressService : IAdressService // precisamos criar uma lsita na model do banco a mais, gerar scaffold, para armazenar rotas para a casa de tamanho variavel. Devemos ver para converter para BLOB e armazenar a lista e fazer post e put e trabalhgar como XML.
{
    private readonly MydatabaseContext _databaseContext;

    public AdressService(MydatabaseContext mydatabaseContext)
    {
        _databaseContext = mydatabaseContext;
    }

    public async Task<BuscarAdressDto> GetAdressById(int id)
    {
        var queryResult = await _databaseContext.Adresses.FirstOrDefaultAsync(x => x.Id == id);

        var resultInDto = new BuscarAdressDto
        {
            Id = queryResult.Id,
            Street = Encoding.UTF8.GetString(queryResult.Street),
            NumberOfPlace = Encoding.UTF8.GetString(queryResult.NumberOfPlace),
            Neighborhood = Encoding.UTF8.GetString(queryResult.Neighborhood),
            City = Encoding.UTF8.GetString(queryResult.City),
            Country = Encoding.UTF8.GetString(queryResult.Country),
        };

        return resultInDto;
    }
}
