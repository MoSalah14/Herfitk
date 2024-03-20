using AutoMapper;
using Herfitk.Core.Models;
using Herfitk.Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Herfitk_Dashboard.Controllers
{
    public class UserController : Controller
    {
        private readonly IGenericRepository<AppUser> repository;
        private readonly IMapper mapper;
        public UserController(IGenericRepository<AppUser> repository , IMapper mapper)
        {
             this.repository = repository;
             this.repository = repository;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}
