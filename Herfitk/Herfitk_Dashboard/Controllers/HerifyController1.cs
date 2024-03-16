using AutoMapper;
using Herfitk.API.DTO;
using Herfitk.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Herfitk_Dashboard.Controllers
{
    public class HerifyController : Controller
    {
        private readonly IGenericRepository<HerfiyReturnDto> repository;
        private readonly IMapper mapper;
        HerifyController(IGenericRepository<HerfiyReturnDto> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        //Get All Herifys
        public IActionResult Index()
        {
            return View(repository.GetAllAsync());
        }


    }
}
