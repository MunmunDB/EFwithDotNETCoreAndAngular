using DataAccessLayer;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Data;
using System.Data.SqlClient;

namespace Project1.Business
{
    public interface ICompanyBusiness
    {
        
       public IEnumerable<Company> GetAll();
        public custMsg AddNew(Company record);
    }
    public class CompanyBusiness : ICompanyBusiness
    {
        IEFDataContext _context;
        custMsg ICompanyBusiness.AddNew(Company record)
        {
            try
            {
                //Duplicate code check
                if (!IsDuplicate(record))
                {
                    _context.Update(new DataAccessLayer.Model.CompanyDB() { Code = record.Code, CompanyName = record.CompanyName, CreatedDate = DateTime.Now, SharePrice = record.SharePrice });

                    return new custMsg(){ Message = "Added successfully"  };
                }
                return new custMsg() { Message = "Company exists with code : "+ record.Code  };
            }
            catch (Exception ex){ return new custMsg() { Message = ex.Message }; }
            
        }

        IEnumerable<Company> ICompanyBusiness.GetAll()
        {
            IEnumerable<Company> list1 = new List<Company>();
             list1 = _context.Get().Select( comp=> new Company(){  Code= comp.Code, CompanyName= comp.CompanyName, 
              
              CreatedDate= comp.CreatedDate, SharePrice= comp.SharePrice});
            return list1;
        }

        bool IsDuplicate(Company record)
        {
           
               var isExist =  _context.GetByCode(record.Code );
                return isExist ==null ? false: true;
           
          
        }

       

        public CompanyBusiness(IEFDataContext dbcontext) => _context = dbcontext;
    }

    
}
