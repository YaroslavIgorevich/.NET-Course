using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp
{
    class Temperature
    {
        private double value;
        private bool isCelsius;

        double Value
        {
            get { return value; }

            set { this.value = value; }
        }

        bool IsCelsius
        {
            get { return isCelsius; }

            set { this.isCelsius = value; }
        }            

        public Temperature(double value, bool isCelcius = true)
        {
            this.value = value;
            this.isCelsius = isCelcius;
        }

        public static Temperature ConvertToF(Temperature temp)
        {
            if (temp.isCelsius)
            {
                temp.Value = temp.Value * 9 / 5 + 32;
                temp.IsCelsius = false;
            }            

            return temp;
        }

        public static Temperature ConvertToC(Temperature temp)
        {
            if (!temp.isCelsius)
            {
                temp.Value = (temp.Value - 32) * 5 / 9;
                temp.IsCelsius = true;
            }           

            return temp;
        }

        public static void CoerceToCommonScale (Temperature t1, Temperature t2)
        {
            if (t1.IsCelsius ^ t2.IsCelsius)
            {
                t2 = t1.isCelsius ? ConvertToC(t2) : ConvertToF(t2);
            }
        }

        public static Temperature GetAverage(Temperature[] temps)
        {
            double sum = 0;

            foreach (var temp in temps)
            {
                sum += ConvertToC(temp).Value;                    
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

            CoerceToCommonScale(this, otherTemp);

            return (otherTemp.Value == this.value);
        }

        public override int GetHashCode()
        {
            return 31 * value.GetHashCode() + isCelsius.GetHashCode();
        }

        public override string ToString()
        {
            return $"{value} {(isCelsius ? "C" : "F")}";
        }

        public static Temperature operator +(Temperature t1, Temperature t2)
        {
            CoerceToCommonScale(t1, t2);

            return new Temperature(t1.Value + t2.Value, t1.IsCelsius);
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
            CoerceToCommonScale(t1, t2);

            return new Temperature(t1.Value - t2.Value, t1.IsCelsius);
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