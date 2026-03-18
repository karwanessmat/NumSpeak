
⭐ NumSpeaks - Number to Words Converter ⭐

📚 Description: It is used to convert Kurdish, Arabic, and English numerals into words. It's a valuable tool for developers, and anyone working with numbers in these scripts. Stay tuned for future updates with support for additional languages.

🚀 **Features:**
- Easy conversion of Kurdish, Arabic, and English numbers into words.
- Supports decimal numbers (e.g., 123.33).
- Quick and precise results for all numerical inputs.
- Enhance documents, financial statements, and more with written numbers.


**Example Usage in Code:**

```csharp
// Convert a number to Kurdish words
var numberInKurdishText = 991_887_766_551.ToKurdishWords();
// RESULT: نۆ سەد و نۆوەت و یەک ملیار و هەشت سەد و هەشتا و حەوت ملیۆن و حەوت سەد و شەست و شەش هەزار و پێنج سەد و پەنجا و یەک

// Convert a number to Arabic words
var numberInArabicText = 991_887_766_551.ToArabicWords();
// RESULT: تسعة مائة و واحد و تسعون مليار و ثمانية مائة و سبعة و ثمانون مليون و سبعة مائة و ستة و ستون ألف و خمسة مائة و واحد و خمسون

// Convert a number to English words
var numberInEnglishText = 123_456_789_012.ToEnglishWords();
// RESULT: one hundred twenty-three billion four hundred fifty-six million seven hundred eighty-nine thousand twelve
```

**Decimal Examples:**

```csharp
// Kurdish decimal
var kurdishDecimal = 123.33m.ToKurdishWords();
// RESULT: سەد و بیست و سێ و پۆینت سی و سێ

// Arabic decimal
var arabicDecimal = 123.33m.ToArabicWords();
// RESULT: مئة و ثلاثة و عشرون فاصلة ثلاثة و ثلاثون

// English decimal
var englishDecimal = 123.33m.ToEnglishWords();
// RESULT: one hundred twenty-three point thirty-three
```



🔧 Usage:

📝 Input: Enter the numeric value (integer or decimal, in Kurdish or Arabic or English script).
📖 Output: Get the corresponding words in the same script.


🌐 **Future Updates:**
Stay tuned for updates that will add support for new languages, making NumSpeaks even more versatile.

📣 **Feedback:**
If you encounter issues or have suggestions, please [open an issue](https://github.com/karwanessmat/NumberToKurdishWords/issues) on our [GitHub repository](https://github.com/karwanessmat/NumberToKurdishWords).

📄 **License:**
This project is licensed under the [MIT License](LICENSE).
