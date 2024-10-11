using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Шифрование
{
    public class Polybia
    {
        char[,] alfrus = { { 'а', 'б', 'в', 'г', 'д', 'е' },
            { 'ё', 'ж', 'з', 'и', 'й', 'к' },
            { 'л', 'м', 'н', 'о', 'п', 'р' },
            { 'с', 'т', 'у', 'ф', 'х', 'ц' },
            { 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь' },
            { 'э', 'ю', 'я', '.', ',', '!'} };

        public string Encrypt(string message)
        {
            string new_message = "";

            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == ' ')
                {
                    new_message += ' ';
                    continue;
                }

                for (int j = 0; j < alfrus.GetLength(0); j++)
                    for (int k = 0; k < alfrus.GetLength(1); k++)
                        if (Char.ToLower(alfrus[j, k]) == message[i] || Char.ToUpper(alfrus[j, k]) == message[i])
                        {
                            new_message += (" " + Convert.ToString(j + 1) + Convert.ToString(k + 1));
                            break;
                        }
            }

            return new_message;
        }

        public string Decrypt(string message)
        {
            string new_message = "";

            if (!Regex.IsMatch(message, @"[^\d\s]"))
            {
                if (message.Count(char.IsDigit) % 2 == 0)
                {
                    for (int i = 0; i < message.Length; i += 2)
                    {
                        if (message[i] == ' ')
                        {
                            new_message += ' ';
                            i--;
                            continue;
                        }

                        int row = Convert.ToInt32(message[i].ToString()) - 1;
                        int column = Convert.ToInt32(message[i + 1].ToString()) - 1;
                        new_message += alfrus[row, column];
                    }
                    return new_message;
                }
                else
                {
                    new_message = "Ошибка! Введено неправильное количество цифр!";
                    return new_message;
                }
            }
            else
            {
                new_message = "При таких настройках разрешено использовать только цифры и пробелы!";
                return new_message;
            }
        }
    }
}
