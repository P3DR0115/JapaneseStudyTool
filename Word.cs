using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseStudyTool
{
    // This is the class for a vocab word. Will wupport Hiragana/Katakana and Kanji
    public class Word
    {
        public string kana; // for either hiragana or katakana as a word will not have both. Alternatively can support roomaji
        public string english; // for the english definition.
        public string kanji; // the kanji symol that corresponds if applicable

        /* Example:
         * kana = "たべる"
         * english = "To eat"
         * kanji = "食"
         * 
         * Example 2
         * kana = "のむ"
         * english = "To drink"
         * kanji = "飲"
         */
    }
}
