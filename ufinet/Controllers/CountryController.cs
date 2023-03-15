using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ufinet.Models;
using ufinet.Services.Interfaces;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public CountriesController(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<JsonResult> GetCountries([FromQuery] string filter = null, int pageNumber = 1, int pageSize = 10)
    {
        var countries = await _countryRepository.GetCountries(filter, pageNumber, pageSize);
        var totalCount = await _countryRepository.GetTotalCount(filter);

        var metadata = new
        {
            totalCount,
            pageSize,
            pageNumber,
            totalPages = (int)Math.Ceiling((double)totalCount / pageSize)
        };

        Response.Headers.Add("X-Total-Count", totalCount.ToString());

        var countriesDto = _mapper.Map<IEnumerable<CountryDto>>(countries);

        return new JsonResult(new { metadata, data = countriesDto });
    }
}