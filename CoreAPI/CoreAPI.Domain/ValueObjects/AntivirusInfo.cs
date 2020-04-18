using CoreAPI.Domain.Entities;

namespace CoreAPI.Domain.ValueObjects
{
    public class AntivirusInfo : Entity
    {
        public bool HasAntivirusInstalled { get; set; }
        public string ApplicationName { get; set; }

        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}