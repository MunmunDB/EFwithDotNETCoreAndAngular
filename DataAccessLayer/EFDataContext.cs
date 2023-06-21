using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IEFDataContext
    {
        public List<CompanyDB> Get();
        public CompanyDB GetByCode(string code);
        public bool Update(CompanyDB record);
      

    }
    public class EFDataContext : DbContext , IEFDataContext
    {
        
         DbSet<CompanyDB> CompanyDBs { get; set; }
         DbSet<InvestorDB> InvestorsDB { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=(localdb)\MSSQLLocalDB; initial catalog=Downing.Investment.Database;persist security info=True; Integrated Security=SSPI;");
        }

  
        List<CompanyDB> IEFDataContext.Get()
        {
           
            return CompanyDBs.ToList();
        }

        CompanyDB IEFDataContext.GetByCode(string code)
        {
            var companyobj = CompanyDBs.Where(p=>p.Code== code);
            return companyobj.FirstOrDefault();
        }

        bool IEFDataContext.Update(CompanyDB record)
        {
            //explicity implement for Update
            try
            {
                CompanyDBs.Add(record);
                this.SaveChanges();
                

                return true;
            }
            catch (Exception ex) { return false; }
        }

       
    }
}
