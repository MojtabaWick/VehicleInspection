using VehicleInspection.Domain.Core._common;

namespace VehicleInspection.Domain.Core.OperatorAgg.Entities
{
    public class Operator : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}