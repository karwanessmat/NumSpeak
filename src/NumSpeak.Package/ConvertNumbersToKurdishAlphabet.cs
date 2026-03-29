using System.Text;

namespace NumSpeaks
{

    public static class ConvertNumbersToKurdishAlphabet
    {
        public static string ToKurdishWords(this object val, Currency? currency = null)
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
                    var integerWords = integerPart.ToKurdishWords();
                    var decimalWords = decimalPart.ToKurdishWords();

                    if (currency.HasValue)
                    {
                        var info = CurrencyInfo.Get(currency.Value);
                        return $"{integerWords} {info.KurdishName} و {decimalWords} {info.KurdishSubUnit}";
                    }

                    return $"{integerWords} و پۆینت {decimalWords}";
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

            if (currency.HasValue)
            {
                var info = CurrencyInfo.Get(currency.Value);
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
