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
        private List<char> alphabet = new List<char>() { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        private List<char> inscryptAlphabet = new List<char>();
        private char[,] alphabetMatrix = new char[4,8];
        private Regex isLetter = new Regex(@"[а-яА-Я]+");
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
            for(int i = 0; i < alphabetMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < alphabetMatrix.GetLength(1); j++)
                {
                    Console.Write(alphabetMatrix[i,j]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < _text.Length; i++)
            {
                if (!isLetter.IsMatch(_text[i].ToString()))
                    continue;

                int index = IndexOf(_text[i]) + alphabetMatrix.GetLength(1);
                if (index % 31 == 0)
                    _text[i] = inscryptAlphabet[index];
                else
                    _text[i] = inscryptAlphabet[index%32];
            }
        }

        public void Descrypt()
        {
            InscryptAlphabet();
            for (int i = 0; i < alphabetMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < alphabetMatrix.GetLength(1); j++)
                {
                    Console.Write(alphabetMatrix[i, j]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < _text.Length; i++)
            {
                if (!isLetter.IsMatch(_text[i].ToString()))
                    continue;

                int index = IndexOf(_text[i]) - alphabetMatrix.GetLength(1);
                if (index < 0)
                    index += 32;
                if (index % 31 == 0)
                    _text[i] = inscryptAlphabet[index];
                else
                    _text[i] = inscryptAlphabet[index % 31];
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

            for(int i = 0; i < alphabetMatrix.GetLength(0); i++)
            {
                for(int j =0; j < alphabetMatrix.GetLength(1); j++)
                {
                    alphabetMatrix[i, j] = inscryptAlphabet[i * alphabetMatrix.GetLength(1) + j]; 
                }
            }
        }
        private int IndexOf(char letter)
        {
            for(int i = 0; i < alphabetMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < alphabetMatrix.GetLength(1); j++)
                {
                    if (alphabetMatrix[i, j] == letter)
                        return i * alphabetMatrix.GetLength(1) + j;
                }
            }
            return -1;
        }

        public override string ToString()
        {
            return _text.ToString();
        }

    }
}
