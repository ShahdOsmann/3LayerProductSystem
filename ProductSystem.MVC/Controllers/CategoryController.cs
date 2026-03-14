using ProductSystem.BLL;
using ProductSystem.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ProductSystem.BLL.Managers;

namespace ProductSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            var categories = categoryManager.GetAll();
            return View(categories);
        }

        public IActionResult Details(int id)
        {
            var category = categoryManager.GetById(id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryFormVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            categoryManager.Add(vm);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = categoryManager.GetById(id);

            if (category == null)
                return NotFound();

            CategoryFormVM vm = new CategoryFormVM
            {
                Id = category.Id,
                Name = category.Name
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(CategoryFormVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            categoryManager.Update(vm);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            categoryManager.Delete(id);

            return RedirectToAction("Index");
        }
    }
}