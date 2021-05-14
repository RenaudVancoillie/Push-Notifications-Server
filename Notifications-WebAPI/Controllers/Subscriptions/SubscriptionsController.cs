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

        [HttpGet("{id:int:min(1)}")]
        [ProducesResponseType(typeof(SubscriptionDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public ActionResult<SubscriptionDTO> GetById(int id)
        {
            try
            {
                SubscriptionDTO subscription = subscriptionsService.GetById(id);
                if (subscription == null)
                {
                    return NotFound($"Subscription with id {id} not found.");
                }
                return Ok(subscription);
            }
            catch (Exception exc)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Something went wrong: {exc.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(SubscriptionDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
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
