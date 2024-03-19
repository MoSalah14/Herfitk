using AutoMapper;
using Herfitk.API.DTO;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using Herfitk.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using Herfitk_Dashboard.Models;
namespace Herfitk_Dashboard.Controllers
{
    public class HerifyController : Controller
    {
       
        private readonly IHerifyRepository repository;
        private readonly IMapper mapper;
        public HerifyController(IHerifyRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

       // Get All Herifys
        public async Task<IActionResult> Index()
        {
            var herifys = await repository.GetAllHerfyIncluding();
    
            // Using Mapper To Transform From DTO To Model 
            // var herifyDtos = mapper.Map<List<Herfiy>, List<HerfiyReturnDto>>((List<Herfiy>)herifys);
            if (herifys == null)
            {
                return NotFound();
            }
            // Add List For Loop On every Elemnt 
            var mappedData =  mapper.Map<List< Herfiy>, List<HerfiyReturnDto>>(herifys);

            return View(mappedData);
        }

        //Get Herifys By Id 
        public async Task<IActionResult> IndexId(int id)
        {
            //var herify = await repository.GetByIdAsync(id);
            //var mappedDataId = mapper.Map<Herfiy, HerfiyReturnDto>(herify);
            //return View(mappedDataId);

            var herify = await repository.GetByIdAsync(id);

            if (herify == null)
            {
                return NotFound(); // Return 404 Not Found if no Herfiy with the given id is found
            }

            var mappedDataId = mapper.Map<Herfiy, HerfiyReturnDto>(herify);
            return View(mappedDataId);
        }

        //Add new Herifys 
        public IActionResult Add()
        {
            return View(new HerfiyReturnDto());
        }

        [HttpPost]
        public async Task<IActionResult> Add(HerfiyReturnDto herfiyReturnDto)
        {
           
            
            if (herfiyReturnDto == null)
            {
                return NotFound();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newHerfiy = mapper.Map<HerfiyReturnDto, Herfiy>(herfiyReturnDto);
            // Add the new Herfiy to the repository
            await repository.AddAsync(newHerfiy);
            return RedirectToAction("Index");

        }

        //Edite Herifys 
        public async Task<IActionResult> Edite(int id)
        {

            var editeHerify = await repository.GetByIdAsync(id);
            if (editeHerify == null)
            {
                return NotFound();
            }
            var editeHerifyReturnDto = mapper.Map<Herfiy, HerfiyReturnDto>(editeHerify);
            return View(editeHerifyReturnDto);

        }

        [HttpPost]
        public async Task<IActionResult> Edite(HerfiyReturnDto herfiyReturnDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var editeHerify = mapper.Map<HerfiyReturnDto, Herfiy>(herfiyReturnDto);
            var editeHerifyReturn = await repository.UpdateAsync(editeHerify , editeHerify.Id);
            return RedirectToAction("Index");

        }

        //Delete Herifys
        public async Task<IActionResult> Delete(int id)
        {
          
           var deleteHerify = await repository.DeleteAsync(id);
            if (deleteHerify == null)
            {
                return NotFound();
            }
          return RedirectToAction("Index");

        }

    }
}
