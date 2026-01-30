using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectPP.Data;
using ProjectPP.Dtos;
using ProjectPP.Services.Interfaces;
using ProjectPP.Utils;

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

        var routesString = EncodingUtils.GetString(queryResult.Routes);
        var routesList = string.IsNullOrWhiteSpace(routesString)
            ? new List<RoutesDto>()
            : JsonConvert.DeserializeObject<List<RoutesDto>>(routesString);

        var resultInDto = new BuscarAdressDto
        {
            Id = queryResult.Id,
            Street = EncodingUtils.GetString(queryResult.Street),
            NumberOfPlace = EncodingUtils.GetString(queryResult.NumberOfPlace),
            Neighborhood = EncodingUtils.GetString(queryResult.Neighborhood),
            City = EncodingUtils.GetString(queryResult.City),
            Country = EncodingUtils.GetString(queryResult.Country),
            Routes = routesList!
        };

        return resultInDto;
    }
}
