using InsonusK.Xunit.ExpectationsTest;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace InsonusK.Shared.Validation.Test;

public class UTCKindAttributeTest : ExpectationsTestBase
{
    public UTCKindAttributeTest(ITestOutputHelper output, LogLevel logLevel = LogLevel.Debug) : base(output, logLevel)
    {
    }

    [Fact]
    public void WHEN_dt_is_UTC_THEN_Ok()
    {
        #region Array
        Logger.LogDebug("Test ARRAY");

        var using_dt = DateTime.UtcNow;

        var usingAtr = new UTCKindAttribute();
        #endregion


        #region Act
        Logger.LogDebug("Test ACT");

        var asserted_result = usingAtr.IsValid(using_dt);

        #endregion


        #region Assert
        Logger.LogDebug("Test ASSERT");

        Expect("Expect is valid", () => Assert.True(asserted_result));

        #endregion
    }

    [Fact]
    public void WHEN_dt_is_not_UTC_THEN_Ok()
    {
        #region Array
        Logger.LogDebug("Test ARRAY");

        var using_dt = DateTime.Now;
        var usingAtr = new UTCKindAttribute();
        #endregion


        #region Act
        Logger.LogDebug("Test ACT");

        var asserted_result = usingAtr.IsValid(using_dt);

        #endregion


        #region Assert
        Logger.LogDebug("Test ASSERT");

        Expect("Expect is not valid", () => Assert.False(asserted_result));

        #endregion
    }
}