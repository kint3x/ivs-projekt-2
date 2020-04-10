using System;
using System.Collections.Generic;
using System.Text;

namespace mathlib
{
	public class math
	{
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

		public static double Faktorial(double a)
		{
			double res = 1;
			if (a < 1)
			{
				throw new System.InvalidOperationException("Neda sa spravit faktorial z cisla mensieho ako 1!");
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

		public static double Mocnina(double x, double n)
		{ // funkcia ktora umocnuje
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

		public static double Absolutna(double abs)
		{
			if (abs >= 0) return abs;
			return -abs;
		}

		public static double Sinus(double radians, double epsilon)
		{
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

		static double Square(double n,
					 double i, double j)
		{
			double mid = (i + j) / 2;
			double mul = mid * mid;

			// If mid itself is the square root, 
			// return mid 
			if ((mul == n) ||
				(Absolutna(mul - n) < 0.00001))
				return mid;

			// If mul is less than n,  
			// recur second half 
			else if (mul < n)
				return Square(n, mid, j);

			// Else recur first half 
			else
				return Square(n, i, mid);
		}

		// Function to find the square root of n 
		public static double findSqrt(double n)
		{
			double i = 1;

			// While the square root is not found 
			Boolean found = false;
			while (!found)
			{

				// If n is a perfect square 
				if (i * i == n)
				{
					return i;
				}

				else if (i * i > n)
				{

					// Square root will lie in the 
					// interval i-1 and i 
					double res = Square(n, i - 1, i);
					return i;
				}
				i++;
			}
			
			throw new System.InvalidOperationException("Nenašla sa odmocnina!");

		}

	}
}
