using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAPI.Domain.ValueObjects
{
    public class Command
    {
        public string Instruction { get; set; }
        public string MachineAddress { get; set; }
    }
}
