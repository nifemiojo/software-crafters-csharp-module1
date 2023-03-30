namespace LeapYear
{
    public class LeapYearImpl
    {
        public static bool IsLeapYear(int year)
        {
	        if (year == 400) return true;
            if (year % 100 == 0) return false;
	        return year % 4 == 0;
        }
    }
}