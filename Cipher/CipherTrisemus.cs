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
        private Regex isLetter = new Regex(@"[а-яА-ЯёЁ]+");
        private StringBuilder _text;
        private string _keyWord;


        public CipherTrisemus(string text, string keyWord)
        {
            _text = new StringBuilder(text.ToLower());
            _keyWord = keyWord;
        }

        public void Inscrypt()
        {
            InscryptAlphabet();
            for (int i = 0; i < _text.Length; i++)
            {
                if (!isLetter.IsMatch(_text[i].ToString()))
                    continue;
                _text[i] = inscryptAlphabet[alphabet.IndexOf(_text[i])];
            }
        }

        private void InscryptAlphabet()
        {
            foreach(char letter in _keyWord)
                inscryptAlphabet.Add(letter);

            foreach (char letter in alphabet)
            {
                if (_keyWord.Contains(letter))
                    continue;
                inscryptAlphabet.Add(letter);
            }
        }

        public override string ToString()
        {
            return _text.ToString();
        }

    }
}
