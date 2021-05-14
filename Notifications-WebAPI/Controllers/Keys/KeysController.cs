using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Notifications_DAL.DTO.Keys;

namespace Notifications_WebAPI.Controllers.Keys
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeysController : ControllerBase
    {
        private readonly VapidPublicKeyDTO vapidPublicKey;

        public KeysController(IConfiguration configuration)
        {
            vapidPublicKey = new VapidPublicKeyDTO() { PublicKey = configuration.GetSection("VAPID").GetSection("PublicKey").Value };
        }

        [HttpGet("vapid")]
        public ActionResult<VapidPublicKeyDTO> GetVapidKey()
        {
            return Ok(vapidPublicKey);
        }
    }
}
