namespace NumSpeaks;



public static class ConvertNumbersToEnglishAlphabet
{
    private static readonly string[] Units = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    private static readonly string[] Teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
    private static readonly string[] Tens = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
    private static readonly string[] Thousands = { "", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion" };

    public static string ToEnglishWords(this object val, CurrencyCode? currencyCode = null)
    {
        var stringVal = val.ToString()?.Trim() ?? "";

        // Handle decimal numbers
        if (stringVal.Contains('.'))
        {
            var parts = stringVal.Split('.');
            if (parts.Length == 2
                && long.TryParse(parts[0], out var integerPart)
                && long.TryParse(parts[1], out var decimalPart))
            {
                var integerWords = integerPart.ToEnglishWords();

                if (currencyCode.HasValue)
                {
                    var info = CurrencyInfo.Get(currencyCode.Value);
                    return decimalPart == 0
                        ? $"{integerWords} {info.EnglishName}"
                        : $"{integerWords} {info.EnglishName} and {decimalPart.ToEnglishWords()} {info.EnglishSubUnit}";
                }

                return decimalPart == 0
                    ? integerWords
                    : $"{integerWords} and {decimalPart.ToEnglishWords()}";
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
}
