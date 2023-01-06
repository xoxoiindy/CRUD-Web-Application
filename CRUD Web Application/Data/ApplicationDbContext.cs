using CRUD_Web_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Web_Application.Data
{
    public class ApplicationDbContext :DbContext  
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {

        }

        //references the models folder ->category.cs - getter & setters
        //Databse set for the Category Table 
        public  DbSet<Category> Categories { get; set; }
    }
}
