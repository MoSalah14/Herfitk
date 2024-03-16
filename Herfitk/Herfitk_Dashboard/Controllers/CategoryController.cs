using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using Herfitk_Dashboard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Herfitk_Dashboard.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HerfitkContext _context;

        public CategoryController(HerfitkContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    Descraption = c.Descraption,
                    Image = c.Image
                })
                .ToList();

            return View(categories);
        }
    }
}

