using System;
namespace Code_of_Lab_1
{
    public class Parameters
    {
        public Parameters()
        {
        }
        public Parameters(string _name, string _value)
        {
            name = _name; value = _value;
        }
        public string name { get; }
        private string value;
        public dynamic get_value()
        {
            return value;
            /*if (Int32.TryParse(value, out int intval))
            {
                return intval;
            }
            else if (Double.TryParse(value, out double doubletval))
            {
                return doubletval;
            }
            else
            {
                return value;
            }*/
                
        }
    }
}
