using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleProject.Contracts;
using SampleProject.Data;
using SampleProject.Models.Country;

namespace SampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        
        private readonly IMapper mapper;
        private readonly ICountriesRepository countriesRepository;

        public CountriesController(IMapper mapper,ICountriesRepository countriesRepository)
        {
           this.mapper=mapper;
           this.countriesRepository=countriesRepository;

        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountry>>> GetCountries()
        {
           var countries=await countriesRepository.GetAllAsync();
            var records=mapper.Map<List<GetCountry>>(countries);
            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await countriesRepository.GetDetails(id);

            if (country == null)
            {
                return NotFound();
            }

            var countryDto =mapper.Map<CountryDto>(country);
            return Ok(countryDto);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountry updateCountry)
        {
            if (id != updateCountry.Id)
            {
                return BadRequest();
            }

            var country = await countriesRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            mapper.Map(updateCountry,country);

            try
            {
                await countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountry countryCreate)
        {
            var country = mapper.Map<Country>(countryCreate);

            await countriesRepository.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await countriesRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            await countriesRepository.DeleteAsync(id);
            

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await countriesRepository.Exists(id);
        }
    }
}
