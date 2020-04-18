using Microsoft.AspNetCore.Mvc;
using WebCLI.Domain.Interfaces.Services;

namespace WebCLI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly IServiceInformation _serviceInformation;

        public SubscriptionController(IServiceInformation serviceInformation)
        {
            _serviceInformation = serviceInformation;
        }

        [HttpPost]
        [Route("v1/subscribe")]
        public IActionResult Subscribe()
        {
            _serviceInformation.Subscribe();
            return Ok();
        }

        [HttpPost]
        [Route("v1/unsubscribe")]
        public IActionResult Unsubscribe()
        {
            _serviceInformation.Unsubscribe();
            return Ok();
        }
    }
}