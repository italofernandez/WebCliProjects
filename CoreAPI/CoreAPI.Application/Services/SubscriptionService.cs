using CoreAPI.Domain.Entities;
using CoreAPI.Domain.Interfaces.Repositories;
using CoreAPI.Domain.Interfaces.Services;
using CoreAPI.Domain.ValueObjects.Return;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreAPI.Application.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ILogRepository _logRepository;

        public SubscriptionService(IServiceRepository serviceRepository, ILogRepository logRepository)
        {
            _serviceRepository = serviceRepository;
            _logRepository = logRepository;
        }

        public CustomResponse<List<Machine>> GetRestisteredMachines()
        {
            var result = _serviceRepository.Get().ToList();
            return new CustomResponse<List<Machine>>()
            {
                Data = result,
                Message = "Machines list retrieved"
            };
        }

        public CustomResponse<Machine> Subscribe(Machine serviceInfo)
        {
            var result = _serviceRepository.Subscribe(serviceInfo);
            _logRepository.LogMessageAsync("Subscription", $"The machine {serviceInfo.MachineName} registered", DateTime.Now);
            return new CustomResponse<Machine>()
            {
                Data = result,
                Message = "Service registered"
            };
        }

        public CustomResponse<Machine> Unsubscribe(Machine serviceInfo)
        {
            var result = _serviceRepository.Unsubscribe(serviceInfo);
            _logRepository.LogMessageAsync("Unsubscription", $"The machine {serviceInfo.MachineName} unregistered", DateTime.Now);
            return new CustomResponse<Machine>()
            {
                Data = result,
                Message = "Service unregistered"
            };
        }
    }
}
