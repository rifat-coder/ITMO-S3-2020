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
            
        }
    }
}
