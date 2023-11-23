using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using InsonusK.Shared.Validation;
using InsonusK.Xunit.ExpectationsTest;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

public class CompareToAttribute_Test : ExpectationsTestBase
{
  public class TestClass : IComparable
  {
    private readonly int value;

    public TestClass(int value)
    {
      this.value = value;
    }
    public int CompareTo(object? obj)
    {
      if (obj is TestClass tc)
        return value.CompareTo(tc.value);
      throw new ArgumentException("wrong type");
    }
  }

  public CompareToAttribute_Test(ITestOutputHelper output, LogLevel logLevel = LogLevel.Debug) : base(output, logLevel)
  {

  }

  [Fact]
  public void WHEN_give_null_compareValue_THEN_Exception()
  {
    #region Array
    Logger.LogDebug("Test ARRAY");



    #endregion


    #region Act
    Logger.LogDebug("Test ACT");


    #endregion


    #region Assert
    Logger.LogDebug("Test ASSERT");

    Assert.Throws<ArgumentNullException>(() => new CompareAttribute<TestClass>(CompareType.EQ, null));

    #endregion
  }

  [Theory]
  [InlineData(CompareType.GE, 10)]
  [InlineData(CompareType.GE, 11)]
  [InlineData(CompareType.LE, 10)]
  [InlineData(CompareType.LE, 9)]
  [InlineData(CompareType.GT, 11)]
  [InlineData(CompareType.LT, 9)]
  [InlineData(CompareType.EQ, 10)]
  [InlineData(CompareType.NE, 11)]
  [InlineData(CompareType.NE, 9)]
  public void WHEN_compore_ok_THEN_true(CompareType compareType, int value)
  {
    #region Array
    Logger.LogDebug("Test ARRAY");

    var validation_atr = new CompareAttribute<TestClass>(compareType, new TestClass(10));
    var validated_obj = new TestClass(value);
    #endregion


    #region Act
    Logger.LogDebug("Test ACT");

    var asserted_validation_result = validation_atr.IsValid(validated_obj);

    #endregion


    #region Assert
    Logger.LogDebug("Test ASSERT");

    Assert.True(asserted_validation_result);

    #endregion
  }

  [Theory]
  [InlineData(CompareType.GE, 9)]
  [InlineData(CompareType.LE, 11)]
  [InlineData(CompareType.GT, 10)]
  [InlineData(CompareType.GT, 9)]
  [InlineData(CompareType.LT, 10)]
  [InlineData(CompareType.LT, 11)]
  [InlineData(CompareType.EQ, 11)]
  [InlineData(CompareType.EQ, 9)]
  [InlineData(CompareType.NE, 10)]
  public void WHEN_compore_not_ok_THEN_false(CompareType compareType, int value)
  {
    #region Array
    Logger.LogDebug("Test ARRAY");

    var validation_atr = new CompareAttribute<TestClass>(compareType, new TestClass(10));
    var validated_obj = new TestClass(value);
    #endregion


    #region Act
    Logger.LogDebug("Test ACT");

    var asserted_validation_result = validation_atr.IsValid(validated_obj);

    #endregion


    #region Assert
    Logger.LogDebug("Test ASSERT");

    Assert.False(asserted_validation_result);

    #endregion
  }
}