using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace mathlib
{

	public class math
	{
		public const double EPSILON = 0.0000000001;
		public static double Sucet(double a, double b)
		{
			return a + b;
		}

		public static double Nasobenie(double a, double b)
		{
			return a * b;
		}

		public static double Delenie(double a, double b)
		{
			if (b == 0)
			{
				throw new System.InvalidOperationException("DELENIE NULOU!");
			}
			return a / b;
		}
		public static double Rozdiel(double a, double b)
		{
			return a - b;
		}
		// Vrati faktorial cisla
		public static double Faktorial(double a)
		{
			double res = 1;
			if (a == 0) return 1;
			if (a < 0)
			{
				throw new System.InvalidOperationException("Neda sa spravit faktorial z cisla mensieho ako 0!");
			}

			if (a % 1 != 0)
			{
				throw new System.InvalidOperationException("Faktorial sa da iba na celé číslo!");
			}

			for (int i = 1; i <= a; i++)
			{
				res *= i;
			}
			return res;
		}
		// Vrati N-tú odmocninu z čísla x
		public static double Mocnina(double x, double n)
		{ // funkcia ktora umocnuje
			if (n % 1 != 0)
			{
				throw new InvalidOperationException("Nemožno použiť desatinné číslo ako mocninu!");
			}

			if (n == 0)
			{
				return 1;
			}

			double mocnina = x;   // x sa nam bude zvacsovat a ale nasobit budeme stale len zakladom 
			for (int i = 2; i <= n; i++)
			{
				x *= mocnina;
			}
			return x;
		}
		// Vrati absolutnu hodnotu cisla
		public static double Absolutna(double abs)
		{
			if (abs >= 0) return abs;
			return -abs;
		}
		// Vrati sinus cisla, najskor si premeni radiany na stupne a potom vypocita sinus, je mozne zadat aj inu presnost
		public static double Sinus(double radians, double epsilon = EPSILON)
		{
			if (radians == 90) return 1;
			if (radians == -90) return -1;
			if (radians % 180 == 0) return 0;

			radians = radians * 3.141592654 / 180;
			int i = 1, moc = 3;
			double vysledok = radians, povodny = 0;
			while (true)
			{ //toto je ten rad zapisany v nekonecnom cykle
				if (i % 2 != 0)
				{ //ak je zlomok parny tak sa pricita, ak neparny tak odcita od vysledku
					vysledok -= (Mocnina(radians, moc) / Faktorial(moc));
				}
				else
				{
					vysledok += (Mocnina(radians, moc) / Faktorial(moc));
				}
				moc += 2; //v tom rade sa mocniny a faktorial zvysuju o 2
				i++; // i uchovava poradie zlomku

				if (Absolutna(povodny - vysledok) > epsilon)
				{ // ak je absolutna hodnota povodneho vysledku a aktualneho vysledku vacsia ako epsilon, pokracuje a aktualny vysledok ulozi uz ako povodny
					povodny = vysledok;
				}
				else return vysledok; // ak nie tak sme v presnosti epsilon a vratime vysledok
			}

		}
		// Iterativna metoda na najdenie odmconiny Babylonian method
		// Vrati odmocninu z cisla
		public static double findSqrt(double S)
		{

			double epsilon = 0.00001;
			if (S < 0)
			{
				throw new System.InvalidOperationException("Odmocnina zo zaporneho cisla? Really?");
			}
			else if (S == 0) return 0;

			double x = S / 2;
			double xPrev = 0;
			do
			{
				xPrev = x;
				x = (xPrev + S / xPrev) / 2; 
			} while (Absolutna(x - xPrev) > epsilon);
		
			return(x);
		}

		// vrati Ntu odmocninu z A
		public static double obecna_odmocnina(double A, double N)
		{
			if (A < 0)
			{
				throw new InvalidOperationException("Odmocnina zo zaporneho cisla? Really?");
			}
			Random rand = new Random();
			// nahodne cislo initial guess
			// 0 - 9 
			double xPre = rand.Next(10); ;

			// epsilon presnost
			double eps = 0.00001;

			// initializing difference between two 
			// roots by INT_MAX 
			double delX = 2147483647;

			// xK denotes current value of x 
			double xK = 0.0;

			// loop untill we reach desired accuracy 
			while (delX > eps)
			{
				// calculating current value from previous 
				// value by newton's method 
				xK = ((N - 1.0) * xPre +
				(double)A / Math.Pow(xPre, N - 1)) / (double)N;
				delX = Math.Abs(xK - xPre);
				xPre = xK;
			}

			return xK;
		}

	}
}
