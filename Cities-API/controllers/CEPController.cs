using Microsoft.AspNetCore.Mvc;

namespace Cities_API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CEPController : ControllerBase
{
    private readonly IDataLoad _dataLoad;

    private readonly ILogger<CEPController> _logger;

    public CEPController(ILogger<CEPController> logger, IDataLoad dataLoad)
    {
        _logger = logger;
        _dataLoad = dataLoad;
    }

    [HttpGet(Name = "City")]
    public IEnumerable<string> Cities([FromHeader] string stateCode, [FromHeader] string countryCode)
    {
        List<City> cities = _dataLoad.Cities();
        var objCity = cities.Where(c => c.state_code == stateCode && c.country_code == countryCode);
        var name = objCity.Select(c => c.name);
        return name;
    }

    [HttpGet(Name = "State")]
    public IEnumerable<string> States([FromHeader] string countryCode)
    {
        List<State> states = _dataLoad.States();
        var objEstado = states.Where(e => e.country_code == countryCode);
        var name = objEstado.Select(e => e.name);
        return name;
    }

    [HttpGet(Name = "Countries")]
    public IEnumerable<string> Countries()
    {
        List<Country> countries = _dataLoad.Countries();
        var name = countries.Select(p => p.name);
        return name;
    }

    [HttpGet(Name = "CEP")]
    public IEnumerable<object> CEP([FromHeader] string city)
    {
        List<City> cities = _dataLoad.Cities();
        var objCity = cities.Where(c => c.name == city);
        var CEP = objCity.Select(c => new
        {
            City = c.name,
            State = c.state_name,
            País = c.country_name
        });
        return CEP;
    }
}