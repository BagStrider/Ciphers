using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cipher
{
    internal class CipherCaesar
    {
        private List<char> alphabet = new List<char>() { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        private List<char> inscryptAlphabet = new List<char>() { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        private Regex isLetter = new Regex(@"[а-яА-ЯёЁ]+");
        private StringBuilder _text;
        private int _offset;
    
        public CipherCaesar(string text, int offset)
        {
            _text = new StringBuilder(text.ToLower());
            _offset = offset;
        }

        public void Inscrypt()
        {
            InscryptAlphabetByOffset();
            for (int i = 0; i < _text.Length; i++)
            {
                if (!isLetter.IsMatch(_text[i].ToString()))
                    continue;
                _text[i] = inscryptAlphabet[alphabet.IndexOf(_text[i])];
            }
        }

        public void Descrypt()
        {
            InscryptAlphabetByOffset();
            for (int i = 0; i < _text.Length; i++)
            {
                if (!isLetter.IsMatch(_text[i].ToString()))
                    continue;
                _text[i] = alphabet[inscryptAlphabet.IndexOf(_text[i])];
            }
        }

        private void InscryptAlphabetByOffset()
        {
            inscryptAlphabet = new List<char>() { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            inscryptAlphabet.Reverse(0, _offset);
            inscryptAlphabet.Reverse(_offset, alphabet.Count - _offset);
            inscryptAlphabet.Reverse(0, alphabet.Count);
        }

        public override string ToString()
        {
            return _text.ToString();
        }
    }
}
