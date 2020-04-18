using Microsoft.AspNetCore.Mvc;
using WebCLI.Domain.Interfaces.Services;

namespace WebCLI.Controllers
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

        [HttpPost("v1/execute")]
        public IActionResult ExecuteCommand([FromBody] string command)
        {
            var result = _commandService.ExecuteCommand(command);
            return Ok(result);
        }
    }
}