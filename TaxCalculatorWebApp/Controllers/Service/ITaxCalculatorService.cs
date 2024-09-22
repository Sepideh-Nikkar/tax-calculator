using TaxCalculatorWebApp.Controllers.Models;

namespace TaxCalculatorWebApp.Controllers.Service
{
    public interface ITaxCalculatorService
    {
        bool TryCalculateTax(CalculateTollFeeRequest request, out CalculateTollFeeResponse? response);
    }
}
