using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI_Tema4_Ejer4
{
    public delegate double Operacion(double num1, double num2);
    public partial class Form1 : Form
    {
        Operacion op;
        Hashtable operaciones = new Hashtable();
        int min = 0;
        int seg = 0;
        string crono;
        public Form1()
        {
            InitializeComponent();
            radioButton1.Tag = "+";
            radioButton2.Tag = "-";
            radioButton3.Tag = "*";
            radioButton4.Tag = "/";

            operaciones.Add("+", new Operacion((num1,num2)=> { return num1 + num2; }));
            operaciones.Add("-", new Operacion((num1, num2) => { return num1 - num2; }));
            operaciones.Add("*", new Operacion((num1, num2) => { return num1 * num2; }));
            operaciones.Add("/", new Operacion((num1, num2) => {
                if (num2 != 0)
                {
                    return num1 / num2;
                }
                else
                {
                    MessageBox.Show("Dividiendo entre 0 ¿eh?", "Error", MessageBoxButtons.OK);

                    return 0;
                }
            }));

            op = (Operacion)operaciones["+"];
            /*Thread t = new Thread(MiTimer);
            t.IsBackground = true;
            t.Start();*/
            this.Text = "Nah, no me salio lo que queria hacer aqui";
        }

        public void MiTimer()
        {
            Thread.Sleep(1000);
            Form1 f = new Form1();
            seg++;
            if(seg == 60)
            {
                min++;
                seg = 0;
            }
            String minFormato = min.ToString("D2");
            String segFormato = seg.ToString("D2");
            crono = String.Format("{0}:{1}", minFormato, segFormato);
            //Form1_ChangeUICues(this, new UICuesEventArgs(new UICues()));
            
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
            string operador = ((RadioButton)sender).Tag + "";
            label1.Text = operador;

            op = (Operacion)operaciones[operador];
        }

        private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=_ezIkdD8fVM");
        }
        

        /* private void Form1_ChangeUICues(object sender, UICuesEventArgs e)
         {
             this.Text = crono;
         }*/
    }
}
