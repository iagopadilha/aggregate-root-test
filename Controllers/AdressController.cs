using Microsoft.AspNetCore.Mvc;
using ProjectPP.Dtos;
using ProjectPP.Services.Interfaces;

namespace ProjectPP.Controllers;

[Route("api/adresses")]
public class AdressController : ControllerBase
{
    private readonly IAdressService _adressService;

    public AdressController(IAdressService adressService)
    {
        _adressService = adressService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BuscarAdressDto>> BuscarEnderecoPorId(int id)
    {
        var adressDto = await _adressService.GetAdressById(id);
        return adressDto;
    }
}
