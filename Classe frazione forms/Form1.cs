using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classe_frazione_forms
{
    
    public partial class Form1 : Form
    {
        class frazione
        {
            protected double numeratore;
            protected double denominatore;
            public double Numeratore
            {
                get => numeratore;
                set => numeratore = value;
            }
            public double Denominatore
            {
                get => denominatore;
                set => denominatore = value;
            }

            private double MCD(double a, double b)
            {
                while (b != 0)
                {
                    double temp = b;
                    b = a % b;
                    a = temp;
                }
                return a;
            }

            public string semplificafrazione()
            {
                double mcd = MCD(numeratore, denominatore);
                numeratore /= mcd;
                denominatore /= mcd;
                string result = $"{numeratore}/{denominatore}";
                return result;

            }
            public double somma()
            {
                return numeratore + denominatore;
            }
            public double sottrai()
            {
                return numeratore - denominatore;
            }
            public double moltiplica()
            {
                return numeratore * denominatore;
            }
            public double dividi()
            {
                return numeratore / denominatore;
            }
        }
        class derivata : frazione
        {
            private double esponente;
            private double numerodecimale;
            public double Esponente
            {
                get => esponente;
                set => esponente = value;
            }
            public double Numerodecimale
            {
                get => numerodecimale;
                set => numerodecimale = value;
            }
            public double rappresentazionedecimale()
            {
                return numeratore / denominatore;
            }
            public string conversionedecimalefrazione()
            {
                int precisioneMassima = 1000000;

                double numeratore = numerodecimale;
                double denominatore = 1;

                for (int i = 1; i < precisioneMassima; i++)
                {
                    if (Math.Abs(Math.Round(numeratore) - numeratore) < 0)
                        break;

                    numeratore *= 10;
                    denominatore *= 10;
                }

                return numeratore.ToString()+"/"+denominatore.ToString();

            }
            public string calcolaesponente()
            {
                double newnum = Math.Pow(numeratore, esponente);
                double newden = Math.Pow(denominatore, esponente);
                return newnum.ToString() + "/" + newden.ToString();                
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void D_Click(object sender, EventArgs e)
        {
            frazione semplif = new frazione();
            semplif.Numeratore = double.Parse(textBox1.Text);
            semplif.Denominatore = double.Parse(textBox2.Text);
            Ris.Text = semplif.semplificafrazione();
        }

        private void Somma_Click(object sender, EventArgs e)
        {
            frazione semplif = new frazione();
            semplif.Numeratore = double.Parse(textBox1.Text);
            semplif.Denominatore = double.Parse(textBox2.Text);
            Ris.Text = semplif.somma().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frazione semplif = new frazione();
            semplif.Numeratore = double.Parse(textBox1.Text);
            semplif.Denominatore = double.Parse(textBox2.Text);
            Ris.Text = semplif.sottrai().ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frazione semplif = new frazione();
            semplif.Numeratore = double.Parse(textBox1.Text);
            semplif.Denominatore = double.Parse(textBox2.Text);
            Ris.Text = semplif.moltiplica().ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            frazione semplif = new frazione();
            semplif.Numeratore = double.Parse(textBox1.Text);
            semplif.Denominatore = double.Parse(textBox2.Text);
            Ris.Text = semplif.dividi().ToString();
        }

        private void rappdeci_Click(object sender, EventArgs e)
        {
            derivata semplif = new derivata();
            semplif.Numeratore = double.Parse(textBox1.Text);
            semplif.Denominatore = double.Parse(textBox2.Text);
            Ris.Text = semplif.rappresentazionedecimale().ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            derivata semplif = new derivata();
            semplif.Numerodecimale = double.Parse(textBox3.Text);
            Ris.Text = semplif.conversionedecimalefrazione();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            derivata semplif = new derivata();
            semplif.Numeratore = double.Parse(textBox1.Text);
            semplif.Denominatore = double.Parse(textBox2.Text);
            semplif.Esponente = double.Parse(textBox4.Text);
            Ris.Text = semplif.calcolaesponente();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
