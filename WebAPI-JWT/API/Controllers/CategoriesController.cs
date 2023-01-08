﻿using Domain;
using Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        #region Logger

        private readonly ILogger<ItemsController> _logger = null!;

        #endregion Logger

        #region Repositories

        private readonly ICategoryRepository _categoryRepository = null!;

        #endregion Repositories

        #region Constructor

        public CategoriesController(ILogger<ItemsController> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        #endregion Constructor

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                List<Category> categories = await _categoryRepository.GetAllAsync();

                if (categories.Any() == false)
                    return NoContent();

                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }
    }
}