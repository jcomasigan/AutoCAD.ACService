using System;

namespace ACDataService
{
    class MathFunc
    {
        public static double Deg2Rad(double dDegrees)
        {
            return (dDegrees * Math.PI / 180);
        }

        public static double Rad2Deg(double dRadians)
        {
            return (dRadians * 180) / Math.PI;
        }

        public static float Knots2Kmph(float dKnots)
        {
            return dKnots * 1.852f;
        }

        public static float Knots2MPS(float dKnots)
        {
            return (dKnots * 1.852f * 1000) / 3600;
        }

        public struct Complex
        {
            public double R;
            public double I;

            // Constructor.
            public Complex(double real, double imaginary)
            {
                this.R = real;
                this.I = imaginary;
            }

            // Specify which operator to overload (+), 
            // the types that can be added (two Complex objects),
            // and the return type (Complex).
            public static Complex operator +(Complex c1, Complex c2)
            {
                return new Complex(c1.R + c2.R, c1.I + c2.I);
            }

            // Specify which operator to overload (-), 
            // the types that can be subtracted (two Complex objects),
            // and the return type (Complex).
            public static Complex operator -(Complex c1, Complex c2)
            {
                return new Complex(c1.R - c2.R, c1.I - c2.I);
            }

            public static Complex operator *(Complex c1, Complex c2)
            {
                return new Complex(c1.R * c2.R - c1.I * c2.I,
                        c1.R * c1.I + c2.R * c2.I);
            }

            // Override the ToString() method to display a complex number 
            // in the traditional format:
            public override string ToString()
            {
                return (System.String.Format("{0} + {1}i", R, I));
            }
        }
    }
}
