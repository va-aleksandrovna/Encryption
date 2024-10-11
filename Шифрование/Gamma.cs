using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шифрование
{
    internal class Gamma
    {
        //словарь
        public Dictionary<char, int> symbols = new Dictionary<char, int>()
        {
            {'А',192},
            {'Б',193},
            {'В',194},
            {'Г',195},
            {'Д',196},
            {'Е',197},
            {'Ж',198},
            {'З',199},
            {'И',200},
            {'Й',201},
            {'К',202},
            {'Л',203},
            {'М',204},
            {'Н',205},
            {'О',206},
            {'П',207},
            {'Р',208},
            {'С',209},
            {'Т',210},
            {'У',211},
            {'Ф',212},
            {'Х',213},
            {'Ц',214},
            {'Ч',215},
            {'Ш',216},
            {'Щ',217},
            {'Ъ',218},
            {'Ы',219},
            {'Ь',220},
            {'Э',221},
            {'Ю',222},
            {'Я',223},
            {'а',224},
            {'б',225},
            {'в',226},
            {'г',227},
            {'д',228},
            {'е',229},
            {'ж',230},
            {'з',231},
            {'и',232},
            {'й',233},
            {'к',234},
            {'л',235},
            {'м',236},
            {'н',237},
            {'о',238},
            {'п',239},
            {'р',240},
            {'с',241},
            {'т',242},
            {'у',243},
            {'ф',244},
            {'х',245},
            {'ц',246},
            {'ч',247},
            {'ш',248},
            {'щ',249},
            {'ъ',250},
            {'ы',251},
            {'ь',252},
            {'э',253},
            {'ю',254},
            {'я',255}
        };
        public class Symbol : Gamma
        {
            public char symbol;
            public int number10;
            public string number2;
            public char gamma;
            public int gamma10;
            public string gamma2;
            public int result10;
            public string result2;
            public char shifr;

            public static string GetResult2(string g2, string n2)//вычисление xor
            {
                int lg2 = g2.Length;
                int ln2 = n2.Length;
                int k;
                string result = "";
                if (ln2 > lg2)
                {
                    k = lg2 - 1;
                    for (int i = ln2 - 1; i >= 0; i--)
                    {
                        if (k >= 0)
                        {
                            int sum = Int32.Parse(n2[i].ToString()) ^ Int32.Parse(g2[k].ToString());
                            result = result + sum.ToString();
                            k--;
                        }
                        else
                        {
                            result = result + n2[i];
                        }
                    }
                    char[] chars = result.ToCharArray();
                    Array.Reverse(chars);
                    return new string(chars);
                }
                else
                {
                    k = ln2 - 1;
                    for (int i = lg2 - 1; i >= 0; i--)
                    {
                        if (k >= 0)
                        {
                            int sum = Int32.Parse(n2[k].ToString()) ^ Int32.Parse(g2[i].ToString());
                            result = result + sum.ToString();
                            k--;
                        }
                        else
                        {
                            result = result + g2[i];
                        }
                    }
                    char[] chars = result.ToCharArray();
                    Array.Reverse(chars);
                    return new string(chars);
                }
            }

            public Symbol(char s, char g)
            {
                gamma = g;
                symbol = s;
                foreach (var item in symbols)//поиск кода, соответствующего символу, из словаря
                {
                    if (s == item.Key)
                    {
                        number10 = item.Value;//надодим в 10 системе
                        number2 = Convert.ToString(number10, 2);//перевод в 2 систему
                    }
                }
                gamma2 = Convert.ToString(gamma, 2);//переводим гамму в 2ое число
                result2 = GetResult2(gamma2, number2);//вычисление xor
                result10 = Convert.ToInt32(result2, 2);//перевод рез-тата в 10ое число
                foreach (var item in symbols)//поиск ключа по значению в словаре
                {
                    if (item.Value == result10)
                    {
                        shifr = item.Key;
                    }

                }
            }
        }


        public List<Symbol> Result = new List<Symbol>();//список с расшифрованными символами

        public string GetResult(string data, int[] gamma)//метод расшифровки сообщения
        {
            int lengthData = data.Length;
            int lengthGamma = gamma.Length;
            int k = 0;
            for (int i = 0; i < lengthData; i++)
            {
                if (k == lengthGamma)
                {
                    k = 0;
                }
                Symbol s = new Symbol(data[i], (char)gamma[k]);//создаем экземпляр класса, который по символу и гамме, находит символ

                k++;

                Result.Add(s);//добавление рез-та в список
            }
            string res = "";
            foreach (var item in Result)//переводим список в строку
            {
                res = res + item.shifr;
            }
            return res;
        }
    }
}
