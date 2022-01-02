using System;

namespace Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CipherCaesar cc = new CipherCaesar("Саня здарова", 3);

            cc.Inscrypt();
            Console.WriteLine(cc);
        }

      
    }
}
