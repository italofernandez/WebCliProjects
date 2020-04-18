using CoreAPI.Domain.Interfaces.Services;
using CoreAPI.Domain.ValueObjects;
using CoreAPI.Domain.ValueObjects.Return;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace CoreAPI.Application.Services
{
    public class CommandService : ICommandService
    {
        private const string resource = "commands/v1/execute";
        private readonly IConfiguration _configuration;

        public CommandService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CustomResponse<string> Execute(Command command)
        {
            string host = command.MachineAddress;
            string port = _configuration["ClientApplicationPort"];
            string baseUrl = $"http://{host}:{port}/api";
            
            var client = new RestClient(baseUrl);

            var request = new RestRequest(resource, Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(command.Instruction));
            var resp = client.Execute(request);

            string feedbackMessage = "Executed command";

            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
                feedbackMessage = "An error occurred while sending the command";

            return new CustomResponse<string>()
            {
                Data = resp.Content,
                Message = feedbackMessage
            };
        }
    }
}
