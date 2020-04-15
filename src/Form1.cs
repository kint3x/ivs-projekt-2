using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mathlib;

namespace src
{
    public partial class Form1 : Form
    {
        private int sucet = 0;
        private int nasobenie = 0;
        private int delenie = 0;
        private int rozdiel = 0;
        private int enter = 0;
        private int bodka = 0;
        private int mocnina = 0;
        private int faktorial = 0;
        private int odmocnina = 0;
        private int sinus = 0;
        
        private double a;
        private double b;
        
        public Form1()
        {
            InitializeComponent();
        }

        public void btn_1_Click(object sender, EventArgs e)
        {
            if (faktorial == 1)
            {
                display.Text = display.Text;
            }
            else
            {
                if (display.Text == "0" || enter == 1)
                {
                    display.Clear();
                    enter = 0;
                    bodka = 0;
                }

                display.Text = display.Text + "1";
            }
        }

        public void btn_7_Click(object sender, EventArgs e)
        {
            if (faktorial == 1)
            {
                display.Text = display.Text;
            }
            else
            {
                if (display.Text == "0" || enter == 1)
                {
                    display.Clear();
                    enter = 0;
                    bodka = 0;
                }

                display.Text = display.Text + "7";
            }
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void btn_del_Click(object sender, EventArgs e)
        {
            if (display.Text == "Sin " || display.Text == "√")
            {
                display.Text = "0";
                sinus = 0;
                odmocnina = 0;
            }
            else if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ") || display.Text.EndsWith("^")  || display.Text.EndsWith("!"))
            {
                display.Text = display.Text.Remove(display.Text.Length - 1);
                sucet = 0;
                nasobenie = 0;
                delenie = 0;
                rozdiel = 0;
                mocnina = 0;
                faktorial = 0;
            }
            else if (display.Text.EndsWith(","))
            {
                display.Text = display.Text.Remove(display.Text.Length - 1);
                bodka = 0;
            }
            else if (display.Text == "0" || display.Text.Length == 1 )
            {
                display.Text ="0";
            }
            else
            {
                display.Text = display.Text.Remove(display.Text.Length - 1);
            }
        }

        public void btn_pow_Click(object sender, EventArgs e)
        {
            if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ") || display.Text.EndsWith("^") || display.Text.EndsWith("√"))
            {
                display.Text = display.Text;
            }
            else
            {
                if (sucet == 1)
                {
                    string vymazat = Convert.ToString(a) + "+";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    sucet = 0;
                    display.Text = Convert.ToString(math.Sucet(a, b));
                }
                else if (rozdiel == 1)
                {
                    string vymazat = Convert.ToString(a) + "-";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    rozdiel = 0;
                    display.Text = Convert.ToString(math.Rozdiel(a, b));
                }
                else if (nasobenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "*";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    nasobenie = 0;
                    display.Text = Convert.ToString(math.Nasobenie(a, b));
                }
                else if (delenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "/";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    delenie = 0;
                    display.Text = Convert.ToString(math.Delenie(a, b));
                }
                else if (mocnina == 1)
                {
                    string vymazat = Convert.ToString(a) + "^";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    mocnina = 0;
                    display.Text = Convert.ToString(math.Mocnina(a, b));
                }
                else if (faktorial == 1)
                {
                    faktorial = 0;
                    display.Text = Convert.ToString(math.Faktorial(a));
                }
                else if (odmocnina == 1)
                {
                    odmocnina = 0;
                    a = Convert.ToDouble(display.Text.Replace("√", ""));
                    display.Text = Convert.ToString(math.findSqrt(a));
                }
                else if (sinus == 1)
                {
                    sinus = 0;
                    a = Convert.ToDouble(display.Text.Replace("Sin ", ""));
                    display.Text = Convert.ToString(math.Sinus(a, 0.000000001));
                }

                a = Convert.ToDouble(display.Text);
                mocnina = 1;
                display.Text = display.Text + "^";
                enter = 0;
                bodka = 0;

            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        public void display_TextChanged(object sender, EventArgs e)
        {

        }

        public void btn_8_Click(object sender, EventArgs e)
        {
            if (faktorial == 1)
            {
                display.Text = display.Text;
            }
            else
            {
                if (display.Text == "0" || enter == 1)
                {
                    display.Clear();
                    enter = 0;
                    bodka = 0;
                }

                display.Text = display.Text + "8";
            }
        }

        public void btn_0_Click(object sender, EventArgs e)
        {
            if (faktorial == 1)
            {
                display.Text = display.Text;
            }
            else
            {
                if (display.Text == "0" || enter == 1)
                {
                    display.Clear();
                    enter = 0;
                    bodka = 0;
                }

                display.Text = display.Text + "0";
            }
        }

        public void btn_dot_Click(object sender, EventArgs e)
        {
            if (faktorial == 1)
            {
                display.Text = display.Text;
            }   
            else
            { 
                bodka = bodka + 1;
                if (bodka > 1)
                {
                    display.Text = display.Text;
                }
                else
                {
                    if (display.Text == "0" || enter == 1)
                    {
                        display.Text = "0,";
                        enter = 0;
                        bodka = 1;
                    }
                    else if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ") || display.Text.EndsWith("^") || display.Text.EndsWith("√"))
                    {
                        display.Text = display.Text + "0,";
                    }
                    else
                    {
                        display.Text = display.Text + ",";
                    }
                }
            }
        }

        public void btn_3_Click(object sender, EventArgs e)
        {
            if (faktorial == 1)
            {
                display.Text = display.Text;
            }
            else
            {
                if (display.Text == "0" || enter == 1)
                {
                    display.Clear();
                    enter = 0;
                    bodka = 0;
                }

                display.Text = display.Text + "3";
            }
        }

        public void btn_2_Click(object sender, EventArgs e)
        {
            if (faktorial == 1)
            {
                display.Text = display.Text;
            }
            else
            {
                if (display.Text == "0" || enter == 1)
                {
                    display.Clear();
                    enter = 0;
                    bodka = 0;
                }

                display.Text = display.Text + "2";
            }
        }

        public void btn_6_Click(object sender, EventArgs e)
        {
            if (faktorial == 1)
            {
                display.Text = display.Text;
            }
            else
            {
                if (display.Text == "0" || enter == 1)
                {
                    display.Clear();
                    enter = 0;
                    bodka = 0;
                }

                display.Text = display.Text + "6";
            }
        }

        public void btn_5_Click(object sender, EventArgs e)
        {
            if (faktorial == 1)
            {
                display.Text = display.Text;
            }
            else
            {
                if (display.Text == "0" || enter == 1)
                {
                    display.Clear();
                    enter = 0;
                    bodka = 0;
                }

                display.Text = display.Text + "5";
            }
        }

        public void btn_4_Click(object sender, EventArgs e)
        {
            if (faktorial == 1)
            {
                display.Text = display.Text;
            }
            else
            {
                if (display.Text == "0" || enter == 1)
                {
                    display.Clear();
                    enter = 0;
                    bodka = 0;
                }

                display.Text = display.Text + "4";
            }
        }

        public void btn_9_Click(object sender, EventArgs e)
        {
            if (faktorial == 1)
            {
                display.Text = display.Text;
            }
            else
            {
                if (display.Text == "0" || enter == 1)
                {
                    display.Clear();
                    enter = 0;
                    bodka = 0;
                }

                display.Text = display.Text + "9";
            }
        }

        public void btn_ac_Click(object sender, EventArgs e)
        {
            display.Clear();
            display.Text = "0";
            sucet = 0;
            nasobenie = 0;
            delenie = 0;
            rozdiel = 0;
            enter = 0;
            bodka = 0;
            mocnina = 0;
            faktorial = 0;
            odmocnina = 0;
            sinus = 0;
    }

        public void btn_add_Click(object sender, EventArgs e)
        {
            if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ")|| display.Text.EndsWith("^") || display.Text.EndsWith("√"))
            {
                display.Text = display.Text;
            }
            else
            {
                if (sucet == 1)
                {
                    string vymazat = Convert.ToString(a) + "+";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    sucet = 0;
                    display.Text = Convert.ToString(math.Sucet(a, b));
                }
                else if (rozdiel == 1)
                {
                    string vymazat = Convert.ToString(a) + "-";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    rozdiel = 0;
                    display.Text = Convert.ToString(math.Rozdiel(a, b));
                }
                else if (nasobenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "*";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    nasobenie = 0;
                    display.Text = Convert.ToString(math.Nasobenie(a, b));
                }
                else if (delenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "/";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    delenie = 0;
                    display.Text = Convert.ToString(math.Delenie(a, b));
                }
                else if (mocnina == 1)
                {
                    string vymazat = Convert.ToString(a) + "^";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    mocnina = 0;
                    display.Text = Convert.ToString(math.Mocnina(a, b));
                }
                else if (faktorial == 1)
                {
                    faktorial = 0;
                    display.Text = Convert.ToString(math.Faktorial(a));
                }
                else if (odmocnina == 1)
                {
                    odmocnina = 0;
                    a = Convert.ToDouble(display.Text.Replace("√", ""));
                    display.Text = Convert.ToString(math.findSqrt(a));
                }
                else if (sinus == 1)
                {
                    sinus = 0;
                    a = Convert.ToDouble(display.Text.Replace("Sin ", ""));
                    display.Text = Convert.ToString(math.Sinus(a, 0.000000001));
                }

                a = Convert.ToDouble(display.Text);
                sucet = 1;
                display.Text = display.Text + "+";
                enter = 0;
                bodka = 0;

            }
        }

        public void btn_sub_Click(object sender, EventArgs e)
        {
            if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ")|| display.Text.EndsWith("^") || display.Text.EndsWith("√"))
            {
                display.Text = display.Text;
            }
            else
            {
                if (sucet == 1)
                {
                    string vymazat = Convert.ToString(a) + "+";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    sucet = 0;
                    display.Text = Convert.ToString(math.Sucet(a, b));
                }
                else if (rozdiel == 1)
                {
                    string vymazat = Convert.ToString(a) + "-";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    rozdiel = 0;
                    display.Text = Convert.ToString(math.Rozdiel(a, b));
                }
                else if (nasobenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "*";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    nasobenie = 0;
                    display.Text = Convert.ToString(math.Nasobenie(a, b));
                }
                else if (delenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "/";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    delenie = 0;
                    display.Text = Convert.ToString(math.Delenie(a, b));
                }
                else if (mocnina == 1)
                {
                    string vymazat = Convert.ToString(a) + "^";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    mocnina = 0;
                    display.Text = Convert.ToString(math.Mocnina(a, b));
                }
                else if (faktorial == 1)
                {
                    faktorial = 0;
                    display.Text = Convert.ToString(math.Faktorial(a));
                }
                else if (odmocnina == 1)
                {
                    odmocnina = 0;
                    a = Convert.ToDouble(display.Text.Replace("√", ""));
                    display.Text = Convert.ToString(math.findSqrt(a));
                }
                else if (sinus == 1)
                {
                    sinus = 0;
                    a = Convert.ToDouble(display.Text.Replace("Sin ", ""));
                    display.Text = Convert.ToString(math.Sinus(a, 0.000000001));
                }

                a = Convert.ToDouble(display.Text);
                rozdiel = 1;
                display.Text = display.Text + "-";
                enter = 0;
                bodka = 0;

            }
        }

        public void btn_div_Click(object sender, EventArgs e)
        {
            if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ")|| display.Text.EndsWith("^") || display.Text.EndsWith("√"))
            {
                display.Text = display.Text;
            }
            else
            {
                if (sucet == 1)
                {
                    string vymazat = Convert.ToString(a) + "+";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    sucet = 0;
                    display.Text = Convert.ToString(math.Sucet(a, b));
                }
                else if (rozdiel == 1)
                {
                    string vymazat = Convert.ToString(a) + "-";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    rozdiel = 0;
                    display.Text = Convert.ToString(math.Rozdiel(a, b));
                }
                else if (nasobenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "*";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    nasobenie = 0;
                    display.Text = Convert.ToString(math.Nasobenie(a, b));
                }
                else if (delenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "/";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    delenie = 0;
                    display.Text = Convert.ToString(math.Delenie(a, b));
                }
                else if (mocnina == 1)
                {
                    string vymazat = Convert.ToString(a) + "^";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    mocnina = 0;
                    display.Text = Convert.ToString(math.Mocnina(a, b));
                }
                else if (faktorial == 1)
                {
                    faktorial = 0;
                    display.Text = Convert.ToString(math.Faktorial(a));
                }
                else if (odmocnina == 1)
                {
                    odmocnina = 0;
                    a = Convert.ToDouble(display.Text.Replace("√", ""));
                    display.Text = Convert.ToString(math.findSqrt(a));
                }
                else if (sinus == 1)
                {
                    sinus = 0;
                    a = Convert.ToDouble(display.Text.Replace("Sin ", ""));
                    display.Text = Convert.ToString(math.Sinus(a, 0.000000001));
                }

                a = Convert.ToDouble(display.Text);
                nasobenie = 1;
                display.Text = display.Text + "/";
                enter = 0;
                bodka = 0;

            }
        }

        public void btn_mul_Click(object sender, EventArgs e)
        {
            if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ")|| display.Text.EndsWith("^") || display.Text.EndsWith("√"))
            {
                display.Text = display.Text;
            }
            else
            {
                if (sucet == 1)
                {
                    string vymazat = Convert.ToString(a) + "+";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    sucet = 0;
                    display.Text = Convert.ToString(math.Sucet(a, b));
                }
                else if (rozdiel == 1)
                {
                    string vymazat = Convert.ToString(a) + "-";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    rozdiel = 0;
                    display.Text = Convert.ToString(math.Rozdiel(a, b));
                }
                else if (nasobenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "*";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    nasobenie = 0;
                    display.Text = Convert.ToString(math.Nasobenie(a, b));
                }
                else if (delenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "/";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    delenie = 0;
                    display.Text = Convert.ToString(math.Delenie(a, b));
                }
                else if (mocnina == 1)
                {
                    string vymazat = Convert.ToString(a) + "^";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    mocnina = 0;
                    display.Text = Convert.ToString(math.Mocnina(a, b));
                }
                else if (faktorial == 1)
                {
                    faktorial = 0;
                    display.Text = Convert.ToString(math.Faktorial(a));
                }
                else if (odmocnina == 1)
                {
                    odmocnina = 0;
                    a = Convert.ToDouble(display.Text.Replace("√", ""));
                    display.Text = Convert.ToString(math.findSqrt(a));
                }
                else if (sinus == 1)
                {
                    sinus = 0;
                    a = Convert.ToDouble(display.Text.Replace("Sin ", ""));
                    display.Text = Convert.ToString(math.Sinus(a, 0.000000001));
                }

                a = Convert.ToDouble(display.Text);
                nasobenie = 1;
                display.Text = display.Text + "*";
                enter = 0;
                bodka = 0;

            }

        }

        public void btn_fact_Click(object sender, EventArgs e)
        {
            if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ") || display.Text.EndsWith("^") || display.Text.EndsWith("√"))
            {
                display.Text = display.Text;
            }
            else
            {
                if (sucet == 1)
                {
                    string vymazat = Convert.ToString(a) + "+";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    sucet = 0;
                    display.Text = Convert.ToString(math.Sucet(a, b));
                }
                else if (rozdiel == 1)
                {
                    string vymazat = Convert.ToString(a) + "-";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    rozdiel = 0;
                    display.Text = Convert.ToString(math.Rozdiel(a, b));
                }
                else if (nasobenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "*";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    nasobenie = 0;
                    display.Text = Convert.ToString(math.Nasobenie(a, b));
                }
                else if (delenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "/";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    delenie = 0;
                    display.Text = Convert.ToString(math.Delenie(a, b));
                }
                else if (mocnina == 1)
                {
                    string vymazat = Convert.ToString(a) + "^";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    mocnina = 0;
                    display.Text = Convert.ToString(math.Mocnina(a, b));
                }
                else if (faktorial == 1)
                {
                    faktorial = 0;
                    display.Text = Convert.ToString(math.Faktorial(a));
                }
                else if (odmocnina == 1)
                {
                    odmocnina = 0;
                    a = Convert.ToDouble(display.Text.Replace("√", ""));
                    display.Text = Convert.ToString(math.findSqrt(a));
                }
                else if (sinus == 1)
                {
                    sinus = 0;
                    a = Convert.ToDouble(display.Text.Replace("Sin ", ""));
                    display.Text = Convert.ToString(math.Sinus(a, 0.000000001));
                }

                a = Convert.ToDouble(display.Text);
                faktorial = 1;
                display.Text = display.Text + "!";
                enter = 0;
            }
        }

        public void btn_sin_Click(object sender, EventArgs e)
        {
            if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ") || display.Text.EndsWith("^") || display.Text.EndsWith("√"))
            {
                display.Text = display.Text;
            }
            else
            {
                if (sucet == 1)
                {
                    string vymazat = Convert.ToString(a) + "+";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    sucet = 0;
                    sinus = 1;
                    display.Text = Convert.ToString(math.Sucet(a, b));
                    display.Text = "Sin " + display.Text;
                }
                else if (rozdiel == 1)
                {
                    string vymazat = Convert.ToString(a) + "-";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    rozdiel = 0;
                    sinus = 1;
                    display.Text = Convert.ToString(math.Rozdiel(a, b));
                    display.Text = "Sin " + display.Text;
                }
                else if (nasobenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "*";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    nasobenie = 0;
                    sinus = 1;
                    display.Text = Convert.ToString(math.Nasobenie(a, b));
                    display.Text = "Sin " + display.Text;
                }
                else if (delenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "/";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    delenie = 0;
                    sinus = 1;
                    display.Text = Convert.ToString(math.Delenie(a, b));
                    display.Text = "Sin " + display.Text;
                }
                else if (mocnina == 1)
                {
                    string vymazat = Convert.ToString(a) + "^";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    mocnina = 0;
                    sinus = 1;
                    display.Text = Convert.ToString(math.Mocnina(a, b));
                    display.Text = "Sin " + display.Text;
                }
                else if (faktorial == 1)
                {
                    faktorial = 0;
                    sinus = 1;
                    display.Text = Convert.ToString(math.Faktorial(a));
                    display.Text = "Sin " + display.Text;
                }
                else if (odmocnina == 1)
                {
                    odmocnina = 0;
                    sinus = 1;
                    a = Convert.ToDouble(display.Text.Replace("√", ""));
                    display.Text = Convert.ToString(math.findSqrt(a));
                    display.Text = "Sin " + display.Text;
                }
                else if (sinus == 1)
                {
                    a = Convert.ToDouble(display.Text.Replace("Sin ", ""));
                    display.Text = Convert.ToString(math.Sinus(a, 0.000000001));
                    display.Text = "Sin " + display.Text;
                }
                else
                {
                    if (display.Text == "0")
                    {
                        display.Text = "Sin ";
                    }
                    else
                    {
                        display.Text = "Sin " + display.Text;
                    }
                    sinus = 1;
                    enter = 0;
                }
            }
        }
        
        public void btn_enter_Click(object sender, EventArgs e)
        {
            if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ") || display.Text.EndsWith("^") || display.Text.EndsWith("√"))
            {
                display.Clear();
                display.Text = "0";
                sucet = 0;
                nasobenie = 0;
                delenie = 0;
                rozdiel = 0;
                enter = 0;
                bodka = 0;
                mocnina = 0;
                faktorial = 0;
                odmocnina = 0;
                sinus = 0;
            }
            else
            {
                if (sucet == 1)
                {
                    string vymazat = Convert.ToString(a) + "+";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    sucet = 0;
                    display.Text = Convert.ToString(math.Sucet(a, b));
                }
                else if (rozdiel == 1)
                {
                    string vymazat = Convert.ToString(a) + "-";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    rozdiel = 0;
                    display.Text = Convert.ToString(math.Rozdiel(a, b));
                }
                else if (nasobenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "*";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    nasobenie = 0;
                    display.Text = Convert.ToString(math.Nasobenie(a, b));
                }
                else if (delenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "/";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    delenie = 0;
                    display.Text = Convert.ToString(math.Delenie(a, b));
                }
                else if (mocnina == 1)
                {
                    string vymazat = Convert.ToString(a) + "^";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    mocnina = 0;
                    display.Text = Convert.ToString(math.Mocnina(a, b));
                }
                else if (faktorial == 1)
                {
                    faktorial = 0;
                    display.Text = Convert.ToString(math.Faktorial(a));
                }
                else if (odmocnina == 1)
                {
                    odmocnina = 0;
                    a = Convert.ToDouble(display.Text.Replace("√", ""));
                    display.Text = Convert.ToString(math.findSqrt(a));
                }
                else if (sinus == 1)
                {
                    sinus = 0;
                    a = Convert.ToDouble(display.Text.Replace("Sin ", ""));
                    display.Text = Convert.ToString(math.Sinus(a, 0.000000001));
                }
                enter = 1;
            }
        }

        private void btn_sqrt_Click(object sender, EventArgs e)
        {
            if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ") || display.Text.EndsWith("^") || display.Text.EndsWith("√"))
            {
                display.Text = display.Text;
            }
            else
            {
                if (sucet == 1)
                {
                    string vymazat = Convert.ToString(a) + "+";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    sucet = 0;
                    odmocnina = 1;
                    display.Text = Convert.ToString(math.Sucet(a, b));
                    display.Text = "√" + display.Text;
                }
                else if (rozdiel == 1)
                {
                    string vymazat = Convert.ToString(a) + "-";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    rozdiel = 0;
                    odmocnina = 1;
                    display.Text = Convert.ToString(math.Rozdiel(a, b));
                    display.Text = "√" + display.Text;
                }
                else if (nasobenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "*";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    nasobenie = 0;
                    odmocnina = 1;
                    display.Text = Convert.ToString(math.Nasobenie(a, b));
                    display.Text = "√" + display.Text;
                }
                else if (delenie == 1)
                {
                    string vymazat = Convert.ToString(a) + "/";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    delenie = 0;
                    odmocnina = 1;
                    display.Text = Convert.ToString(math.Delenie(a, b));
                    display.Text = "√" + display.Text;
                }
                else if (mocnina == 1)
                {
                    string vymazat = Convert.ToString(a) + "^";
                    b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    mocnina = 0;
                    odmocnina = 1;
                    display.Text = Convert.ToString(math.Mocnina(a, b));
                    display.Text = "√" + display.Text;
                }
                else if (faktorial == 1)
                {
                    faktorial = 0;
                    odmocnina = 1;
                    display.Text = Convert.ToString(math.Faktorial(a));
                    display.Text = "√" + display.Text;
                }
                else if (odmocnina == 1)
                {
                    a = Convert.ToDouble(display.Text.Replace("√", ""));
                    display.Text = Convert.ToString(math.findSqrt(a));
                    display.Text = "√" + display.Text;
                }
                else if (sinus == 1)
                {
                    sinus = 0;
                    odmocnina = 1;
                    a = Convert.ToDouble(display.Text.Replace("Sin ", ""));
                    display.Text = Convert.ToString(math.Sinus(a, 0.000000001));
                    display.Text = "√" + display.Text;
                }
                else
                {
                    if (display.Text == "0")
                    {
                        display.Text = "√";
                    }
                    else
                    {
                        display.Text = "√" + display.Text;
                    }
                    odmocnina = 1;
                    enter = 0;
                }
            }
        }
    }
}
