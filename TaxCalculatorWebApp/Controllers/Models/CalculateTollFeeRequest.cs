
namespace TaxCalculatorWebApp.Controllers.Models
{
    public class CalculateTollFeeRequest
    {
        public DateTime[] DateTimes { get; set; }

        public string VehicleType { get; set; }
    }
}