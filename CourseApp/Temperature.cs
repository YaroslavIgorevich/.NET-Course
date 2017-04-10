using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp
{
    class Temperature
    {
        private double _value;
        private bool _isCelsius;

        double Value
        {
            get { return _value; }

            set { _value = value; }
        }

        bool IsCelsius
        {
            get { return _isCelsius; }

            set { _isCelsius = value; }
        }            

        public Temperature(double value, bool isCelcius = true)
        {
            _value = value;
            _isCelsius = isCelcius;
        }

        public static Temperature ConvertToF(Temperature temp)
        {
            if (temp._isCelsius)
            {
                return new Temperature(temp.Value * 9 / 5 + 32, false);                
            }            

            return temp;
        }

        public static Temperature ConvertToC(Temperature temp)
        {
            if (!temp._isCelsius)
            {
                return new Temperature((temp.Value - 32) * 5 / 9, true);                
            }           

            return temp;
        }

        private Temperature CoerceTo(Temperature other)
        {
            if (_isCelsius ^ other.IsCelsius)
            {
                return other._isCelsius ? ConvertToC(this) : ConvertToF(this);
            }

            return this;
        }

        public static Temperature GetAverage(Temperature[] temps, string scale)
        {
            double sum = 0;

            switch (scale)
            {
                case "C":
                    foreach (var temp in temps)
                    {
                        sum += ConvertToC(temp).Value;
                    }
                    break;

                case "F":
                    foreach (var temp in temps)
                    {
                        sum += ConvertToF(temp).Value;
                    }
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }            

            return new Temperature(sum / temps.Length);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Temperature otherTemp = obj as Temperature;
            if ((System.Object)otherTemp == null)
            {
                return false;
            }

            var otherTempCoerced = otherTemp.CoerceTo(this);

            return (otherTempCoerced.Value == _value);
        }

        public override int GetHashCode()
        {
            return 31 * _value.GetHashCode() + _isCelsius.GetHashCode();
        }

        public override string ToString()
        {
            return $"{_value} {(_isCelsius ? "C" : "F")}";
        }

        public static Temperature operator +(Temperature t1, Temperature t2)
        {
            var t2Coerced = t2.CoerceTo(t1);

            return new Temperature(t1.Value + t2Coerced.Value, t1.IsCelsius);
        }

        public static Temperature operator +(Temperature t1, int change)
        {
            return new Temperature(t1.Value + change, t1.IsCelsius);
        }

        public static Temperature operator +(Temperature t1, double change)
        {
            return new Temperature(t1.Value + change, t1.IsCelsius);
        }

        public static Temperature operator -(Temperature t1, Temperature t2)
        {
            var t2Coerced = t2.CoerceTo(t1);

            return new Temperature(t1.Value - t2Coerced.Value, t1.IsCelsius);
        }

        public static Temperature operator -(Temperature t1, int change)
        {
            return new Temperature(t1.Value - change, t1.IsCelsius);
        }

        public static Temperature operator -(Temperature t1, double change)
        {
            return new Temperature(t1.Value - change, t1.IsCelsius);
        }
        
        public static bool operator ==(Temperature t1, Temperature t2)
        {
            return t1.Equals(t2);
        }

        public static bool operator !=(Temperature t1, Temperature t2)
        {
            return !t1.Equals(t2);
        }
    }
}