using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Web_Application.Models
{
    public class Category
    {
        //Id is the primary key & identity column - Key is attribute 
        [Key]
        public int Id { get; set; }

        //Name = required for validation
        [Required]
        [DisplayName("Title")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage="Description must be atleast 1 to 100.")]
        public int DisplayOrder { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;



    }
}
