

using System;
class Complex
{
    public int a;
    public int b;

    public Complex()
    {
        a = 1;
        b = 1;
    }

    public Complex(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public void Print()
    {
        if (b >= 0)
            Console.WriteLine("{0} + {1}i", a, b);
        else
            Console.WriteLine("{0} - {1}i", a, -b);
    }

    public static Complex operator +(Complex op1, Complex op2)
    {
        Complex res = new Complex();
        res.a = op1.a + op2.a;
        res.b = op1.b + op2.b;

        return res;
    }

    public static Complex operator -(Complex op)
    {
        Complex res = new Complex();
        res.a = -op.a;
        res.b = -op.b;

        return res;
    }

    public static Complex operator -(Complex op1, Complex op2)
    {
        Complex res = new Complex();
        res.a = op1.a - op2.a;
        res.b = op1.b - op2.b;

        return res;
    }

    public static Complex operator ++(Complex op)
    {
        op.a++;
        op.b++;
        return op;
    }

    public static Complex operator --(Complex op)
    {
        op.a--;
        op.b--;
        return op;
    }

    public static Complex operator +(Complex op1, int op2)
    {
        Complex res = new Complex();
        res.a = op1.a + op2;
        res.b = op1.b + op2;

        return res;
    }

    public static Complex operator +(int op1, Complex op2)
    {
        Complex res = new Complex();
        res.a = op1 + op2.a;
        res.b = op1 + op2.b;

        return res;
    }

   

    public static explicit operator string(Complex op)
    {
        string s;
        s = (op.a).ToString();
        if (op.b >= 0)
        {
            s += " + ";
            s += (op.b).ToString();
            s += "i";
        }
        else
        {
            s += (op.b).ToString();
            s += "i";
        }
        return s;
    }
}
class ComplexUse
{
    static void Main(string[] args)
    {
        Complex A = new Complex(1, 1);
        Complex B = new Complex();
        Complex C = new Complex(1, 0);
        Complex obj4 = new Complex(1, 2);
        Complex obj5 = new Complex(2, 3);
        Complex obj6 = new Complex(1, 6);
        Complex obj7 = new Complex(2, -2);
        Complex obj8 = new Complex(5, 5);
        int i;
        string str;
        A.Print();
        B.Print();
        C.Print();
        obj4.Print();
        obj5.Print();
        obj6.Print();
        obj7.Print();
        obj8.Print();
        A = B + C;
        Console.Write("Результат сложения obj2 и obj3 = ");
        A.Print();

        A = B - C;
        Console.Write("Результат вычитания obj2 и obj3 = ");
        A.Print();

        A = -B;
        Console.Write("Результат применения операции унарный минус для obj2 = ");
        A.Print();

        C++;
        Console.Write("Результат применения операции инкремента для obj3 = ");
        C.Print();
        // Console.WriteLine(obj2.b);

        A = B + 5;
        Console.Write("Результат сложения obj2 и числа 5 = ");
        A.Print();

        A = 4 + B;
        Console.Write("Результат сложения числа 4 и obj2 = ");
        A.Print();

        
        
    }
}
