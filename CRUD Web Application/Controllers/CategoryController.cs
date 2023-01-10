using CRUD_Web_Application.Data;
using Microsoft.AspNetCore.Mvc;
using CRUD_Web_Application.Models;


namespace CRUD_Web_Application.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //GET Create action method
        public IActionResult Create()
        {
            
            return View();
        }

        //POST create
        [HttpPost]
        //Prevents cross site request forgery attack
        [ValidateAntiForgeryToken] 
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            //form validation
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                //posts to database & saves 
                _db.SaveChanges();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }



		//UPDATE Edit action method
		public IActionResult Edit(int? id)
		{
            if(id==null || id== 0)
            {
                return View();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
		}

		//POST Edit
		[HttpPost]
		//Prevents cross site request forgery attack
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
			}
			//form validation
			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj);
				//posts to database & saves 
				_db.SaveChanges();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
			}
			return View(obj);
		}



        //DELETE action method
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return View();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST Delete
        [HttpPost,ActionName("Delete")]
        //Prevents cross site request forgery attack
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            { 
                return NotFound();
            }
            
                _db.Categories.Remove(obj);
                //posts to database & saves 
                _db.SaveChanges();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
            
            return View(obj);
        }



    }
}
