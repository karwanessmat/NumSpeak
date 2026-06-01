using System.Text;

namespace NumSpeaks
{

    public static class ConvertNumbersToKurdishAlphabet
    {
        private static readonly string[] KurdishDigits = { "سفر", "یەک", "دوو", "سێ", "چوار", "پێنج", "شەش", "حەوت", "هەشت", "نۆ" };

        public static string ToKurdishWords(this object val, CurrencyCode? currencyCode = null, int? decimals = null)
        {
            var stringVal = val.ToString()?.Trim() ?? "";

            // Currency amounts: see the English converter for the rationale. Uses the
            // currency's SubUnitFactor so the sub-unit is correct regardless of decimal scale.
            if (currencyCode.HasValue && MoneyParts.TryGetDecimal(val, out var money))
            {
                var info = CurrencyInfo.Get(currencyCode.Value);
                // decimals == null → currency's natural sub-unit; otherwise honour the caller's
                // precision (e.g. IQD with decimals: 0 → no fils). Pass 0 or the currency's real power.
                var factor = decimals is int dp ? MoneyParts.Pow10(dp) : info.SubUnitFactor;
                MoneyParts.Split(money, factor, out var whole, out var minor);
                var sign = money < 0 ? "- " : "";
                return minor == 0
                    ? $"{sign}{whole.ToKurdishWords()} {info.KurdishName}"
                    : $"{sign}{whole.ToKurdishWords()} {info.KurdishName} و {minor.ToKurdishWords()} {info.KurdishSubUnit}";
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
                    var integerWords = integerPart.ToKurdishWords();

                    // Read the fraction digit-by-digit after "پۆینت" so place value is kept
                    // (3.074 distinct from 3.74). Trailing zeros trimmed; pure-zero → integer.
                    var fraction = parts[1].TrimEnd('0');
                    if (fraction.Length == 0)
                        return integerWords;

                    var digits = string.Join(" ", fraction.Select(d => KurdishDigits[d - '0']));
                    return $"{integerWords} پۆینت {digits}";
                }

                return "تەنها پشتگیری ژمارە دەکات.";
            }

            var isNumber = long.TryParse(stringVal, out var number);

            if (!isNumber)
            {
                return "تەنها پشتگیری ژمارە دەکات.";
            }


            if (number == 0)
                return "سفر";

            if (number < 0)
                return "- " + Math.Abs(number).ToKurdishWords();

            if (number > 999999999999999)
                return "پشتگیری ژمارەی بەرزتر لە تریلیۆن ناکات.";

            var words = new StringBuilder();
            words.Append(ConvertNumberToKurdish(number));
            var result = words.ToString().Trim();

            if (currencyCode.HasValue)
            {
                var info = CurrencyInfo.Get(currencyCode.Value);
                result = $"{result} {info.KurdishName}";
            }

            return result;
        }

        private static string ConvertNumberToKurdish(long number)
        {
            var words = new StringBuilder();

            // Trillions
            if (number / 1000000000000 > 0)
            {
                words.Append(ConvertTrillions(number / 1000000000000));
                number %= 1000000000000;
                if (number > 0) words.Append(" و ");
            }

            // Billions
            if (number / 1000000000 > 0)
            {
                words.Append(ConvertBillions(number / 1000000000));
                number %= 1000000000;
                if (number > 0) words.Append(" و ");
            }

            // Millions
            if (number / 1000000 > 0)
            {
                words.Append(ConvertMillions(number / 1000000));
                number %= 1000000;
                if (number > 0) words.Append(" و ");
            }

            // Thousands
            if (number / 1000 > 0)
            {
                words.Append(ConvertThousands(number / 1000));
                number %= 1000;
                if (number > 0) words.Append(" و ");
            }

            // Hundreds
            if (number / 100 > 0)
            {
                words.Append(ConvertHundreds(number / 100));
                number %= 100;
                if (number > 0) words.Append(" و ");
            }

            // Tens and Units
            if (number > 0)
            {
                words.Append(ConvertTensAndUnits(number));
            }

            return words.ToString();
        }
        private static string ConvertTrillions(long number)
        {
            if (number == 1)
                return "یه‌ك تریلیۆن";  // Special case for one trillion
                //return "تریلیۆنێك";  // Special case for one trillion

            return number.ToKurdishWords() + " تریلیۆن";
        }

        private static string ConvertBillions(long number)
        {
            if (number == 1)
                return "یه‌ك ملیار";  // Special case for one billion
                //return "ملیارێك";  // Special case for one billion

            return number.ToKurdishWords() + " ملیار";
        }

        private static string ConvertMillions(long number)
        {
            if (number == 1)
                return "یه‌ك ملیۆن";  // Special case for one million
                //return "ملیۆنێك";  // Special case for one million

            return number.ToKurdishWords() + " ملیۆن";
        }
        private static string ConvertThousands(long number)
        {
            if (number == 1)
                return "یه‌ك هه‌زار";  // Just "هەزار" for 1000
                //return "هەزار";  // Just "هەزار" for 1000

            return number.ToKurdishWords() + " هەزار";
        }

        private static string ConvertHundreds(long number)
        {
            if (number == 1)
                return "سەد";  // Just "سەد" for 100

            return number.ToKurdishWords() + " سەد";
        }

        private static string ConvertTensAndUnits(long number)
        {
            var unitsMap = GetUnitsMap();
            var tensMap = GetTensMap();

            if (number < 20)
                return unitsMap[number];

            var tens = tensMap[number / 10];
            var units = number % 10 > 0 ? " و " + unitsMap[number % 10] : "";
            return tens + units;
        }

        private static string[] GetUnitsMap()
        {
            return new[] { "سفر", "یەک", "دوو", "سێ", "چوار", "پێنج", "شەش", "حەوت", "هەشت", "نۆ", "دە‌", "یازدە‌", "دوازدە‌", "سێزدە‌", "چواردە‌", "پازدە‌", "شازدە‌", "حەڤدە‌", "هەژدە‌", "نۆزدە‌" };
        }

        private static string[] GetTensMap()
        {
            return new[] { "سفر", "دە‌", "بیست", "سی", "چل", "پەنجا", "شەست", "حەفتا", "هەشتا", "نۆوەت" };
        }
    }
}
