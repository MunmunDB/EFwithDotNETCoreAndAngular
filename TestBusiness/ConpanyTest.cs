using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project1.Business;
using Project1.Controllers;
using Microsoft.Extensions.DependencyInjection;
using DataAccessLayer;
using Microsoft.Extensions.Configuration;
using AutoMapper.Configuration;
using Moq;
using Project1;
using DataAccessLayer.Model;

namespace TestBusiness
{
    public class CompanyTest
    {
        readonly Mock<IEFDataContext> mockDB = new Mock<IEFDataContext> { CallBase = true };
        Mock<ILogger<CompanyController>> mocklogger = new Mock<ILogger<CompanyController>>() { };
        ICompanyBusiness _business { get; set; }
        CompanyController _CompanyController { get; set; }
        IEFDataContext _eFDataContext { get; set; }
        ICompanyBusiness _companyBusiness { set; get; }
        IConfiguration iconfiguration { set; get; }
        
        public CompanyTest()
        {
            
        }
      
        [SetUp]
        public void Setup()
        {
            _business = new CompanyBusiness(mockDB.Object);
            _CompanyController = new CompanyController( mocklogger.Object, _business);

            mockDB.Setup(p => p.Get()).Returns(_list);
            mockDB.Setup(p => p.GetByCode("AAAC")).Returns(new CompanyDB() { CompanyName = "AAA11", Code = "AAAC", SharePrice = new decimal(1111.11) });
        }

        [Test]
        public void TestGet()
        {
            IActionResult resultvalue = _CompanyController.GetCompany();
            Console.Write(resultvalue);
            resultvalue.Equals(new OkResult());
           
            //assert
            Assert.NotNull(resultvalue);
            var resultvalulist = resultvalue as OkObjectResult;
            // Assert.That(resultvalulist.Value, Is.EqualTo(_blist));
            Assert.AreEqual(resultvalulist.StatusCode, new OkResult().StatusCode);
            Assert.Pass();
        }
        [Test]
        public void TestAdd()
        {
            var duplicateComp = new Company() { CompanyName = "AAA11", Code = "AAAC", SharePrice = new decimal(1111.11) };
            IActionResult resultvalue_duplicateerr = _CompanyController.AddCompany(duplicateComp);
            var resultvalue = resultvalue_duplicateerr as OkObjectResult;
            Assert.AreEqual((custMsg)resultvalue.Value, new custMsg() { Code = "", Message = "Company exists with code : " + duplicateComp.Code });
            //Assert.That(resultvalue.Value,Is.EqualTo( new[] { new custMsg() { Code = "", Message = "Company exists with code : " + duplicateComp.Code } }));

            //assert
            Assert.NotNull(resultvalue);

            Assert.Pass();
        }

        private List<CompanyDB> getData()
        {
            return _list;
        }
        List<CompanyDB> _list = new List<CompanyDB>() { new CompanyDB() { CompanyName = "AAA11", Code = "AAAC", SharePrice = new decimal(1111.11) }, new CompanyDB() { CompanyName = "DDF", Code = "FFT4", SharePrice = new decimal(34534) }, new CompanyDB() { CompanyName = "AADD", Code = "DD", SharePrice = new decimal(423.6666) } };
        List<Company> _blist = new List<Company>() { new Company() { CompanyName = "AAA11", Code = "AAAC", SharePrice = new decimal(1111.11) }, new Company() { CompanyName = "DDF", Code = "FFT4", SharePrice = new decimal(34534) }, new Company() { CompanyName = "AADD", Code = "DD", SharePrice = new decimal(423.6666) } };
    }
}