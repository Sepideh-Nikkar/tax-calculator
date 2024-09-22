using congestion.calculator;
using Xunit;

namespace congestion_tax_calculator_tests
{
    public class CongestionTaxCalculatorTests
    {
        [Fact]
        public void GetTax_CarWithMultiEntranceInSingleTaxMarginNoneHoliday_ReturnsTotalTax()
        {
            // Arrange
            var dates = new DateTime[] { new DateTime(2013, 1, 14, 6, 0, 0), new DateTime(2013, 1, 14, 6, 29, 30) };
            var congestionTaxCalculator = new CongestionTaxCalculator();

            // Act
            var actualTax = congestionTaxCalculator.GetTax(VehicleType.Car, dates);

            // Assert
            Assert.Equal(8, actualTax);
        }
        [Fact]
        public void GetTax_CarAtMultiEntranceMarginTimeNoneHoliday_ReturnsTotalTax()
        {
            // Arrange
            var dates = new DateTime[] { new DateTime(2013, 1, 14, 6, 0, 0), new DateTime(2013, 1, 14, 6, 30, 00) };
            var congestionTaxCalculator = new CongestionTaxCalculator();

            // Act
            var actualTax = congestionTaxCalculator.GetTax(VehicleType.Car, dates);

            // Assert
            Assert.Equal(13, actualTax);
        }

        [Fact]
        public void GetTax_CarWithhMultiTaxMarginLessThanHourApartNoneHoliday_ReturnsTotalTax()
        {
            var dates = new DateTime[] { new DateTime(2013, 1, 14, 6, 0, 0), new DateTime(2013, 1, 14, 6, 31, 00) };
            var congestionTaxCalculator = new CongestionTaxCalculator();

            // Act
            var actualTax = congestionTaxCalculator.GetTax(VehicleType.Car, dates);

            // Assert
            Assert.Equal(13, actualTax);
        }

        [Fact]
        public void GetTax_CarWtithOneDayApartDatesNoneHoliday_AnHourAppartDates()
        {
            // Arrange
            var dates = new DateTime[] { new DateTime(2013, 01, 14, 21, 00, 00), new DateTime(2013, 01, 15, 21, 00, 00) };
            var congestionTaxCalculator = new CongestionTaxCalculator();

            // Act
            var actualTax = congestionTaxCalculator.GetTax(VehicleType.Car, dates);

            // Assert
            Assert.Equal(0, actualTax);

        }
        [Fact]
        public void GetTax_CarWithLessThanADayNoneHoliday_ReturnsTotalTax()
        {
            // Arrange
            var dates = new DateTime[] { new DateTime(2013, 02, 07, 6, 23, 27), new DateTime (2013, 02, 07, 15, 27, 00) }; 
            var congestionTaxCalculator = new CongestionTaxCalculator();

            // Act
            var actualTax = congestionTaxCalculator.GetTax(VehicleType.Car, dates);

            // Assert
            Assert.Equal(21, actualTax);
        }

        [Fact]
        public void GetTax_CarWithLessThanADayInTwoDatsNoneHoliday_ReturnsTotalTax()
        {
            // Arrange
            var dates = new DateTime[] { new DateTime(2013, 02, 07, 15, 27, 00), new DateTime(2013, 02, 08, 6, 27, 00) };
            var congestionTaxCalculator = new CongestionTaxCalculator();

            // Act
            var actualTax = congestionTaxCalculator.GetTax(VehicleType.Car, dates);

            // Assert
            Assert.Equal(21, actualTax);
        }

        [Fact]
        public void GetTax_CarWithLessThanADayMultipleEntranceNoneHoliday_ReturnsTotalTax()
        {
            // Arrange
            var dates = new DateTime[] { new DateTime(2013, 02, 08, 6, 27, 00), new DateTime(2013, 02, 08, 6, 20, 27), new DateTime (2013, 02,08, 14, 35,00), new DateTime(2013, 02,08, 15, 29,00), new DateTime(2013, 02, 08, 15, 47, 00), new DateTime(2013, 02, 08, 16, 01, 00), new DateTime(2013, 02, 08, 16, 48, 00) , new DateTime(2013, 02, 08, 17, 49, 00), new DateTime(2013, 02, 08, 18, 29, 00), new DateTime(2013, 02, 08, 18, 35, 00) };
            var congestionTaxCalculator = new CongestionTaxCalculator();

            // Act
            var actualTax = congestionTaxCalculator.GetTax(VehicleType.Car, dates);

            // Assert
            Assert.Equal(60, actualTax);
        }

        [Fact]
        public void GetTax_CarWithTwoDaysApartNoneHoliday_ReturnsTotalTax()
        {
            // Arrange
            var dates = new DateTime[] { new DateTime(2013, 03, 26, 14, 25, 00), new DateTime(2013, 03, 28, 14, 07, 27) };
            var congestionTaxCalculator = new CongestionTaxCalculator();

            // Act
            var actualTax = congestionTaxCalculator.GetTax(VehicleType.Car, dates);

            // Assert
            Assert.Equal(8, actualTax);
        }


        // Test Other Vehicle Types
        [Fact]
        public void GetTax_MotorcycleWithMultiEntranceInSingleTaxMarginNoneHoliday_ReturnsTotalTax()
        {
            // Arrange
            var dates = new DateTime[] { new DateTime(2013, 1, 14, 6, 0, 0), new DateTime(2013, 1, 14, 6, 29, 30) };
            var congestionTaxCalculator = new CongestionTaxCalculator();

            // Act
            var actualTax = congestionTaxCalculator.GetTax(VehicleType.Motorcycle, dates);

            // Assert
            Assert.Equal(0, actualTax);
        }
    }
}