using Microsoft.AspNetCore.Mvc;
using ProjectPP.Dtos;
using ProjectPP.Services.Interfaces;
using ProjectPP.Utils;

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
    public async Task<IActionResult> BuscarEnderecoPorId(int id)
    {
        var adressDto = await _adressService.GetAdressById(id);
        var xml = XmlUtils.SerializeToXml(adressDto);
        return Content(xml, "application/xml");
    }

    [HttpPost]
    public async Task<ActionResult<BuscarAdressDto>> AdicionarEndereco(int id)
    {
        var adressDto = await _adressService.GetAdressById(id);
        return adressDto;
    }
}
