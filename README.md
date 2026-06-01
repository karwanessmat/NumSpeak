
# NumSpeaks - Number to Words Converter

A .NET library to convert numbers into words in **English**, **Arabic**, and **Kurdish (Sorani)**, with proper **currency support** for 155+ ISO 4217 currencies — correct sub-units, English pluralization, and standard Arabic number-noun agreement (including gender).

## What's new in 3.3.0

- **Correct sub-units** — cents/fils are computed from the amount and each currency's sub-unit size, not the raw digits after the decimal point. `3.8` now reads "eighty cents" (not "eight"), and a high-precision value like `3.8400000000` no longer becomes "… billion cents".
- **`decimals` override** — optionally set the sub-unit precision per call (e.g. `decimals: 0` to suppress fils).
- **English pluralization** — "three US dollars", "one US dollar and **one cent**".
- **Standard Arabic agreement (العدد والمعدود)** — dual, plural (incl. broken plurals دنانير/دراهم), and **gender**: "ثلاث ليرات" (feminine) vs "ثلاثة دولارات" (masculine).
- **Digit-by-digit bare decimals** — `3.074` → "three point zero seven four", distinct from `3.74`.
- **Zero-decimal currencies** (yen, ISK, CFA francs…) print with no sub-unit and round to the whole unit.

## Features

- Convert numbers to words in English, Arabic, and Kurdish.
- Decimal amounts, with currency-aware sub-units.
- **155+ currencies** via a type-safe `CurrencyCode` enum — no string typos.
- Each currency can be referenced by **ISO code** or **descriptive name**.
- Standard financial wording (unit + sub-unit), pluralized in English; Arabic number-noun agreement with gender for currencies that carry grammatical data.

## Installation

```bash
dotnet add package NumSpeaks
```

## Usage

### Basic Number to Words

```csharp
using NumSpeaks;

// English
var english = 123_456_789.ToEnglishWords();
// one hundred twenty-three million four hundred fifty-six thousand seven hundred eighty-nine

// Kurdish
var kurdish = 991_887_766_551.ToKurdishWords();
// نۆ سەد و نۆوەت و یەک ملیار و هەشت سەد و هەشتا و حەوت ملیۆن و حەوت سەد و شەست و شەش هەزار و پێنج سەد و پەنجا و یەک
```

### Decimal Numbers (no currency) — read digit by digit

```csharp
// English
(123.33m).ToEnglishWords();   // one hundred twenty-three point three three
(3.074m).ToEnglishWords();    // three point zero seven four
(3.74m).ToEnglishWords();     // three point seven four   (distinct from 3.074)

// Kurdish
(123.33m).ToKurdishWords();   // سەد و بیست و سێ پۆینت سێ سێ

// Arabic
(123.33m).ToArabicWords();    // مئة و ثلاثة و عشرون فاصل ثلاثة ثلاثة
```

### Currency Support (Type-Safe)

Use either the **ISO code** or the **descriptive name** — both are equivalent:

```csharp
// By ISO code
var usd = (234.32m).ToEnglishWords(CurrencyCode.USD);
// two hundred thirty-four US dollars and thirty-two cents

// By descriptive name (same result)
var usd2 = (234.32m).ToEnglishWords(CurrencyCode.UnitedStatesDollar);
// two hundred thirty-four US dollars and thirty-two cents
```

### Currency in All Languages

```csharp
// English with Iraqi Dinar (fils = 3 sub-unit digits)
(1500.750m).ToEnglishWords(CurrencyCode.IQD);
// one thousand five hundred Iraqi dinars and seven hundred fifty fils

// English with Turkish Lira
(250.99m).ToEnglishWords(CurrencyCode.TurkishLira);
// two hundred fifty Turkish liras and ninety-nine kurus

// Kurdish with Euro
(50.25m).ToKurdishWords(CurrencyCode.Euro);
// پەنجا یۆرۆ و بیست و پێنج سەنت

// Whole number with currency (pluralized in English)
(1000).ToEnglishWords(CurrencyCode.BritishPound);
// one thousand British pounds
```

### Override the sub-unit precision

By default the sub-unit follows the currency (2 for USD, 3 for IQD, 0 for JPY). Pass `decimals` to override it:

```csharp
(1500.75m).ToEnglishWords(CurrencyCode.IQD, decimals: 0);
// one thousand five hundred one Iraqi dinars   (no fils)
```

### Arabic — standard number-noun agreement, including gender

The numeral agrees with the counted noun (العدد والمعدود): 1 → singular, 2 → dual, 3–10 → plural, 11+ → singular; and 3–10 take the opposite-gender numeral (مخالفة):

```csharp
(3m).ToArabicWords(CurrencyCode.USD);    // ثلاثة دولارات أمريكية   (masculine noun)
(3m).ToArabicWords(CurrencyCode.SYP);    // ثلاث ليرات سورية         (feminine noun: ثلاث, not ثلاثة)
(99.50m).ToArabicWords(CurrencyCode.SAR);// تسعة و تسعون ريال سعودي و خمسون هللة
```

### Supported Currencies

All 155 ISO 4217 currencies are supported. Each can be referenced by code or name:

| ISO Code | Descriptive Name | English | Kurdish | Arabic |
|----------|-----------------|---------|---------|--------|
| `USD` | `UnitedStatesDollar` | US dollar | دۆلاری ئەمریکی | دولار أمريكي |
| `EUR` | `Euro` | euro | یۆرۆ | يورو |
| `GBP` | `BritishPound` | British pound | پاوەندی بەریتانی | جنيه إسترليني |
| `IQD` | `IraqiDinar` | Iraqi dinar | دیناری عێراقی | دينار عراقي |
| `TRY` | `TurkishLira` | Turkish lira | لیرەی تورکی | ليرة تركية |
| `SAR` | `SaudiRiyal` | Saudi riyal | ریاڵی سعوودی | ريال سعودي |
| `AED` | `UnitedArabEmiratesDirham` | UAE dirham | دیرهەمی ئیماراتی | درهم إماراتي |
| `KWD` | `KuwaitiDinar` | Kuwaiti dinar | دیناری کوەیتی | دينار كويتي |
| `JPY` | `JapaneseYen` | Japanese yen | یەنی ژاپۆنی | ين ياباني |
| `CNY` | `ChineseYuan` | Chinese yuan | یوانی چینی | يوان صيني |
| ... | ... | ... | ... | ... |

And 145+ more currencies with full support.

## API Reference

```csharp
// Extension methods on any numeric value.
// currencyCode: omit for a plain number; supply to format as money (unit + sub-unit).
// decimals:     optional precision override; defaults to the currency's natural sub-unit.
public static string ToEnglishWords(this object value, CurrencyCode? currencyCode = null, int? decimals = null);
public static string ToArabicWords (this object value, CurrencyCode? currencyCode = null, int? decimals = null);
public static string ToKurdishWords(this object value, CurrencyCode? currencyCode = null, int? decimals = null);
```

> English pluralization and Arabic number-noun agreement are applied for the currencies that carry grammatical data (USD, IQD, SAR, AED, KWD, QAR, GBP, EGP, JOD, BHD, LYD, YER, SYP, …); any other currency falls back to a safe singular form.

## Feedback

If you encounter issues or have suggestions, please [open an issue](https://github.com/karwanessmat/NumSpeak/issues) on the [GitHub repository](https://github.com/karwanessmat/NumSpeak).

## License

This project is licensed under the [MIT License](LICENSE).
