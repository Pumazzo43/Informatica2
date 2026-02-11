using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.OverloadOperator
{
    public class Fraction
    {
        public int Num { get; set; }
        public int Den { get; set; }

        public Fraction(int num, int den)
        {
            if (den == 0)
                throw new Exception("Denominator cannot be zero");
            this.Num = num;
            this.Den = den;
        }

        public Fraction Add(Fraction f)
        {
            int den = this.Den * f.Den;
            return new Fraction(this.Den * f.Num + this.Num * f.Den, den);
        }
        public Fraction Multiply(Fraction f)
        {
            return new Fraction(this.Num * f.Num, this.Den * f.Den);
        }
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return f1.Add(f2);
        }
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return f1.Multiply(f2);
        }
        public static explicit operator double(Fraction f)
        {
            return (double)f.Num / f.Den;
        }
        public static bool operator ==(Fraction f1, Fraction f2)
        {
            return (double)f1 == (double)f2;
        }
        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !((double)f1 == (double)f2);
        }
        public override string ToString()
        {
            return $"{this.Num}/{this.Den}";
        }
    }
}
