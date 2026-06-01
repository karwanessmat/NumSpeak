using System.Globalization;
using NumSpeaks;
using Xunit;

namespace NumSpeak.Package.Tests;

public class NumberToWordsTests
{
    // Parse with InvariantCulture so the decimal's SCALE is preserved exactly
    // (e.g. "3.8400000000" stays scale-10) — that scale is what used to break things.
    private static decimal D(string s) => decimal.Parse(s, CultureInfo.InvariantCulture);

    // ── USD (cents, factor 100): value-driven, scale-independent, plural-aware ──
    [Theory]
    [InlineData("1.00", "one US dollar")]                                   // singular unit, no cents
    [InlineData("1.01", "one US dollar and one cent")]                      // singular unit + singular cent
    [InlineData("1.05", "one US dollar and five cents")]
    [InlineData("2.01", "two US dollars and one cent")]                     // plural unit + singular cent
    [InlineData("3.84", "three US dollars and eighty-four cents")]
    [InlineData("3.8", "three US dollars and eighty cents")]                // scale 1 → eighty, not "eight"
    [InlineData("3.80", "three US dollars and eighty cents")]
    [InlineData("3.8400000000", "three US dollars and eighty-four cents")]  // scale 10, not "... billion"
    [InlineData("100.50", "one hundred US dollars and fifty cents")]
    [InlineData("3.074", "three US dollars and seven cents")]               // 3rd decimal rounds into cents
    [InlineData("3.74", "three US dollars and seventy-four cents")]
    [InlineData("3.749", "three US dollars and seventy-five cents")]        // rounds up
    [InlineData("3.999", "four US dollars")]                                // carries into the unit
    [InlineData("1500", "one thousand five hundred US dollars")]
    [InlineData("0.84", "zero US dollars and eighty-four cents")]           // zero → plural
    public void Usd_English(string number, string expected)
        => Assert.Equal(expected, D(number).ToEnglishWords(CurrencyCode.USD));

    // ── GBP: irregular sub-unit singular (pence → penny) ──
    [Theory]
    [InlineData("1.01", "one British pound and one penny")]
    [InlineData("1.05", "one British pound and five pence")]
    [InlineData("2.00", "two British pounds")]
    [InlineData("3.50", "three British pounds and fifty pence")]
    public void Gbp_English(string number, string expected)
        => Assert.Equal(expected, D(number).ToEnglishWords(CurrencyCode.GBP));

    // ── IQD (fils, factor 1000): invariant sub-unit "fils", plural unit ──
    [Theory]
    [InlineData("1.250", "one Iraqi dinar and two hundred fifty fils")]
    [InlineData("1.001", "one Iraqi dinar and one fils")]                   // minor==1, fils invariant
    [InlineData("1.5", "one Iraqi dinar and five hundred fils")]
    [InlineData("2.000", "two Iraqi dinars")]
    [InlineData("1500", "one thousand five hundred Iraqi dinars")]
    public void Iqd_English(string number, string expected)
        => Assert.Equal(expected, D(number).ToEnglishWords(CurrencyCode.IQD));

    // ── No-sub-unit currencies (factor 1): round to nearest whole; yen invariant plural ──
    [Theory]
    [InlineData("1", CurrencyCode.JPY, "one Japanese yen")]
    [InlineData("1500", CurrencyCode.JPY, "one thousand five hundred Japanese yen")]
    [InlineData("1500.75", CurrencyCode.JPY, "one thousand five hundred one Japanese yen")] // rounds 1500.75→1501
    [InlineData("1500.5", CurrencyCode.ISK, "one thousand five hundred one Icelandic kronas")]
    [InlineData("250.9", CurrencyCode.XOF, "two hundred fifty-one West African CFA francs")]
    public void NoSubUnit_English(string number, CurrencyCode code, string expected)
        => Assert.Equal(expected, D(number).ToEnglishWords(code));

    // ── Optional decimals override ──
    [Theory]
    [InlineData("3.74", CurrencyCode.USD, 0, "four US dollars")]                            // 0 dp → round 3.74→4
    [InlineData("1500.750", CurrencyCode.IQD, 0, "one thousand five hundred one Iraqi dinars")]
    [InlineData("3.84", CurrencyCode.USD, 2, "three US dollars and eighty-four cents")]     // explicit default
    public void DecimalsOverride_English(string number, CurrencyCode code, int decimals, string expected)
        => Assert.Equal(expected, D(number).ToEnglishWords(code, decimals));

    // ── Bare numbers (no currency): digit-by-digit, place value preserved ──
    [Theory]
    [InlineData("3.74", "three point seven four")]
    [InlineData("3.074", "three point zero seven four")]   // leading zero kept
    [InlineData("3.7", "three point seven")]
    [InlineData("3.70", "three point seven")]              // trailing zero trimmed
    [InlineData("3.07", "three point zero seven")]
    [InlineData("12.5", "twelve point five")]
    [InlineData("3.0", "three")]                           // pure-zero fraction → integer only
    [InlineData("100", "one hundred")]
    public void Bare_English(string number, string expected)
        => Assert.Equal(expected, D(number).ToEnglishWords());

    // ── The headline: 3.074 and 3.74 are now distinct in every mode/language ──
    [Fact]
    public void DistinguishesPlaceValue_AllModes()
    {
        Assert.NotEqual(D("3.074").ToEnglishWords(CurrencyCode.USD), D("3.74").ToEnglishWords(CurrencyCode.USD));
        Assert.NotEqual(D("3.074").ToArabicWords(CurrencyCode.USD),  D("3.74").ToArabicWords(CurrencyCode.USD));
        Assert.NotEqual(D("3.074").ToKurdishWords(CurrencyCode.USD), D("3.74").ToKurdishWords(CurrencyCode.USD));

        Assert.NotEqual(D("3.074").ToEnglishWords(), D("3.74").ToEnglishWords());
        Assert.NotEqual(D("3.074").ToArabicWords(),  D("3.74").ToArabicWords());
        Assert.NotEqual(D("3.074").ToKurdishWords(), D("3.74").ToKurdishWords());
    }

    // ── Arabic/Kurdish: scale-independent and value-sensitive (no brittle RTL literals) ──
    [Fact]
    public void Arabic_Kurdish_ScaleIndependent_And_ValueSensitive()
    {
        Assert.Equal(D("3.8").ToArabicWords(CurrencyCode.USD),  D("3.80").ToArabicWords(CurrencyCode.USD));
        Assert.Equal(D("3.8").ToKurdishWords(CurrencyCode.USD), D("3.80").ToKurdishWords(CurrencyCode.USD));

        Assert.NotEqual(D("3.80").ToArabicWords(CurrencyCode.USD),  D("3.84").ToArabicWords(CurrencyCode.USD));
        Assert.NotEqual(D("3.80").ToKurdishWords(CurrencyCode.USD), D("3.84").ToKurdishWords(CurrencyCode.USD));
    }

    // ── Arabic number-noun agreement: 2 → dual, 3-10 → plural (incl. broken plurals),
    //    11+/100 → singular; unpopulated currencies fall back to the singular ──
    [Fact]
    public void Arabic_NumberNounAgreement()
    {
        Assert.Contains("دولاران", D("2").ToArabicWords(CurrencyCode.USD));   // dual
        Assert.Contains("دولارات", D("3").ToArabicWords(CurrencyCode.USD));   // 3-10 plural
        Assert.Contains("دولارات", D("10").ToArabicWords(CurrencyCode.USD));
        Assert.Contains("ديناران", D("2").ToArabicWords(CurrencyCode.IQD));   // dual
        Assert.Contains("دنانير",  D("5").ToArabicWords(CurrencyCode.IQD));   // broken plural
        Assert.Contains("سنتات",   D("0.03").ToArabicWords(CurrencyCode.USD)); // 3 cents → plural

        // 11+ and 100 use the singular form (no dual/plural marker)
        Assert.DoesNotContain("دولارات", D("100").ToArabicWords(CurrencyCode.USD));
        Assert.DoesNotContain("دولاران", D("100").ToArabicWords(CurrencyCode.USD));
        Assert.DoesNotContain("دولارات", D("25").ToArabicWords(CurrencyCode.USD));

        // count 1 → noun-first "دولار ... واحد"; 11 → masculine "أحد عشر"
        Assert.Contains("دولار أمريكي واحد", D("1").ToArabicWords(CurrencyCode.USD));
        Assert.Contains("أحد عشر", D("11").ToArabicWords(CurrencyCode.USD));
        Assert.Contains("جنيهات", D("3").ToArabicWords(CurrencyCode.GBP)); // extended currency

        // Unpopulated currency: falls back to singular, no throw
        Assert.Contains("يورو", D("3").ToArabicWords(CurrencyCode.EUR));
    }

    // ── Arabic gender agreement (مخالفة): feminine nouns take the opposite-gender
    //    numeral (ثلاث not ثلاثة), واحدة, إحدى عشرة; sub-unit gender is independent ──
    [Fact]
    public void Arabic_GenderAgreement()
    {
        // feminine main noun (SYP ليرة)
        Assert.Contains("ثلاث ليرات", D("3").ToArabicWords(CurrencyCode.SYP));   // bare numeral
        Assert.DoesNotContain("ثلاثة", D("3").ToArabicWords(CurrencyCode.SYP));  // not the masculine ة-form
        Assert.Contains("ليرتان", D("2").ToArabicWords(CurrencyCode.SYP));        // feminine dual
        Assert.Contains("ليرة سورية واحدة", D("1").ToArabicWords(CurrencyCode.SYP)); // واحدة
        Assert.Contains("إحدى عشرة", D("11").ToArabicWords(CurrencyCode.SYP));    // feminine eleven

        // masculine main noun still uses the ة-numeral
        Assert.Contains("ثلاثة دولارات", D("3").ToArabicWords(CurrencyCode.USD));

        // feminine sub-unit (SAR halala) is independent of the masculine riyal
        Assert.Contains("ثلاث هللات", D("1.03").ToArabicWords(CurrencyCode.SAR));

        // compound ending in 3 → plural noun (103 → دولارات)
        Assert.Contains("دولارات", D("103").ToArabicWords(CurrencyCode.USD));
    }

    // ── Non-numeric / malformed input is still rejected ──
    [Theory]
    [InlineData("abc")]
    [InlineData("3.7.4")]
    public void BadInput_English(string bad)
        => Assert.Equal("Just support number", bad.ToEnglishWords());
}
