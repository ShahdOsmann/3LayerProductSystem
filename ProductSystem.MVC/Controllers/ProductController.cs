using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductSystem.BLL.Managers;
using ProductSystem.BLL.ViewModels;

namespace ProductSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;

        public ProductController(
            IProductManager productManager,
            ICategoryManager categoryManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
        }
        [Authorize]

        public IActionResult Index()
        {
            var products = _productManager.GetAll();
            return View(products);
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            var product = _productManager.GetById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            var vm = new ProductFormVM
            {
                Categories = _categoryManager.GetAll()
            };

            ViewBag.Categories = ConvertToSelectList(vm.Categories);

            return View(vm);
        }
        [Authorize(Roles = "Admin")] 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                ReloadCategories(vm);
                return View(vm);
            }

            _productManager.Create(vm);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")] 
        public IActionResult Edit(int id)
        {
            var product = _productManager.GetById(id);

            if (product == null)
                return NotFound();

            var vm = new ProductFormVM
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                Description = product.Description,
                Count = product.Count,
                ImageUrl = product.ImageUrl,
                ExpiryDate = product.ExpiryDate,
                CategoryId = product.CategoryId,  
                Categories = _categoryManager.GetAll()
            };

            ViewBag.Categories = ConvertToSelectList(vm.Categories, vm.CategoryId);

            return View(vm);
        }
        [Authorize(Roles = "Admin")] 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                ReloadCategories(vm);
                return View(vm);
            }

            _productManager.Update(vm);
            return RedirectToAction(nameof(Index));
        }
         
        public IActionResult Delete(int id)
        {
            _productManager.Delete(id);
            return RedirectToAction(nameof(Index));
        }
         
        private List<SelectListItem> ConvertToSelectList(
            List<CategoryListVM>? categories,
            int? selectedId = null)
        {
            if (categories == null)
                return new List<SelectListItem>();

            return categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = selectedId.HasValue && c.Id == selectedId.Value
            }).ToList();
        }

        private void ReloadCategories(ProductFormVM vm)
        {
            vm.Categories = _categoryManager.GetAll();
            ViewBag.Categories = ConvertToSelectList(vm.Categories, vm.CategoryId);
        }
    }
}