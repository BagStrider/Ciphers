using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cipher
{
    internal class CipherTrisemus
    {
        private List<char> alphabet = new List<char>() { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        private List<char> inscryptAlphabet = new List<char>();
        private Regex isLetter = new Regex(@"[a - zA - Z]");
        private StringBuilder _text;
        private string _keyWord;


        public CipherTrisemus(string text, string keyWord)
        {
            _text = new StringBuilder(text.ToLower());
            _keyWord = keyWord;
        }





    }
}
