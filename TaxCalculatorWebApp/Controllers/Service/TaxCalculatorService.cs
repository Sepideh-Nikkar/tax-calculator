using congestion.calculator;
using TaxCalculatorWebApp.Controllers.Models;

namespace TaxCalculatorWebApp.Controllers.Service
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly CongestionTaxCalculator _calculator;

        public TaxCalculatorService(CongestionTaxCalculator calculator)
        {
            _calculator = calculator;
        }

        public bool TryCalculateTax(CalculateTollFeeRequest request, out CalculateTollFeeResponse response)
        {
            response = new CalculateTollFeeResponse();
            var isVehicleFound = Enum.TryParse(request.VehicleType, true, out VehicleType vehicle);
            if (!isVehicleFound)
            {
                response.ErrorMessage = "Invalid vehicle Type";
                return false;
            }

            if (request.DateTimes.Length == 0)
            {
                response.ErrorMessage = "No dates provided";
                return false;
            }
            else if (request.DateTimes.Any(dateTime => dateTime.Year != 2013))
            {
                response.ErrorMessage = "This API only supports year 2013";
                return false;
            }

            var totalTax = _calculator.GetTax(vehicle, request.DateTimes);
            response = new CalculateTollFeeResponse
            {
                TotalTax = totalTax
            };
            return true;
        }
    }
}
