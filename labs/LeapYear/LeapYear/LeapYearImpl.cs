namespace LeapYear
{
    public class LeapYearImpl
    {
        public static bool IsLeapYear(int year)
        {
	        return year % 4 == 0;
        }
    }
}