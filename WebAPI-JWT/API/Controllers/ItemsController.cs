using Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        #region Logger

        private readonly ILogger<ItemsController> _logger = null!;

        #endregion Logger

        #region Repositories

        private readonly IItemRepository _itemRepository = null!;

        #endregion Repositories

        #region Constructor

        public ItemsController(ILogger<ItemsController> logger, IItemRepository itemRepository)
        {
            _logger = logger;
            _itemRepository = itemRepository;
        }

        #endregion Constructor

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var items = await _itemRepository.GetAllAsync();

                if (items.Any() == false)
                    return NoContent();

                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }
    }
}