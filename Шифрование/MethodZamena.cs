using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Шифрование
{
    internal class MethodZamena
    {
        private int count;
        public Zamena()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key.Text != "" && OwnDataShifr.Text != "")
            {
                //float c = Math.Sqrt(ow)
            }
        }

        private void GetEnableKey_Click(object sender, EventArgs e)
        {
            if (OwnDataShifr.Text != "")
            {
                string key = "";
                double c = Math.Sqrt(OwnDataShifr.Text.Length);
                bool isInt = false;
                var text = OwnDataShifr.Text;
                for (int z = 0; z < c.ToString().Length; z++)
                {
                    if (c.ToString()[z] == ',')
                    {
                        isInt = true;
                        break;
                    }
                }
                if (!isInt)
                {
                    for (int i = 1; i <= c; i++)
                    {
                        key = key + (i - 1).ToString();
                    }
                    count = Int32.Parse(c.ToString()[0].ToString());
                }
                else
                {
                    for (int i = 1; i <= c + 1; i++)
                    {
                        key = key + (i - 1).ToString();
                    }
                    count = Int32.Parse(c.ToString()[0].ToString()) + 1;
                    while (c != count)
                    {
                        text = text + "!";
                        c = Math.Sqrt(text.Length);
                    }
                    if (c == count)
                    {
                        OwnDataShifr.Text = text;
                    }
                }
                EnableKey.Text = key;
            }
        }

        private void Shifr_Click(object sender, EventArgs e)
        {
            char[,] text = new char[count, count];
            char[,] newText1 = new char[count, count];
            char[,] newText2 = new char[count, count];
            string result = "";
            int k = 0;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    text[i, j] = OwnDataShifr.Text[k];
                    k++;
                }
            }
            if (key.Text != "" && stolb.Text != "")
            {
                int l = 0;
                for (int i = 0; i < key.Text.Length; i++)
                {
                    if (i == 0)
                    {
                        l = 0;
                    }
                    for (int j = 0; j < count; j++)
                    {
                        newText1[l, j] = text[Int32.Parse(key.Text[i].ToString()), j];
                    }
                    l++;
                }
                for (int i = 0; i < stolb.Text.Length; i++)
                {
                    if (i == 0)
                    {
                        l = 0;
                    }
                    for (int j = 0; j < count; j++)
                    {
                        newText2[j, l] = newText1[j, Int32.Parse(stolb.Text[i].ToString())];
                    }
                    l++;
                }
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        result = result + newText2[j, i];
                    }
                }
                ResultShifr.Text = result;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Rashifr_Click(object sender, EventArgs e)
        {
            char[,] text = new char[count, count];
            char[,] newText1 = new char[count, count];
            char[,] newText2 = new char[count, count];
            string result = "";
            int k = 0;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    text[j, i] = OwnDataRashifr.Text[k];
                    k++;
                }
            }
            if (key1.Text != "" && stolb1.Text != "")
            {
                int l = 0;
                for (int i = 0; i < key1.Text.Length; i++)
                {
                    if (i == 0)
                    {
                        l = 0;
                    }
                    for (int j = 0; j < count; j++)
                    {
                        newText1[Int32.Parse(key1.Text[i].ToString()), j] = text[l, j];
                    }
                    l++;
                }
                for (int i = 0; i < stolb1.Text.Length; i++)
                {
                    if (i == 0)
                    {
                        l = 0;
                    }
                    for (int j = 0; j < count; j++)
                    {
                        newText2[j, Int32.Parse(stolb1.Text[i].ToString())] = newText1[j, l];
                    }
                    l++;
                }
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        result = result + newText2[i, j];
                    }
                }
                ResultRashifr.Text = result;
            }
        }
    }
}
