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
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;



    }
}
