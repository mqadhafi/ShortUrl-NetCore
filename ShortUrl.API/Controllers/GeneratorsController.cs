using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.Business.Contract;
using ShortUrl.Business.Models;

namespace ShortUrl.API.Controllers
{
    [ApiController]
    public class GeneratorsController : ControllerBase
    {
        #region Private Fields
        private readonly IItemBusiness _itemBusiness;
        #endregion

        #region Constructor
        public GeneratorsController(IItemBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness ?? throw new ArgumentNullException(nameof(itemBusiness));
        }
        #endregion

        #region Public Methods
        [HttpPost("generators")]
        public async Task<IActionResult> Post(ItemModel model)
        {
            Response response = await _itemBusiness.GenerateAsync(model);

            if (response.IsSuccess)
                return Ok();

            return BadRequest(response.Message);
        }
        #endregion
    }
}