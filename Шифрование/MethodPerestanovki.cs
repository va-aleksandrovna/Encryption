using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шифрование
{
    internal class MethodPerestanovki
    {
        public string Decrypt(string ciphertext, int[] keyWrite, int[] keyRead)
        {
            //string ciphertext = "ППОЕСИЛУЧООЧИТСЗГОВ6ОЛНЛАНЧОО1ГАЯККЕОПО7ТЛЮИОНОЕО2ОИУОЛИУСД9ЕДЬААВТАГ4ЛАЛТТЗАСТ3ЧИСТТЕТДЛ8ВУПЕВЛОДЖ5";
            //int[] keyWrite = { 8, 2, 5, 4, 1, 3, 7, 9, 6, 10 };
            //int[] keyRead = { 8, 2, 5, 4, 1, 3, 7, 9, 6, 10 };

            int r = keyRead.Length;

            // Разбиваем криптограмму на группы по r символов
            string[] groups = SplitIntoGroups(ciphertext, r);

            // Создаем пустую матрицу rxr
            char[,] matrix = new char[r, r];

            // Заполняем матрицу в соответствии с ключом записи
            for (int i = 0; i < groups.Length; i++)
            {
                int column = keyRead[i] - 1;
                for (int j = 0; j < groups[i].Length; j++)
                {
                    matrix[j, column] = groups[i][j];
                }
            }

            // Считываем открытый текст в соответствии с ключом записи
            string decryptedText = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int row = keyWrite[i] - 1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    decryptedText += matrix[row, j];
                }
            }
            return decryptedText;
        }

        static string[] SplitIntoGroups(string text, int groupSize)
        {
            int numGroups = (int)Math.Ceiling((double)text.Length / groupSize);
            string[] groups = new string[numGroups];

            for (int i = 0; i < numGroups; i++)
            {
                int startIndex = i * groupSize;
                int length = Math.Min(groupSize, text.Length - startIndex);
                groups[i] = text.Substring(startIndex, length);
            }
            return groups;
        }

        public int[] Perevod(string str)
        {
            string[] numbers = str.Split(' ');
            int[] intArray = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                int.TryParse(numbers[i], out intArray[i]);
            }
            return intArray;
        }
    }
}
