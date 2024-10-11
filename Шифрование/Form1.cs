using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ЛБ_1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;

namespace Шифрование
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            textBox3.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;

            label7.Visible = false;
            textBox10.Visible = false;
            label10.Visible = false;
            textBox12.Visible = false;

        }

        private void checkboxSelect(string selectedCB)
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl.Name != selectedCB)
                {
                    CheckBox cb = (CheckBox)ctrl;
                    cb.Checked = false;
                }
            }

            foreach (Control ctrl in groupBox2.Controls)
            {
                if (ctrl.Name != selectedCB)
                {
                    CheckBox cb = (CheckBox)ctrl;
                    cb.Checked = false;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.CheckState == CheckState.Checked)
            {
                checkboxSelect(cb.Name);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.CheckState == CheckState.Checked)
            {
                checkboxSelect(cb.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var atbash = new Atbash();
            var cipher = new Caesar();
            var pleifer = new Pleifer();
            var polibiya = new Polybia();
            var perestanovka = new MethodPerestanovki();
            var vig = new Vigener();
            var gamma = new Gamma();
            var affine = new AffineCipher();
            var rsa = new RSA();
            string decryptedMessage;
            string encryptedMessage;
            string str = textBox1.Text;

            textBox2.Text = string.Empty;

            if (str == "")
            {
                textBox2.Text = "     Не все входные данные выбраны!";
                return;
            }

            if (checkBox1.Checked)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case -1:
                        textBox2.Text = "     Не все входные данные выбраны!";
                        break;
                    case 0:
                        decryptedMessage = atbash.Decrypt(str);
                        textBox2.Text = decryptedMessage;
                        break;
                    case 1:
                        if (textBox3.Text == "")
                        {
                            textBox2.Text = "     Не все входные данные выбраны!";
                        }
                        else
                        {
                            int secretKey = int.Parse(textBox3.Text);
                            decryptedMessage = cipher.Decrypt(str, secretKey);
                            textBox2.Text = decryptedMessage;
                        }
                        break;
                    case 2:
                        decryptedMessage = polibiya.Decrypt(str);
                        textBox2.Text = decryptedMessage;
                        break;
                    case 3:
                        decryptedMessage = pleifer.Decrypt(str);
                        textBox2.Text = decryptedMessage;
                        break;
                    case 4:
                        if (textBox3.Text == "" || textBox4.Text == "")
                        {
                            textBox2.Text = "     Не все входные данные выбраны!";
                        }
                        else
                        {
                            int[] keyWrite = perestanovka.Perevod(textBox3.Text);
                            int[] keyRead = perestanovka.Perevod(textBox4.Text);
                            decryptedMessage = perestanovka.Decrypt(str, keyWrite, keyRead);
                            textBox2.Text = decryptedMessage;
                        }
                        break;
                    case 5:
                        if (textBox5.Text == "")
                        {
                            textBox2.Text = "     Не все входные данные выбраны!";
                        }
                        else
                        {
                            string secretKey = textBox5.Text;
                            decryptedMessage = vig.DecodeVig(str, secretKey);
                            textBox2.Text = decryptedMessage;
                        }
                        break;
                    case 6:
                        if (textBox3.Text == "")
                        {
                            textBox2.Text = "     Не все входные данные выбраны!";
                        }
                        else
                        {
                            int[] keyWrite = perestanovka.Perevod(textBox3.Text);
                            decryptedMessage = gamma.GetResult(str, keyWrite);
                            textBox2.Text = decryptedMessage;
                        }
                        break;
                    case 7:
                        if (textBox4.Text == "" || textBox5.Text == "")
                        {
                            textBox2.Text = "     Не все входные данные выбраны!";
                        }
                        else
                        {
                            int a = int.Parse(textBox5.Text);
                            int b = int.Parse(textBox4.Text);
                            if ((a > -1 && a < 33) && (b > -1 && b < 33))
                            {
                                decryptedMessage = affine.Decrypt(str, a, b);
                                textBox2.Text = decryptedMessage;
                            }
                            else
                            {
                                textBox2.Text = "     a и b должны быть в диапозоне [0;32]";
                            }
                        }
                        break;
                    case 8:
                        if (textBox4.Text == "" || textBox5.Text == "")
                        {
                            textBox2.Text = "     Не все входные данные выбраны!";
                        }
                        else if (!Regex.IsMatch(str, @"[^\d\s]") == false)
                        {
                            textBox2.Text = "     Не должно быть букв в шифрограмме!";
                        }
                        else
                        {
                            int a = int.Parse(textBox5.Text);
                            int b = int.Parse(textBox4.Text);
                            decryptedMessage = rsa.Decrypt(str, a, b);
                            textBox2.Text = decryptedMessage;
                        }
                        break;
                }
            }
            else if (checkBox2.Checked)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case -1:
                        textBox2.Text = "     Не все входные данные выбраны!";
                        break;
                    case 0:
                        encryptedMessage = atbash.Encrypt(str);
                        textBox2.Text = encryptedMessage;
                        break;
                    case 1:
                        if (textBox3.Text == "")
                        {
                            textBox2.Text = "     Не все входные данные выбраны!";
                        }
                        else
                        {
                            int secretKey = int.Parse(textBox3.Text);
                            encryptedMessage = cipher.Encrypt(str, secretKey);
                            textBox2.Text = encryptedMessage;
                        }
                        break;
                    case 2:
                        encryptedMessage = polibiya.Encrypt(str);
                        textBox2.Text = encryptedMessage;
                        break;
                    case 3:
                        encryptedMessage = pleifer.Encrypt(str);
                        textBox2.Text = encryptedMessage;
                        break;
                    case 5:
                        if (textBox5.Text == "")
                        {
                            textBox2.Text = "     Не все входные данные выбраны!";
                        }
                        else
                        {
                            string secretKey = textBox5.Text;
                            encryptedMessage = vig.EncodeVig(str, secretKey);
                            textBox2.Text = encryptedMessage;
                        }
                        break;
                    case 7:
                        if (textBox4.Text == "" || textBox5.Text == "")
                        {
                            textBox2.Text = "     Не все входные данные выбраны!";
                        }
                        else
                        {
                            int a = int.Parse(textBox5.Text);
                            int b = int.Parse(textBox4.Text);
                            if ((a>-1 && a<33) && (b>-1 && b < 33))
                            {
                                encryptedMessage = affine.Encrypt(str, a, b);
                                textBox2.Text = encryptedMessage;
                            }
                            else
                            {
                                textBox2.Text = "     a и b должны быть в диапозоне [0;32]";
                            }
                           
                        }
                        break;
                    case 8:
                        if (textBox4.Text == "" || textBox5.Text == "")
                        {
                            textBox2.Text = "     Не все входные данные выбраны!";
                        }
                        else
                        {
                            int a = int.Parse(textBox5.Text);
                            int b = int.Parse(textBox4.Text);
                            decryptedMessage = rsa.Encrypt(str, a, b);
                            textBox2.Text = decryptedMessage;
                        }
                        break;
                }
            }
            else
            {
                textBox2.Text = "     Не все входные данные выбраны!";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox3.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            checkBox2.Visible = true;

            if (comboBox1.SelectedIndex == 1)
            {
                label1.Visible = true;
                textBox3.Visible = true;
            }
            if (comboBox1.SelectedIndex == 4)
            {
                label2.Visible = true;
                label3.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                checkBox2.Visible = false;
            }
            if (comboBox1.SelectedIndex == 5)
            {
                label1.Visible = true;
                textBox5.Visible = true;
            }
            if (comboBox1.SelectedIndex == 6)
            {
                label1.Visible = true;
                label1.Text = "Гамма";
                textBox3.Visible = true;
                checkBox2.Visible = false;
            }
            if (comboBox1.SelectedIndex == 7)
            {
                label3.Visible = true;
                label3.Text = "a";
                label2.Visible = true;
                label2.Text = "b";
                textBox4.Visible = true;
                textBox5.Visible = true;
            }
            if (comboBox1.SelectedIndex == 8)
            {
                label3.Visible = true;
                label3.Text = "p";
                label2.Visible = true;
                label2.Text = "q";
                textBox4.Visible = true;
                textBox5.Visible = true;
            }
        }

        private char[] abc = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у',
            'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'};

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    e.Handled = true;
            }

            if (comboBox1.SelectedIndex == 4)
            {
                if(!char.IsDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }

            if (comboBox1.SelectedIndex == 6)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }

            if (comboBox1.SelectedIndex == 7)
            {
                if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    e.Handled = true;
            }

            if (comboBox1.SelectedIndex == 8)
            {
                if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == 5)
            {
                if (e.KeyChar == '\b')
                {
                    // Разрешение удаления символов
                    e.Handled = false;
                }
                else if (!abc.Contains(char.ToLower(e.KeyChar)))
                    e.Handled = true;
            }

            if (comboBox1.SelectedIndex == 7)
            {
                if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    e.Handled = true;
            }

            if (comboBox1.SelectedIndex == 8)
            {
                if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == 6)
            {
                e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            }

            if (comboBox1.SelectedIndex == 7)
            {
                e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
            textBox10.Visible = false;
            label10.Visible = false;
            textBox12.Visible = false;

            if (comboBox2.SelectedIndex == 1)
            {
                label7.Visible = true;
                textBox10.Visible = true;
                label10.Visible = true;
                textBox12.Visible = true;
                label9.Text = "Общий ключ между А и Z:";
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var deffi = new Deffi();

            if (textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                textBox13.Text = "Не все входные данные выбраны!";
            }
            else
            {
                int a = int.Parse(textBox8.Text);
                int b = int.Parse(textBox9.Text);
                int g = int.Parse(textBox6.Text);
                int p = int.Parse(textBox7.Text);

                switch (comboBox2.SelectedIndex)
                {
                    case -1:
                        textBox13.Text = "Не все входные данные выбраны!";
                        break;
                    case 0:
                        string result = deffi.WithoutScammer(g, a, b, p).ToString();

                        textBox11.Text = result;

                        textBox13.Text = "Если -1, то нет общего ключа!";
                        break;
                    case 1:
                        if (textBox10.Text == "")
                        {
                            textBox13.Text = "Не все входные данные выбраны!";
                        }
                        else
                        {
                            int z = int.Parse(textBox10.Text);

                            double[] result2 = deffi.WithScammer(g, a, b, z, p);

                            textBox11.Text = result2[0].ToString();
                            textBox12.Text = result2[1].ToString();

                            textBox13.Text = "Если -1, то нет общего ключа!";
                        }
                        break;
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.CheckState == CheckState.Checked)
            {
                checkboxSelect(cb.Name);
            }

            label13.Visible = true;
            textBox18.Visible = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.CheckState == CheckState.Checked)
            {
                checkboxSelect(cb.Name);
            }

            label13.Visible = false;
            textBox18.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ecp = new ECP();
            string decryptedMessage;
            string str = textBox15.Text;

            textBox17.Text = string.Empty;

            if (str == "")
            {
                textBox17.Text = "     Не все входные данные выбраны!";
                return;
            }

            if (checkBox4.Checked)
            {
                if (textBox14.Text == "" || textBox16.Text == "")
                {
                    textBox17.Text = "     Не все входные данные выбраны!";
                }
                else
                {
                    int n = int.Parse(textBox14.Text);
                    int d = int.Parse(textBox16.Text);
                    decryptedMessage = ecp.Hash(str, n, d);
                    textBox17.Text = decryptedMessage;
                }
            }
            else if (checkBox3.Checked)
            {
                if (textBox14.Text == "" || textBox16.Text == "" || textBox18.Text == "")
                {
                    textBox17.Text = "     Не все входные данные выбраны!";
                }
                else
                {
                    int n = int.Parse(textBox14.Text);
                    int d = int.Parse(textBox16.Text);
                    int e2 = int.Parse(textBox18.Text);
                    decryptedMessage = ecp.Podlinost(str, n, d, e2);
                    textBox17.Text = decryptedMessage;
                }
            }
        }
    }
}
