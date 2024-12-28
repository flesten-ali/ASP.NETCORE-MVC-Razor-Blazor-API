using BathenyShop.Models;
using BathenyShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BathenyShop.Controllers
{
    public class PieController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPieRepository _pieRepository;

        public PieController(ICategoryRepository categoryRepository , IPieRepository pieRepository)
        {
            _categoryRepository = categoryRepository;
            _pieRepository = pieRepository;
        }
        //public ViewResult List()
        //{
        //    //ViewBag.CurrentCategory = "Chees";
        //    //return View(_pieRepository.AllPies);
        //    var result = new PieListViewModel("All Pies", _pieRepository.AllPies);
        //    return View(result);
        //}
        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new PieListViewModel(currentCategory, pies));
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();

            return View(pie);
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
