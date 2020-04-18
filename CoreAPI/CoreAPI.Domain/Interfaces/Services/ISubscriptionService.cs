using CoreAPI.Domain.Entities;
using CoreAPI.Domain.ValueObjects.Return;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAPI.Domain.Interfaces.Services
{
    public interface ISubscriptionService
    {
        CustomResponse<Machine> Subscribe(Machine serviceInfo);
        CustomResponse<Machine> Unsubscribe(Machine serviceInfo);
        CustomResponse<List<Machine>> GetRestisteredMachines();
    }
}
