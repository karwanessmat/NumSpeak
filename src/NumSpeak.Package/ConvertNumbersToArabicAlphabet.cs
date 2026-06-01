namespace NumSpeaks;

public static class ConvertNumbersToArabicAlphabet
{
    private static readonly string[] ArabicDigits = { "صفر", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة" };

    public static string ToArabicWords(this object val, CurrencyCode? currencyCode = null, int? decimals = null)
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
            var unit = ArabicCountedNoun(whole, info.ArabicName, info.ArabicNameDual, info.ArabicNamePlural, info.ArabicFeminine);
            return minor == 0
                ? $"{sign}{unit}"
                : $"{sign}{unit} و {ArabicCountedNoun(minor, info.ArabicSubUnit, info.ArabicSubUnitDual, info.ArabicSubUnitPlural, info.ArabicSubUnitFeminine)}";
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
                var integerWords = integerPart.ToArabicWords();

                // Read the fraction digit-by-digit after "فاصل" so place value is kept
                // (3.074 distinct from 3.74). Trailing zeros trimmed; pure-zero → integer.
                var fraction = parts[1].TrimEnd('0');
                if (fraction.Length == 0)
                    return integerWords;

                var digits = string.Join(" ", fraction.Select(d => ArabicDigits[d - '0']));
                return $"{integerWords} فاصل {digits}";
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

        if (currencyCode.HasValue)
        {
            var info = CurrencyInfo.Get(currencyCode.Value);
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
        var teensMap = new[] { "عشرة", "أحد عشر", "اثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر" };
        var tensMap = new[] { "صفر", "عشرة", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };

        if (number < 10) return unitsMap[number];
        if (number >= 11 && number <= 19) return teensMap[number - 10];

        var tens = tensMap[number / 10];
        var units = number % 10 > 0 ? unitsMap[number % 10] + " و " : "";
        return units + tens;
    }

    // Arabic number-noun agreement (العدد والمعدود): 1 -> singular, 2 -> dual (the dual
    // form already conveys "two", so the numeral is dropped), 3-10 -> plural, 0/11+ ->
    // singular. Falls back to the singular when a currency has no dual/plural supplied.
    // ── Gender-aware Arabic cardinal speller for counting a noun (معدود) ──────────────
    // Bare numbers still use ToArabicWords above; this path is used only for currency
    // counts, so it can apply number-noun gender agreement (مخالفة).
    private static readonly string[] OnesMasc = { "", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة" };
    private static readonly string[] OnesFem  = { "", "واحدة", "اثنتان", "ثلاث", "أربع", "خمس", "ست", "سبع", "ثمان", "تسع" };
    private static readonly string[] TeensMascArr = { "عشرة", "أحد عشر", "اثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر" };
    private static readonly string[] TeensFemArr  = { "عشر", "إحدى عشرة", "اثنتا عشرة", "ثلاث عشرة", "أربع عشرة", "خمس عشرة", "ست عشرة", "سبع عشرة", "ثمان عشرة", "تسع عشرة" };
    private static readonly string[] TensArr = { "", "", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };
    private static readonly string[] HundredsArr = { "", "مئة", "مئتان", "ثلاثمائة", "أربعمائة", "خمسمائة", "ستمائة", "سبعمائة", "ثمانمائة", "تسعمائة" };

    // Counted-noun form + numeral with agreement: 1 -> "noun واحد(ة)" (noun-first),
    // 2 -> dual (numeral dropped), 3-10 -> plural, else -> singular. The form is governed
    // by the last two digits; the numeral is spelled with the noun's gender.
    private static string ArabicCountedNoun(long count, string singular, string? dual, string? plural, bool feminine)
    {
        if (count == 1)
            return $"{singular} {(feminine ? "واحدة" : "واحد")}";
        if (count == 2 && dual is not null)
            return dual;

        var m = count % 100;
        var form = (count == 2) ? (dual ?? singular)
                 : (m >= 3 && m <= 10) ? (plural ?? singular)
                 : singular;
        return $"{ArabicCardinal(count, feminine)} {form}";
    }

    // Full cardinal for 0..999,999,999,999. Only the trailing 0-999 group takes the noun's
    // gender; the thousand/million/billion counts are themselves masculine (ألف/مليون/مليار).
    private static string ArabicCardinal(long n, bool feminine)
    {
        if (n == 0) return "صفر";

        var segments = new List<string>();
        var billions = n / 1_000_000_000L; n %= 1_000_000_000L;
        var millions = n / 1_000_000L;     n %= 1_000_000L;
        var thousands = n / 1_000L;        n %= 1_000L;
        var rest = (int)n;

        if (billions > 0)  segments.Add(ArabicScale(billions, "مليار", "ملياران", "مليارات", "مليار"));
        if (millions > 0)  segments.Add(ArabicScale(millions, "مليون", "مليونان", "ملايين", "مليون"));
        if (thousands > 0) segments.Add(ArabicScale(thousands, "ألف", "ألفان", "آلاف", "ألف"));
        if (rest > 0)      segments.Add(ArabicBelow1000(rest, feminine));

        return string.Join(" و ", segments);
    }

    // A scale group (thousands/millions/billions). The unit word is masculine, so its count
    // is spelled masculine; the unit takes the plural (آلاف) for 3-10, singular otherwise.
    private static string ArabicScale(long count, string one, string two, string plural310, string singular)
    {
        if (count == 1) return one;
        if (count == 2) return two;
        var m = count % 100;
        var unit = (m >= 3 && m <= 10) ? plural310 : singular;
        return $"{ArabicCardinal(count, false)} {unit}";
    }

    private static string ArabicBelow1000(int n, bool feminine)
    {
        var hundreds = n / 100;
        var rest = n % 100;
        if (hundreds == 0) return ArabicTensUnits(rest, feminine);
        var head = HundredsArr[hundreds];
        return rest == 0 ? head : $"{head} و {ArabicTensUnits(rest, feminine)}";
    }

    private static string ArabicTensUnits(int n, bool feminine)
    {
        if (n == 0) return "";
        var ones = feminine ? OnesFem : OnesMasc;
        if (n < 10) return ones[n];
        if (n < 20) return (feminine ? TeensFemArr : TeensMascArr)[n - 10];
        var t = n / 10;
        var u = n % 10;
        return u == 0 ? TensArr[t] : $"{ones[u]} و {TensArr[t]}";
    }



}
