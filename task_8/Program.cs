using System;

namespace task_8
{
    class MyComplex
    {
        private double re, im;

        public MyComplex(double initRe = 0, double initIm = 0)
        {
            re = initRe;
            im = initIm;
        }

        public double this[string type]
        {
            get
            {
                if (type == "realValue")
                {
                    return re;
                }
                if (type == "imaginaryValue")
                {
                    return im;
                }
                return 0;
            }
        }

        public static MyComplex operator +(MyComplex a, MyComplex b)
        {
            MyComplex res = new MyComplex();
            res.re = a.re + b.re;
            res.im = a.im + b.im;
            return res;
        }
        public static MyComplex operator +(MyComplex a, double b)
        {
            MyComplex res = new MyComplex();
            res.re = a.re + b;
            res.im = a.im;
            return res;
        }
        public static MyComplex operator +(double b, MyComplex a)
        {
            return a+b;
        }
        public static MyComplex operator -(MyComplex a)
        {
            MyComplex res = new MyComplex();
            res.re = -a.re;
            res.im = -a.im;
            return res;
        }
        public static MyComplex operator -(MyComplex a, MyComplex b)
        {
            MyComplex res = new MyComplex();
            res.re = a.re - b.re;
            res.im = a.im - b.im;
            return res;
        }
        public static MyComplex operator -(double b, MyComplex a)
        {
            MyComplex res = new MyComplex();
            res.re = a.re - b;
            res.im = a.im;
            return res;
        }
        public static MyComplex operator -(MyComplex a, double b)
        {
            
            return -b+a;
        }

        public void InputFromTerminal()
        {
            re = CheckNumber("real");
            im = CheckNumber("imagine");
        }

        private double CheckNumber(string text)
        {
            double number;
            Console.Write($"Enter {text} value: ");
            String stringNumber = Console.ReadLine();
            while (!double.TryParse(stringNumber, out number))
            {
                Console.WriteLine("Enter correct value, type int!");
                stringNumber = Console.ReadLine();
            }
            return number;
        }

        public override string ToString() {
            if (this.im < 0)
            {
                return ($"{this.re} {this.im}i");
            }
            else return ($"{this.re} + {this.im}i ");
            
                }
        
    }

    class Program 
    {
        static void Main(string[] args)
        {
            MyComplex A = new MyComplex(1, 1);
            MyComplex B = new MyComplex();
            MyComplex C = new MyComplex(1);
            MyComplex D = new MyComplex();
            D.InputFromTerminal();
            C = A + D;
            Console.WriteLine($"C = {C}");
            C = A + 10.5;

            Console.WriteLine($"A = {A}, B = {B}, C = {C}, D = {D}");
            C = 10.5 + A;
            D = -C;
            C = A + B + C + D;
            C = A = B = C;

            


            Console.WriteLine($"Re(A) = {A["realValue"]}, Im(A) = {A["imaginaryValue"]}");
            

        }
    }
}