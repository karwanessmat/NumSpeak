namespace NumSpeaks;

/// <summary>
/// Currency metadata including names in English, Kurdish, and Arabic, plus sub-unit info.
/// </summary>
public class CurrencyInfo
{
    public string EnglishName { get; init; } = "";
    public string EnglishSubUnit { get; init; } = "cents";
    public string KurdishName { get; init; } = "";
    public string KurdishSubUnit { get; init; } = "";
    public string ArabicName { get; init; } = "";
    public string ArabicSubUnit { get; init; } = "";
    public int SubUnitFactor { get; init; } = 100;

    private static readonly Dictionary<Currency, CurrencyInfo> Data = new()
    {
        // ── A ──
        [Currency.AED] = new CurrencyInfo
        {
            EnglishName = "UAE dirham", EnglishSubUnit = "fils",
            KurdishName = "دیرهەمی ئیماراتی", KurdishSubUnit = "فلس",
            ArabicName = "درهم إماراتي", ArabicSubUnit = "فلس"
        },
        [Currency.AFN] = new CurrencyInfo
        {
            EnglishName = "Afghan afghani", EnglishSubUnit = "pul",
            KurdishName = "ئەفغانیی ئەفغانستانی", KurdishSubUnit = "پوول",
            ArabicName = "أفغاني أفغانستاني", ArabicSubUnit = "بول"
        },
        [Currency.ALL] = new CurrencyInfo
        {
            EnglishName = "Albanian lek", EnglishSubUnit = "qindarka",
            KurdishName = "لێکی ئەلبانی", KurdishSubUnit = "قیندارکا",
            ArabicName = "ليك ألباني", ArabicSubUnit = "قندركة"
        },
        [Currency.AMD] = new CurrencyInfo
        {
            EnglishName = "Armenian dram", EnglishSubUnit = "luma",
            KurdishName = "درامی ئەرمەنی", KurdishSubUnit = "لوما",
            ArabicName = "درام أرميني", ArabicSubUnit = "لوما"
        },
        [Currency.ANG] = new CurrencyInfo
        {
            EnglishName = "Netherlands Antillean guilder", EnglishSubUnit = "cents",
            KurdishName = "گیلدەری ئەنتیلی هۆلەندی", KurdishSubUnit = "سەنت",
            ArabicName = "غيلدر أنتيلي هولندي", ArabicSubUnit = "سنت"
        },
        [Currency.AOA] = new CurrencyInfo
        {
            EnglishName = "Angolan kwanza", EnglishSubUnit = "centimos",
            KurdishName = "کوانزای ئەنگۆلی", KurdishSubUnit = "سەنتیمۆ",
            ArabicName = "كوانزا أنغولية", ArabicSubUnit = "سنتيمو"
        },
        [Currency.ARS] = new CurrencyInfo
        {
            EnglishName = "Argentine peso", EnglishSubUnit = "centavos",
            KurdishName = "پێسۆی ئەرژەنتینی", KurdishSubUnit = "سەنتاڤۆ",
            ArabicName = "بيزو أرجنتيني", ArabicSubUnit = "سنتافو"
        },
        [Currency.AUD] = new CurrencyInfo
        {
            EnglishName = "Australian dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری ئوسترالی", KurdishSubUnit = "سەنت",
            ArabicName = "دولار أسترالي", ArabicSubUnit = "سنت"
        },
        [Currency.AWG] = new CurrencyInfo
        {
            EnglishName = "Aruban florin", EnglishSubUnit = "cents",
            KurdishName = "فلۆرینی ئاروبایی", KurdishSubUnit = "سەنت",
            ArabicName = "فلورن أروبي", ArabicSubUnit = "سنت"
        },
        [Currency.AZN] = new CurrencyInfo
        {
            EnglishName = "Azerbaijani manat", EnglishSubUnit = "qapik",
            KurdishName = "ماناتی ئازەربایجانی", KurdishSubUnit = "قاپیک",
            ArabicName = "مانات أذربيجاني", ArabicSubUnit = "قابيك"
        },

        // ── B ──
        [Currency.BAM] = new CurrencyInfo
        {
            EnglishName = "Bosnian convertible mark", EnglishSubUnit = "fening",
            KurdishName = "مارکی بۆسنی", KurdishSubUnit = "فێنینگ",
            ArabicName = "مارك بوسني", ArabicSubUnit = "فينينغ"
        },
        [Currency.BBD] = new CurrencyInfo
        {
            EnglishName = "Barbadian dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری باربادۆسی", KurdishSubUnit = "سەنت",
            ArabicName = "دولار بربادوسي", ArabicSubUnit = "سنت"
        },
        [Currency.BDT] = new CurrencyInfo
        {
            EnglishName = "Bangladeshi taka", EnglishSubUnit = "poisha",
            KurdishName = "تاکای بەنگلادیشی", KurdishSubUnit = "پۆیشا",
            ArabicName = "تاكا بنغلاديشية", ArabicSubUnit = "بويشة"
        },
        [Currency.BGN] = new CurrencyInfo
        {
            EnglishName = "Bulgarian lev", EnglishSubUnit = "stotinki",
            KurdishName = "لێڤی بولگاری", KurdishSubUnit = "ستۆتینکی",
            ArabicName = "ليف بلغاري", ArabicSubUnit = "ستوتينكي"
        },
        [Currency.BHD] = new CurrencyInfo
        {
            EnglishName = "Bahraini dinar", EnglishSubUnit = "fils",
            KurdishName = "دیناری بەحرەینی", KurdishSubUnit = "فلس",
            ArabicName = "دينار بحريني", ArabicSubUnit = "فلس",
            SubUnitFactor = 1000
        },
        [Currency.BIF] = new CurrencyInfo
        {
            EnglishName = "Burundian franc", EnglishSubUnit = "centimes",
            KurdishName = "فرانکی بوروندی", KurdishSubUnit = "سەنتیم",
            ArabicName = "فرنك بوروندي", ArabicSubUnit = "سنتيم"
        },
        [Currency.BMD] = new CurrencyInfo
        {
            EnglishName = "Bermudian dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری بێرمودایی", KurdishSubUnit = "سەنت",
            ArabicName = "دولار برمودي", ArabicSubUnit = "سنت"
        },
        [Currency.BND] = new CurrencyInfo
        {
            EnglishName = "Brunei dollar", EnglishSubUnit = "sen",
            KurdishName = "دۆلاری بروونایی", KurdishSubUnit = "سێن",
            ArabicName = "دولار بروناي", ArabicSubUnit = "سن"
        },
        [Currency.BOB] = new CurrencyInfo
        {
            EnglishName = "Bolivian boliviano", EnglishSubUnit = "centavos",
            KurdishName = "بۆلیڤیانۆی بۆلیڤی", KurdishSubUnit = "سەنتاڤۆ",
            ArabicName = "بوليفيانو بوليفي", ArabicSubUnit = "سنتافو"
        },
        [Currency.BRL] = new CurrencyInfo
        {
            EnglishName = "Brazilian real", EnglishSubUnit = "centavos",
            KurdishName = "ڕیاڵی بەرازیلی", KurdishSubUnit = "سەنتاڤۆ",
            ArabicName = "ريال برازيلي", ArabicSubUnit = "سنتافو"
        },
        [Currency.BSD] = new CurrencyInfo
        {
            EnglishName = "Bahamian dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری باهامایی", KurdishSubUnit = "سەنت",
            ArabicName = "دولار باهامي", ArabicSubUnit = "سنت"
        },
        [Currency.BTN] = new CurrencyInfo
        {
            EnglishName = "Bhutanese ngultrum", EnglishSubUnit = "chetrum",
            KurdishName = "نگولترومی بوتانی", KurdishSubUnit = "چێتروم",
            ArabicName = "نغولتروم بوتاني", ArabicSubUnit = "شيتروم"
        },
        [Currency.BWP] = new CurrencyInfo
        {
            EnglishName = "Botswana pula", EnglishSubUnit = "thebe",
            KurdishName = "پوولای بۆتسوانایی", KurdishSubUnit = "تێبێ",
            ArabicName = "بولا بوتسوانية", ArabicSubUnit = "ثيبي"
        },
        [Currency.BYN] = new CurrencyInfo
        {
            EnglishName = "Belarusian ruble", EnglishSubUnit = "kopecks",
            KurdishName = "ڕووبڵی بیلاڕووسی", KurdishSubUnit = "کۆپێک",
            ArabicName = "روبل بيلاروسي", ArabicSubUnit = "كوبيك"
        },
        [Currency.BZD] = new CurrencyInfo
        {
            EnglishName = "Belize dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری بەلیزی", KurdishSubUnit = "سەنت",
            ArabicName = "دولار بليزي", ArabicSubUnit = "سنت"
        },

        // ── C ──
        [Currency.CAD] = new CurrencyInfo
        {
            EnglishName = "Canadian dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری کەنەدی", KurdishSubUnit = "سەنت",
            ArabicName = "دولار كندي", ArabicSubUnit = "سنت"
        },
        [Currency.CDF] = new CurrencyInfo
        {
            EnglishName = "Congolese franc", EnglishSubUnit = "centimes",
            KurdishName = "فرانکی کۆنگۆیی", KurdishSubUnit = "سەنتیم",
            ArabicName = "فرنك كونغولي", ArabicSubUnit = "سنتيم"
        },
        [Currency.CHF] = new CurrencyInfo
        {
            EnglishName = "Swiss franc", EnglishSubUnit = "centimes",
            KurdishName = "فرانکی سویسری", KurdishSubUnit = "سەنتیم",
            ArabicName = "فرنك سويسري", ArabicSubUnit = "سنتيم"
        },
        [Currency.CLP] = new CurrencyInfo
        {
            EnglishName = "Chilean peso", EnglishSubUnit = "centavos",
            KurdishName = "پێسۆی چیلی", KurdishSubUnit = "سەنتاڤۆ",
            ArabicName = "بيزو تشيلي", ArabicSubUnit = "سنتافو"
        },
        [Currency.CNY] = new CurrencyInfo
        {
            EnglishName = "Chinese yuan", EnglishSubUnit = "fen",
            KurdishName = "یوانی چینی", KurdishSubUnit = "فێن",
            ArabicName = "يوان صيني", ArabicSubUnit = "فن"
        },
        [Currency.COP] = new CurrencyInfo
        {
            EnglishName = "Colombian peso", EnglishSubUnit = "centavos",
            KurdishName = "پێسۆی کۆلۆمبی", KurdishSubUnit = "سەنتاڤۆ",
            ArabicName = "بيزو كولومبي", ArabicSubUnit = "سنتافو"
        },
        [Currency.CRC] = new CurrencyInfo
        {
            EnglishName = "Costa Rican colon", EnglishSubUnit = "centimos",
            KurdishName = "کۆلۆنی کۆستاریکایی", KurdishSubUnit = "سەنتیمۆ",
            ArabicName = "كولون كوستاريكي", ArabicSubUnit = "سنتيمو"
        },
        [Currency.CUC] = new CurrencyInfo
        {
            EnglishName = "Cuban convertible peso", EnglishSubUnit = "centavos",
            KurdishName = "پێسۆی کووبایی", KurdishSubUnit = "سەنتاڤۆ",
            ArabicName = "بيزو كوبي", ArabicSubUnit = "سنتافو"
        },
        [Currency.CVE] = new CurrencyInfo
        {
            EnglishName = "Cape Verdean escudo", EnglishSubUnit = "centavos",
            KurdishName = "ئێسکوودۆی کەیپ ڤێردی", KurdishSubUnit = "سەنتاڤۆ",
            ArabicName = "إسكودو رأس أخضر", ArabicSubUnit = "سنتافو"
        },
        [Currency.CZK] = new CurrencyInfo
        {
            EnglishName = "Czech koruna", EnglishSubUnit = "haler",
            KurdishName = "کرۆنای چێکی", KurdishSubUnit = "هالێر",
            ArabicName = "كرونة تشيكية", ArabicSubUnit = "هالير"
        },

        // ── D ──
        [Currency.DJF] = new CurrencyInfo
        {
            EnglishName = "Djiboutian franc", EnglishSubUnit = "centimes",
            KurdishName = "فرانکی جیبوتی", KurdishSubUnit = "سەنتیم",
            ArabicName = "فرنك جيبوتي", ArabicSubUnit = "سنتيم"
        },
        [Currency.DKK] = new CurrencyInfo
        {
            EnglishName = "Danish krone", EnglishSubUnit = "ore",
            KurdishName = "کرۆنای دانیمارکی", KurdishSubUnit = "ئۆرە",
            ArabicName = "كرونة دنماركية", ArabicSubUnit = "أوره"
        },
        [Currency.DOP] = new CurrencyInfo
        {
            EnglishName = "Dominican peso", EnglishSubUnit = "centavos",
            KurdishName = "پێسۆی دۆمینیکانی", KurdishSubUnit = "سەنتاڤۆ",
            ArabicName = "بيزو دومينيكاني", ArabicSubUnit = "سنتافو"
        },
        [Currency.DZD] = new CurrencyInfo
        {
            EnglishName = "Algerian dinar", EnglishSubUnit = "centimes",
            KurdishName = "دیناری جەزایری", KurdishSubUnit = "سەنتیم",
            ArabicName = "دينار جزائري", ArabicSubUnit = "سنتيم"
        },

        // ── E ──
        [Currency.EGP] = new CurrencyInfo
        {
            EnglishName = "Egyptian pound", EnglishSubUnit = "piastres",
            KurdishName = "پاوەندی میسری", KurdishSubUnit = "قرش",
            ArabicName = "جنيه مصري", ArabicSubUnit = "قرش"
        },
        [Currency.ERN] = new CurrencyInfo
        {
            EnglishName = "Eritrean nakfa", EnglishSubUnit = "cents",
            KurdishName = "ناکفای ئەریتری", KurdishSubUnit = "سەنت",
            ArabicName = "نكفة إريترية", ArabicSubUnit = "سنت"
        },
        [Currency.ETB] = new CurrencyInfo
        {
            EnglishName = "Ethiopian birr", EnglishSubUnit = "santim",
            KurdishName = "بیری ئیتیۆپی", KurdishSubUnit = "سانتیم",
            ArabicName = "بر إثيوبي", ArabicSubUnit = "سنتيم"
        },
        [Currency.EUR] = new CurrencyInfo
        {
            EnglishName = "euro", EnglishSubUnit = "cents",
            KurdishName = "یۆرۆ", KurdishSubUnit = "سەنت",
            ArabicName = "يورو", ArabicSubUnit = "سنت"
        },

        // ── F ──
        [Currency.FJD] = new CurrencyInfo
        {
            EnglishName = "Fijian dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری فیجی", KurdishSubUnit = "سەنت",
            ArabicName = "دولار فيجي", ArabicSubUnit = "سنت"
        },
        [Currency.FKP] = new CurrencyInfo
        {
            EnglishName = "Falkland Islands pound", EnglishSubUnit = "pence",
            KurdishName = "پاوەندی دوورگەکانی فالکلاند", KurdishSubUnit = "پێنس",
            ArabicName = "جنيه جزر فوكلاند", ArabicSubUnit = "بنس"
        },

        // ── G ──
        [Currency.GBP] = new CurrencyInfo
        {
            EnglishName = "British pound", EnglishSubUnit = "pence",
            KurdishName = "پاوەندی بەریتانی", KurdishSubUnit = "پێنس",
            ArabicName = "جنيه إسترليني", ArabicSubUnit = "بنس"
        },
        [Currency.GEL] = new CurrencyInfo
        {
            EnglishName = "Georgian lari", EnglishSubUnit = "tetri",
            KurdishName = "لاریی گورجستانی", KurdishSubUnit = "تێتری",
            ArabicName = "لاري جورجي", ArabicSubUnit = "تتري"
        },
        [Currency.GHS] = new CurrencyInfo
        {
            EnglishName = "Ghanaian cedi", EnglishSubUnit = "pesewas",
            KurdishName = "سیدیی غەنایی", KurdishSubUnit = "پێسێوا",
            ArabicName = "سيدي غاني", ArabicSubUnit = "بيسيوا"
        },
        [Currency.GIP] = new CurrencyInfo
        {
            EnglishName = "Gibraltar pound", EnglishSubUnit = "pence",
            KurdishName = "پاوەندی جیبرالتار", KurdishSubUnit = "پێنس",
            ArabicName = "جنيه جبل طارق", ArabicSubUnit = "بنس"
        },
        [Currency.GMD] = new CurrencyInfo
        {
            EnglishName = "Gambian dalasi", EnglishSubUnit = "bututs",
            KurdishName = "دالاسیی گامبیایی", KurdishSubUnit = "بوتوت",
            ArabicName = "دلاسي غامبي", ArabicSubUnit = "بوتوت"
        },
        [Currency.GNF] = new CurrencyInfo
        {
            EnglishName = "Guinean franc", EnglishSubUnit = "centimes",
            KurdishName = "فرانکی گینێیی", KurdishSubUnit = "سەنتیم",
            ArabicName = "فرنك غيني", ArabicSubUnit = "سنتيم"
        },
        [Currency.GTQ] = new CurrencyInfo
        {
            EnglishName = "Guatemalan quetzal", EnglishSubUnit = "centavos",
            KurdishName = "کویتزاڵی گواتیمالایی", KurdishSubUnit = "سەنتاڤۆ",
            ArabicName = "كتزال غواتيمالي", ArabicSubUnit = "سنتافو"
        },
        [Currency.GYD] = new CurrencyInfo
        {
            EnglishName = "Guyanese dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری گایانایی", KurdishSubUnit = "سەنت",
            ArabicName = "دولار غياني", ArabicSubUnit = "سنت"
        },

        // ── H ──
        [Currency.HKD] = new CurrencyInfo
        {
            EnglishName = "Hong Kong dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری هۆنگ کۆنگ", KurdishSubUnit = "سەنت",
            ArabicName = "دولار هونغ كونغ", ArabicSubUnit = "سنت"
        },
        [Currency.HNL] = new CurrencyInfo
        {
            EnglishName = "Honduran lempira", EnglishSubUnit = "centavos",
            KurdishName = "لێمپیرای هۆندوراسی", KurdishSubUnit = "سەنتاڤۆ",
            ArabicName = "لمبيرة هندوراسية", ArabicSubUnit = "سنتافو"
        },
        [Currency.HTG] = new CurrencyInfo
        {
            EnglishName = "Haitian gourde", EnglishSubUnit = "centimes",
            KurdishName = "گوردی هایتی", KurdishSubUnit = "سەنتیم",
            ArabicName = "غورد هايتي", ArabicSubUnit = "سنتيم"
        },
        [Currency.HUF] = new CurrencyInfo
        {
            EnglishName = "Hungarian forint", EnglishSubUnit = "filler",
            KurdishName = "فۆرینتی مەجاری", KurdishSubUnit = "فیلێر",
            ArabicName = "فورنت مجري", ArabicSubUnit = "فيلير"
        },

        // ── I ──
        [Currency.IDR] = new CurrencyInfo
        {
            EnglishName = "Indonesian rupiah", EnglishSubUnit = "sen",
            KurdishName = "ڕووپیای ئیندۆنیزی", KurdishSubUnit = "سێن",
            ArabicName = "روبية إندونيسية", ArabicSubUnit = "سن"
        },
        [Currency.ILS] = new CurrencyInfo
        {
            EnglishName = "Israeli new shekel", EnglishSubUnit = "agorot",
            KurdishName = "شێکڵی ئیسرائیلی", KurdishSubUnit = "ئاگۆرا",
            ArabicName = "شيكل إسرائيلي", ArabicSubUnit = "أغورة"
        },
        [Currency.INR] = new CurrencyInfo
        {
            EnglishName = "Indian rupee", EnglishSubUnit = "paise",
            KurdishName = "ڕووپیی هیندی", KurdishSubUnit = "پایسە",
            ArabicName = "روبية هندية", ArabicSubUnit = "بيسة"
        },
        [Currency.IQD] = new CurrencyInfo
        {
            EnglishName = "Iraqi dinar", EnglishSubUnit = "fils",
            KurdishName = "دیناری عێراقی", KurdishSubUnit = "فلس",
            ArabicName = "دينار عراقي", ArabicSubUnit = "فلس",
            SubUnitFactor = 1000
        },
        [Currency.IRR] = new CurrencyInfo
        {
            EnglishName = "Iranian rial", EnglishSubUnit = "dinars",
            KurdishName = "ریاڵی ئێرانی", KurdishSubUnit = "دینار",
            ArabicName = "ريال إيراني", ArabicSubUnit = "دينار"
        },
        [Currency.ISK] = new CurrencyInfo
        {
            EnglishName = "Icelandic krona", EnglishSubUnit = "aurar",
            KurdishName = "کرۆنای ئایسلەندی", KurdishSubUnit = "ئۆرار",
            ArabicName = "كرونة آيسلندية", ArabicSubUnit = "أورار"
        },

        // ── J ──
        [Currency.JMD] = new CurrencyInfo
        {
            EnglishName = "Jamaican dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری جامایکایی", KurdishSubUnit = "سەنت",
            ArabicName = "دولار جامايكي", ArabicSubUnit = "سنت"
        },
        [Currency.JOD] = new CurrencyInfo
        {
            EnglishName = "Jordanian dinar", EnglishSubUnit = "piastres",
            KurdishName = "دیناری ئوردنی", KurdishSubUnit = "قرش",
            ArabicName = "دينار أردني", ArabicSubUnit = "قرش"
        },
        [Currency.JPY] = new CurrencyInfo
        {
            EnglishName = "Japanese yen", EnglishSubUnit = "sen",
            KurdishName = "یەنی ژاپۆنی", KurdishSubUnit = "سێن",
            ArabicName = "ين ياباني", ArabicSubUnit = "سن",
            SubUnitFactor = 1
        },

        // ── K ──
        [Currency.KES] = new CurrencyInfo
        {
            EnglishName = "Kenyan shilling", EnglishSubUnit = "cents",
            KurdishName = "شیلنگی کینیایی", KurdishSubUnit = "سەنت",
            ArabicName = "شلن كيني", ArabicSubUnit = "سنت"
        },
        [Currency.KGS] = new CurrencyInfo
        {
            EnglishName = "Kyrgyzstani som", EnglishSubUnit = "tyiyn",
            KurdishName = "سۆمی قرغیزستانی", KurdishSubUnit = "تییین",
            ArabicName = "سوم قرغيزستاني", ArabicSubUnit = "تيين"
        },
        [Currency.KHR] = new CurrencyInfo
        {
            EnglishName = "Cambodian riel", EnglishSubUnit = "sen",
            KurdishName = "ڕیێڵی کەمبۆدی", KurdishSubUnit = "سێن",
            ArabicName = "ريال كمبودي", ArabicSubUnit = "سن"
        },
        [Currency.KMF] = new CurrencyInfo
        {
            EnglishName = "Comorian franc", EnglishSubUnit = "centimes",
            KurdishName = "فرانکی کۆمۆری", KurdishSubUnit = "سەنتیم",
            ArabicName = "فرنك قمري", ArabicSubUnit = "سنتيم"
        },
        [Currency.KPW] = new CurrencyInfo
        {
            EnglishName = "North Korean won", EnglishSubUnit = "chon",
            KurdishName = "وۆنی کۆریای باکوور", KurdishSubUnit = "چۆن",
            ArabicName = "وون كوري شمالي", ArabicSubUnit = "تشون"
        },
        [Currency.KRW] = new CurrencyInfo
        {
            EnglishName = "South Korean won", EnglishSubUnit = "jeon",
            KurdishName = "وۆنی کۆریای باشوور", KurdishSubUnit = "جیۆن",
            ArabicName = "وون كوري جنوبي", ArabicSubUnit = "جون",
            SubUnitFactor = 1
        },
        [Currency.KWD] = new CurrencyInfo
        {
            EnglishName = "Kuwaiti dinar", EnglishSubUnit = "fils",
            KurdishName = "دیناری کوەیتی", KurdishSubUnit = "فلس",
            ArabicName = "دينار كويتي", ArabicSubUnit = "فلس",
            SubUnitFactor = 1000
        },
        [Currency.KYD] = new CurrencyInfo
        {
            EnglishName = "Cayman Islands dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری دوورگەکانی کەیمان", KurdishSubUnit = "سەنت",
            ArabicName = "دولار جزر كايمان", ArabicSubUnit = "سنت"
        },
        [Currency.KZT] = new CurrencyInfo
        {
            EnglishName = "Kazakhstani tenge", EnglishSubUnit = "tiyn",
            KurdishName = "تێنگەی کازاخستانی", KurdishSubUnit = "تییین",
            ArabicName = "تنغة كازاخستانية", ArabicSubUnit = "تيين"
        },

        // ── L ──
        [Currency.LAK] = new CurrencyInfo
        {
            EnglishName = "Lao kip", EnglishSubUnit = "att",
            KurdishName = "کیپی لاوسی", KurdishSubUnit = "ئات",
            ArabicName = "كيب لاوسي", ArabicSubUnit = "آت"
        },
        [Currency.LBP] = new CurrencyInfo
        {
            EnglishName = "Lebanese pound", EnglishSubUnit = "piastres",
            KurdishName = "لیرەی لوبنانی", KurdishSubUnit = "قرش",
            ArabicName = "ليرة لبنانية", ArabicSubUnit = "قرش"
        },
        [Currency.LKR] = new CurrencyInfo
        {
            EnglishName = "Sri Lankan rupee", EnglishSubUnit = "cents",
            KurdishName = "ڕووپیی سریلانکایی", KurdishSubUnit = "سەنت",
            ArabicName = "روبية سريلانكية", ArabicSubUnit = "سنت"
        },
        [Currency.LRD] = new CurrencyInfo
        {
            EnglishName = "Liberian dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری لیبەریایی", KurdishSubUnit = "سەنت",
            ArabicName = "دولار ليبيري", ArabicSubUnit = "سنت"
        },
        [Currency.LSL] = new CurrencyInfo
        {
            EnglishName = "Lesotho loti", EnglishSubUnit = "lisente",
            KurdishName = "لۆتیی لیسۆتۆیی", KurdishSubUnit = "لیسێنتە",
            ArabicName = "لوتي ليسوتو", ArabicSubUnit = "ليسنتي"
        },
        [Currency.LYD] = new CurrencyInfo
        {
            EnglishName = "Libyan dinar", EnglishSubUnit = "dirhams",
            KurdishName = "دیناری لیبی", KurdishSubUnit = "دیرهەم",
            ArabicName = "دينار ليبي", ArabicSubUnit = "درهم",
            SubUnitFactor = 1000
        },

        // ── M ──
        [Currency.MAD] = new CurrencyInfo
        {
            EnglishName = "Moroccan dirham", EnglishSubUnit = "centimes",
            KurdishName = "دیرهەمی مەغریبی", KurdishSubUnit = "سەنتیم",
            ArabicName = "درهم مغربي", ArabicSubUnit = "سنتيم"
        },
        [Currency.MDL] = new CurrencyInfo
        {
            EnglishName = "Moldovan leu", EnglishSubUnit = "bani",
            KurdishName = "لێوی مۆلدۆڤی", KurdishSubUnit = "بانی",
            ArabicName = "ليو مولدوفي", ArabicSubUnit = "باني"
        },
        [Currency.MGA] = new CurrencyInfo
        {
            EnglishName = "Malagasy ariary", EnglishSubUnit = "iraimbilanja",
            KurdishName = "ئاریاریی مادغەشقەری", KurdishSubUnit = "ئیرایمبیلانجا",
            ArabicName = "أرياري مدغشقري", ArabicSubUnit = "إيرايمبيلنجة"
        },
        [Currency.MKD] = new CurrencyInfo
        {
            EnglishName = "Macedonian denar", EnglishSubUnit = "deni",
            KurdishName = "دیناری مەقدۆنی", KurdishSubUnit = "دێنی",
            ArabicName = "دينار مقدوني", ArabicSubUnit = "ديني"
        },
        [Currency.MMK] = new CurrencyInfo
        {
            EnglishName = "Myanmar kyat", EnglishSubUnit = "pya",
            KurdishName = "کیاتی میانماری", KurdishSubUnit = "پیا",
            ArabicName = "كيات ميانماري", ArabicSubUnit = "بيا"
        },
        [Currency.MNT] = new CurrencyInfo
        {
            EnglishName = "Mongolian tugrik", EnglishSubUnit = "mongo",
            KurdishName = "تۆگریکی مەنگۆلی", KurdishSubUnit = "مۆنگۆ",
            ArabicName = "توغريك منغولي", ArabicSubUnit = "مونغو"
        },
        [Currency.MOP] = new CurrencyInfo
        {
            EnglishName = "Macanese pataca", EnglishSubUnit = "avos",
            KurdishName = "پاتاکای ماکاوی", KurdishSubUnit = "ئاڤۆ",
            ArabicName = "باتاكا ماكاوية", ArabicSubUnit = "آفو"
        },
        [Currency.MRU] = new CurrencyInfo
        {
            EnglishName = "Mauritanian ouguiya", EnglishSubUnit = "khoums",
            KurdishName = "ئوگیای مۆریتانی", KurdishSubUnit = "خومس",
            ArabicName = "أوقية موريتانية", ArabicSubUnit = "خمس"
        },
        [Currency.MUR] = new CurrencyInfo
        {
            EnglishName = "Mauritian rupee", EnglishSubUnit = "cents",
            KurdishName = "ڕووپیی مۆریسی", KurdishSubUnit = "سەنت",
            ArabicName = "روبية موريشيوسية", ArabicSubUnit = "سنت"
        },
        [Currency.MVR] = new CurrencyInfo
        {
            EnglishName = "Maldivian rufiyaa", EnglishSubUnit = "laari",
            KurdishName = "ڕوفیای مالدیڤی", KurdishSubUnit = "لاری",
            ArabicName = "روفية مالديفية", ArabicSubUnit = "لاري"
        },
        [Currency.MWK] = new CurrencyInfo
        {
            EnglishName = "Malawian kwacha", EnglishSubUnit = "tambala",
            KurdishName = "کواچای مالاویی", KurdishSubUnit = "تامبالا",
            ArabicName = "كواشا مالاوية", ArabicSubUnit = "تمبالا"
        },
        [Currency.MXN] = new CurrencyInfo
        {
            EnglishName = "Mexican peso", EnglishSubUnit = "centavos",
            KurdishName = "پێسۆی مەکسیکی", KurdishSubUnit = "سەنتاڤۆ",
            ArabicName = "بيزو مكسيكي", ArabicSubUnit = "سنتافو"
        },
        [Currency.MYR] = new CurrencyInfo
        {
            EnglishName = "Malaysian ringgit", EnglishSubUnit = "sen",
            KurdishName = "رینگیتی مالیزی", KurdishSubUnit = "سێن",
            ArabicName = "رينغيت ماليزي", ArabicSubUnit = "سن"
        },
        [Currency.MZN] = new CurrencyInfo
        {
            EnglishName = "Mozambican metical", EnglishSubUnit = "centavos",
            KurdishName = "مێتیکاڵی مۆزامبیکی", KurdishSubUnit = "سەنتاڤۆ",
            ArabicName = "متيكال موزمبيقي", ArabicSubUnit = "سنتافو"
        },

        // ── N ──
        [Currency.NAD] = new CurrencyInfo
        {
            EnglishName = "Namibian dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری نامیبیایی", KurdishSubUnit = "سەنت",
            ArabicName = "دولار ناميبي", ArabicSubUnit = "سنت"
        },
        [Currency.NGN] = new CurrencyInfo
        {
            EnglishName = "Nigerian naira", EnglishSubUnit = "kobo",
            KurdishName = "نایرای نایجیریایی", KurdishSubUnit = "کۆبۆ",
            ArabicName = "نيرة نيجيرية", ArabicSubUnit = "كوبو"
        },
        [Currency.NIO] = new CurrencyInfo
        {
            EnglishName = "Nicaraguan cordoba", EnglishSubUnit = "centavos",
            KurdishName = "کۆردۆبای نیکاراگوایی", KurdishSubUnit = "سەنتاڤۆ",
            ArabicName = "قرطبة نيكاراغوية", ArabicSubUnit = "سنتافو"
        },
        [Currency.NOK] = new CurrencyInfo
        {
            EnglishName = "Norwegian krone", EnglishSubUnit = "ore",
            KurdishName = "کرۆنای نەرویجی", KurdishSubUnit = "ئۆرە",
            ArabicName = "كرونة نرويجية", ArabicSubUnit = "أوره"
        },
        [Currency.NPR] = new CurrencyInfo
        {
            EnglishName = "Nepalese rupee", EnglishSubUnit = "paisa",
            KurdishName = "ڕووپیی نیپاڵی", KurdishSubUnit = "پایسا",
            ArabicName = "روبية نيبالية", ArabicSubUnit = "بيسة"
        },
        [Currency.NZD] = new CurrencyInfo
        {
            EnglishName = "New Zealand dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری نیوزیلاندی", KurdishSubUnit = "سەنت",
            ArabicName = "دولار نيوزيلندي", ArabicSubUnit = "سنت"
        },

        // ── O ──
        [Currency.OMR] = new CurrencyInfo
        {
            EnglishName = "Omani rial", EnglishSubUnit = "baisa",
            KurdishName = "ریاڵی عومانی", KurdishSubUnit = "بایسا",
            ArabicName = "ريال عماني", ArabicSubUnit = "بيسة",
            SubUnitFactor = 1000
        },

        // ── P ──
        [Currency.PAB] = new CurrencyInfo
        {
            EnglishName = "Panamanian balboa", EnglishSubUnit = "centesimos",
            KurdishName = "باڵبۆای پاناماییی", KurdishSubUnit = "سەنتێسیمۆ",
            ArabicName = "بلبوا بنمي", ArabicSubUnit = "سنتيسيمو"
        },
        [Currency.PEN] = new CurrencyInfo
        {
            EnglishName = "Peruvian sol", EnglishSubUnit = "centimos",
            KurdishName = "سۆلی پێرووی", KurdishSubUnit = "سەنتیمۆ",
            ArabicName = "سول بيروفي", ArabicSubUnit = "سنتيمو"
        },
        [Currency.PGK] = new CurrencyInfo
        {
            EnglishName = "Papua New Guinean kina", EnglishSubUnit = "toea",
            KurdishName = "کینای پاپوا گینێی نوێ", KurdishSubUnit = "تۆیا",
            ArabicName = "كينا بابوا غينيا الجديدة", ArabicSubUnit = "تويا"
        },
        [Currency.PHP] = new CurrencyInfo
        {
            EnglishName = "Philippine peso", EnglishSubUnit = "centavos",
            KurdishName = "پێسۆی فیلیپینی", KurdishSubUnit = "سەنتاڤۆ",
            ArabicName = "بيزو فلبيني", ArabicSubUnit = "سنتافو"
        },
        [Currency.PKR] = new CurrencyInfo
        {
            EnglishName = "Pakistani rupee", EnglishSubUnit = "paisa",
            KurdishName = "ڕووپیی پاکستانی", KurdishSubUnit = "پایسا",
            ArabicName = "روبية باكستانية", ArabicSubUnit = "بيسة"
        },
        [Currency.PLN] = new CurrencyInfo
        {
            EnglishName = "Polish zloty", EnglishSubUnit = "groszy",
            KurdishName = "زلۆتیی پۆلەندی", KurdishSubUnit = "گرۆشی",
            ArabicName = "زلوتي بولندي", ArabicSubUnit = "غروشي"
        },
        [Currency.PYG] = new CurrencyInfo
        {
            EnglishName = "Paraguayan guarani", EnglishSubUnit = "centimos",
            KurdishName = "گوارانیی پاراگوایی", KurdishSubUnit = "سەنتیمۆ",
            ArabicName = "غواراني باراغواي", ArabicSubUnit = "سنتيمو"
        },

        // ── Q ──
        [Currency.QAR] = new CurrencyInfo
        {
            EnglishName = "Qatari riyal", EnglishSubUnit = "dirhams",
            KurdishName = "ریاڵی قەتەری", KurdishSubUnit = "دیرهەم",
            ArabicName = "ريال قطري", ArabicSubUnit = "درهم"
        },

        // ── R ──
        [Currency.RON] = new CurrencyInfo
        {
            EnglishName = "Romanian leu", EnglishSubUnit = "bani",
            KurdishName = "لێوی ڕۆمانی", KurdishSubUnit = "بانی",
            ArabicName = "ليو روماني", ArabicSubUnit = "باني"
        },
        [Currency.RSD] = new CurrencyInfo
        {
            EnglishName = "Serbian dinar", EnglishSubUnit = "para",
            KurdishName = "دیناری سربی", KurdishSubUnit = "پارا",
            ArabicName = "دينار صربي", ArabicSubUnit = "بارة"
        },
        [Currency.RUB] = new CurrencyInfo
        {
            EnglishName = "Russian ruble", EnglishSubUnit = "kopecks",
            KurdishName = "ڕووبڵی ڕووسی", KurdishSubUnit = "کۆپێک",
            ArabicName = "روبل روسي", ArabicSubUnit = "كوبيك"
        },
        [Currency.RWF] = new CurrencyInfo
        {
            EnglishName = "Rwandan franc", EnglishSubUnit = "centimes",
            KurdishName = "فرانکی ڕواندایی", KurdishSubUnit = "سەنتیم",
            ArabicName = "فرنك رواندي", ArabicSubUnit = "سنتيم"
        },

        // ── S ──
        [Currency.SAR] = new CurrencyInfo
        {
            EnglishName = "Saudi riyal", EnglishSubUnit = "halalas",
            KurdishName = "ریاڵی سعوودی", KurdishSubUnit = "هەلەلە",
            ArabicName = "ريال سعودي", ArabicSubUnit = "هللة"
        },
        [Currency.SBD] = new CurrencyInfo
        {
            EnglishName = "Solomon Islands dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری دوورگەکانی سلێمان", KurdishSubUnit = "سەنت",
            ArabicName = "دولار جزر سليمان", ArabicSubUnit = "سنت"
        },
        [Currency.SCR] = new CurrencyInfo
        {
            EnglishName = "Seychellois rupee", EnglishSubUnit = "cents",
            KurdishName = "ڕووپیی سیشێلی", KurdishSubUnit = "سەنت",
            ArabicName = "روبية سيشلية", ArabicSubUnit = "سنت"
        },
        [Currency.SDG] = new CurrencyInfo
        {
            EnglishName = "Sudanese pound", EnglishSubUnit = "piastres",
            KurdishName = "پاوەندی سوودانی", KurdishSubUnit = "قرش",
            ArabicName = "جنيه سوداني", ArabicSubUnit = "قرش"
        },
        [Currency.SEK] = new CurrencyInfo
        {
            EnglishName = "Swedish krona", EnglishSubUnit = "ore",
            KurdishName = "کرۆنای سویدی", KurdishSubUnit = "ئۆرە",
            ArabicName = "كرونة سويدية", ArabicSubUnit = "أوره"
        },
        [Currency.SGD] = new CurrencyInfo
        {
            EnglishName = "Singapore dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری سینگاپووری", KurdishSubUnit = "سەنت",
            ArabicName = "دولار سنغافوري", ArabicSubUnit = "سنت"
        },
        [Currency.SHP] = new CurrencyInfo
        {
            EnglishName = "Saint Helena pound", EnglishSubUnit = "pence",
            KurdishName = "پاوەندی سەینت هێلینا", KurdishSubUnit = "پێنس",
            ArabicName = "جنيه سانت هيلانة", ArabicSubUnit = "بنس"
        },
        [Currency.SLL] = new CurrencyInfo
        {
            EnglishName = "Sierra Leonean leone", EnglishSubUnit = "cents",
            KurdishName = "لیۆنی سیەرالیۆنی", KurdishSubUnit = "سەنت",
            ArabicName = "ليون سيراليوني", ArabicSubUnit = "سنت"
        },
        [Currency.SOS] = new CurrencyInfo
        {
            EnglishName = "Somali shilling", EnglishSubUnit = "cents",
            KurdishName = "شیلنگی سۆمالی", KurdishSubUnit = "سەنت",
            ArabicName = "شلن صومالي", ArabicSubUnit = "سنت"
        },
        [Currency.SRD] = new CurrencyInfo
        {
            EnglishName = "Surinamese dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری سورینامی", KurdishSubUnit = "سەنت",
            ArabicName = "دولار سورينامي", ArabicSubUnit = "سنت"
        },
        [Currency.SSP] = new CurrencyInfo
        {
            EnglishName = "South Sudanese pound", EnglishSubUnit = "piastres",
            KurdishName = "پاوەندی سوودانی باشوور", KurdishSubUnit = "قرش",
            ArabicName = "جنيه جنوب سوداني", ArabicSubUnit = "قرش"
        },
        [Currency.STN] = new CurrencyInfo
        {
            EnglishName = "Sao Tome and Principe dobra", EnglishSubUnit = "centimos",
            KurdishName = "دۆبرای ساو تۆمێ", KurdishSubUnit = "سەنتیمۆ",
            ArabicName = "دوبرا ساو تومي", ArabicSubUnit = "سنتيمو"
        },
        [Currency.SYP] = new CurrencyInfo
        {
            EnglishName = "Syrian pound", EnglishSubUnit = "piastres",
            KurdishName = "لیرەی سووری", KurdishSubUnit = "قرش",
            ArabicName = "ليرة سورية", ArabicSubUnit = "قرش"
        },
        [Currency.SZL] = new CurrencyInfo
        {
            EnglishName = "Swazi lilangeni", EnglishSubUnit = "cents",
            KurdishName = "لیلانگێنیی سوازیلاندی", KurdishSubUnit = "سەنت",
            ArabicName = "ليلانجيني سوازيلندي", ArabicSubUnit = "سنت"
        },

        // ── T ──
        [Currency.THB] = new CurrencyInfo
        {
            EnglishName = "Thai baht", EnglishSubUnit = "satang",
            KurdishName = "باتی تایلەندی", KurdishSubUnit = "ساتانگ",
            ArabicName = "بات تايلندي", ArabicSubUnit = "ساتانغ"
        },
        [Currency.TJS] = new CurrencyInfo
        {
            EnglishName = "Tajikistani somoni", EnglishSubUnit = "diram",
            KurdishName = "سۆمۆنیی تاجیکستانی", KurdishSubUnit = "دیرام",
            ArabicName = "سوموني طاجيكستاني", ArabicSubUnit = "ديرام"
        },
        [Currency.TMT] = new CurrencyInfo
        {
            EnglishName = "Turkmenistan manat", EnglishSubUnit = "tennesi",
            KurdishName = "ماناتی تورکمانستانی", KurdishSubUnit = "تێنێسی",
            ArabicName = "مانات تركمانستاني", ArabicSubUnit = "تنسي"
        },
        [Currency.TND] = new CurrencyInfo
        {
            EnglishName = "Tunisian dinar", EnglishSubUnit = "millimes",
            KurdishName = "دیناری تونسی", KurdishSubUnit = "ملیم",
            ArabicName = "دينار تونسي", ArabicSubUnit = "مليم",
            SubUnitFactor = 1000
        },
        [Currency.TOP] = new CurrencyInfo
        {
            EnglishName = "Tongan paanga", EnglishSubUnit = "seniti",
            KurdishName = "پاعانگای تۆنگایی", KurdishSubUnit = "سێنیتی",
            ArabicName = "بانغا تونغي", ArabicSubUnit = "سنيتي"
        },
        [Currency.TRY] = new CurrencyInfo
        {
            EnglishName = "Turkish lira", EnglishSubUnit = "kurus",
            KurdishName = "لیرەی تورکی", KurdishSubUnit = "قروش",
            ArabicName = "ليرة تركية", ArabicSubUnit = "قرش"
        },
        [Currency.TTD] = new CurrencyInfo
        {
            EnglishName = "Trinidad and Tobago dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری ترینیداد و تۆباگۆ", KurdishSubUnit = "سەنت",
            ArabicName = "دولار ترينيداد وتوباغو", ArabicSubUnit = "سنت"
        },
        [Currency.TWD] = new CurrencyInfo
        {
            EnglishName = "New Taiwan dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری تایوانی", KurdishSubUnit = "سەنت",
            ArabicName = "دولار تايواني", ArabicSubUnit = "سنت"
        },
        [Currency.TZS] = new CurrencyInfo
        {
            EnglishName = "Tanzanian shilling", EnglishSubUnit = "cents",
            KurdishName = "شیلنگی تانزانیایی", KurdishSubUnit = "سەنت",
            ArabicName = "شلن تنزاني", ArabicSubUnit = "سنت"
        },

        // ── U ──
        [Currency.UAH] = new CurrencyInfo
        {
            EnglishName = "Ukrainian hryvnia", EnglishSubUnit = "kopiykas",
            KurdishName = "هریڤنیای ئۆکرانی", KurdishSubUnit = "کۆپییکا",
            ArabicName = "هريفنيا أوكرانية", ArabicSubUnit = "كوبيكا"
        },
        [Currency.UGX] = new CurrencyInfo
        {
            EnglishName = "Ugandan shilling", EnglishSubUnit = "cents",
            KurdishName = "شیلنگی ئوگاندایی", KurdishSubUnit = "سەنت",
            ArabicName = "شلن أوغندي", ArabicSubUnit = "سنت"
        },
        [Currency.USD] = new CurrencyInfo
        {
            EnglishName = "US dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری ئەمریکی", KurdishSubUnit = "سەنت",
            ArabicName = "دولار أمريكي", ArabicSubUnit = "سنت"
        },
        [Currency.UYU] = new CurrencyInfo
        {
            EnglishName = "Uruguayan peso", EnglishSubUnit = "centesimos",
            KurdishName = "پێسۆی ئوروگوایی", KurdishSubUnit = "سەنتێسیمۆ",
            ArabicName = "بيزو أوروغواي", ArabicSubUnit = "سنتيسيمو"
        },
        [Currency.UZS] = new CurrencyInfo
        {
            EnglishName = "Uzbekistani som", EnglishSubUnit = "tiyin",
            KurdishName = "سۆمی ئوزبەکستانی", KurdishSubUnit = "تییین",
            ArabicName = "سوم أوزبكستاني", ArabicSubUnit = "تيين"
        },

        // ── V ──
        [Currency.VES] = new CurrencyInfo
        {
            EnglishName = "Venezuelan bolivar", EnglishSubUnit = "centimos",
            KurdishName = "بۆلیڤاری ڤەنزوێلایی", KurdishSubUnit = "سەنتیمۆ",
            ArabicName = "بوليفار فنزويلي", ArabicSubUnit = "سنتيمو"
        },
        [Currency.VND] = new CurrencyInfo
        {
            EnglishName = "Vietnamese dong", EnglishSubUnit = "hao",
            KurdishName = "دۆنگی ڤیەتنامی", KurdishSubUnit = "هاو",
            ArabicName = "دونغ فيتنامي", ArabicSubUnit = "هاو",
            SubUnitFactor = 1
        },
        [Currency.VUV] = new CurrencyInfo
        {
            EnglishName = "Vanuatu vatu", EnglishSubUnit = "none",
            KurdishName = "ڤاتوی ڤانواتوویی", KurdishSubUnit = "نییە",
            ArabicName = "فاتو فانواتي", ArabicSubUnit = "لا يوجد",
            SubUnitFactor = 1
        },

        // ── W ──
        [Currency.WST] = new CurrencyInfo
        {
            EnglishName = "Samoan tala", EnglishSubUnit = "sene",
            KurdishName = "تالای ساموایی", KurdishSubUnit = "سێنە",
            ArabicName = "تالا ساموي", ArabicSubUnit = "سيني"
        },

        // ── X (Regional) ──
        [Currency.XAF] = new CurrencyInfo
        {
            EnglishName = "Central African CFA franc", EnglishSubUnit = "centimes",
            KurdishName = "فرانکی سی ئێف ئەی ناوەندی ئەفریقا", KurdishSubUnit = "سەنتیم",
            ArabicName = "فرنك وسط أفريقي", ArabicSubUnit = "سنتيم"
        },
        [Currency.XCD] = new CurrencyInfo
        {
            EnglishName = "Eastern Caribbean dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری کاریبی ڕۆژهەڵات", KurdishSubUnit = "سەنت",
            ArabicName = "دولار شرق كاريبي", ArabicSubUnit = "سنت"
        },
        [Currency.XOF] = new CurrencyInfo
        {
            EnglishName = "West African CFA franc", EnglishSubUnit = "centimes",
            KurdishName = "فرانکی سی ئێف ئەی ڕۆژئاوای ئەفریقا", KurdishSubUnit = "سەنتیم",
            ArabicName = "فرنك غرب أفريقي", ArabicSubUnit = "سنتيم"
        },
        [Currency.XPF] = new CurrencyInfo
        {
            EnglishName = "CFP franc", EnglishSubUnit = "centimes",
            KurdishName = "فرانکی سی ئێف پی", KurdishSubUnit = "سەنتیم",
            ArabicName = "فرنك سي إف بي", ArabicSubUnit = "سنتيم"
        },

        // ── Y ──
        [Currency.YER] = new CurrencyInfo
        {
            EnglishName = "Yemeni rial", EnglishSubUnit = "fils",
            KurdishName = "ریاڵی یەمەنی", KurdishSubUnit = "فلس",
            ArabicName = "ريال يمني", ArabicSubUnit = "فلس"
        },

        // ── Z ──
        [Currency.ZAR] = new CurrencyInfo
        {
            EnglishName = "South African rand", EnglishSubUnit = "cents",
            KurdishName = "ڕاندی ئەفریقای باشوور", KurdishSubUnit = "سەنت",
            ArabicName = "راند جنوب أفريقي", ArabicSubUnit = "سنت"
        },
        [Currency.ZMW] = new CurrencyInfo
        {
            EnglishName = "Zambian kwacha", EnglishSubUnit = "ngwee",
            KurdishName = "کواچای زامبیایی", KurdishSubUnit = "نگوی",
            ArabicName = "كواشا زامبية", ArabicSubUnit = "نغوي"
        },
        [Currency.ZWL] = new CurrencyInfo
        {
            EnglishName = "Zimbabwean dollar", EnglishSubUnit = "cents",
            KurdishName = "دۆلاری زیمبابوی", KurdishSubUnit = "سەنت",
            ArabicName = "دولار زيمبابوي", ArabicSubUnit = "سنت"
        },
    };

    /// <summary>
    /// Gets the CurrencyInfo for a given currency code.
    /// Falls back to the enum name if not explicitly mapped.
    /// </summary>
    public static CurrencyInfo Get(Currency currency)
    {
        if (Data.TryGetValue(currency, out var info))
            return info;

        var code = currency.ToString();
        return new CurrencyInfo
        {
            EnglishName = code,
            EnglishSubUnit = "cents",
            KurdishName = code,
            KurdishSubUnit = "سەنت",
            ArabicName = code,
            ArabicSubUnit = "سنت"
        };
    }
}
