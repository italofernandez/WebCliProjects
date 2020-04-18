using CoreAPI.Domain.ValueObjects;
using CoreAPI.Domain.ValueObjects.Return;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAPI.Domain.Interfaces.Services
{
    public interface ICommandService
    {
        CustomResponse<string> Execute(Command command);
    }
}
