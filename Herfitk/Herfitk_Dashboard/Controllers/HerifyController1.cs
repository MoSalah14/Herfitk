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
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
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
       //Search String First Step Path Parameter To Search  
       public async Task<IActionResult> Index(string searchString)
        {
            try
            {
                var herifys = await repository.GetAllHerfyIncluding();

                if (herifys == null)
                {
                    return NotFound();
                }

                // Filter herifys based on the searchString
                if (!string.IsNullOrEmpty(searchString))
                {
                    herifys = herifys.Where(herify => herify.Speciality.Contains(searchString)).ToList();

                }
                if (int.TryParse(searchString, out int id))
                {
                    // Redirect to IndexId action if the searchString is a valid ID
                    return RedirectToAction(nameof(IndexId), new { id });
                }
                var mappedData = mapper.Map<List<Herfiy>, List<HerfiyReturnDto>>(herifys);

                return View(mappedData);
            }
            catch (Exception)
            {
                return Content("Error With Data"); 
            }
        }
        //Add This for get the search 
        //notUsed Make OverLoad 
        //[HttpPost]
        //public string Index(string searchString, bool notUsed)
        //{
        //    return "From [HttpPost]Index: filter on " + searchString;
        //}
        //Get Herifys By Id 
        public async Task<IActionResult> IndexId(int id)
        {
            //var herify = await repository.GetByIdAsync(id);
            //var mappedDataId = mapper.Map<Herfiy, HerfiyReturnDto>(herify);
            //return View(mappedDataId);
            try
            {
                var herify = await repository.GetByIdAsync(id);

                if (herify == null)
                {
                    return NotFound(); // Return 404 Not Found if no Herfiy with the given id is found
                }
                var mappedDataId = mapper.Map<Herfiy, HerfiyReturnDto>(herify);
                return View(mappedDataId);
            }
            catch(Exception)
            {
                return Content("Error With Data");
            }
        }
        //Add new Herifys 
        public IActionResult Add()
        {
            try
            {
                return View(new HerfiyReturnDto());

            }
            catch
            {
                return Content("Error With Data");
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Add(HerfiyReturnDto herfiyReturnDto)
        {
            try
            {
                if (herfiyReturnDto == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var newHerfiy = mapper.Map<HerfiyReturnDto, Herfiy>(herfiyReturnDto);
                // Add the new Herfiy to the repository
                await repository.AddAsync(newHerfiy);
                return RedirectToAction("Index");

            }
            catch(Exception)
            {
                return Content("Error With Data");
            }
           
          
        }
        //Edite Herifys 
        public async Task<IActionResult> Edite(int id)
        {
            try
            {
                var editeHerify = await repository.GetByIdAsync(id);
                if (editeHerify == null)
                {
                    return NotFound();
                }
                var editeHerifyReturnDto = mapper.Map<Herfiy, HerfiyReturnDto>(editeHerify);
                return View(editeHerifyReturnDto);

            }
            catch(Exception)
            {
                return Content("Error With Data");
            }


        }

        [HttpPost]
        public async Task<IActionResult> Edite(HerfiyReturnDto herfiyReturnDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var editeHerify = mapper.Map<HerfiyReturnDto, Herfiy>(herfiyReturnDto);
                var editeHerifyReturn = await repository.UpdateAsync(editeHerify, editeHerify.Id);
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return Content("Error With Data");
            }
           

        }

        //Delete Herifys
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleteHerify = await repository.DeleteAsync(id);
                if (deleteHerify == null)
                {
                    return NotFound();
                }
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return Content("Error With Data");
            }
        

        }

    }
}
