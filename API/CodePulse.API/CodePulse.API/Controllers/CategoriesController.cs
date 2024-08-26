using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Implementation;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult>CreateCategory(CreateCategoryRequestDto request)
        {
            //Map DTO to Domain Model
            var Category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,

            };

            await categoryRepository.CreateAsync(Category);

            //Map Domain Model to DTO
            var response = new CategoryDto
            {
                Id = Category.Id,
                Name = Category.Name,
                UrlHandle = Category.UrlHandle,
            };
            return Ok(response);



        }

    }
}
