
# NumSpeaks - Number to Words Converter

A .NET library to convert numbers into words in **Kurdish**, **Arabic**, and **English** with full **currency support** for 155+ world currencies.

## Features

- Convert numbers to words in Kurdish, Arabic, and English.
- Supports decimal numbers (e.g., 123.33).
- **155+ currencies** with type-safe `Currency` enum — no string typos.
- Each currency can be referenced by **ISO code** or **descriptive name**.
- Standard financial format with currency name and sub-unit.
- Full currency names in all 3 languages (e.g., "US dollar", "دۆلاری ئەمریکی", "دولار أمريكي").

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

// Arabic
var arabic = 123_456.ToArabicWords();
// مئة و ثلاثة و عشرون ألف و أربعة مائة و ستة و خمسون
```

### Decimal Numbers

```csharp
// English
var en = 123.33m.ToEnglishWords();
// one hundred twenty-three and thirty-three

// Kurdish
var ku = 123.33m.ToKurdishWords();
// سەد و بیست و سێ و پۆینت سی و سێ

// Arabic
var ar = 123.33m.ToArabicWords();
// مئة و ثلاثة و عشرون فاصل ثلاثة و ثلاثون
```

### Currency Support (Type-Safe)

Use either the **ISO code** or the **descriptive name** — both are equivalent:

```csharp
// By ISO code
var usd = 234.32m.ToEnglishWords(Currency.USD);
// two hundred thirty-four US dollar and thirty-two cents

// By descriptive name (same result)
var usd2 = 234.32m.ToEnglishWords(Currency.UnitedStatesDollar);
// two hundred thirty-four US dollar and thirty-two cents
```

### Currency in All Languages

```csharp
// English with Iraqi Dinar
var en = 1500.750m.ToEnglishWords(Currency.IQD);
// one thousand five hundred Iraqi dinar and seven hundred fifty fils

// Kurdish with Iraqi Dinar
var ku = 1500.750m.ToKurdishWords(Currency.IraqiDinar);
// هەزار و پێنج سەد دیناری عێراقی و حەوت سەد و پەنجا فلس

// Arabic with Saudi Riyal
var ar = 99.50m.ToArabicWords(Currency.SaudiRiyal);
// تسعة و تسعون ريال سعودي و خمسون هللة

// English with Turkish Lira
var tr = 250.99m.ToEnglishWords(Currency.TurkishLira);
// two hundred fifty Turkish lira and ninety-nine kurus

// Kurdish with Euro
var eu = 50.25m.ToKurdishWords(Currency.Euro);
// پەنجا یۆرۆ و بیست و پێنج سەنت

// Whole number with currency
var whole = 1000.ToEnglishWords(Currency.BritishPound);
// one thousand British pound
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
// Extension methods on any numeric type
public static string ToEnglishWords(this object val, Currency? currency = null);
public static string ToKurdishWords(this object val, Currency? currency = null);
public static string ToArabicWords(this object val, Currency? currency = null);
```

## Feedback

If you encounter issues or have suggestions, please [open an issue](https://github.com/karwanessmat/NumberToKurdishWords/issues) on our [GitHub repository](https://github.com/karwanessmat/NumberToKurdishWords).

## License

This project is licensed under the [MIT License](LICENSE).
