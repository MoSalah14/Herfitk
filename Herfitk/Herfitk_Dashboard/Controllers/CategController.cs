using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using AutoMapper;
using Herfitk_Dashboard.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Protocol.Core.Types;

namespace Herfitk_Dashboard.Controllers
{
    public class CategController : Controller
    {
        private readonly IGenericRepository<Category> context;
        private readonly IMapper mapper;

        public CategController(IGenericRepository<Category> context, IMapper mapper)
        {

            this.context = context;
            this.mapper = mapper;
        }

        // GET: Categ
        public async Task<IActionResult> Index(string searchString)
        {
            var category = await context.GetAllAsync();
            // Filter herifys based on the searchString
            if (!string.IsNullOrEmpty(searchString))
            {
                category = category.Where(herify => herify.CategoryName.Contains(searchString)).ToList();

            }
            if (int.TryParse(searchString, out int id))
            {
                // Redirect to IndexId action if the searchString is a valid ID
                return RedirectToAction(nameof(Details), new { id });
            }
            return View(await context.GetAllAsync());
        }

        // GET: Categ/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var category = await context.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: Categ/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categ/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryName,Descraption,Image")] CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                if (category.Image != null && category.Image.Length > 0)
                {
                    if (category.Image.Length < 2097152) // Check file size (less than 2 MB)
                    {
                        string currentDirectory = Directory.GetCurrentDirectory();

                        // Navigate up to the "Herfitk" directory and create the uploadsDirectory path
                        string herfitkDirectory = Path.Combine(currentDirectory, "..", "..", "..", "..", "GitHub", "Herfitk");
                        string wwwrootUploadsDirectory = Path.Combine(herfitkDirectory, "Herfitk", "Herfitk_Dashboard", "wwwroot", "UploadsPhotos");
                        string assetsUploadsDirectory = Path.Combine(herfitkDirectory, "front-end", "Herfitk", "src", "assets", "UploadsPhotos");

                        // Check if the uploadsDirectories exist, and create them if they don't
                        if (!Directory.Exists(wwwrootUploadsDirectory))
                            Directory.CreateDirectory(wwwrootUploadsDirectory);

                        if (!Directory.Exists(assetsUploadsDirectory))
                            Directory.CreateDirectory(assetsUploadsDirectory);


                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + category.Image.FileName;
                        var wwwrootFilePath = Path.Combine(wwwrootUploadsDirectory, uniqueFileName);
                        var assetsFilePath = Path.Combine(assetsUploadsDirectory, uniqueFileName);

                        using (var wwwrootFileStream = new FileStream(wwwrootFilePath, FileMode.Create))
                        using (var assetsFileStream = new FileStream(assetsFilePath, FileMode.Create))
                        {
                            await category.Image.CopyToAsync(wwwrootFileStream);
                            await category.Image.CopyToAsync(assetsFileStream);
                        }

                        var newCategory = new Category
                        {
                            CategoryName = category.CategoryName,
                            Descraption = category.Descraption,
                            Image = "/UploadsPhotos/" + uniqueFileName // Assuming ImagePath is the property to store file path
                        };

                        await context.AddAsync(newCategory);

                        return RedirectToAction(nameof(Index));
                    }


                    else
                        ModelState.AddModelError("Image", "The file is too large.");

                }
                else
                    ModelState.AddModelError("Image", "Please select a file.");

            }

            return View(category);
        }




        // GET: Categ/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var category = await context.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: Categ/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryName,Descraption,Image")] CategoryViewModel categoryViewModel)
        {
            if (id != categoryViewModel.Id)
                return NotFound();


            if (ModelState.IsValid)
            {
                try
                {
                    var categoryToUpdate = await context.GetByIdAsync(id);
                    if (categoryToUpdate == null)
                        return NotFound();


                    // Check if a new image is uploaded
                    if (categoryViewModel.Image != null && categoryViewModel.Image.Length > 0)
                    {
                        // Check file size (less than 2 MB)
                        if (categoryViewModel.Image.Length < 2097152)
                        {
                            var currentDirectory = Directory.GetCurrentDirectory();

                            // Navigate up to the "Herfitk" directory and create the uploadsDirectory paths
                            string herfitkDirectory = Path.Combine(currentDirectory, "..", "..", "..", "..", "GitHub", "Herfitk");
                            string wwwrootUploadsDirectory = Path.Combine(herfitkDirectory, "Herfitk", "Herfitk_Dashboard", "wwwroot", "UploadsPhotos");
                            string assetsUploadsDirectory = Path.Combine(herfitkDirectory, "front-end", "Herfitk", "src", "assets", "UploadsPhotos");




                            // Check if the uploadsDirectories exist, and create them if they don't
                            if (!Directory.Exists(wwwrootUploadsDirectory))
                                Directory.CreateDirectory(wwwrootUploadsDirectory);

                            if (!Directory.Exists(assetsUploadsDirectory))
                                Directory.CreateDirectory(assetsUploadsDirectory);


                            var uniqueFileName = Guid.NewGuid().ToString() + "_" + categoryViewModel.Image.FileName;
                            var wwwrootFilePath = Path.Combine(wwwrootUploadsDirectory, uniqueFileName);
                            var assetsFilePath = Path.Combine(assetsUploadsDirectory, uniqueFileName);

                            using (var wwwrootFileStream = new FileStream(wwwrootFilePath, FileMode.Create))
                            using (var assetsFileStream = new FileStream(assetsFilePath, FileMode.Create))
                            {
                                await categoryViewModel.Image.CopyToAsync(wwwrootFileStream);
                                await categoryViewModel.Image.CopyToAsync(assetsFileStream);
                            }

                            // Update the existing Category instance with new data including the image path
                            categoryToUpdate.CategoryName = categoryViewModel.CategoryName;
                            categoryToUpdate.Descraption = categoryViewModel.Descraption;
                            categoryToUpdate.Image = "/UploadsPhotos/" + uniqueFileName; // Assuming ImagePath is the property to store file path
                        }
                        else
                        {
                            ModelState.AddModelError("Image", "The file is too large.");
                            return View(categoryViewModel);
                        }
                    }
                    else
                    {
                        // If no new image is uploaded, retain the existing image data
                        categoryToUpdate.CategoryName = categoryViewModel.CategoryName;
                        categoryToUpdate.Descraption = categoryViewModel.Descraption;
                    }

                    await context.UpdateAsync(categoryToUpdate, id);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            return View(categoryViewModel);
        }


        // GET: Categ/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var category = await context.GetByIdAsync(id);

            if (category == null)
                return NotFound();


            return View(category);
        }

        // POST: Categ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await context.GetByIdAsync(id);
            if (category != null)
            {
                await context.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
