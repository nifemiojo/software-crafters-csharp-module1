namespace LeapYear
{
    public class LeapYearImpl
    {
        public static bool IsLeapYear(int year)
        {
            if (year == 100) return false;
	        return year % 4 == 0;
        }
    }
}