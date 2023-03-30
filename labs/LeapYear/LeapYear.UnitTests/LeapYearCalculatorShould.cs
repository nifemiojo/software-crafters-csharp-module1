using LeapYear;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
    public class LeapYearCalculatorShould
    {
        // Divisible by 4

	    [Test]
	    public void ReturnTrue_WhenInputIs4()
	    {
		    bool result = LeapYearImpl.IsLeapYear(4);

			Assert.True(result);
	    }

        [Test]
        public void ReturnFalse_WhenInputIs3()
        {
            bool result = LeapYearImpl.IsLeapYear(3);

            Assert.False(result);
        }
        
        [Test]
        public void ReturnFalse_WhenInputIs5()
        {
            bool result = LeapYearImpl.IsLeapYear(5);

            Assert.False(result);
        }
    }
}