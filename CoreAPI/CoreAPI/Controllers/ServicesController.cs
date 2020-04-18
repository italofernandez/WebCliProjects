using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using CoreAPI.Domain.Entities;
using CoreAPI.Domain.Interfaces.Services;
using CoreAPI.Application.Services;
using Microsoft.AspNetCore.SignalR;
using CoreAPI.Hubs;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private IHubContext<SubscriptionHub> _hub;
        private readonly ILogService _logService;
        private readonly ISubscriptionService _subscriptionService;

        public ServicesController(ILogService logService, ISubscriptionService subscriptionService, IHubContext<SubscriptionHub> hub)
        {
            _hub = hub;
            _logService = logService;
            _subscriptionService = subscriptionService;
        }

        [HttpGet("test")]
        public IActionResult TestEndpoint()
        {

            return Ok("Im here! The Core API aplication is running.");
        }

        [HttpPost("v1/subscribe")]
        public IActionResult ServiceSubscribe([FromBody] Machine serviceInfo)
        {
            // nesse momento deve haver o uso do WebSocket para repassar a informação ao front
            var result = _subscriptionService.Subscribe(serviceInfo);

            if (serviceInfo != null)
                return Ok(result);
            else
                return BadRequest("The object send is invalid.");
        }

        [HttpPost("v1/unsubscribe")]
        public IActionResult ServiceUnsubscribe([FromBody] Machine serviceInfo)
        {
            // nesse momento deve haver o uso do WebSocket para repassar a informação ao front
            var result = _subscriptionService.Unsubscribe(serviceInfo);

            if (serviceInfo != null)
                return Ok(result);
            else
                return BadRequest("The object send is invalid.");
        }

        [HttpGet("v1/subscription")]
        public IActionResult SignalRTest()
        {
            this._hub.Clients.All.SendAsync("transferchartdata", new { resp = "resposta SignalR" });
            return Ok("Retorno Teste");
        }

        [HttpGet("v1/list")]
        public IActionResult GetServiceList()
        {
            var result = _subscriptionService.GetRestisteredMachines();
            return Ok(result);
        } 
    }
}