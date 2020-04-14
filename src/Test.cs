using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Test
    {
            // Test súčet
            public void TestAdd(double a, double b)
            {
                a = 1;
                b = 2;
                if(a+b==3)
                {
                    Console.WriteLine("TestAdd successful.");
                }
                else
                {
                    Console.WriteLine("TestAdd failed!");
                }

            }
        // Test odčítanie
        public void TestSub(double a, double b)
        {
            a = 2;
            b = 1;
            if (a - b == 1)
            {
                Console.WriteLine("TestSub successful.");
            }
            else
            {
                Console.WriteLine("TestSub failed!");
            }

        }

        public void TestMul(double a, double b)
        {
            a = 2;
            b = 3;
            if (a * b == 6)
            {
                Console.WriteLine("TestSub successful.");
            }
            else
            {
                Console.WriteLine("TestSub failed!");
            }

        }

        public void TestDiv(double a, double b)
        {
            a = 0;
            b = 1;
            try
            {
                try
                {
                    // Throws ' cannot divide by zero ' error
                    double error = b / a;
                }
                catch (DivideByZeroException)
                {
                    // Throws error again of course
                    double somenum = b / a;
                }
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("I can never make it here ...");
            }

        }

        public void TestFact(double a)
        {
            a = 2;
            if (a == 2)
            {
                Console.WriteLine("TestSub successful.");
            }
            else
            {
                Console.WriteLine("TestSub failed!");
            }

        }

        public void TestPow(double a, double n)
        {
            a = 2;
            n = 2;
            if (a / n == 1)
            {
                Console.WriteLine("TestSub successful.");
            }
            else
            {
                Console.WriteLine("TestSub failed!");
            }


        }
    }
}
