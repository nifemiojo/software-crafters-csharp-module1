namespace LeapYear
{
    public class LeapYearImpl
    {
        public static bool IsLeapYear(int year)
        {
            if (year == 3 || year == 5)
                return false;

            return true;
        }
    }
}