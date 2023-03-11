using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kalkulor
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "+";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "-";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "*";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "/";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HashSet<string> skup = new HashSet<string>();
            skup.Add("1");
            skup.Add("2");
            skup.Add("3");
            skup.Add("4");
            skup.Add("5");
            skup.Add("6");
            skup.Add("7");
            skup.Add("8");
            skup.Add("9");
            skup.Add("0");
            skup.Add("+");
            skup.Add("-");



        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
    class Kompleksni
    {
        protected double real, imag;
        public Kompleksni(string real, string imag)
        {
            this.real = Convert.ToDouble(real);
            for(int i=0;i<imag.Length;i++)
            {
                if (imag[i]=='i')
                {
                    //imag[i] = ' ';
                }
            }
            this.imag=Convert.ToDouble(imag);
        }

    }
}
