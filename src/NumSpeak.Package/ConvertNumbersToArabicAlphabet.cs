namespace NumSpeaks;

public static class ConvertNumbersToArabicAlphabet
{
    public static string ToArabicWords(this object val, Currency? currency = null)
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
                var integerWords = integerPart.ToArabicWords();
                var decimalWords = decimalPart.ToArabicWords();

                if (currency.HasValue)
                {
                    var info = CurrencyInfo.Get(currency.Value);
                    return $"{integerWords} {info.ArabicName} و {decimalWords} {info.ArabicSubUnit}";
                }

                return $"{integerWords} فاصل {decimalWords}";
            }

            return "وهو يدعم الأرقام فقط.";
        }

        var isNumber = long.TryParse(stringVal, out var number);

        if (!isNumber)
        {
            return "وهو يدعم الأرقام فقط.";
        }

        if (number == 0) return "صفر";

        if (number < 0) return "minus " + Math.Abs(number).ToArabicWords();

        string words = "";

        if (number / 1000000000000 > 0)
        {
            words += ConvertTrillions(number / 1000000000000);
            number %= 1000000000000;
            if (number > 0) words += " و ";
        }

        if (number / 1000000000 > 0)
        {
            words += ConvertBillions(number / 1000000000);
            number %= 1000000000;
            if (number > 0) words += " و ";
        }

        if (number / 1000000 > 0)
        {
            words += ConvertMillions(number / 1000000);
            number %= 1000000;
            if (number > 0) words += " و ";
        }

        if (number / 1000 > 0)
        {
            words += ConvertThousands(number / 1000);
            number %= 1000;
            if (number > 0) words += " و ";
        }

        if (number / 100 > 0)
        {
            words += ConvertHundreds(number / 100);
            number %= 100;
            if (number > 0) words += " و ";
        }

        if (number > 0)
        {
            words += ConvertTensAndUnits(number);
        }

        var result = words.Trim();

        if (currency.HasValue)
        {
            var info = CurrencyInfo.Get(currency.Value);
            result = $"{result} {info.ArabicName}";
        }

        return result;
    }

    private static string ConvertTrillions(long number)
    {
        if (number == 1) return "تريليون";
        if (number == 2) return "تريليونان";
        if (number > 2 && number < 11) return number.ToArabicWords() + " تريليونات";
        return number.ToArabicWords() + " تريليون";
    }

    private static string ConvertBillions(long number)
    {
        if (number == 1) return "مليار";
        if (number == 2) return "ملياران";
        if (number > 2 && number < 11) return number.ToArabicWords() + " مليارات";
        return number.ToArabicWords() + " مليار";
    }

    private static string ConvertMillions(long number)
    {
        if (number == 1) return "مليون";
        if (number == 2) return "إثنان مليون";
        if (number > 2 && number < 11) return number.ToArabicWords() + " ملايين";
        return number.ToArabicWords() + " مليون";
    }

    private static string ConvertThousands(long number)
    {
        if (number == 1) return "ألف";
        if (number == 2) return "ألفان";
        if (number > 2 && number < 11) return number.ToArabicWords() + " آلاف";
        return number.ToArabicWords() + " ألف";
    }

    private static string ConvertHundreds(long number)
    {
        if (number == 1) return "مئة";
        if (number == 2) return "مئتان";
        if (number > 2) return number.ToArabicWords() + " مائة";
        return "";
    }

    private static string ConvertTensAndUnits(long number)
    {
        var unitsMap = new[] { "صفر", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة" };
        var teensMap = new[] { "عشرة", "إحدى عشر", "اثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر" };
        var tensMap = new[] { "صفر", "عشرة", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };

        if (number < 10) return unitsMap[number];
        if (number >= 11 && number <= 19) return teensMap[number - 10];

        var tens = tensMap[number / 10];
        var units = number % 10 > 0 ? unitsMap[number % 10] + " و " : "";
        return units + tens;
    }



}
