## FizzBuzz Kata trainer notes
# Trainer A
1. First round - add first failing test

    `FizzBuzzShould.cs`
    ```csharp    
    namespace FizzBuzz.Tests;

    using FizzBuzz.Demo;
    using NUnit.Framework;

    [TestFixture]
    public class FizzBuzzShould
    {
        [Test]
        public void Convert_1_to_1()
        {
            var result = FizzBuzz.Convert(1);
            Assert.That(result, Is.EqualTo("1"));            
        }
    }       
    ```
    
1. Add method with no implementation (fail for the right reason)

    `FizzBuzz.cs`
    ```csharp
    namespace FizzBuzz.Demo;

    public static class FizzBuzz
    {
        public static string Convert(int number)
        {
            throw new NotImplementedException();
        }
    }        
    ```
    Run test to see it's red

# Trainer B
1. Make first test pass in the simplest possible way
    > You are not allowed to write any production code unless it is for making a failing unit test pass

    `FizzBuzz.cs`
    ```csharp
    public static string Convert(int number)
    {  
        return "1";
    }
    ```
    Run test to see it's green

1. There's no duplication in the code that can be removed, so there's no refactoring to do yet.

1. Second round - write test which will fail

    `FizzBuzzShould.cs`
    ```csharp
    [Test]
    public void Convert_2_to_2()
    {
        var result = FizzBuzz.Convert(2);
        Assert.That(result, Is.EqualTo("2"));
    }   
    ```
    Run test to see it's red

# Trainer A
1. Write the simplest code to make it work

    `FizzBuzz.cs`
    ```csharp
    public static string Convert(int number)
    {  
        if (number == 2)
        {
            return "2";
        }

        return "1";
    }
    ```
    Run all tests to see all are green

1. Phase of refactoring for both code and tests, we see some duplication, but it's better to wait a bit more to have more information and see the whole picture
    > Until we see three cases of obvious redundancy, we will defer refactoring it out. This is known as the Rule of Three.

1. Third round - Time for a red test - we take 4 to finish writing implementation for this feature - which is returning same number as input

    `FizzBuzzShould.cs`
    ```csharp
    [Test]
    public void Convert_4_to_4()
    {
        var result = FizzBuzz.Convert(4);
        Assert.That(result, Is.EqualTo("4"));
    }  
    ```
    Run test to see it's red

# Trainer B
1. Write the simplest code to make it work

    `FizzBuzz.cs`
    ```csharp
    public static string Convert(int number)
    {  
        if (number == 4)
        {
            return "4";
        }

        if (number == 2)
        {
            return "2";
        }

        return "1";
    }
    ```
    Run all tests to see all are green

1. Refactoring - we see some duplicated code, so following DRY and also the Rule of Three (we can see a pattern) - we can remove redundant code

    `FizzBuzz.cs`
    ```csharp
    public static string Convert(int number)
    {  
        return number.ToString();
    }
    ```

    Tests are first class ctizens - they need refactoring too
    Add parametrized test

    `FizzBuzzShould.cs`
    ```csharp
    [TestCase(1, "1")]
    [TestCase(2, "2")]
    [TestCase(4, "4")]
    public void Convert_RegularNumber_To_Self(int number, string expectedValue)
    {
        var result = FizzBuzz.Convert(number);
        Assert.That(result, Is.EqualTo(expectedValue));
    }
    ```

    Run all tests to see all are green
    Now it's safe to remove old tests (from 1-3)

1. Fourth round 
    Our first feature is completed, we can check that by adding next number which follows rule display same number
    we can check that by adding another test case which will be green

    `FizzBuzzShould.cs`
    ```csharp
    [TestCase(1, "1")]
    [TestCase(2, "2")]
    [TestCase(4, "4")]
    [TestCase(7, "7")]
    public void Convert_RegularNumber_To_Self(int number, int expectedValue)
    ```
    
    Next step is to focus on next feature "Return Fizz for multiples of 3" and write failing test for it
    > We now try to use the third implementation strategy of triangulation. We do this by creating a specific test case, that forces the behaviour of your code to change.

    `FizzBuzzShould.cs`
    ```csharp
    [Test]
    public void Convert_3_To_Fizz()
    {
        var result = FizzBuzz.Convert(3);
        Assert.That(result, Is.EqualTo("Fizz"));
    }
    ```
    Run test and see it's red    


# Trainer A
1. Write code which is necessary to make the test pass

    `FizzBuzz.cs`
    ```csharp
    public static string Convert(int number)
    {  
        if (number == 3)
        {
            return "Fizz";
        }

        return number.ToString();
    }
    ``` 
    Run all tests to see all are green

1. No need for refactoring at this stage

1. Fifth round - failing test following the same rule (multiples of 3)

    `FizzBuzzShould.cs`
    ```csharp
    [Test]
    public void Convert_6_To_Fizz()
    {
        var result = FizzBuzz.Convert(6);
        Assert.That(result, Is.EqualTo("Fizz"));
    }
    ```
    Run test and see it's red

# Trainer B
1. Write code which is necessary to make the test pass

    `FizzBuzz.cs`
    ```csharp
    public static string Convert(int number)
    {  
        if (number == 3 || number == 6)
        {
            return "Fizz";
        }

        return number.ToString();
    }
    ``` 
    Run all tests to see all are green

1. No need for refactoring at this stage

1. Sixth round - failing test following the same rule (multiples of 3)

    `FizzBuzzShould.cs`
    ```csharp
    [Test]
    public void Convert_9_To_Fizz()
    {
        var result = FizzBuzz.Convert(9);
        Assert.That(result, Is.EqualTo("Fizz"));
    }
    ```
    Run test and see it's red

# Trainer A
1. Write code which is necessary to make the test pass

    `FizzBuzz.cs`
    ```csharp
    public static string Convert(int number)
    {  
        if (number == 3 || number == 6 || number == 9)
        {
            return "Fizz";
        }

        return number.ToString();
    }
    ``` 
    Run all tests to see all are green

1. Again we see duplicated code and we can use the Rule of Three, we can see a pattern so it's a good moment for refactor
   
    `FizzBuzz.cs`
    ```csharp
    public static string Convert(int number)
    {  
        if (number % 3 == 0)
        {
            return "Fizz";
        }

        return number.ToString();
    }
    ``` 
    Run all tests to see all are green

    Tests are first class ctizens - they need refactoring too
    Add parametrized test

    `FizzBuzzShould.cs`
    ```csharp
    [TestCase(3)]
    [TestCase(6)]
    [TestCase(9)]
    public void Convert_MultiplesOf3_To_Fizz(int number)
    {
        var result = FizzBuzz.Convert(number);
        Assert.That(result, Is.EqualTo("Fizz"));
    }
    ```

    Run all tests to see all are green
    Now it's safe to remove old tests (from 1-3)

1. Seventh round - we implemented previous feature - multiples of 3
    we can add another test case to see it will be green

    `FizzBuzzShould.cs`
    ```csharp
    [TestCase(3)]
    [TestCase(6)]
    [TestCase(9)]
    [TestCase(12)]
    public void Convert_MultiplesOf3_To_Fizz(int number)    
    ```

    now we can focus on next feature - Return Buzz for multiples of 5
    And again we are using triangulation here

    `FizzBuzzShould.cs`
    ```csharp
    [Test]
    public void Convert_5_To_Buzz()
    {
        var result = FizzBuzz.Convert(5);
        Assert.That(result, Is.EqualTo("Buzz"));
    }
    ```
    
    Run test and see it's red

# Trainer B
1. Write code which is necessary to make the test pass

    `FizzBuzz.cs`
    ```csharp
    public static string Convert(int number)
    {  
        if (number == 5) 
        {
            return "Buzz";
        }

        if (number % 3 == 0)
        {
            return "Fizz";
        }

        return number.ToString();
    }
    ``` 
    Run all tests to see all are green

1. No need for refactoring at this stage

1. Eighth round - failing test following the same rule (multiples of 5)
 
    `FizzBuzzShould.cs`
    ```csharp
    [Test]
    public void Convert_10_To_Buzz()
    {
        var result = FizzBuzz.Convert(10);
        Assert.That(result, Is.EqualTo("Buzz"));
    }
    ```

    Run test and see it's red

# Trainer A
1. Write code which is necessary to make the test pass
   
    `FizzBuzz.cs`
    ```csharp
    public static string Convert(int number)
    {  
        if (number == 5 || number == 10) 
        {
            return "Buzz";
        }

        if (number % 3 == 0)
        {
            return "Fizz";
        }

        return number.ToString();
    }
    ``` 
    Run all tests to see all are green

1. No need for refactoring at this stage

1. Nineth round - failing test following the same rule (multiples of 5)

    `FizzBuzzShould.cs`
    ```csharp
    [Test]
    public void Convert_20_To_Buzz()
    {
        var result = FizzBuzz.Convert(20);
        Assert.That(result, Is.EqualTo("Buzz"));
    }
    ```

    Run test and see it's red

# Trainer B
1. Write code which is necessary to make the test pass

    `FizzBuzz.cs`
    ```csharp
    public static string Convert(int number)
    {  
        if (number == 5 || number == 10 || number == 20) 
        {
            return "Buzz";
        }

        if (number % 3 == 0)
        {
            return "Fizz";
        }

        return number.ToString();
    }
    ``` 

    Run all tests to see all are green

1. Again we see duplicated code and we can use the Rule of Three, we can see a pattern so it's a good moment for refactor

    `FizzBuzz.cs`
    ```csharp
    public static string Convert(int number)
    {  
        if (number % 5 == 0) 
        {
            return "Buzz";
        }

        if (number % 3 == 0)
        {
            return "Fizz";
        }

        return number.ToString();
    }
    ```
    Run all tests to see all are green

    Tests are first class ctizens - they need refactoring too
    Add parametrized test

    `FizzBuzzShould.cs`
    ```csharp
    [TestCase(5)]
    [TestCase(10)]
    [TestCase(20)]
    public void Convert_MultiplesOf5_To_Buzz(int number)
    {
        var result = FizzBuzz.Convert(number);
        Assert.That(result, Is.EqualTo("Buzz"));
    }
    ```

    Run all tests to see all are green
    Now it's safe to remove old tests (from 1-3)

1. Tenth round - we implemented previous feature - multiples of 5
    we can add another test case to see it will be green

    `FizzBuzzShould.cs`
    ```csharp
    [TestCase(5)]
    [TestCase(10)]
    [TestCase(20)]
    [TestCase(25)]
    public void Convert_MultiplesOf5_To_Buzz(int number)    
    ```

    now we can focus on last feature - Return FizzBuzz for multiples of 3 and 5
    And again we are using triangulation here

    `FizzBuzzShould.cs`
    ```csharp
    [Test]
    public void Convert_15_To_FizzBuzz()
    {
        var result = FizzBuzz.Convert(15);
        Assert.That(result, Is.EqualTo("FizzBuzz"));
    }
    ```
    Run test and see it's red

# Trainer A
1. Write code which is necessary to make the test pass
 
    `FizzBuzz.cs`
    ```csharp
    public static string Convert(int number)
    {  
        if (number == 15)
        {
            return "FizzBuzz";
        }

        if (number % 5 == 0) 
        {
            return "Buzz";
        }

        if (number % 3 == 0)
        {
            return "Fizz";
        }

        return number.ToString();
    }
    ```
    Run all tests to see all are green

1. No need for refactoring at this stage

1. Eleventh round - failing test following the same rule (multiples of 3 and 5)
       
    `FizzBuzzShould.cs`
    ```csharp
    [Test]
    public void Convert_30_To_FizzBuzz()
    {
        var result = FizzBuzz.Convert(30);
        Assert.That(result, Is.EqualTo("FizzBuzz"));
    }
    ```
   
    Run test and see it's red

# Trainer B
1. Write code which is necessary to make the test pass
  
    `FizzBuzz.cs`
    ```csharp
    public static string Convert(int number)
    {  
        if (number == 15 || number == 30)
        {
            return "FizzBuzz";
        }

        if (number % 5 == 0) 
        {
            return "Buzz";
        }

        if (number % 3 == 0)
        {
            return "Fizz";
        }

        return number.ToString();
    }
    ```
    Run all tests to see all are green

1. No need for refactoring at this stage

1. Eleventh round - failing test following the same rule (multiples of 3 and 5)
  
    `FizzBuzzShould.cs`
    ```csharp
    [Test]
    public void Convert_45_To_FizzBuzz()
    {
        var result = FizzBuzz.Convert(45);
        Assert.That(result, Is.EqualTo("FizzBuzz"));
    }
    ```
    Run test and see it's red

# Trainer A
1. Write code which is necessary to make the test pass

    `FizzBuzz.cs`
    ```csharp
    public static string Convert(int number)
    {  
        if (number == 15 || number == 30 || number == 45)
        {
            return "FizzBuzz";
        }

        if (number % 5 == 0) 
        {
            return "Buzz";
        }

        if (number % 3 == 0)
        {
            return "Fizz";
        }

        return number.ToString();
    }
    ```
    Run all tests to see all are green

1. Again we see duplicated code and we can use the Rule of Three, we can see a pattern so it's a good moment for refactor
     `FizzBuzz.cs`
    ```csharp
    public static string Convert(int number)
    {  
        if (number % 3 == 0 && number % 5 == 0)
        {
            return "FizzBuzz";
        }

        if (number % 5 == 0) 
        {
            return "Buzz";
        }

        if (number % 3 == 0)
        {
            return "Fizz";
        }

        return number.ToString();
    }
    ```
    Run all tests to see all are green

    Tests are first class ctizens - they need refactoring too
    Add parametrized test

    `FizzBuzzShould.cs`
    ```csharp
    [TestCase(15)]
    [TestCase(30)]
    [TestCase(45)]
    public void Convert_MultiplesOf3And5_To_FizzBuzz(int number)
    {
        var result = FizzBuzz.Convert(number);
        Assert.That(result, Is.EqualTo("FizzBuzz"));
    }
    ```    

    Run all tests to see all are green
    Now it's safe to remove old tests (from 1-3)

1. Tenth round - we implemented previous feature - multiples of 3 and 5
    we can add another test case to see it will be green

    `FizzBuzzShould.cs`
    ```csharp
    [TestCase(15)]
    [TestCase(30)]
    [TestCase(45)]
    [TestCase(60)]
    public void Convert_MultiplesOf3And5_To_FizzBuzz(int number)
    ```
    Run all tests to see all are green

    That's it!