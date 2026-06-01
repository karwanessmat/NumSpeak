using System.Globalization;

namespace NumSpeaks;

/// <summary>
/// Helpers for turning a money value into the parts a currency-aware
/// number-to-words conversion needs: the whole units and the sub-units
/// (cents / fils / …). The sub-unit count comes from the currency's
/// <see cref="CurrencyInfo.SubUnitFactor"/>, NOT from how many digits the
/// caller happened to write after the decimal point — so 3.8, 3.80 and
/// 3.8400000000 all yield the same, correct result.
/// </summary>
internal static class MoneyParts
{
    /// <summary>
    /// Read <paramref name="val"/> as a decimal. Numeric types are used directly;
    /// only string inputs are parsed, and those with <see cref="CultureInfo.InvariantCulture"/>
    /// so a locale that uses ',' as the decimal separator can't corrupt the value.
    /// </summary>
    public static bool TryGetDecimal(object? val, out decimal money)
    {
        switch (val)
        {
            case null:
                money = 0m;
                return false;
            case decimal d:
                money = d;
                return true;
            case double db:
                money = (decimal)db;
                return true;
            case float f:
                money = (decimal)f;
                return true;
            case byte or sbyte or short or ushort or int or uint or long or ulong:
                money = Convert.ToDecimal(val, CultureInfo.InvariantCulture);
                return true;
            default:
                return decimal.TryParse(val.ToString(), NumberStyles.Number,
                                        CultureInfo.InvariantCulture, out money);
        }
    }

    /// <summary>
    /// Split a money value into whole units and sub-units using the currency's
    /// <paramref name="subUnitFactor"/> (100 = cents, 1000 = fils, 1 = no sub-unit).
    /// The fraction is rounded to the sub-unit, carrying into the whole part when it
    /// rounds up (e.g. 3.999 USD → whole 4, minor 0). Computed on the absolute value;
    /// callers prepend the sign.
    /// </summary>
    public static void Split(decimal money, int subUnitFactor, out long whole, out long minor)
    {
        var abs = Math.Abs(money);

        if (subUnitFactor <= 1)   // no sub-unit (e.g. yen) → round to the nearest whole unit
        {
            whole = (long)Math.Round(abs, MidpointRounding.AwayFromZero);
            minor = 0;
            return;
        }

        whole = (long)decimal.Truncate(abs);
        minor = (long)Math.Round((abs - whole) * subUnitFactor, MidpointRounding.AwayFromZero);
        if (minor >= subUnitFactor)   // fraction rounded up to a whole unit
        {
            whole++;
            minor = 0;
        }
    }

    /// <summary>
    /// 10^<paramref name="exponent"/> as a sub-unit factor: 0 → 1 (no sub-unit),
    /// 2 → 100 (cents), 3 → 1000 (fils). Lets a caller choose the precision
    /// explicitly instead of the currency default. Clamped to a safe range.
    /// </summary>
    public static int Pow10(int exponent)
    {
        if (exponent <= 0) return 1;
        if (exponent > 9) exponent = 9;   // 10^9 fits in int; guard against overflow
        var result = 1;
        for (var i = 0; i < exponent; i++) result *= 10;
        return result;
    }
}
