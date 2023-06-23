using DataAccessLayer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Project1.Business;
using System.Collections.Generic;

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
        public IActionResult GetCompany()
        {
            try
            {
                var result = companybusiness.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        /// <summary>
        /// Add a new record for Company
        /// </summary>
        /// <param name="newrecord"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]", Name = "AddCompany")]
        public IActionResult AddCompany(Company newrecord)
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

                    return Ok(msg);
                }
                 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

    }
}