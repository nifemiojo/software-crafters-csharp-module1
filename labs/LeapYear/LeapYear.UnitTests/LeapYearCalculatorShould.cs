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

        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]
        public void ReturnFalse_WhenInputIsDivisibleBy100(int year)
        {
            bool result = LeapYearImpl.IsLeapYear(year);

            Assert.False(result);
        }

        [Test]
        public void ReturnTrue_WhenInputIs400()
        {
            bool result = LeapYearImpl.IsLeapYear(400);

            Assert.True(result);
        }
        
        [Test]
        public void ReturnTrue_WhenInputIs800()
        {
            bool result = LeapYearImpl.IsLeapYear(800);

            Assert.True(result);
        }

    }
}