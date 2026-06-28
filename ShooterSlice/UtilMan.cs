
namespace ShooterSlice;

public static class UtilMan
{
    /// <summary>
    /// Corrects negative values to zero. If the input value is negative, it returns 0; otherwise, it returns the original value.
    /// </summary>
    /// <param name="value">The integer value to correct.</param>
    /// <returns>The corrected integer value.</returns>
    public static int NegCorrect(int value)
    {
        if (value < 0) {
            return 0;
        }
        return value;
    }
}