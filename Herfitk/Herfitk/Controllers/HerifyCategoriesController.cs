﻿using AutoMapper;
using Herfitk.API.DTO;
using Herfitk.Core;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Talabat.API.Errors;

namespace Herfitk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerifyCategoriesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public HerifyCategoriesController(IUnitOfWork unitOfwork, IMapper mapper)
        {
            unitOfWork = unitOfwork;
            this.mapper = mapper;
        }

        // GET: api/HerifyCategories
        [HttpGet]
        public async Task<IActionResult> GetAllHerifyByCatID([FromQuery] HerifySpecParam herifySpec)
        {
            var spec = new HerifyCategoryWithSpec(herifySpec);

            var GetAll = await unitOfWork.Repository<HerifyCategory>().GetAllWithSpecAsync(spec);

            var herifyDtos = mapper.Map<IEnumerable<HerifyCategory>, List<HerifyDto>>(GetAll);

            return Ok(herifyDtos);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateHerifyCategory(int id, HerifyCategory herifyCategory)
        {
            if (id != herifyCategory.CategoryId)
                return BadRequest();

            try
            {
                unitOfWork.Repository<HerifyCategory>().UpdateAsync(herifyCategory, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateHerifyCategory(HerifyCategoryDto herifyCategory)
        {
            try
            {
                var getHerifyAndCategoryID = new HerifyCategory
                {
                    CategoryId = herifyCategory.CategoryID,
                    HerifyId = herifyCategory.HerifyID
                };

                await unitOfWork.Repository<HerifyCategory>().AddAsync(getHerifyAndCategoryID);
                await unitOfWork.CompleteAsync();
                return Ok();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        // DELETE: api/HerifyCategories/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteHerifyCategory(int id)
        {
            try
            {
                var herifyCategory = await unitOfWork.Repository<HerifyCategory>().GetByIdAsync(id);
                if (herifyCategory == null)
                    return NotFound();

                await unitOfWork.Repository<HerifyCategory>().DeleteAsync(id);
                await unitOfWork.CompleteAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse(500, "Error message : " + ex.Message);
                return StatusCode(errorResponse.StatusCode, errorResponse);
            }
        }
    }
}