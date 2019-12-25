using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.Business.Contract;
using ShortUrl.Business.Models;

namespace ShortUrl.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class NavigationsController : ControllerBase
    {
        #region Private Fields
        private readonly IItemBusiness _itemBusiness;
        #endregion

        #region Constructor
        public NavigationsController(IItemBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness ?? throw new ArgumentNullException(nameof(itemBusiness));
        }
        #endregion

        #region Public Methods
        [HttpGet("{segment}")]
        public async Task<IActionResult> Get(string segment)
        {
            RedirectResponse response = await _itemBusiness.NavigatesAsync(new RedirectRequest
            {
                Segment = segment,
                IpAddress = HttpContext.Connection.RemoteIpAddress.ToString()
            });

            if (response.IsSuccess)
                return Redirect(response.OriginUrl);

            return BadRequest(response.Message);
        }
        #endregion
    }
}