using LeapYear;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
    public class LeapYearCalculatorShould
    {
        // Is True if:
			// Divisible by 4
			// Not divisible by 100
				//	unless also divisible by 400

	    [Test]
	    public void ReturnTrue_WhenInputIs4()
	    {
		    bool result = LeapYearImpl.IsLeapYear(4);

			Assert.True(result);
	    }

	    [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        public void ReturnFalse_WhenInputIsNotDivisibleBy4(int year)
        {
            bool result = LeapYearImpl.IsLeapYear(year);

            Assert.False(result);
        }

        [Test]
        public void ReturnFalse_WhenInputIs100()
        {
            bool result = LeapYearImpl.IsLeapYear(100);

            Assert.False(result);
        }


    }
}