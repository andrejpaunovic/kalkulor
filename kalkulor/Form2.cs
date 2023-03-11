using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace kalkulor
{
    public partial class Form2 : Form
    {
        protected int radnja = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            radnja = 1;
            textBox3.Text = "+";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radnja = 2;
            textBox3.Text = "-";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            radnja = 3;
            textBox3.Text = "*";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            radnja = 4;
            textBox3.Text = "/";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RomanToDecimal broj1,broj2;
            Rimski_brojevi prvi, drugi;
            prvi = new Rimski_brojevi(textBox1.Text);
            drugi = new Rimski_brojevi(textBox2.Text);
            broj1 = new RomanToDecimal();
            broj2 = new RomanToDecimal();
            if((prvi.provera(textBox1.Text)==false)||(drugi.provera(textBox2.Text)==false)||(textBox1.Text=="")||(textBox2.Text==""))
            {
                MessageBox.Show("Nemojte molim vas:(", "Greska!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox3.Text=="+")
                {
                    if(prvi.provera(prvi.convertint(broj1.Convert(textBox1.Text) + broj2.Convert(textBox2.Text)))==true)
                    {
                        textBox1.Text = prvi.convertint(broj1.Convert(textBox1.Text) + broj2.Convert(textBox2.Text));
                    }
                    else
                    {
                        MessageBox.Show("Izlazite van granice rimskih brojeva!", "Greska!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                if (textBox3.Text=="-")
                {
                    if(broj1.Convert(textBox1.Text) - broj2.Convert(textBox2.Text)>0)
                    {
                        if(prvi.provera(prvi.convertint(broj1.Convert(textBox1.Text) - broj2.Convert(textBox2.Text))) == true)
                        textBox1.Text = prvi.convertint(broj1.Convert(textBox1.Text) - broj2.Convert(textBox2.Text));
                    }
                    else
                    {
                        MessageBox.Show("Izlazite van granice rimskih brojeva!", "Greska!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if(textBox3.Text=="*")
                {
                    if (prvi.provera(prvi.convertint(broj1.Convert(textBox1.Text) * broj2.Convert(textBox2.Text))) == true)
                    {
                        textBox1.Text = prvi.convertint(broj1.Convert(textBox1.Text) * broj2.Convert(textBox2.Text));
                    }
                    else
                    {
                        MessageBox.Show("Izlazite van granice rimskih brojeva!", "Greska!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if(textBox3.Text=="/")
                {
                    if (prvi.provera(prvi.convertint(broj1.Convert(textBox1.Text) / broj2.Convert(textBox2.Text))) == true)
                    {
                        textBox1.Text = prvi.convertint(broj1.Convert(textBox1.Text) / broj2.Convert(textBox2.Text));
                    }
                    else
                    {
                        MessageBox.Show("Izlazite van granice rimskih brojeva!", "Greska!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                textBox3.Text = "";

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";


        }
    }
    class Rimski_brojevi
    {
        protected string broj;
        protected int num;
        public Rimski_brojevi(string broj)
        {
            this.broj = broj;
            this.num = 0;
        }
        public bool provera(string s)
        {
            string str = @"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
            Regex re = new Regex(str);
            if (re.IsMatch(s)) return true;
            return false;
        }
        public string convertint(int n)
        {
            string[] roman_symbol = { "MMM", "MM", "M", "CM", "DCCC", "DCC", "DC", "D", "CD", "CCC", "CC", "C", "XC", "LXXX", "LXX", "LX", "L", "XL", "XXX", "XX", "X", "IX", "VIII", "VII", "VI", "V", "IV", "III", "II", "I" };
            int[] int_value = { 3000, 2000, 1000, 900, 800, 700, 600, 500, 400, 300, 200, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            var roman_numerals = new StringBuilder();
            var index_num = 0;
            while (n != 0)
            {
                if (n >= int_value[index_num])
                {
                    n -= int_value[index_num];
                    roman_numerals.Append(roman_symbol[index_num]);
                }
                else
                {
                    index_num++;
                }
            }

            return roman_numerals.ToString();
        }
    }

    public class RomanToDecimal
    {
        private int GetIntegerValue(char symbol)
        {
            switch (symbol)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default: return -1;
            }
        }

        public int Convert(string roman)
        {
            var sum = 0;
            for (var i = 0; i < roman.Length; i++)
            {
                var current = GetIntegerValue(roman[i]);
                if (current == -1)
                    return -1;

                if ((i + 1) < roman.Length)
                {
                    var next = GetIntegerValue(roman[i + 1]);
                    if (next == -1)
                        return -1;

                    if (next > current)
                    {
                        if (next > 10 * current)
                            return -1;

                        sum -= current;
                        continue;
                    }
                }
                sum += current;
            }
            return sum;
        }

       
    }
}
