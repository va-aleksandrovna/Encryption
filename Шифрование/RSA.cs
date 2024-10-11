using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Шифрование
{
    class RSA
    {
        public static Dictionary<char, int> abc = new Dictionary<char, int>()
        {
            {'А',1},
            {'Б',2},
            {'В',3},
            {'Г',4},
            {'Д',5},
            {'Е',6},
            {'Ё',7},
            {'Ж',8},
            {'З',9},
            {'И',10},
            {'Й',11},
            {'К',12},
            {'Л',13},
            {'М',14},
            {'Н',15},
            {'О',15},
            {'П',17},
            {'Р',18},
            {'С',19},
            {'Т',20},
            {'У',21},
            {'Ф',22},
            {'Х',23},
            {'Ц',24},
            {'Ч',25},
            {'Ш',26},
            {'Щ',27},
            {'Ъ',28},
            {'Ы',29},
            {'Ь',30},
            {'Э',31},
            {'Ю',32},
            {'Я',33},
            {' ',34},
            {'0',35},
            {'1',36},
            {'2',37},
            {'3',38},
            {'4',39},
            {'5',40},
            {'6',41},
            {'7',42},
            {'8',43},
            {'9',44}
        };

        public string Encrypt(string message, int p, int q)
        {
            string encryptedMessage = "";

            int n = p * q;
            int fn = (p - 1) * (q - 1);
            int e = 0;
            for (int i = p - 1; i > 0; i--)
            {
                if (IsPrime(i))
                {
                    e = i;
                    break;
                }
            }

            string m = "";
            message = message.ToUpper();
            foreach (var item in message)//поиск кода, соответствующего символу, из словаря
            {
                abc.TryGetValue(item, out int m2);
                m += m2.ToString();
            }
            Console.WriteLine(m);

            int blockSize = n.ToString().Length + 1;// размер блока
            bool res = true;
            int k;
            List<int> blocm = new List<int>();
            while (res)
            {
                k = 0;
                blockSize--;
                blocm.Clear();
                for (int i = 0; i < m.Length; i += blockSize)
                {
                    string block = m.Substring(i, Math.Min(blockSize, m.Length - i)).PadLeft(blockSize, '0');
                    if (Convert.ToInt32(block) >= n)
                    {
                        k = 1;
                    }
                    blocm.Add(Convert.ToInt32(block));
                }
                if (k != 1)
                {
                    res = false;
                }
            }
            foreach (var item in blocm)
            {
                BigInteger v = BigInteger.ModPow(item, e, n);
                encryptedMessage = encryptedMessage + v.ToString() + " ";
            }

            return encryptedMessage;
        }

        public static bool IsPrime(int number) // проверка числа на простоту
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        public string Decrypt(string encryptedMessage, int p, int q)
        {
            string decryptedMessage = "";

            int n = p * q;
            double fn = (p - 1) * (q - 1);
            double e = 0;
            for (int i = p - 1; i > 0; i--)
            {
                if (IsPrime(i))
                {
                    e = i;
                    break;
                }
            }

            double d = 0;
            double k = 0;
            bool result = true;
            while (result)
            {
                k++;
                d = ((k * fn) + 1) / e;
                if ((d == (int)d))
                {
                    result = false;
                }
            }

            encryptedMessage = encryptedMessage.Trim();
            int[] a = encryptedMessage.Split(' ').Select(x => int.Parse(x)).ToArray();

            foreach (var item in a)
            {
                BigInteger v = BigInteger.ModPow(item, (BigInteger)d, n);
                decryptedMessage = decryptedMessage + v.ToString() + " ";
            }
            return decryptedMessage;
        }

        //static void Main()
        //{
        //    Console.WriteLine("Введите сообщение:");
        //    string message = Console.ReadLine();

        //    Console.WriteLine("Введите значение p:");
        //    int a = int.Parse(Console.ReadLine());

        //    Console.WriteLine("Введите значение q:");
        //    int b = int.Parse(Console.ReadLine());

        //    string encryptedMessage = Encrypt(message, a, b);
        //    Console.WriteLine("Зашифрованный текст: " + encryptedMessage);

        //    string decryptedMessage = Decrypt(encryptedMessage, a, b);
        //    Console.WriteLine("Расшифрованный текст: " + decryptedMessage);

        //    Console.ReadKey();
        //}
    }
}
