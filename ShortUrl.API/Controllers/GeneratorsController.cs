﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.Business.Contract;
using ShortUrl.Business.Models;

namespace ShortUrl.API.Controllers
{
    [ApiController]
    [Route("generators")]
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
        [HttpPost]
        public async Task<IActionResult> Post(GeneratorRequest model)
        {
            model.IpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            GeneratorResponse response = await _itemBusiness.GenerateAsync(model);

            if (response.IsSuccess)
                return Ok(new Uri(Request.Scheme + "://" + Request.Host.Value + Request.PathBase + "/" + response.Segment).ToString());

            return BadRequest(response.Message);
        }
        #endregion
    }
}