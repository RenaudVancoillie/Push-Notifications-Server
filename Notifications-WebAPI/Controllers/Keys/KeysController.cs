using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Notifications_DAL.DTO.Keys;
using Notifications_WebAPI.Helpers;

namespace Notifications_WebAPI.Controllers.Keys
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeysController : ControllerBase
    {
        private readonly VapidPublicKeyDTO vapidPublicKey;

        public KeysController(IOptions<VapidDetails> vapidKeys)
        {
            vapidPublicKey = new VapidPublicKeyDTO() { PublicKey = vapidKeys.Value.PublicKey };
        }

        [HttpGet("vapid")]
        public ActionResult<VapidPublicKeyDTO> GetVapidKey()
        {
            return Ok(vapidPublicKey);
        }
    }
}
