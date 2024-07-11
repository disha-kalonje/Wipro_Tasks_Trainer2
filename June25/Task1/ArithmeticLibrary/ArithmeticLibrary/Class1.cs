using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticLibrary
{
    public class Arithmetic
    {
        public int Add(int? a, int? b)
        {
            if (a == null || b==null)
            {
                throw new ArgumentNullException("Input valus can not be null");
            }
            else
            {
                return a.Value + b.Value;
            }
        }

        public int Subtract(int? a, int? b)
        {
            if (a == null || b == null)
            {
                throw new ArgumentNullException("Input valus can not be null");
            }
            else
            {
                return a.Value - b.Value;
            }
        }

        public int Multiply(int? a, int? b)
        {
            if (a == null || b == null)
            {
                throw new ArgumentNullException("Input valus can not be null");
            }
            else
            {
                return a.Value * b.Value;
            }
        }

        public double Divide(int? a, int? b)
        {
            if (a == null || b == null)
            {
                throw new ArgumentNullException("Input valus can not be null");
            }
            else
            {
                return a.Value/b.Value;
            }
        }

        
    }
}
