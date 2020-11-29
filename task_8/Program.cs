using System;

namespace _8
{
    class MyComplex
    {
        private double re, im;

        public MyComplex(double initRe = 0, double initIm = 0)
        {
            re = initRe;
            im = initIm;
        }

        public string this[string key]
        {
            get
            {
                switch (key)
                {
                    case "realValue": return re.ToString();
                    case "imaginaryValue": return im + "i";
                    default: return null;
                }
            }
        }

        public static MyComplex operator +(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.re + b.re, a.im + b.im);
        }

        public static MyComplex operator +(MyComplex a, double b)
        {
            return new MyComplex(a.re + b, a.im);
        }

        public static MyComplex operator +(double a, MyComplex b)
        {
            return new MyComplex(a + b.re, b.im);
        }

        public static MyComplex operator -(MyComplex a)
        {
            return new MyComplex(-a.re, -a.im);
        }

        public static MyComplex operator -(MyComplex a, MyComplex B)
        {
            return new MyComplex(a.re - B.re, a.im - B.im);
        }

        public void InputFromTerminal()
        {
            re = TryCatch("реальное");
            im = TryCatch("мнимое");
        }

        private double TryCatch(string text)
        {
            while (true)
            {
                Console.Write($"Введите {text} число: ");
                try
                {
                    return Convert.ToDouble(Console.ReadLine());
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public override string ToString()
        {
            if (im > 0)
            {
                return $"{re}+{im}i";
            }

            return $"{re}{im}i";
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

            C = A + B;
            C = A + 10.5;
            C = 10.5 + A;
            D = -C;
            C = A + B + C + D;
            C = A = B = C;

            D.InputFromTerminal();

            Console.WriteLine($"A = {A}, B = {B}, C = {C}, D = {D}");

            Console.WriteLine($"Re(A) = {A["realValue"]}, Im(A) = {A["imaginaryValue"]}");
            Console.WriteLine($"Re(B) = {B["realValue"]}, Im(B) = {B["imaginaryValue"]}");
            Console.WriteLine($"Re(C) = {C["realValue"]}, Im(C) = {C["imaginaryValue"]}");
            Console.WriteLine($"Re(D) = {D["realValue"]}, Im(D) = {D["imaginaryValue"]}");
        }
    }
}