using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notifications_DAL.DTO.Subscriptions;
using Notifications_DAL.Services.Subscriptions;

namespace Notifications_WebAPI.Controllers.Subscriptions
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionsService subscriptionsService;

        public SubscriptionsController(ISubscriptionsService subscriptionsService)
        {
            this.subscriptionsService = subscriptionsService;
        }

        [HttpPost]
        public ActionResult<SubscriptionDTO> Create([FromBody] SubscriptionDTO subscription)
        {
            try
            {
                if (subscription != null && ModelState.IsValid)
                {
                    SubscriptionDTO created = subscriptionsService.Create(subscription);
                    return Ok(subscription);
                }
                else
                {
                    return BadRequest($"Incorrect data received. For model reference: {ModelState.ValidationState}");
                }
            }
            catch (Exception exc)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Something went wrong: {exc.Message}");
            }
        }
    }
}
