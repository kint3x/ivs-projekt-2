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
        private int pomocna = 0;

        private int exception_stav;

        private double a;
        private double b;
        
        public Form1()
        {
            InitializeComponent();
        }

        public void btn_0_Click(object sender, EventArgs e)
        {
            op_btn("0");
        }
        public void btn_1_Click(object sender, EventArgs e)
        {
            op_btn("1");
        }

        public void btn_2_Click(object sender, EventArgs e)
        {
            op_btn("2");
        }

        public void btn_3_Click(object sender, EventArgs e)
        {
            op_btn("3");
        }

        public void btn_4_Click(object sender, EventArgs e)
        {
            op_btn("4");
        }

        public void btn_5_Click(object sender, EventArgs e)
        {
            op_btn("5");
        }

        public void btn_6_Click(object sender, EventArgs e)
        {
            op_btn("6");
        }

        public void btn_7_Click(object sender, EventArgs e)
        {
            op_btn("7");
        }

        public void btn_8_Click(object sender, EventArgs e)
        {
            op_btn("8");
        }

        public void btn_9_Click(object sender, EventArgs e)
        {
            op_btn("9");
        }

        public void btn_dot_Click(object sender, EventArgs e)
        {
            Is_exception();
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

        public void btn_del_Click(object sender, EventArgs e)
        {
            Is_exception();
            if (display.Text == "Sin " || display.Text == "√")
            {
                display.Text = "0";
                sinus = 0;
                odmocnina = 0;
            }
            else if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ") || display.Text.EndsWith("^") || display.Text.EndsWith("!"))
            {

                if (display.Text.EndsWith("-") && pomocna == 1)
                {
                    display.Text = display.Text.Remove(display.Text.Length - 1);
                    pomocna = 0;
                }
                else
                {
                    display.Text = display.Text.Remove(display.Text.Length - 1);
                    sucet = 0;
                    nasobenie = 0;
                    delenie = 0;
                    rozdiel = 0;
                    mocnina = 0;
                    faktorial = 0;
                }
            }
            else if (display.Text.EndsWith(","))
            {
                display.Text = display.Text.Remove(display.Text.Length - 1);
                bodka = 0;
            }
            else if (display.Text == "0" || display.Text.Length == 1)
            {
                display.Text = "0";
            }
            else
            {
                display.Text = display.Text.Remove(display.Text.Length - 1);
            }
        }

        public void btn_pow_Click(object sender, EventArgs e)
        {
            Is_exception();
            if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ") || display.Text.EndsWith("^") || display.Text.EndsWith("√"))
            {
                display.Text = display.Text;
            }
            else
            {
                podmienky();
                mocnina = 1;
                if_bodka();
                display.Text = display.Text + "^";
                nulovanie();
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
        }

        public void display_TextChanged(object sender, EventArgs e)
        {
        }

        public void btn_ac_Click(object sender, EventArgs e)
        {
            Is_exception();
            nas_nula();
            pomocna = 0;
        }

        public void btn_add_Click(object sender, EventArgs e)
        {
            Is_exception();
            if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ")|| display.Text.EndsWith("^") || display.Text.EndsWith("√"))
            {
                display.Text = display.Text;
            }
            else
            {
                podmienky();                
                sucet = 1;
                if_bodka();               
                display.Text = display.Text + "+";
                nulovanie();
            }
        }

        public void btn_sub_Click(object sender, EventArgs e)
        {
            Is_exception();
            if ( display.Text.EndsWith("√"))
            {
                display.Text = display.Text;
            }
            else
            {
                if (sucet == 1)
                {
                    if (display.Text.EndsWith("+") || display.Text.EndsWith("-"))
                    {
                        if (pomocna == 0)
                        {
                            display.Text = display.Text + "-";
                            pomocna = 1;
                        }
                        else
                        {
                            display.Text = display.Text;
                        }
                    }
                    else
                    {
                        string vymazat = Convert.ToString(a) + "+";
                        b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                        sucet = 0;
                        pomocna = 0;
                        display.Text = Convert.ToString(math.Sucet(a, b));
                    }
                }
                else if (rozdiel == 1)
                {
                    if (display.Text.EndsWith("-") )
                    {
                        if (pomocna == 0)
                        {
                            display.Text = display.Text + "-";
                            pomocna = 1;
                        }
                        else 
                        {
                            display.Text = display.Text;
                        }
                    }
                    else
                    {
                        string vymazat = Convert.ToString(a) + "-";
                        b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                        pomocna = 0;
                        rozdiel = 0;
                        display.Text = Convert.ToString(math.Rozdiel(a, b));
                    }
                }
                else if (nasobenie == 1)
                {
                        if (display.Text.EndsWith("*") || display.Text.EndsWith("-"))
                        {
                            if (pomocna == 0)
                            {
                                display.Text = display.Text + "-";
                                pomocna = 1;
                            }
                            else
                            {
                                display.Text = display.Text;
                            }
                        }
                        else
                        {
                            string vymazat = Convert.ToString(a) + "*";
                            b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                            nasobenie = 0;
                            pomocna = 0;
                            display.Text = Convert.ToString(math.Nasobenie(a, b));
                        }
                }
                else if (delenie == 1)
                {
                        if (display.Text.EndsWith("/") || display.Text.EndsWith("-"))
                        {
                            if (pomocna == 0)
                            {
                                display.Text = display.Text + "-";
                                pomocna = 1;
                            }
                            else
                            {
                                display.Text = display.Text;
                            }
                        }
                        else
                        {
                            string vymazat = Convert.ToString(a) + "/";
                            b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                            delenie = 0;
                            pomocna = 0;
                            display.Text = Convert.ToString(math.Delenie(a, b));
                        }
                }
                else if (mocnina == 1)
                {
                        if (display.Text.EndsWith("^") || display.Text.EndsWith("-"))
                        {
                            if (pomocna == 0)
                            {
                                display.Text = display.Text + "-";
                                pomocna = 1;
                            }
                            else
                            {
                                display.Text = display.Text;
                            }
                        }
                        else
                        {
                            string vymazat = Convert.ToString(a) + "^";
                            b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                            mocnina = 0;
                            pomocna = 0;
                            display.Text = Convert.ToString(math.Mocnina(a, b));
                        }
                }
                else if (faktorial == 1)
                {
                    faktorial = 0;
                    pomocna = 0;
                    display.Text = Convert.ToString(math.Faktorial(a));
                }
                else if (odmocnina == 1)
                {
                    odmocnina = 0;
                    pomocna = 0;
                    a = Convert.ToDouble(display.Text.Replace("√", ""));
                    display.Text = Convert.ToString(math.findSqrt(a));
                }
                else if (sinus == 1)
                {
                    sinus = 0;
                    pomocna = 0;
                    a = Convert.ToDouble(display.Text.Replace("Sin ", ""));
                    display.Text = Convert.ToString(math.Sinus(a, 0.000000001));
                }
                if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ") || display.Text.EndsWith("^"))
                {
                    ;
                }
                else
                {
                    a = Convert.ToDouble(display.Text);
                    rozdiel = 1;
                    if (bodka == 1)
                    {
                        if (display.Text.EndsWith(","))
                        {
                            display.Text = display.Text.Remove(display.Text.Length - 1);
                            bodka = 0;
                        }
                        else if (Convert.ToInt64(display.Text.Split(',')[1]) == 0)
                        {
                            display.Text = display.Text.Split(',')[0];
                            bodka = 0;
                        }
                    }
                    display.Text = display.Text + "-";
                    nulovanie();
                }
            }
        }

        public void btn_div_Click(object sender, EventArgs e)
        {
            Is_exception();
            if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ")|| display.Text.EndsWith("^") || display.Text.EndsWith("√"))
            {
                display.Text = display.Text;
            }
            else
            {
                podmienky();
                delenie = 1;
                if_bodka();
                display.Text = display.Text + "/";
                nulovanie();
            }
        }

        public void btn_mul_Click(object sender, EventArgs e)
        {
            Is_exception();
            if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ")|| display.Text.EndsWith("^") || display.Text.EndsWith("√"))
            {
                display.Text = display.Text;
            }
            else
            {
                podmienky();
                nasobenie = 1;
                if_bodka();
                display.Text = display.Text + "*";
                nulovanie();
            }

        }

        public void btn_fact_Click(object sender, EventArgs e)
        {
            Is_exception();
            if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ") || display.Text.EndsWith("^") || display.Text.EndsWith("√"))
            {
                display.Text = display.Text;
            }
            else
            {
                podmienky();
                faktorial = 1;
                if_bodka();
                display.Text = display.Text + "!";
                enter = 0;
            }
        }

        public void btn_sin_Click(object sender, EventArgs e)
        {
            Is_exception();
            if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ") || display.Text.EndsWith("^") || display.Text.EndsWith("√"))
            {
                display.Text = display.Text;
            }
            else
            {
                pomocna = 0;
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

        private void btn_sqrt_Click(object sender, EventArgs e)
        {
            Is_exception();
            pomocna = 0;
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

        public void btn_enter_Click(object sender, EventArgs e)
        {
            if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ") || display.Text.EndsWith("^") || display.Text.EndsWith("√"))
            {
                nas_nula();
            }
            else
            {

                if (bodka == 1)
                {
                    if (display.Text.EndsWith(","))
                    {
                        display.Text = display.Text.Remove(display.Text.Length - 1);
                        bodka = 0;
                    }
                }
                if (sucet == 1)
                {
                    if (bodka == 1 && Convert.ToInt64(((display.Text.Split('+')[1])).Split(',')[1]) == 0)
                    {
                        display.Text = ((display.Text.Split('+')[1])).Split(',')[0];
                        b = Convert.ToDouble(display.Text);
                    }
                    else
                    {
                        string vymazat = Convert.ToString(a) + "+";
                        b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    }
                    sucet = 0;
                    display.Text = Convert.ToString(math.Sucet(a, b));
                }
                else if (rozdiel == 1)
                {
                    if (pomocna == 1 && bodka == 1)
                    {
                        display.Text = display.Text.Replace("--", "-");
                    }
                    if (bodka == 1 && Convert.ToInt64(((display.Text.Split('-')[1])).Split(',')[1]) == 0)
                    {
                        display.Text = ((display.Text.Split('-')[1])).Split(',')[0];
                        b = Convert.ToDouble(display.Text);
                    }
                    else
                    {
                        string vymazat = Convert.ToString(a) + "-";
                        b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    }
                    rozdiel = 0;
                    if (pomocna == 1)
                    {
                        display.Text = Convert.ToString(math.Rozdiel(a, -b));
                    }
                    else
                    {
                        display.Text = Convert.ToString(math.Rozdiel(a, b));
                    }
                }
                else if (nasobenie == 1)
                {
                    if (bodka == 1 && Convert.ToInt64(((display.Text.Split('*')[1])).Split(',')[1]) == 0)
                    {
                        display.Text = ((display.Text.Split('*')[1])).Split(',')[0];
                        b = Convert.ToDouble(display.Text);
                    }
                    else
                    {
                        string vymazat = Convert.ToString(a) + "*";
                        b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    }
                    nasobenie = 0;
                    display.Text = Convert.ToString(math.Nasobenie(a, b));
                }
                else if (delenie == 1)
                {
                    if (bodka == 1 && Convert.ToInt64(((display.Text.Split('/')[1])).Split(',')[1]) == 0)
                    {
                        display.Text = ((display.Text.Split('/')[1])).Split(',')[0];
                        b = Convert.ToDouble(display.Text);
                    }
                    else
                    {
                        string vymazat = Convert.ToString(a) + "/";
                        b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    }
                    delenie = 0;
                    try
                    {
                        display.Text = Convert.ToString(math.Delenie(a, b));
                    }
                    catch (InvalidOperationException exception)
                    {
                        exception_stav = 1;
                        Is_exception(exception.Message);
                    }
                }
                else if (mocnina == 1)
                {
                    if (bodka == 1 && Convert.ToInt64(((display.Text.Split('^')[1])).Split(',')[1]) == 0)
                    {
                        display.Text = ((display.Text.Split('^')[1])).Split(',')[0];
                        b = Convert.ToDouble(display.Text);
                    }
                    else
                    {
                        string vymazat = Convert.ToString(a) + "^";
                        b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    }
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
                nulovanie();
                pomocna = 0;
            }
        }


        // Funkcia ma tri stavy , ak je exception_stav 1, znamena to, ze exception bola vyhodena a treba ju vypisat a nastavit na 2
        // ak je exception_stav 2, tak bola vypisana a treba ju schovat vypisanim 0 a nastavit na 3 
        // ak je exception_stav 3, tak nic nerobi
        void Is_exception(string exception = "")
        {
            if (exception_stav == 1)
            {
                display.ForeColor = System.Drawing.Color.Red;
                display.Text = exception;

                exception_stav = 2;
            }
            else if (exception_stav == 2)
            {
                display.ForeColor = System.Drawing.Color.Black;
                display.Text = "0";
                exception_stav = 3;
            }
        }
       
       /////////////////////////////////////////////////////////////////////////////////////////////////////////////
       
        void podmienky()
        {
            if (sucet == 1)
            {
                string vymazat = Convert.ToString(a) + "+";
                b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                sucet = 0;
                pomocna = 0;
                display.Text = Convert.ToString(math.Sucet(a, b));
            }
            else if (rozdiel == 1)
            {
                string vymazat = Convert.ToString(a) + "-";
                b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                rozdiel = 0;
                pomocna = 0;
                display.Text = Convert.ToString(math.Rozdiel(a, b));
            }
            else if (nasobenie == 1)
            {
                string vymazat = Convert.ToString(a) + "*";
                b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                nasobenie = 0;
                pomocna = 0;
                display.Text = Convert.ToString(math.Nasobenie(a, b));
            }
            else if (delenie == 1)
            {
                string vymazat = Convert.ToString(a) + "/";
                b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                delenie = 0;
                pomocna = 0;
                display.Text = Convert.ToString(math.Delenie(a, b));
            }
            else if (mocnina == 1)
            {
                string vymazat = Convert.ToString(a) + "^";
                b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                mocnina = 0;
                pomocna = 0;
                display.Text = Convert.ToString(math.Mocnina(a, b));
            }
            else if (faktorial == 1)
            {
                faktorial = 0;
                pomocna = 0;
                display.Text = Convert.ToString(math.Faktorial(a));
            }
            else if (odmocnina == 1)
            {
                odmocnina = 0;
                pomocna = 0;
                a = Convert.ToDouble(display.Text.Replace("√", ""));
                display.Text = Convert.ToString(math.findSqrt(a));
            }
            else if (sinus == 1)
            {
                sinus = 0;
                pomocna = 0;
                a = Convert.ToDouble(display.Text.Replace("Sin ", ""));
                display.Text = Convert.ToString(math.Sinus(a));
            }
            a = Convert.ToDouble(display.Text);
        }

        /////////////////////////////////////////////////////////

        void if_bodka()
        {
            if (bodka == 1)
            {
                if (display.Text.EndsWith(","))
                {
                    display.Text = display.Text.Remove(display.Text.Length - 1);

                }
                else if (Convert.ToInt64(display.Text.Split(',')[1]) == 0)
                {
                    display.Text = display.Text.Split(',')[0];

                }
            }
        }

        ////////////////////////////////////

        void nulovanie()
        {
            enter = 0;
            bodka = 0;
        }

        ///////////////////////////////////

        void nas_nula()
        {
            display.Text = "0";
            sucet = 0;
            nasobenie = 0;
            delenie = 0;
            rozdiel = 0;
            mocnina = 0;
            faktorial = 0;
            odmocnina = 0;
            sinus = 0;
            nulovanie();
        }
        
        ///////////////////////////////
        
        void op_btn(string but)
        {
            Is_exception();
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
                }
                display.Text = display.Text + but;
            }
        }
    }
}
