using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Project1.Business;

namespace Project1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        

        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyBusiness companybusiness;

        public CompanyController(ILogger<CompanyController> logger, ICompanyBusiness companybusiness)
        {
            _logger = logger;
            this.companybusiness = companybusiness;
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