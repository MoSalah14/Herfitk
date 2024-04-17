using AutoMapper;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using Herfitk_Dashboard.Models;
using Microsoft.AspNetCore.Mvc;

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
                var herifys = await repository.GetAllAsync();

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
                //Continu Later ****
                //var mappedData = mapper.Map<List<Herfiy>, List<HerfiyReturnDto>>(herifys);

                return View(herifys);
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
                // var mappedDataId = mapper.Map<Herfiy, HerfiyReturnDto>(herify);
                return View(herify);
            }
            catch (Exception)
            {
                return Content("Error With Data");
            }
        }

        //Add new Herifys
        public IActionResult Add()
        {
            try
            {
                return View(new Herfiy());
            }
            catch
            {
                return Content("Error With Data");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("UserId,Zone,History,Speciality")] HerifyViewModel herifyViewModel, Herfiy herfiy)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (herifyViewModel != null)
                    {
                        var newHerfy = new Herfiy
                        {
                            Zone = herifyViewModel.Zone,
                            History = herifyViewModel.History,
                            Speciality = herifyViewModel.Speciality,
                            UserId = herifyViewModel.UserId
                        };
                        //Must Be 4 ....Herfy
                        await repository.AddAsync(newHerfy);

                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(herfiy);
            }
            catch (Exception)
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
                //Continu ....
                //var editeHerifyReturnDto = mapper.Map<Herfiy, HerfiyReturnDto>(editeHerify);
                return View(editeHerify);
            }
            catch (Exception)
            {
                return Content("Error With Data");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edite(int id, [Bind("Id,UserId,Zone,History,Speciality")] HerifyViewModel herifyViewModel)
        {
            if (id != herifyViewModel.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    var herfyUpdate = await repository.GetByIdAsync(id);
                    if (herfyUpdate == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        herfyUpdate.Zone = herifyViewModel.Zone;
                        herfyUpdate.History = herifyViewModel.History;
                        herfyUpdate.Speciality = herifyViewModel.Speciality;
                        //I don't no the edite here right or not ... tell the logic
                        herfyUpdate.UserId = herifyViewModel.UserId;
                    }

                    await repository.UpdateAsync(herfyUpdate, id);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return Content("Error With Data");
                }
            }

            return View(herifyViewModel);
        }

        //Delete Herifys
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleteHerify = repository.DeleteAsync(id);
                if (deleteHerify == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return Content("Error With Data");
            }
        }
    }
}