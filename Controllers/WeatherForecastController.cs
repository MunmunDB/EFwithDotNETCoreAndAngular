using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Project1.Business;

namespace Project1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICompanyBusiness companybusiness;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICompanyBusiness companybusiness)
        {
            _logger = logger;
            this.companybusiness = companybusiness;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Fetch all company records
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]", Name = "GetCompany")]
        public IEnumerable<Company> GetCompany()
        {

           return companybusiness.GetAll(); 

        }


        /// <summary>
        /// Add a new record for Company
        /// </summary>
        /// <param name="newrecord"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]", Name = "AddCompany")]
        public ActionResult AddCompany(Company newrecord)
        {
            try
            {
                if (newrecord == null)
                {
                    return BadRequest();
                }
                else
                {
                    var msg = companybusiness.AddNew(newrecord);
                    
                    return StatusCode(StatusCodes.Status200OK, msg);
                }
                 
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
           
        }

    }
}