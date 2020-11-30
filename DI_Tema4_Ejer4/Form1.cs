using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI_Tema4_Ejer4
{
    public delegate double Operacion(double num1, double num2);
    public partial class Form1 : Form
    {
        Operacion op;
        public double suma(double num1 , double num2)
        {
            return num1 + num2;
        }
        public double resta(double num1, double num2)
        {
            return num1 - num2;
        }
        public double multiplicacion(double num1, double num2)
        {
            return num1 * num2;          
        }
        public double division(double num1, double num2)
        {
            if (num2 != 0)
            {
                return num1 / num2;
            }
            else
            {
                MessageBox.Show("Dividiendo entre 0 ¿eh?", "Error", MessageBoxButtons.OK);

                return 0;
            }
        }

        public Form1()
        {
            InitializeComponent();
            radioButton1.Tag = "+";
            radioButton2.Tag = "-";
            radioButton3.Tag = "*";
            radioButton4.Tag = "/";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double num1) && double.TryParse(textBox2.Text, out double num2))
            {
                label2.Text = " = " + op(num1, num2);
            }
            else
            {
                MessageBox.Show("Uno de los elementos no era un numero", "Error",MessageBoxButtons.OK);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string operacion = ((RadioButton)sender).Tag + "";
            label1.Text = operacion;

            switch (operacion)
            {
                case "+":
                    op = suma;
                    break;
                case "-":
                    op = resta;
                    break;
                case "*":
                    op = multiplicacion;
                    break;
                case "/":
                    op = division;
                    break;
            }
        }
    }
}
