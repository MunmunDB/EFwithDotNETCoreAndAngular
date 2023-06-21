using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Model
{
    [Table("Companies", Schema ="dbo")]
    public class CompanyDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public  int Id { set; get; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Company Name")]
        public string CompanyName { set; get; }
        public CompanyDB() { }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        [Display(Name = "Code")]
        public string Code { get; set; }
public DateTime CreatedDate { set; get; }
        public decimal SharePrice { get; set; }
    }
}
