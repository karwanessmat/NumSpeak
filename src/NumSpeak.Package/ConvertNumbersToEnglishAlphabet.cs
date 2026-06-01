namespace NumSpeaks;



public static class ConvertNumbersToEnglishAlphabet
{
    private static readonly string[] Units = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    private static readonly string[] Teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
    private static readonly string[] Tens = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
    private static readonly string[] Thousands = { "", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion" };

    // Currency pluralization. Main names are stored singular ("US dollar"), sub-units
    // plural ("cents"): pluralize the unit when the count isn't 1, singularize the
    // sub-unit when it is. Invariant units / irregular sub-unit singulars are listed.
    private static readonly HashSet<string> InvariantUnits =
        new(StringComparer.OrdinalIgnoreCase) { "yen", "won" };
    private static readonly Dictionary<string, string> SubUnitSingular =
        new(StringComparer.OrdinalIgnoreCase) { ["pence"] = "penny", ["paise"] = "paisa", ["fils"] = "fils", ["kurus"] = "kurus" };

    public static string ToEnglishWords(
        this object val, 
        CurrencyCode? currencyCode = null, 
        int? decimals = null)
    {
        var stringVal = val.ToString()?.Trim() ?? "";

        // Currency amounts: split into whole units + sub-units using the currency's
        // SubUnitFactor (cents = 100, fils/dinar = 1000, yen = 1). Done on the decimal
        // value rather than the text after '.', so the result no longer depends on how
        // many decimals the caller passed (3.8, 3.80 and 3.8400000000 all read the same)
        // and non-100 currencies (dinar fils, yen) come out right.
        if (currencyCode.HasValue && MoneyParts.TryGetDecimal(val, out var money))
        {
            var info = CurrencyInfo.Get(currencyCode.Value);
            // decimals == null → currency's natural sub-unit; otherwise honour the caller's
            // precision (e.g. IQD with decimals: 0 → no fils). Pass 0 or the currency's real power.
            var factor = decimals is int dp ? MoneyParts.Pow10(dp) : info.SubUnitFactor;
            MoneyParts.Split(money, factor, out var whole, out var minor);
            var sign = money < 0 ? "- " : "";
            var unit = whole == 1 ? info.EnglishName : PluralizeUnit(info.EnglishName);
            return minor == 0
                ? $"{sign}{whole.ToEnglishWords()} {unit}"
                : $"{sign}{whole.ToEnglishWords()} {unit} and {minor.ToEnglishWords()} {(minor == 1 ? SingularizeSubUnit(info.EnglishSubUnit) : info.EnglishSubUnit)}";
        }

        // Handle decimal numbers (no currency — currency is handled above)
        if (stringVal.Contains('.'))
        {
            var parts = stringVal.Split('.');
            if (parts.Length == 2
                && long.TryParse(parts[0], out var integerPart)
                && parts[1].Length > 0
                && parts[1].All(char.IsDigit))
            {
                var integerWords = integerPart.ToEnglishWords();

                // Read the fraction digit-by-digit after "point" so place value is kept:
                // 3.074 → "three point zero seven four", distinct from 3.74. Trailing zeros
                // are trimmed (3.7 and 3.70 read the same); a pure-zero fraction → integer only.
                var fraction = parts[1].TrimEnd('0');
                if (fraction.Length == 0)
                    return integerWords;

                var digits = string.Join(" ", fraction.Select(d => Units[d - '0']));
                return $"{integerWords} point {digits}";
            }

            return "Just support number";
        }

        var isNumber = long.TryParse(stringVal, out var number);

        if (!isNumber)
        {
            return "Just support number";
        }

        if (number == 0)
            return "zero";

        if (number < 0)
            return "- " + ToEnglishWords(Math.Abs(number));

        var words = "";

        int thousandCounter = 0;

        while (number > 0)
        {
            if (number % 1000 != 0)
            {
                var prefix = ConvertLessThanOneThousand(number % 1000) + " " + Thousands[thousandCounter];
                words = prefix.Trim() + (string.IsNullOrEmpty(words) ? "" : " " + words);
            }

            number /= 1000;
            thousandCounter++;
        }

        var result = words.Trim();

        if (currencyCode.HasValue)
        {
            var info = CurrencyInfo.Get(currencyCode.Value);
            result = $"{result} {info.EnglishName}";
        }

        return result;
    }

    private static string ConvertLessThanOneThousand(long number)
    {
        string words = "";

        if (number % 100 < 20)
        {
            // When number % 100 == 0 (e.g. 100, 600, 1500's "500") there are no
            // tens/units to spell — leave words empty so "six hundred" doesn't
            // become "six hundred zero". Only the < 10 / teens branches emit words.
            var rem = number % 100;
            words = rem == 0 ? "" : (rem < 10 ? Units[rem] : Teens[rem - 10]);
            number /= 100;
        }
        else
        {
            if (number % 10 != 0)
            {
                words = Units[number % 10];
            }
            number /= 10;

            if (number % 10 > 0)
            {
                words = (words != "" ? Tens[number % 10] + "-" : Tens[number % 10]) + words;
            }
            number /= 10;
        }

        if (number > 0)
        {
            words = Units[number] + " hundred" + (string.IsNullOrEmpty(words) ? "" : " " + words);
        }

        return words;
    }

    // "US dollar" → "US dollars"; invariant units (yen, won) are unchanged.
    private static string PluralizeUnit(string name)
    {
        var space = name.LastIndexOf(' ');
        var lastWord = space < 0 ? name : name[(space + 1)..];
        return InvariantUnits.Contains(lastWord) ? name : name + "s";
    }

    // Sub-units are stored plural; produce the singular for a count of exactly one.
    private static string SingularizeSubUnit(string subUnit)
    {
        if (SubUnitSingular.TryGetValue(subUnit, out var singular)) return singular;
        return subUnit.EndsWith('s') ? subUnit[..^1] : subUnit;
    }
}
