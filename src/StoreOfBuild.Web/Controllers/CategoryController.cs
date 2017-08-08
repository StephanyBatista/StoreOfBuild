using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Web.ViewsModels;

namespace StoreOfBuild.Web.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class CategoryController : Controller
    {
        private readonly CategoryStorer _categoryStorer;
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(CategoryStorer categoryStorer,
            IRepository<Category> categoryRepository)
        {
            _categoryStorer = categoryStorer;
            _categoryRepository = categoryRepository;
        }
        
        public IActionResult Index()
        {
            var categories = _categoryRepository.All();
            
            var viewsModels = categories.Select(c => new CategoryViewModel{ Id = c.Id, Name = c.Name });
            return View(viewsModels);
        }

        public IActionResult CreateOrEdit(int id)
        {
            if(id > 0)
            {
                var category = _categoryRepository.GetById(id);
                var categoryViewModel = new CategoryViewModel { Id = category.Id, Name = category.Name };
                return View(categoryViewModel);
            }
            return View();
            
        }

        [HttpPost]
        public IActionResult CreateOrEdit(CategoryViewModel viewModel)
        {
            _categoryStorer.Store(viewModel.Id, viewModel.Name);
            return RedirectToAction("Index");
        }
    }
}
