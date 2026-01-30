namespace ProjectPP.Dtos;

public class BuscarAdressDto
{
    public int Id { get; set; }

    public string Street { get; set; }

    public string NumberOfPlace { get; set; }

    public string Neighborhood { get; set; }

    public string City { get; set; }

    public string Country { get; set; }
    public List<RoutesDto> Routes { get; set; }
}
