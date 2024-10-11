using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Шифрование
{
    internal class ECP
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
            {'О',16},
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

        public string Hash(string message, int n, int d)
        {
            string encryptedMessage = "";

            int[] m = new int[message.Length];
            message = message.ToUpper();
            int i = 0;
            foreach (var item in message)//поиск кода, соответствующего символу, из словаря
            {
                abc.TryGetValue(item, out int m2);
                m[i] = m2;
                i++;
            }

            BigInteger h = 0;
            i = 0;
            foreach (var item in m)
            {
                h = BigInteger.ModPow((h + m[i]), 2, n);
                i++;
            }

            BigInteger s = BigInteger.ModPow(h, d, n);

            encryptedMessage = s.ToString() + message;

            return encryptedMessage;
        }

        static string OtdFirst(string строка)
        {
            Match match = Regex.Match(строка, @"\d+");
            if (match.Success)
            {
                return match.Value;
            }
            else
            {
                return "";
            }
        }

        static string OtdAbc(string строка)
        {
            Match match = Regex.Match(строка, @"^\d+(.+$)");
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                return "";
            }
        }

        public string Podlinost(string message, int e, int n, int d)
        {
            string decryptedMessage = "";

            string s = OtdFirst(message);

            BigInteger h1 = BigInteger.ModPow(BigInteger.Parse(s), e, n);

            message = OtdAbc(message);

            int[] m = new int[message.Length];
            message = message.ToUpper();
            int i = 0;
            foreach (var item in message)//поиск кода, соответствующего символу, из словаря
            {
                abc.TryGetValue(item, out int m2);
                m[i] = m2;
                i++;
            }

            BigInteger h2 = 0;
            i = 0;
            foreach (var item in m)
            {
                h2 = BigInteger.ModPow((h2 + m[i]), 2, n);
                i++;
            }

            Console.WriteLine(h1);
            Console.WriteLine(h2);

            if (h1 == h2)
            {
                decryptedMessage = "Подпись подлинная";
            }
            else
            {
                decryptedMessage = "Подпись не подлинная";
            }

            return decryptedMessage;
        }
    }
}
