using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Model
{
    [Table("Investors", Schema ="dbo")]
    public class InvestorDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public  int Id { set; get; }
        public int CompanyId { set; get; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Title")]
        public string Title { set; get; }
       
        public InvestorDB() { }
       
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Last Name")]
        public string LastName { set; get;}
        
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "First Name")]
        public string FirstName { set; get; }
       
    }
}
