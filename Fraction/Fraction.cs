using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
	internal class Fraction
	{
		double Numerator { get; set; }
		double Denominator { get; set; }

		public Fraction(double numerator = 0, double denominator = 0) { Denominator = denominator; Numerator = numerator; }
		
		public static Fraction operator +(Fraction a, Fraction b)
		{return new Fraction(a.Numerator *  b.Denominator + b.Numerator * a.Denominator, a.Denominator *  b.Denominator);}
		public static Fraction operator -(Fraction a, Fraction b)
		{ return new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator); }
		public static Fraction operator *(Fraction a, Fraction b)
		{ return new Fraction(a.Numerator * b.Numerator , a.Denominator * b.Denominator); }
		public static Fraction operator /(Fraction a, Fraction b)
		{ return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator); }

		public static bool operator ==(Fraction a, Fraction b) 
		{ return a.Numerator * b.Denominator == b.Numerator * a.Denominator;}

		public static bool operator !=(Fraction a, Fraction b)
		{ return !(a == b); }

		public Fraction reduce()
		{
			int numic = 10;
			while (numic > 1)
			{
				while ( Numerator % numic == 0 && Denominator % numic == 0)
				{
					Numerator /= numic;
					Denominator /= numic;
				}
				--numic;
			}

			return this;
		}


		public override string ToString()
		{
			return $"numerator - {Numerator} ; denominator - {Denominator}";
		}
	}
}
