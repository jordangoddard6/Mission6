using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Goddard.Models
{
    public class Category // CategoryId is PK, both CategoryId and CategoryName are required fields
                           
    {

        [Key]
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }


    }
}
