using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛБ_1
{
    public class Atbash
    {
        private const string alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        //метод для переворачивания строки
        private string Reverse(string inputText)
        {
            //переменная для хранения результата
            var reversedText = string.Empty;
            foreach (var s in inputText)
            {
                //добавляем символ в начало строки
                reversedText = s + reversedText;
            }

            return reversedText;
        }

        //метод шифрования/дешифрования
        private string EncryptDecrypt(string text, string symbols, string cipher)
        {
            var outputText = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                if (char.IsLower(text[i]))
                {
                    //поиск позиции символа в строке алфавита
                    var index = symbols.IndexOf(text[i]);
                    if (index >= 0)
                    {
                        //замена символа на шифр
                        outputText += cipher[index].ToString();
                    }
                    else
                    {
                        outputText += text[i];
                    }
                }
                else
                {
                    //переводим текст в нижний регистр
                    char t = char.ToLower(text[i]);
                    //поиск позиции символа в строке алфавита
                    var index = symbols.IndexOf(t);
                    if (index >= 0)
                    {
                        //замена символа на шифр
                        outputText += char.ToUpper(cipher[index]);
                    }
                    else
                    {
                        outputText += t;
                    }
                }


            }

            return outputText;
        }

        //шифрование текста
        public string Encrypt(string plainText)
        {
            return EncryptDecrypt(plainText, alph, Reverse(alph));
        }

        //расшифровка текста
        public string Decrypt(string encryptedText)
        {
            return EncryptDecrypt(encryptedText, Reverse(alph), alph);
        }
    }
}
