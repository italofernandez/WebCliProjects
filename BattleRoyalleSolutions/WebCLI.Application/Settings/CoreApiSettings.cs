using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCLI.Application.Settings
{
    public class CoreApiSettings
    {
        public CoreApiSettings(string host)
        {
            Host = host;
        }

        public string Host { get; set; }
    }
}
