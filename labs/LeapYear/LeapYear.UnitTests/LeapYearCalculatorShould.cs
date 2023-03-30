using LeapYear;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
    public class LeapYearCalculatorShould
    {
	    [Test]
	    public void ReturnTrue_WhenInputIs4()
	    {
		    bool result = LeapYearImpl.IsLeapYear(4);

			Assert.True(result);
	    }
    }
}