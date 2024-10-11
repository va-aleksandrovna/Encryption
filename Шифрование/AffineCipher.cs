using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шифрование
{
    class AffineCipher
    {
        //чялзвдцхлеойжпрхлеояпйжгяпжгцлзжлжывгэлцмгмгежкнрхгмоэгйгрлвжоцэюжгчгэг
        //5
        //3
        
        static char[] abc = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у',
        'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'};

        public string Encrypt(string message, int a, int b)
        {
            string encryptedMessage = "";
            int cod = 100;
            int m = 33; // размер алфавита
            foreach (char c in message)
            {
                char x = char.ToLower(c);
                for (int i = 0; i < abc.Length; i++)
                {
                    if (x == abc[i])
                    {
                        cod = i;
                    }
                }
                int encryptedCod = (a * cod + b) % m;
                encryptedMessage += abc[encryptedCod];
            }
            return encryptedMessage;
        }

        public string Decrypt(string encryptedMessage, int a, int b)
        {
            string decryptedMessage = "";
            int cod;
            int cod2 = 100;
            int m = 33; // размер алфавита
            foreach (char c in encryptedMessage)
            {
                char x = char.ToLower(c);
                for (int i = 0; i < abc.Length; i++)
                {
                    if (x == abc[i])
                    {
                        cod2 = i;
                    }
                }

                for (int i = 0; i < abc.Length; i++)
                {
                    cod = (a * i + b) % m;
                    if (cod == cod2)
                    {
                        decryptedMessage += abc[i];
                        break;
                    }
                }
            }
            return decryptedMessage;
        }

        //static void Main()
        //{
        //    Console.WriteLine("Введите открытый текст:");
        //    string message = Console.ReadLine();

        //    Console.WriteLine("Введите значение а:");
        //    int a = int.Parse(Console.ReadLine());

        //    Console.WriteLine("Введите значение b:");
        //    int b = int.Parse(Console.ReadLine());

        //    string encryptedMessage = Encrypt(message, a, b);
        //    Console.WriteLine("Зашифрованный текст: " + encryptedMessage);

        //    string decryptedMessage = Decrypt(message, a, b);
        //    Console.WriteLine("Расшифрованный текст: " + decryptedMessage);

        //    Console.ReadKey();
        //}
    }
}
