using AutoMapper;
using Booking.Data;
using Booking.DTO.Country;
using Booking.Models;
using Booking.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<CountryDTO>> GetBtId(int id) 
        {
            var country = await _countryRepository.GetById(id);

            var countryDto = _mapper.Map<CountryDTO>(country);
            if(country == null)
            {
                return NoContent();
            }
            return Ok(countryDto);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<ActionResult <IEnumerable<CountryDTO>>> Getall()
        {
            var countries = await _countryRepository.GetAll();
            var countriesDto = _mapper.Map<List<CountryDTO>>(countries);
            if (countries==null)
            {
                return NoContent();
            }
            return Ok(countriesDto);

   

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        //public ActionResult <Country> CreateCountry([FromBody]Country country)
        public async Task<ActionResult<CreateCountryDTO>> CreateCountry([FromBody] CreateCountryDTO countryDTO)
        {
            var result = _countryRepository.IsCountryExsist(countryDTO.Name);
            if(result)
            {
                return Conflict("Country already exsites");
            }
            //Country country = new Country();
            //country.Name = countryDTO.Name;
            //country.ShortName = countryDTO.ShortName;
            //country.CountryCode = countryDTO.CountryCode;

            var country = _mapper.Map<Country>(countryDTO);
           await _countryRepository.Create(country);
            return  Ok();


        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Country>> UpdateCountry(int id,[FromBody] UpdateCountryDTO countryDto)
        {
            if(countryDto == null ||id != countryDto.Id) { 
                return BadRequest();
            }
            //var countryFromDB = _dbContext.Countries.Find(id);
            //if(countryFromDB!=null)
            //{
            //    return NotFound();
            //}
            //countryFromDB.Name = country.Name;
            //countryFromDB.ShortName = country.ShortName;
            //countryFromDB.CountryCode = country.CountryCode;

            var country =_mapper.Map<Country>(countryDto);

        await _countryRepository.Update(country);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteCountry(int id)
        {
             var country = await _countryRepository.GetById(id);
            if (country == null)
            {
                return NotFound(); // Return 404 if the country is not found
            }
            await _countryRepository.Delete(country);
            return NoContent();
        }
    }
}
