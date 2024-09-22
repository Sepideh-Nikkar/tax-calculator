using congestion.calculator;
using System;
public class CongestionTaxCalculator
{
    /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total congestion tax for that day
         */

    public int GetTax(VehicleType vehicle, DateTime[] dates)
    {
        if (dates == null || dates.Length == 0) return 0;

        Array.Sort(dates);

        DateTime intervalStart = dates[0];
        var totalFee = GetTollFee(intervalStart, vehicle);
        for (int i = 1; i < dates.Length; i++)
        {
            int intervalStartFee = GetTollFee(intervalStart, vehicle);
            int nextFee = GetTollFee(dates[i], vehicle);

            if (AreDatesAnHourApart(dates[i], intervalStart))
            {
                totalFee += nextFee;
                intervalStart = dates[i];
            }
            else
            {
                totalFee -= intervalStartFee;
                totalFee += (nextFee >= intervalStartFee) ? nextFee : intervalStartFee;
            }
        }

        return Math.Min(totalFee, 60);
    }

    private bool AreDatesAnHourApart(DateTime date1, DateTime date2)
    {
        if (date1.Day != date2.Day)
            return true;

        var secondsDiff = date1.Hour * 3600 + date1.Minute * 60 + date1.Second - (date2.Hour * 3600 + date2.Minute * 60 + date2.Second);
        return secondsDiff / 60 >= 60;
    }

    public int GetTollFee(DateTime date, VehicleType vehicle)
    {
        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

        int hour = date.Hour;
        int minute = date.Minute;

        if (hour == 6 && minute >= 0 && minute <= 29) return 8;
        else if (hour == 6 && minute >= 30 && minute <= 59) return 13;
        else if (hour == 7 && minute >= 0 && minute <= 59) return 18;
        else if (hour == 8 && minute >= 0 && minute <= 29) return 13;
        else if ((hour == 8 && minute >= 30) || (hour == 14 && minute <= 59) || (hour > 9 && hour < 14)) return 8;
        else if (hour == 15 && minute >= 0 && minute <= 29) return 13;
        else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;
        else if (hour == 17 && minute >= 0 && minute <= 59) return 13;
        else if (hour == 18 && minute >= 0 && minute <= 29) return 8;
        else return 0;
    }

    private bool IsTollFreeDate(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

        if (year == 2013)
        {
            if (month == 1 && day == 1 ||
                month == 3 && (day == 28 || day == 29) ||
                month == 4 && (day == 1 || day == 30) ||
                month == 5 && (day == 1 || day == 8 || day == 9) ||
                month == 6 && (day == 5 || day == 6 || day == 21) ||
                month == 11 && day == 1 ||
                month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
            {
                return true;
            }
        }
        return false;
    }

    private bool IsTollFreeVehicle(VehicleType vehicle)
    {
        return vehicle == VehicleType.Motorcycle ||
               vehicle == VehicleType.Tractor ||
               vehicle == VehicleType.Emergency ||
               vehicle == VehicleType.Diplomat ||
               vehicle == VehicleType.Foreign ||
               vehicle == VehicleType.Military;
    }
}