using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Шифрование
{
    public class Pleifer
    {
        char[,] matrix = new char[4, 8] {
                    { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з' },
                    { 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п' },
                    { 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч' },
                    { 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' }
                };

        public string Encrypt(string message)
        {
            // Добавляем символ "x", если длина сообщения нечетная
            if (message.Length % 2 != 0)
            {
                message += "x";
            }

            // Разбиваем сообщение на биграммы
            List<string> bigrams = new List<string>();
            for (int i = 0; i < message.Length; i += 2)
            {
                bigrams.Add(message.Substring(i, 2));
            }

            // Шифруем каждую биграмму
            string encryptedMessage = "";
            foreach (string bigram in bigrams)
            {
                char firstChar = bigram[0];
                char secondChar = bigram[1];

                int[] firstIndexes = FindIndexes(matrix, firstChar);
                int[] secondIndexes = FindIndexes(matrix, secondChar);

                if (firstIndexes[0] == secondIndexes[0])
                {
                    // Символы в одной строке
                    int newFirstIndex = (firstIndexes[1] + 1) % 8;
                    int newSecondIndex = (secondIndexes[1] + 1) % 8;
                    encryptedMessage += matrix[firstIndexes[0], newFirstIndex];
                    encryptedMessage += matrix[secondIndexes[0], newSecondIndex];
                }
                else if (firstIndexes[1] == secondIndexes[1])
                {
                    // Символы в одном столбце
                    int newFirstIndex = (firstIndexes[0] + 1) % 4;
                    int newSecondIndex = (secondIndexes[0] + 1) % 4;
                    encryptedMessage += matrix[newFirstIndex, firstIndexes[1]];
                    encryptedMessage += matrix[newSecondIndex, secondIndexes[1]];
                }
                else
                {
                    // Символы в разных строках и столбцах
                    encryptedMessage += matrix[firstIndexes[0], secondIndexes[1]];
                    encryptedMessage += matrix[secondIndexes[0], firstIndexes[1]];
                }
            }

            return encryptedMessage;
        }

        private static int[] FindIndexes(char[,] matrix, char symbol)
        {
            int[] indexes = new int[2];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j] == symbol)
                    {
                        indexes[0] = i;
                        indexes[1] = j;
                        return indexes;
                    }
                }
            }
            return indexes;
        }

        public string Decrypt(string encryptedMessage)
        {
            List<string> bigrams = new List<string>();
            for (int i = 0; i < encryptedMessage.Length; i += 2)
            {
                bigrams.Add(encryptedMessage.Substring(i, 2));
            }

            string decryptedMessage = "";
            foreach (string bigram in bigrams)
            {
                char firstChar = bigram[0];
                char secondChar = bigram[1];

                int[] firstIndexes = FindIndexes(matrix, firstChar);
                int[] secondIndexes = FindIndexes(matrix, secondChar);

                if (firstIndexes[0] == secondIndexes[0])
                {
                    int newFirstIndex = (firstIndexes[1] + 7) % 8;
                    int newSecondIndex = (secondIndexes[1] + 7) % 8;
                    decryptedMessage += matrix[firstIndexes[0], newFirstIndex];
                    if (bigram.Length % 2 != 0)
                    {
                        decryptedMessage += matrix[firstIndexes[0], newFirstIndex - 1];
                    }
                    decryptedMessage += matrix[secondIndexes[0], newSecondIndex];
                }
                else if (firstIndexes[1] == secondIndexes[1])
                {
                    int newFirstIndex = (firstIndexes[0] + 3) % 4;
                    int newSecondIndex = (secondIndexes[0] + 3) % 4;
                    decryptedMessage += matrix[newFirstIndex, firstIndexes[1]];
                    if (bigram.Length % 2 != 0)
                    {
                        decryptedMessage += matrix[newFirstIndex - 1, firstIndexes[1]];
                    }
                    decryptedMessage += matrix[newSecondIndex, secondIndexes[1]];
                }
                else
                {
                    decryptedMessage += matrix[firstIndexes[0], secondIndexes[1]];
                    if (bigram.Length % 2 != 0)
                    {
                        decryptedMessage += matrix[firstIndexes[0], secondIndexes[1]];
                    }
                    decryptedMessage += matrix[secondIndexes[0], firstIndexes[1]];
                }
            }

            return decryptedMessage;
        }
    }
}
