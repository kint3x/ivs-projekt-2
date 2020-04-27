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

/**
 * \namespace src
 * \brief V namespace sa nachádza kód pre GUI kalkulačky
 */

namespace src
{
    /*! \class Form1
    \brief Trieda v ktorej sú všetky metódy ktoré riadia GUI
	*/
    public partial class Form1 : Form
    {
        private int sucet = 0; //!< Príznak pre súčet
        private int nasobenie = 0;//!< Príznak pre násobenie
        private int delenie = 0;//!< Príznak pre delenie
        private int rozdiel = 0;//!< Príznak pre rozdiel
        private int enter = 0;//!< Príznak pre enter
        private int bodka = 0;//!< Príznak pre bodku
        private int mocnina = 0;//!< Príznak pre mocninu
        private int faktorial = 0;//!< Príznak pre faktorial
        private int odmocnina = 0;//!< Príznak pre odmocninu
        private int sinus = 0;//!< Príznak pre sinus
        private int pomocna = 0;//!< Príznak pre del
        private int prazdna = 0;//!< Príznak pre prázdne miesto

        private int exception_stav=3;//!< Príznak pre metódu Is_exception

        private double a;//!< premenna ktorá sa posiela do matematickej funkcie
        private double b;//!< premenna ktorá sa posiela do matematickej funkcie

        public Form1()
        {
            InitializeComponent();
        }
        /**
         * \brief Funkcia zareáguje ak užívateľ stlačí klávesu 0 a vloží ju na monitor
         */
        public void btn_0_Click(object sender, EventArgs e)
        {
            op_btn("0");
        }
        /**
         * \brief Funkcia zareáguje ak užívateľ stlačí klávesu 1 a vloží ju na monitor
         */
        public void btn_1_Click(object sender, EventArgs e)
        {
            op_btn("1");
        }
        /**
         * \brief Funkcia zareáguje ak užívateľ stlačí klávesu 2 a vloží ju na monitor
         */
        public void btn_2_Click(object sender, EventArgs e)
        {
            op_btn("2");
        }
        /**
         * \brief Funkcia zareáguje ak užívateľ stlačí klávesu 3 a vloží ju na monitor
         */
        public void btn_3_Click(object sender, EventArgs e)
        {
            op_btn("3");
        }
        /**
         * \brief Funkcia zareáguje ak užívateľ stlačí klávesu 4 a vloží ju na monitor
         */
        public void btn_4_Click(object sender, EventArgs e)
        {
            op_btn("4");
        }
        /**
         * \brief Funkcia zareáguje ak užívateľ stlačí klávesu 5 a vloží ju na monitor
         */
        public void btn_5_Click(object sender, EventArgs e)
        {
            op_btn("5");
        }
        /**
         * \brief Funkcia zareáguje ak užívateľ stlačí klávesu 6 a vloží ju na monitor
         */
        public void btn_6_Click(object sender, EventArgs e)
        {
            op_btn("6");
        }
        /**
         * \brief Funkcia zareáguje ak užívateľ stlačí klávesu 7 a vloží ju na monitor
         */
        public void btn_7_Click(object sender, EventArgs e)
        {
            op_btn("7");
        }
        /**
         * \brief Funkcia zareáguje ak užívateľ stlačí klávesu 8 a vloží ju na monitor
         */
        public void btn_8_Click(object sender, EventArgs e)
        {
            op_btn("8");
        }
        /**
         * \brief Funkcia zareáguje ak užívateľ stlačí klávesu 9 a vloží ju na monitor
         */
        public void btn_9_Click(object sender, EventArgs e)
        {
            op_btn("9");
        }
        /**
         * \brief Funkcia zareáguje ak užívateľ stlačí tlačidlo bodky
         * Skontroluje všetky príznaky a možnosti, či je možné bodku v aktuálnom stave napísať.
         */
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
                    bodka = bodka - 1;
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
        /**
         * \brief Funkcia zareáguje ak používateľ stlačí tlačídlo DEL 
         * Funkcia vymaže posledné zadaný znak - či už operátor alebo číslo
         */
        public void btn_del_Click(object sender, EventArgs e)
        {
            Is_exception();
            if (display.Text == "Sin " || display.Text == "√")
            {
                display.Text = "0";
                sinus = 0;
                odmocnina = 0;
                prazdna = 0;
            }
            else if (display.Text.EndsWith("+") || display.Text.EndsWith("-") || display.Text.EndsWith("*") || display.Text.EndsWith("/") || display.Text.EndsWith("Sin ") || display.Text.EndsWith("^") || display.Text.EndsWith("!") || display.Text.EndsWith("√"))
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
                    odmocnina = 0;
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
        /**
         * \brief Funkcia zareáguje ak používateľ stlačí tlačídlo mocniny
         * Skontroluje či je možné vložiť znak mocniny ^, následne ho vloží a nastaví príznak delenia na 1 
         * Upravuje formát čísla na obrazovke
         */
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
                If_bodka();
                display.Text = display.Text + "^";
                nulovanie();
            }
        }
        /**
         * \brief Funkcia je zavolaná pri načítaní obrazovky GUI
         */
        public void Form1_Load(object sender, EventArgs e)
        {
        }
        /**
         * \brief Funkcia zobrazí zmenený text
         */
        public void display_TextChanged(object sender, EventArgs e)
        {
        }
        /**
         * \brief Funkcia vynuluje kalkulačku po stlačení tlačidla AC
         */
        public void btn_ac_Click(object sender, EventArgs e)
        {
            Is_exception();
            nas_nula();
            pomocna = 0;
            prazdna = 0;
        }
        /**
         * \brief Funkcia reaguje na stlačenie tlačidla sčítania
         * Skontroluje či je možné napísať znak + a či je možné sčítanie daného čísla, nastaví príznak na sčítanie
         */
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
                If_bodka();               
                display.Text = display.Text + "+";
                nulovanie();
            }
        }
        /**
         * \brief Funkcia reaguje na tlačidlo mínus
         * Tlačidlo funguje ako odčítanie ale aj ako pridanie záporného čísla, preto funkcia kontroluje rôzne stavy kalkulačky a vyhodnocuje ktorá metóda sa uskutoční.
         */
        public void btn_sub_Click(object sender, EventArgs e)
        {
            Is_exception();
            if (display.Text == "0")
            {
                display.Text = "-";
            }
            else if ( display.Text.EndsWith("√"))
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
                    display.Text = display.Text;
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
        /**
         * \brief Funkcia zareáguje ak používateľ stlačí tlačídlo delenia
         * Skontroluje či je možné vložiť znak delenia / , následne ho vloží a nastaví príznak delenia na 1 
         */
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
                If_bodka();
                display.Text = display.Text + "/";
                nulovanie();
            }
        }
        /**
       * \brief Funkcia zareáguje ak používateľ stlačí tlačídlo násobenia
       * Skontroluje či je možné vložiť znak násobenia * , následne ho vloží a nastaví príznak násobenia na 1 
       */
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
                If_bodka();
                display.Text = display.Text + "*";
                nulovanie();
            }

        }
        /**
       * \brief Funkcia zareáguje ak používateľ stlačí tlačídlo faktoriálu
       * Skontroluje či je možné vložiť znak faktoriálu , následne ho vloží a nastaví príznak faktorial na 1 
       */
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
                If_bodka();
                display.Text = display.Text + "!";
                enter = 0;
            }
        }
       /**
       * \brief Funkcia zareáguje ak používateľ stlačí tlačídlo sinus
       * Skontroluje či je možné vložiť funkciu sinus , následne ju vloží na obrazovku a nastaví príznak sinus na 1
       * Upravuje formát čísla na obrazovke
       */
        public void btn_sin_Click(object sender, EventArgs e)
        {
            try
            {
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
                        if (prazdna == 0)
                        {
                            string vymazat = Convert.ToString(a) + "√";
                            b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                        }
                        else
                        {
                            b = Convert.ToDouble(display.Text.Replace("√", ""));
                        }
                        display.Text = Convert.ToString(math.Obecna_odmocnina(b,a));
                        prazdna = 0;
                        display.Text = "Sin " + display.Text;
                    }
                    else if (sinus == 1)
                    {
                        a = Convert.ToDouble(display.Text.Replace("Sin ", ""));
                        display.Text = Convert.ToString(math.Sinus(a));
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
            catch (InvalidOperationException exception)
            {
                exception_stav = 1;
                Is_exception(exception.Message);
            }
        }
        /**
        * \brief Funkcia zareáguje ak používateľ stlačí tlačídlo odmocniny
        * Skontroluje či je možné vložiť znak odmocniny √, následne ho vloží a nastaví príznak odmocniny na 1 
        */
        private void btn_sqrt_Click(object sender, EventArgs e)
        {
            try
            {
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
                        display.Text = display.Text + "√";
                    }
                    else if (rozdiel == 1)
                    {
                        string vymazat = Convert.ToString(a) + "-";
                        b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                        rozdiel = 0;
                        odmocnina = 1;
                        display.Text = Convert.ToString(math.Rozdiel(a, b));
                        display.Text = display.Text + "√";
                    }
                    else if (nasobenie == 1)
                    {
                        string vymazat = Convert.ToString(a) + "*";
                        b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                        nasobenie = 0;
                        odmocnina = 1;
                        display.Text = Convert.ToString(math.Nasobenie(a, b));
                        display.Text = display.Text + "√";
                    }
                    else if (delenie == 1)
                    {
                        string vymazat = Convert.ToString(a) + "/";
                        b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                        delenie = 0;
                        odmocnina = 1;
                        display.Text = Convert.ToString(math.Delenie(a, b));
                        display.Text = display.Text + "√";
                    }
                    else if (mocnina == 1)
                    {
                        string vymazat = Convert.ToString(a) + "^";
                        b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                        mocnina = 0;
                        odmocnina = 1;
                        display.Text = Convert.ToString(math.Mocnina(a, b));
                        display.Text = display.Text + "√";
                    }
                    else if (faktorial == 1)
                    {
                        faktorial = 0;
                        odmocnina = 1;
                        display.Text = Convert.ToString(math.Faktorial(a));
                        display.Text = display.Text + "√";
                    }
                    else if (odmocnina == 1)
                    {
                        if (prazdna == 0)
                        {
                            string vymazat = Convert.ToString(a) + "√";
                            b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                        }
                        else
                        {
                            b = Convert.ToDouble(display.Text.Replace("√", ""));
                        }
                        display.Text = Convert.ToString(math.Obecna_odmocnina(b, a));
                        prazdna = 0;
                        a = Convert.ToDouble(display.Text);
                        display.Text = display.Text + "√";
                    }
                    else if (sinus == 1)
                    {
                        sinus = 0;
                        odmocnina = 1;
                        a = Convert.ToDouble(display.Text.Replace("Sin ", ""));
                        display.Text = Convert.ToString(math.Sinus(a));
                        display.Text = display.Text + "√";
                    }
                    else
                    {
                        if (display.Text == "0")
                        {
                            a = 2;
                            display.Text = "√";
                            prazdna = 1;
                        }
                        else
                        {
                            a = Convert.ToDouble(display.Text);
                            display.Text = display.Text + "√";
                        }
                        odmocnina = 1;
                        enter = 0;
                    }
                }
            }
            catch (InvalidOperationException exception)
            {
                exception_stav = 1;
                Is_exception(exception.Message);
            }
        }
        /**
        * \brief Funkcia zareáguje ak používateľ stlačí tlačídlo enter
        * Funkcia pretypuje výraz na double, a zavolá príslušnú funkciu ktorá vypočíta výsledok v závislosti od príznaku
        */
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
                        if (pomocna == 0)
                        {
                            display.Text = Convert.ToString(math.Rozdiel(a, b));
                        }
                        else
                        {
                            display.Text = Convert.ToString(math.Rozdiel(a, -b));
                        }
                    }
                    else if (pomocna == 1 && bodka == 1)
                    {
                        string vymazat = Convert.ToString(a) + "-";
                        b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                        display.Text = Convert.ToString(math.Rozdiel(a, -b));
                    }
                    else
                    {
                        string vymazat = Convert.ToString(a) + "-";
                        b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                        display.Text = Convert.ToString(math.Rozdiel(a, b));
                    }
                    rozdiel = 0;
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
                    try { display.Text = Convert.ToString(math.Mocnina(a, b)); }
                    catch (InvalidOperationException ex)
                    {
                        if (ex != null)
                        {
                            exception_stav = 1;
                            Is_exception(ex.Message);
                        }
                    }
                }
                else if (faktorial == 1)
                {

                    faktorial = 0;
                    try { display.Text = Convert.ToString(math.Faktorial(a)); }
                    catch (InvalidOperationException exception)
                    {
                        if (exception != null)
                        {
                            Console.WriteLine(exception.Message);
                            exception_stav = 1;
                            Is_exception(exception.Message);
                        }
                    }
                }
                else if (odmocnina == 1)
                {
                    odmocnina = 0;
                    if (prazdna == 0)
                    {
                        string vymazat = Convert.ToString(a) + "√";
                        b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    }
                    else
                    {
                        b = Convert.ToDouble(display.Text.Replace("√", ""));
                    }
                    prazdna = 0;
                    try { display.Text = Convert.ToString(math.Obecna_odmocnina(b, a));}
                    catch (InvalidOperationException ex)
                    {
                        if (ex != null)
                        {
                            exception_stav = 1;
                            Is_exception(ex.Message);
                        }
                    }
                }
                else if (sinus == 1)
                {
                    sinus = 0;
                    a = Convert.ToDouble(display.Text.Replace("Sin ", ""));
                    display.Text = Convert.ToString(math.Sinus(a));
                }
                nulovanie();
                pomocna = 0;
            }
        }



        /**
        * \brief Funkcia vypisuje exception na obrazovku alebo ho schováva podla aktuálneho príznaku <code>exception_stav</code>
        * \param exception premenná typu string ktorú môže vypísať na obrazovku, štandardne nastavená na ""
        * ak je exception_stav 1, znamená to, že exception bola vyhodená a treba ju vypísať a nastavit na 2
        * ak je exception_stav 2, tak bola vypísana a treba ju schovať vypísaním 0 na obrazovku a nastavením stavu na 3 
        * ak je exception_stav 3, tak nič nerobí
        */
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
        /**
         * \brief Funkcia skontroluje podmienky a upravuje text ktorý je zobrazovaný na obrazovke
         */
        void podmienky()
        {
            try
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
                    if (prazdna == 0)
                    {
                        string vymazat = Convert.ToString(a) + "√";
                        b = Convert.ToDouble(display.Text.Replace(vymazat, ""));
                    }
                    else
                    {
                        b = Convert.ToDouble(display.Text.Replace("√", ""));
                    }
                    display.Text = Convert.ToString(math.Obecna_odmocnina(b, a));
                    prazdna = 0;
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
            catch (InvalidOperationException exception)
            {
                exception_stav = 1;
                Is_exception(exception.Message);
            }
        }

        /////////////////////////////////////////////////////////
        /**
         * \brief ak je zadaná bodka, číslo je pretypované do floatu podľa pozície čiarky
         */
        void If_bodka()
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
        /**
         * \brief nastavuje príznaky enter a bodna na 0
         */
        void nulovanie()
        {
            enter = 0;
            bodka = 0;
        }

        ///////////////////////////////////
        /**
        * \brief Funkcia nuluje príznaky matematických operácii
        */
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
        /**
        * \brief Skontroluje, či príznak faktorálu je na 1 ak nie vyčistí display
        */
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
