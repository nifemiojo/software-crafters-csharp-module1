# Fibonacci Sequence using TDD

## Tech Stack

- dotnet core
- xunit
- FluentAssertions

## Step 1 - Setup Classes

## The First Test

- Always Start with Test First (Obviously!)

![warning](images\warning.png)
_Test class name along when connected with test method name should explain what test is doing in one complete sentence_

```csharp
  public class FibonacciEnumeratorShould
  {
      [Fact]
      public void Return_First_Element_As_One()
      {
          var seq = new FibonacciSequence.FibonacciEnumerator();
          seq.First().ShouldBeEqualTo(1);
      }
  }
```

![warning](images\warning.png)
_Your tests and code should not have compile errors_

![create-class-error](images\create-class-error.PNG)

![missing-implementation-error](images\missing-implementation-error.PNG)

![first-test-fail](images\first-test-fail.PNG)

```csharp
public class FibonacciEnumerator : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        yield return 1;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
```

![first-test-pass](images\first-test-pass.PNG)

## Step 2 - Second Test

```csharp
    [Fact]
    public void Return_Second_Element_As_One()
    {
        var seq = new FibonacciEnumerator();
        seq.ElementAt(1).ShouldBeEqualTo(1);
    }
```

![second-test-fail](images\second-test-fail.PNG)

![warning](images\warning.png)
_Remember to run all tests all time when any code/test is changed_

```csharp
    public IEnumerator<int> GetEnumerator()
    {
        yield return 1;
        yield return 1;
    }
```

![second-test-pass](images\second-test-pass.PNG)

## Step 3 - Third Test

```csharp
    [Fact]
    public void Return_Third_Element_As_Two()
    {
        var seq = new FibonacciEnumerator();
        seq.ElementAt(2).ShouldBeEqualTo(2);
    }
```

Now new test case fails, time to fix the code

```csharp
    public IEnumerator<int> GetEnumerator()
    {
        yield return 1;
        yield return 1;
        yield return 2;
    }
```

![third-test-pass](images\third-test-pass.PNG)

Refactor code? - Not yet, Remember Rule of 3 - no pattern repeating 3 times

Refactor test? - Why not - passes Rule of 3

```csharp
public class FibonacciEnumeratorShould
{
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    public void Return_Correct_Element_When_Position_Is_Passed(int position, int element)
    {
        var seq = new FibonacciEnumerator();
        seq.ElementAt(position).ShouldBeEqualTo(element);
    }
}
```

![third-test-pass](images\third-test-pass_refactored.PNG)

## Step 4 - Fourth Test

Lets add test data -   [InlineData(3, 3)]

```csharp
    public IEnumerator<int> GetEnumerator()
    {
        yield return 1;
        yield return 1;
        yield return 2;
        yield return 3;
    }
```

Refactor code? - yes, we can see pattern repeating for second, third and fourth element

```csharp
    public IEnumerator<int> GetEnumerator()
    {
        yield return 1;
        for (var i = 1; true; i++)
        {
            yield return i;
        }
    }
```

## Step 5 - Fifth Test

Lets add test data -   [InlineData(4, 5)]

and test fails...

![fifth-test-fail](images\fifth-test-fail.PNG)

Let's make it red to green

```csharp
    public IEnumerator<int> GetEnumerator()
    {
        yield return 1;
        var previous = 0;
        var current = 1;
        for (var i = 1; true; i++)
        {
            var next = previous + current;
            previous = current;
            current = next;
            yield return current;
        }
    }
```

Refactoring - Remove deadcode

```csharp
    public IEnumerator<int> GetEnumerator()
    {
        yield return 1;
        var previous = 0;
        var current = 1;
        while(true)
        {
            var next = previous + current;
            previous = current;
            current = next;
            yield return current;
        }
    }
```

## Step 5 - Sixth Test - pass till 10th element

## Step 6 - Sixth Test - check for 50th element - Fix overflow
