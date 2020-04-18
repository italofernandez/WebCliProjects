using CoreAPI.Domain.Interfaces.Services;
using CoreAPI.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandService _commandService;

        public CommandsController(ICommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpGet("test")]
        public IActionResult TestEndpoint()
        {
            return Ok("Im here! The Core API aplication is running.");
        }

        [HttpPost("v1/execute")]
        public IActionResult ExecuteCommand([FromBody] Command command)
        {
            var result = _commandService.Execute(command);
            return Ok(result);
        }
    }
}